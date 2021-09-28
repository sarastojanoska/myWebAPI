using MyWebApi.Data;
using MyWebApi.Entities;
using MyWebApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Services
{
    public class StudentService : IStudentService
    {
        private readonly IMyCAcademyDataContext db;
        public StudentService(IMyCAcademyDataContext db)
        {
            this.db = db;
        }
        public List<Student> Get()
        {
            return db.Student.ToList();
        }
        public Student Get(int id)
        {
            return db.Student.FirstOrDefault(f => f.Id == id);
            
        }

        public Student Add (Student s)
        {
            var student = db.Student.Add(s);
            db.SaveChanges();
            return student.Entity;
        }
        public Student Update (Student s)
        {
            var updatedStudent = db.Student.Update(s);
            db.SaveChanges();
            return updatedStudent.Entity;
        }
        
        public bool Delete(int id)
        {
            var st = db.Student.FirstOrDefault(x => x.Id == id);
            db.Student.Remove(st);
            var changesCount = db.SaveChanges();
            return changesCount == 1;
        }

        public List<Student> GetByFacultyId(int facultyid)
        {
            var students = db.Student.Where(x => x.FacultyId == facultyid).ToList();
            return students;
        }
    }
}
