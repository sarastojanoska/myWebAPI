using MyWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Services.Interfaces
{
    public interface IStudentSubjectService
    {
        List<StudentSubject> Get();
        StudentSubject Get(int id);
        StudentSubject Add(StudentSubject studentSubject);
        StudentSubject Update(StudentSubject studentSubject);
       
        bool Delete(int id);
    }
}
