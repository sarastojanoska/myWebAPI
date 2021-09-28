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
    public class StudentSubjectsController : ControllerBase
    {
        private readonly ILogger<StudentSubjectsController> _logger;
        private readonly IStudentSubjectService _studentsubjectService;
        public StudentSubjectsController(ILogger<StudentSubjectsController> logger, IStudentSubjectService studentsubjectService)
        {
            _logger = logger;
            _studentsubjectService = studentsubjectService;
        }
        [HttpGet]
        public List<StudentSubject> Get()
        {
            return _studentsubjectService.Get();
        }
        [HttpGet]
        public StudentSubject Get(int id)
        {
            return _studentsubjectService.Get(id);
        }
        [HttpPost]
        [Route("create/{name}")]
        public StudentSubject Add(StudentSubject model)
        {
            return _studentsubjectService.Add(model);
        }
        [HttpPatch]
        [Route("update/{id}")]
        public StudentSubject Update(StudentSubject studentsubject)
        {
            return _studentsubjectService.Update(studentsubject);
        }
    }
}
