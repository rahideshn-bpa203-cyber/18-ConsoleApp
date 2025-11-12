using Domain.Entities;
using Repository.Repositories.Implementations;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Service.Services.Implementations
{
    public class GroupService : IGroupService
    {
        private GroupRepository groupRepository;
        private int _count = 1;
        public GroupService()
        {
            groupRepository = new GroupRepository();

        }

        public Group Create(Group group)
        {
            group.Id = _count;

            groupRepository.Create(group);

            _count++;
            return group;
        }

        public void Delete(int id)
        {
            Group group = GetById(id);

            groupRepository.Delete(group);
        }

        public List<Group> GetAll()
        {
            return groupRepository.GetAll();
        }

        public Group GetById(int id)
        {
            Group group = groupRepository.Get(g => g.Id == id);
            if (group is null) return null;
            return group;
        }

        public Group GetByRoom(string groupRoom)
        {
            Group group = groupRepository.Get(g => g.Room == groupRoom);
            if (group is null) return null;
            return group;
        }

        public Group GetByTeacher(string groupTeacher)
        {
            Group group = groupRepository.Get(g => g.Teacher == groupTeacher);
            if (group is null) return null;
            return group;
        }

        public List<Group> Search(string name)
        {
            return groupRepository.GetAll(g => g.Name.Trim().ToLower().Contains(name.Trim().ToLower()));
        }

        public Group Update(int id, Group group)
        {
            Group dbGroup = GetById(id);

            if (dbGroup is null) return null;

            group.Id = id;

            groupRepository.Update(group);

            return GetById(id);
        }
    }
}
