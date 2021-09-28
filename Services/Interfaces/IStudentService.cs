using MyWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Services.Interfaces
{
    public interface IStudentService
    {
        List<Student> Get();
        Student Get(int id);
        Student Add(Student student);
        Student Update(Student student);
        bool Delete(int id);
        List<Student> GetByFacultyId(int facultyid);
    }
}
