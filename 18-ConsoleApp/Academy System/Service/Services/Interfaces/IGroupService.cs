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
        Group Create(Group group);
        Group Update(int id, Group group);
        void Delete(int id);
        Group GetById(int id);
        Group GetByTeacher(string groupTeacher);
        Group GetByRoom(string groupRoom);
        List<Group> GetAll();
        List<Group> Search(string name);

    }
}
