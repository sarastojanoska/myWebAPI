using MyWebApi.Data;
using MyWebApi.Entities;
using MyWebApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Services
{
    public class StudentSubjectService : IStudentSubjectService
    {
        private readonly IMyCAcademyDataContext db;
        public StudentSubjectService(IMyCAcademyDataContext db)
        {
            this.db = db;
        }
        public List<StudentSubject> Get()
        {
            return db.StudentSubject.ToList();
        }
        public StudentSubject Get(int id)
        {
            return db.StudentSubject.FirstOrDefault(f => f.Id == id); 
        }
        public StudentSubject Add (StudentSubject studentSubject)
        {
            var ss = db.StudentSubject.Add(studentSubject);
            db.SaveChanges();
            return ss.Entity;
        }
        public StudentSubject Update (StudentSubject studentSubject)
        {
            var updated = db.StudentSubject.Update(studentSubject);
            db.SaveChanges();
            return updated.Entity;
        }
        
        public bool Delete(int id)
        {
            var ss = db.StudentSubject.FirstOrDefault(s => s.Id == id);
            db.StudentSubject.Remove(ss);
            var changesCount = db.SaveChanges();
            return changesCount == 1;
        }
    }
}
