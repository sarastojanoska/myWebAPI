using MyWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Services.Interfaces
{
    public interface IFacultiesService
    {
        List<Faculty> Get();
        Faculty Get(int id);
        Faculty Add(Faculty faculty);
        Faculty Update(Faculty faculty);
        Faculty SafeUpdate(Faculty faculty, int id);
        bool Delete(int id);
    }
}
