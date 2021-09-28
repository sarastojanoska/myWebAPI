using MyWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Services.Interfaces
{
    public interface ISubjectService
    {
        List<Subject> Get();
        Subject Get(int id);
        Subject Add(Subject subject);
        Subject Update(Subject subject);
       
        bool Delete(int id);
        List<Subject> GetByFacultyId(int facultyId);
    }
}
