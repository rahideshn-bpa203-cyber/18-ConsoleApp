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
    public class GroupRepository : IRepository<Groups>
    {
        public void Create(Groups data)
        {
            try
            {
                if (data is null) throw new Exception("Data not Found");
                AppDbContext<Groups>.datas.Add(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Groups data)
        {
            AppDbContext<Groups>.datas.Remove(data);
        }

        public Groups Get(Predicate<Groups> predicate)
        {
            return predicate != null ? AppDbContext<Groups>.datas.Find(predicate) : null;
        }

        public List<Groups> GetAll(Predicate<Groups> predicate=null)
        {
            return predicate != null ? AppDbContext<Groups>.datas.FindAll(predicate) : AppDbContext<Groups>.datas;

        }

        

        public void Update(Groups data)
        {
            Groups groups = Get(g => g.Id == data.Id);
            if (groups == null) return;
            if (!string.IsNullOrEmpty(groups.Name))
            {
                groups.Name = data.Name;
            }
            if (!string.IsNullOrEmpty(groups.Teacher))
            {
                groups.Teacher = data.Teacher;
            }
            if (!string.IsNullOrEmpty(groups.Room))
            {
                groups.Room = data.Room;
            }
        }
    }
}
