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
        Group CreateGroup(Group group);
        Group UpdateGroup(int  id,Group group);
        void DeleteGroup(int id);
        Group GetGroupById(int id);
      
        Group GetAllByTeacher(string teacher);
        Group GetAllByRoom(int room);
        
        List<Group> GetAllGroups();
        Group SearchMethodForGroupsByName(string name);
        
    }
}
