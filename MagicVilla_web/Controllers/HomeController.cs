﻿using AutoMapper;
using MagicVilla_Utilities;
using MagicVilla_web.Models;
using MagicVilla_web.Models.Dto.Villa;
using MagicVilla_web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MagicVilla_web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVillaService _villaService;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IVillaService villaService, IMapper mapper)
        {
            _logger = logger;
            _villaService = villaService;
            _mapper = mapper;

        }

        public async Task<IActionResult> Index()
        {
            List<VillaDTO> list = new();
            var response = await _villaService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response != null && response.IsSuccess)
                list = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result));
            return View(list);
        }

    }
}