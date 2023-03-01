global using Business.Services.Interfaces;
global using Business.Services.Implementations;
global using Business.Utilities.Exceptions;
global using Business.Utilities.Messages;
global using Business.Utilities.Validations.AppUserValidations;
global using Business.Utilities.Validations.CustomValidation;

global using DAL.Repositories.Interfaces;
global using DAL;
global using DAL.Repositories.Implementations;

global using Entities.Concrets;
global using Entities.DTOs.VehicleDtos;
global using Entities.DTOs.BanDtos;
global using Entities.DTOs.CityDtos;
global using Entities.DTOs.ColorDtos;
global using Entities.DTOs.CountryDtos;
global using Entities.DTOs.CurrencyDtos;
global using Entities.DTOs.DriveTrainDtos;
global using Entities.DTOs.EngineCapacityDtos;
global using Entities.DTOs.FuelDtos;
global using Entities.DTOs.GearBoxDtos;
global using Entities.DTOs.MakeDtos;
global using Entities.DTOs.MileageTypeDtos;
global using Entities.DTOs.ModelDtos;
global using Entities.DTOs.OwnerCountDtos;
global using Entities.DTOs.SeatDtos;
global using Entities.DTOs.VehicleReportDtos;
global using Entities.DTOs.VehicleSupplyDtos;
global using Entities.DTOs.YearDtos;
global using Entities.DTOs.AppUserDtos;
global using Entities.DTOs.SettingDtos;

global using System.Reflection;
global using System.Linq.Expressions;
global using System.Text.RegularExpressions;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;

global using AutoMapper;
global using FluentValidation;
global using FluentValidation.AspNetCore;
global using Core.Entities.Concrets;