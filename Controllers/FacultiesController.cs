using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWebApi.Entities;
using MyWebApi.Models;
using MyWebApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FacultiesController : ControllerBase
    {
        private readonly ILogger<FacultiesController> _logger;
        private readonly IFacultiesService _facultiesService;
        public FacultiesController(ILogger<FacultiesController> logger, IFacultiesService facultiesService)
        {
            _logger = logger;
            _facultiesService = facultiesService;
        }
        [HttpGet]
        public List<Faculty> Get()
        {
            return _facultiesService.Get();
        }
        [HttpGet]
        [Route("{id}")]
        public Faculty Get(int id)
        {
            return _facultiesService.Get(id);
        }
        
        [HttpPost]
        [Route("create")]
        public Faculty Add(Faculty model)
        {
            return _facultiesService.Add(model);
        }
        [HttpPatch]
        [Route("update/{id}")]
        public Faculty Update(Faculty faculty)
        {
            return _facultiesService.Update(faculty);
        }
    }
}
