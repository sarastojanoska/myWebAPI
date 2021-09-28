using MyWebApi.Data;
using MyWebApi.Entities;
using MyWebApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IMyCAcademyDataContext db;
        public SubjectService(IMyCAcademyDataContext db)
        {
            this.db = db;
        }
        public List<Subject> Get()
        {
            return db.Subject.ToList();
        }
        public Subject Get(int id)
        {
            return db.Subject.FirstOrDefault(s => s.Id == id);
            
        }
        public Subject Add (Subject subject)
        {
            var sub = db.Subject.Add(subject);
            db.SaveChanges();
            return sub.Entity;
        }
        public Subject Update (Subject subject)
        {
            var updated = db.Subject.Update(subject);
            db.SaveChanges();
            return updated.Entity;
        }
        
        public bool Delete(int id)
        {
            var subject = db.Subject.FirstOrDefault(f => f.Id == id);
            db.Subject.Remove(subject);
            var changesCount = db.SaveChanges();
            return changesCount == 1;
        }
        public List<Subject> GetByFacultyId(int facultyId)
        {
            var subjects = db.Subject.Where(s => s.FacultyId == facultyId).ToList();
            return subjects;
        }
    }
}
