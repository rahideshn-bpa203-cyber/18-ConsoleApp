using Domain.Entities;
using Repository.Repositories.Implementations;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Implementations
{
    public class GroupService : IGroupService
    {
        private GroupRepository _groupRepository;
        private int _count;
        public GroupService()
        {
            _groupRepository= new GroupRepository();
        }
        public Group Create(Group group)
        {
            group.Id = _count; 
            _groupRepository.Create(group);
            _count++;
            return group;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Group GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Group Update(int id, Group group)
        {
            throw new NotImplementedException();
        }
    }
}
