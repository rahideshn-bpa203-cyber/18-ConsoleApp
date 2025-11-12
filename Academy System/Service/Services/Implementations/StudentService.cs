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
    public class StudentService : IStudentService
    {
        public StudentRepository _studentRepository;
        private GroupRepository _groupRepository;
        int _count = 1;
        public StudentService()
        {
            _groupRepository = new GroupRepository();
            _studentRepository = new StudentRepository();

        }
        public Students Create(int GroupId, Students students)
        {
            var group = _groupRepository.Get(g => g.Id == GroupId);
            if (group == null) return null;
            students.Id = _count;
            students.Group = group;
            _studentRepository.Create(students);
            _count++;
            return students;
        }

        public void Delete(int id)
        {
            Students students = GetById(id);
            _studentRepository.Delete(students);
        }

        public Students GetById(int GroupId)
        {
            Students students = _studentRepository.Get(g => g.Id == GroupId);
            if (students == null) return null;
            return students;
        }

        public Students Update(int id, Students students)
        {
            Students student = GetById(id);
            if (student is null) return null;
            student.Name = students.Name;
            student.Surname = students.Surname;
            student.Age = students.Age;
            student.Group = students.Group;
            _studentRepository.Update(student);
            return GetById(id);
        }
        public List<Students> StudentsbyAge(int age)
        {
            List<Students> students = _studentRepository.GetAll(s => s.Age == age);
            return null;
        }
        public List<Students> StudentsbyGroupID(int id)
        {
            List<Students> students = _studentRepository.GetAll(s => s.Group.Id == id);
            return students;
        }
        public List<Students> StudentsbyNameOrSurname(string nameOrSurname)
        {
            List<Students> studentname = _studentRepository.GetAll(s => s.Name.Trim().ToLower() == nameOrSurname.Trim().ToLower());
            List<Students> studentSurname = _studentRepository.GetAll(s => s.Surname.Trim().ToLower() == nameOrSurname.Trim().ToLower());
            if (studentname.Count > 0) { return studentname; }
            else if (studentSurname.Count > 0) { return studentSurname; }
            else { return null; }


        }
    }
}
