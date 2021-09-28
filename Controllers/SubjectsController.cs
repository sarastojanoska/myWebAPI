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
    public class SubjectsController : ControllerBase
    {
        private readonly ILogger<SubjectsController> _logger;
        private readonly ISubjectService _subjectService;
        public SubjectsController(ILogger<SubjectsController> logger, ISubjectService subjectService)
        {
            _logger = logger;
            _subjectService = subjectService;
        }
        [HttpGet]
        public List<Subject> Get()
        {
            return _subjectService.Get();
        }
        [HttpGet]
        public Subject Get(int id)
        {
            return _subjectService.Get(id);
        }
        [HttpGet]
        [Route("Faculty/{id}")]
        public List<Subject> GetSubjectssByFacultyId(int id)
        {
            return _subjectService.GetByFacultyId(id);
        }
        [HttpPost]
        [Route("create/{name}")]
        public Subject Add(Subject model)
        {
            return _subjectService.Add(model);
        }
        [HttpPatch]
        [Route("update/{id}")]
        public Subject Update(Subject subject)
        {
            return _subjectService.Update(subject);
        }
    }
}
