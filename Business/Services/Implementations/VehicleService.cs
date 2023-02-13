using AutoMapper;
using Business.Services.Interfaces;
using Business.Utilities.Exceptions;
using DAL.Repositories.Interfaces;
using Entities.Concrets;
using Entities.DTOs.VehicleDtos;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace Business.Services.Implementations
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _repository;
        private readonly IVehicleReportRepository _reportRepository;
        private readonly IVehicleSupplyRepository _supplyRepository;
        private readonly IIDCheckerService _idCheckerService;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;

        public VehicleService(
                IVehicleRepository repository,
                IMapper mapper,
                IImageService imageService,
                IVehicleReportRepository report,
                IVehicleSupplyRepository supplyRepository,
                IIDCheckerService idCheckerService)
        {
            _repository = repository;
            _mapper = mapper;
            _imageService = imageService;
            _reportRepository = report;
            _supplyRepository = supplyRepository;
            _idCheckerService = idCheckerService;
        }

        public async Task<List<VehicleGetDto>> GetAllAsync(Expression<Func<Vehicle, bool>>? exp, params string[]? includes)
        {
            if (exp is null)
                exp = x => x.isDeleted == false;
            return _mapper.Map<List<VehicleGetDto>>(await _repository.GetAllAsync(exp, includes));
        }

        public async Task<VehicleGetDto> GetByIdAsync(int id,Expression<Func<Vehicle, bool>>? exp)
        {
            if (exp is null)
                exp = x => x.isDeleted == false;
            VehicleGetDto? Vehicle = _mapper.Map<VehicleGetDto>(await _repository.GetByIdAsync(id));
            if (Vehicle is null)
                throw new NotFoundException("Nəqliyyat tapılmadı.");
            return Vehicle;
        }

        public async Task CreateAsync(VehiclePostDto postDto)
        {
            await CheckAllIds(postDto);
            Vehicle newVehicle = _mapper.Map<Vehicle>(postDto);
            if (postDto.formFiles.Count < 3)
                throw new ImageException("Zəhmət olmasa ən azı 3 şəkil daxil edin.");

            List<VehicleImage> Images = new();
            foreach (var item in postDto.formFiles)
            {
                string ImageName = await CheckAndCreateImageAsync(item);
                VehicleImage newImage = new()
                {
                    Path = ImageName,
                    isMain = false
                };
                if (postDto.formFiles.IndexOf(item) is 0)
                    newImage.isMain = true;
                Images.Add(newImage);
            }
            newVehicle.Images = Images;
            newVehicle.Reports = await GetReports(postDto.ReportIds);
            newVehicle.Supplies = await GetSupplies(postDto.ReportIds);
            newVehicle.inAwait = true;
            await _repository.CreateAsync(newVehicle);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Vehicle? Vehicle = await _repository.GetByIdAsync(id);
            if (Vehicle is null)
                throw new NotFoundException("Nəqliyyat tapılmadı.");
            _repository.DeleteAsync(Vehicle);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(VehicleUpdateDto updateDto)
        {
            Vehicle? Vehicle = await _repository.GetByIdAsync(updateDto.getDto.Id);
            if (Vehicle is null)
                throw new NotFoundException("Nəqliyyat tapılmadı.");
            //if (updateDto.postDto.formFile is not null)
            //    Vehicle.Image = await CheckAndCreateImageAsync(updateDto.postDto.formFile);
            //Vehicle.Name = updateDto.postDto.Name;
            await _repository.SaveChangesAsync();

        }
        private async Task<string> CheckAndCreateImageAsync(IFormFile formFile)
        {
            _imageService.CheckType(formFile);
            _imageService.CheckSize(formFile, 2);
            return await _imageService.CreateFileAsync("vehicle-images", formFile);
        }

        private async Task<List<VehicleReport>> GetReports(List<int> ids)
        {
            List<VehicleReport> reports = new List<VehicleReport>();
            foreach (int id in ids)
            {
                VehicleReport? report = await _reportRepository.GetByIdAsync(id);
                if (report is null)
                    throw new NotFoundException("Nəqliyyat vəziyyəti tapılmadı.");
                reports.Add(report);
            }
            return reports;
        }
        private async Task<List<VehicleSupply>> GetSupplies(List<int> ids)
        {
            List<VehicleSupply> supplies = new List<VehicleSupply>();
            foreach (int id in ids)
            {
                VehicleSupply? supply = await _supplyRepository.GetByIdAsync(id);
                if (supply is null)
                    throw new NotFoundException("Nəqliyyat təchizatı tapılmadı.");
                supplies.Add(supply);
            }
            return supplies;
        }
        private async Task CheckAllIds(VehiclePostDto postDto)
        {
            await _idCheckerService.CheckBanId(postDto.BanId);
            await _idCheckerService.CheckModelId(postDto.ModelId);
            await _idCheckerService.CheckOwnerCountId(postDto.OwnerId);
            await _idCheckerService.CheckFuelId(postDto.FuelId);
            await _idCheckerService.CheckDriveTrainId(postDto.DriveTrainId);
            await _idCheckerService.CheckGearBoxId(postDto.GearBoxId);
            await _idCheckerService.CheckMileageTypeId(postDto.MileageTypeId);
            await _idCheckerService.CheckYearId(postDto.YearId);
            await _idCheckerService.CheckColorId(postDto.ColorId);
            await _idCheckerService.CheckEngineCapacityId(postDto.EngineCapacityId);
            await _idCheckerService.CheckSeatId(postDto.SeatId);
            await _idCheckerService.CheckVehicleConditionId(postDto.VehicleConditionId);
            foreach (var id in postDto.SupplyIds)
            {
                await _idCheckerService.CheckVehicleSupplyId(id);
            }
            foreach (var id in postDto.ReportIds)
            {
                await _idCheckerService.CheckVehicleSupplyId(id);
            }
        }
    }
}
