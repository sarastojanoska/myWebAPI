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
    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> _logger;
        private readonly IStudentService _studentsService;
        public StudentsController(ILogger<StudentsController> logger, IStudentService studentsService)
        {
            _logger = logger;
            _studentsService = studentsService;
        }
        [HttpGet]
        public List<Student> Get()
        {
            return _studentsService.Get();
        }
        [HttpGet]
        public Student Get(int id)
        {
            return _studentsService.Get(id);
        }
        [HttpGet]
        [Route("Faculty/{id}")]
        public List<Student> GetStudentsByFacultyId(int id)
        {
            return _studentsService.GetByFacultyId(id);
        }
        [HttpPost]
        [Route("create/{name}")]
        public Student Add(Student model)
        {
            return _studentsService.Add(model);
        }
        [HttpPatch]
        [Route("update/{id}")]
        public Student Update(Student student)
        {
            return _studentsService.Update(student);
        }
    }
}
