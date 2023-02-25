namespace Business.Services.Implementations;
public class VehicleService : IVehicleService
{
    private readonly string[] includes =
        { "Images", "Model", "Model.Make", "Color", "Ban",
        "Seat", "MileageType", "EngineCapacity", "Year",
        "DriveTrain", "GearBox", "City", "Currency", "Country",
        "Fuel", "PhoneNumber", "Supplies", "Reports", "Owner" };
    private readonly IVehicleRepository _repository;
    private readonly IVehicleReportRepository _reportRepository;
    private readonly IVehicleSupplyRepository _supplyRepository;
    private readonly IPhoneNumberRepository _numberRepository;
    private readonly IIDCheckerService _idCheckerService;
    private readonly IMapper _mapper;
    private readonly IImageService _imageService;
    public VehicleService(
            IVehicleRepository repository,
            IMapper mapper,
            IImageService imageService,
            IVehicleReportRepository reportRepository,
            IVehicleSupplyRepository supplyRepository,
            IIDCheckerService idCheckerService,
            IPhoneNumberRepository numberRepository)
    {
        _repository = repository;
        _mapper = mapper;
        _imageService = imageService;
        _reportRepository = reportRepository;
        _supplyRepository = supplyRepository;
        _idCheckerService = idCheckerService;
        _numberRepository = numberRepository;
    }

    public async Task<List<VehicleGetDto>> GetAllAsync(Expression<Func<Vehicle, bool>>? exp, bool include)
    {
        await CheckAllDates();
        if (exp is null)
            exp = x => x.isDeleted == false;
        if (include)
            return _mapper.Map<List<VehicleGetDto>>(await _repository.GetAllAsync(exp, includes));
        else
            return _mapper.Map<List<VehicleGetDto>>(await _repository.GetAllAsync(exp));
    }
    public async Task<VehicleGetDto> GetByIdAsync(int id, bool include)
    {
        await CheckAllDates();
        VehicleGetDto? Vehicle = new();
        if (include)
            Vehicle = _mapper.Map<VehicleGetDto>(await _repository.GetByIdAsync(id, includes));
        else
            Vehicle = _mapper.Map<VehicleGetDto>(await _repository.GetByIdAsync(id));
        if (Vehicle is null)
            throw new NotFoundException(Messages.NotFoundVehicle);
        return Vehicle;
    }
    public async Task ValidatePIN(int id, string PINCode)
    {
        var vehicle = await GetByIdAsync(id, false);
        if (vehicle.PINCode != PINCode)
            throw new WrongPINCodeException(Messages.WrongPINCode);
    }
    public async Task CreateAsync(VehiclePostDto postDto)
    {
        await CheckAllIds(postDto);
        PhoneNumber number = await GetNumber(postDto.TelephoneNumber);
        Vehicle newVehicle = _mapper.Map<Vehicle>(postDto);
        if (postDto.formFiles.Count < 3)
            throw new ImageException(Messages.MinImage3);

        Random generator = new Random();
        string PINCode = generator.Next(0, 1000000).ToString("D6");

        newVehicle.PINCode= PINCode;
        number.forOnce = false;
        newVehicle.Images = await CreateImageAsync(postDto.formFiles, true);
        newVehicle.Supplies = await GetSupplies(postDto.SupplyIds);
        newVehicle.Reports = await GetReports(postDto.ReportIds);
        newVehicle.PhoneNumber = number;
        newVehicle.inAwait = true;
        await _repository.CreateAsync(newVehicle);
        await _repository.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        Vehicle? Vehicle = await _repository.GetByIdAsync(id);
        if (Vehicle is null)
            throw new NotFoundException(Messages.NotFoundVehicle);
        Vehicle.isConfirmed = false;
        Vehicle.inAwait = false;
        Vehicle.isExpired = false;
        Vehicle.isCancelled = false;
        Vehicle.ExpiredDate = null;
        _repository.DeleteAsync(Vehicle);
        await _repository.SaveChangesAsync();
    }
    public async Task UpdateAsync(VehicleUpdateDto updateDto)
    {
        await CheckAllIds(updateDto.postDto);
        Vehicle? Vehicle = await _repository.GetByIdAsync(updateDto.getDto.Id);
        if (Vehicle is null)
            throw new NotFoundException(Messages.NotFoundVehicle);
        Vehicle = _mapper.Map<Vehicle>(updateDto.postDto);
        if (updateDto.postDto.formFiles.Count is not 0)
            Vehicle.Images = await CreateImageAsync(updateDto.postDto.formFiles);
        Vehicle.isEdited = true;
        Vehicle.isConfirmed = false;
        await _repository.SaveChangesAsync();
    }
    public async Task ConfirmAsync(int id)
    {
        Vehicle? vehicle = await _repository.GetByIdAsync(id);
        if (vehicle is null) throw new NotFoundException(Messages.NotFoundVehicle);
        vehicle.isConfirmed = true;
        vehicle.isCancelled = false;
        vehicle.inAwait = false;
        vehicle.isEdited = false;
        vehicle.isExpired = false;
        vehicle.CreatedDate = DateTime.Now;
        vehicle.ExpiredDate = DateTime.Now.AddMonths(1);
        await _repository.SaveChangesAsync();
    }
    public async Task CancelAsync(int id)
    {
        Vehicle? vehicle = await _repository.GetByIdAsync(id);
        if (vehicle is null) throw new NotFoundException(Messages.NotFoundVehicle);
        vehicle.isCancelled = true;
        vehicle.isConfirmed = false;
        vehicle.inAwait = false;
        vehicle.isEdited = false;
        vehicle.ExpiredDate = null;
        await _repository.SaveChangesAsync();
    }
    public async Task AwaitAsync(int id)
    {
        Vehicle? vehicle = await _repository.GetByIdAsync(id);
        if (vehicle is null) throw new NotFoundException(Messages.NotFoundVehicle);
        vehicle.inAwait = true;
        vehicle.isCancelled = false;
        vehicle.isConfirmed = false;
        await _repository.SaveChangesAsync();
    }
    public async Task RenewExpireDateAsync(int id)
    {
        Vehicle? vehicle = await _repository.GetByIdAsync(id);
        if (vehicle is null) throw new NotFoundException(Messages.NotFoundVehicle);
        vehicle.isExpired = false;
        vehicle.CreatedDate = DateTime.Now;
        vehicle.ExpiredDate = DateTime.Now.AddMonths(1);
        await _repository.SaveChangesAsync();
    }

