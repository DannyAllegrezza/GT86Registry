﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GT86Registry.Infrastructure.Data;
using GT86Registry.Web.Models.VehicleViewModels;
using Microsoft.AspNetCore.Identity;
using GT86Registry.Infrastructure.Identity;
using GT86Registry.Web.Interfaces;

namespace GT86Registry.Web.Controllers
{
   
    public class VehiclesController : Controller
    {
        private readonly VehicleRepository _vehicleRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IVehicleViewModelService _vehicleService;

        public VehiclesController(VehicleRepository repository, UserManager<ApplicationUser> userManager, IVehicleViewModelService vehicleService)
        {
            _vehicleRepository = repository;
            _userManager = userManager;
            _vehicleService = vehicleService;
        }

        public IActionResult Index()
        {
            var vehicles = _vehicleService.GetTopVehicles();
            return View("VehiclesIndex", vehicles);
        }

        public async Task<IActionResult> Details(string id)
        {
            var vehicle = _vehicleRepository.GetVehicleByVIN(id);
            var user = await _userManager.FindByIdAsync(vehicle.UserIdentityGuid);

            var vm = new VehicleDetailViewModel(){
                Vehicle = vehicle,
                VehicleOwner = user
            };

            vehicle.ViewCount++;
            _vehicleRepository.Update(vehicle);

            return View("_VehicleDetails", vm);
        }

    }
}