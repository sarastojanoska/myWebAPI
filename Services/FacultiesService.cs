using MyWebApi.Data;
using MyWebApi.Entities;
using MyWebApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Services
{
    public class FacultiesService : IFacultiesService
    {
        private readonly IMyCAcademyDataContext _db;
        public FacultiesService(IMyCAcademyDataContext db)
        {
            _db = db;
        }
        public List<Faculty> Get()
        {
            return _db.Faculty.ToList();
        }
        public Faculty Get(int id)
        {
            var f = _db.Faculty.FirstOrDefault(f => f.Id == id);
            return f;
        }
        public Faculty Add (Faculty faculty)
        {
            var f = _db.Faculty.Add(faculty);
            _db.SaveChanges();
            return f.Entity;
        }
        public Faculty Update (Faculty faculty)
        {
            var updatedFaculty = _db.Faculty.Update(faculty);
            _db.SaveChanges();
            return updatedFaculty.Entity;
        }
        public Faculty SafeUpdate(Faculty faculty, int id)
        {
            var f = _db.Faculty.FirstOrDefault(f => f.Id == id);
            f.Name = faculty.Name;
            var updatedfaculty = _db.Faculty.Update(f);
            var count = _db.SaveChanges();//int vrakja kolku promeni vo samata baza bile izvrseni
            return updatedfaculty.Entity;
        }
        public bool Delete(int id)
        {
            var fac = _db.Faculty.FirstOrDefault(f => f.Id == id);
            _db.Faculty.Remove(fac);
            var changesCount = _db.SaveChanges();
            return changesCount == 1;
        }
    }
}
