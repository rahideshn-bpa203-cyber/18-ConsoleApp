using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IGroupService
    {
        Groups Create(Groups group);
        Groups Update(int id, Groups group);
        void Delete(int id);
        Groups GetById(int id);
        List<Groups> GetAll();
        List<Groups> SearchName(string name);
        List<Groups> SearchRoom(string room);
    }
}
