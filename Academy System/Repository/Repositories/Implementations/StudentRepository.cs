using Domain.Entities;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Implementations
{
    public class StudentRepository : IRepository<Students>
    {
        public void Create(Students data)
        {
            try
            {
                if (data == null) throw new Exception("Student not found");
                AppDbContext<Students>.datas.Add(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Students data)
        {
            AppDbContext<Students>.datas.Remove(data);
        }

        public Students Get(Predicate<Students> predicate)
        {
            return predicate != null ? AppDbContext<Students>.datas.Find(predicate) : null;
        }

        public List<Students> GetAll(Predicate<Students> predicate)
        {
            return predicate != null ? AppDbContext<Students>.datas.FindAll(predicate) : AppDbContext<Students>.datas;
        }

        public void Update(Students data)
        {
            Students students = Get(s => s.Id == data.Id);
            if (students == null) return;
            if (!string.IsNullOrEmpty(students.Name))
            {
                students.Name = data.Name;
            }
            if (!string.IsNullOrEmpty(students.Surname))
            {
                students.Surname = data.Surname;
            }
            if (data.Age > 0)
            {
                students.Age = data.Age;
            }
            if (data.Group != null)
            {
                students.Group = data.Group;
            }

        }
    }
}