    private async Task<List<VehicleImage>> CreateImageAsync(List<IFormFile> formFiles, bool MainExists = false)
    {
        List<VehicleImage> Images = new();
        foreach (var item in formFiles)
        {
            _imageService.CheckType(item);
            _imageService.CheckSize(item, 2);
            string ImageName = await _imageService.CreateFileAsync("vehicle-images", item);
            VehicleImage newImage = new()
            {
                Path = ImageName,
                isMain = false
            };
            if (MainExists && formFiles.IndexOf(item) is 0)
                newImage.isMain = true;
            Images.Add(newImage);
        }
        return Images;
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
    private async Task<PhoneNumber> GetNumber(string phonenumber)
    {
        PhoneNumber? number = await _numberRepository.GetByNumber(phonenumber.Trim().Replace(" ", ""));
        if (number is null)
            number = new() { Number = phonenumber.Trim().Replace(" ", "") };
        else
        {
            if (number.Vehicles.Count >= 1 && !number.forOnce && !number.isMonthly)
                throw new LimitExceededException("Ay ərzində yalnız bir maşın dərc edə bilərsiniz.");
        }
        return number;
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
    }
    private async Task CheckAllDates()
    {
        var vehicles = await _repository.GetAllAsync(x => x.isConfirmed);
        foreach (Vehicle vehicle in vehicles)
        {
            if (vehicle.ExpiredDate is not null && vehicle.ExpiredDate <= DateTime.Now)
            {
                vehicle.isExpired = true;
            };
        }
        var numbers = await _numberRepository.GetAllAsync(x => x.isMonthly);
        foreach (var number in numbers)
        {
            if (number.MonthlyExpireDate >= DateTime.Now)
                number.isMonthly = false;
        }
        await _repository.SaveChangesAsync();
    }
}