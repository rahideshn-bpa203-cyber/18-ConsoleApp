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
        private int _count = 1;
        public GroupService()
        {
            _groupRepository = new GroupRepository();

        }

        public Groups Create(Groups group)
        {
            group.Id = _count;
            _groupRepository.Create(group);
            _count++;
            return group;
        }

        public void Delete(int id)
        {
            Groups groups=GetById(id);
            _groupRepository.Delete(groups);
        }

        public List<Groups> GetAll()
        {
            return _groupRepository.GetAll();
        }

        public Groups GetById(int id)
        {
            Groups groups = _groupRepository.Get(g => g.Id == id);
            if (groups is null) return null;
            return groups;
        }

        public List<Groups> SearchName(string teacherName)
        {
            if (string.IsNullOrEmpty(teacherName)) return new List<Groups>();
            List<Groups> groups = _groupRepository.GetAll(g => !string.IsNullOrEmpty(g?.Teacher) &&
                string.Equals(g.Teacher.Trim(), teacherName.Trim(), StringComparison.OrdinalIgnoreCase));
            return groups;
        }

        public List<Groups> SearchRoom(string room)
        {
            if (string.IsNullOrEmpty(room)) return new List<Groups>();
            return _groupRepository.GetAll(g => !string.IsNullOrEmpty(g?.Room) &&
                string.Equals(g.Room.Trim(), room.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        public Groups Update(int id, Groups group)
        {
            Groups groups = GetById(id);
            if (groups is null) return null;
            groups.Id = id;
            groups.Name = group.Name;
            groups.Room = group.Room;
            groups.Teacher = group.Teacher;

            _groupRepository.Update(groups);
            return GetById(id);
        }
        public Groups GetByName(string name)
        {
            if (string.IsNullOrEmpty(name)) return null;
            Groups groups = _groupRepository.Get(g => !string.IsNullOrEmpty(g?.Name) &&
                string.Equals(g.Name.Trim(), name.Trim(), StringComparison.OrdinalIgnoreCase));
            return groups;
        }
    }
}
