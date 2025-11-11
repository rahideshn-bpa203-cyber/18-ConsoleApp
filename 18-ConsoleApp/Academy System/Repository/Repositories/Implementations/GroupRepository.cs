using Domain.Entities;
using Repository.Data;
using Repository.Exceptions;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Implementations
{
    public class GroupRepository : IRepository<Group>
    {
        public void Create(Group data)
        {
            try
            {
                if (data is null) throw new NotFoundException("data not found");

                AppDpContext<Group>.datas.Add(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Group data)
        {
            AppDpContext<Group>.datas.Remove(data);
        }

        public Group Get(Predicate<Group> predicate)
        {
            return predicate != null ? AppDpContext<Group>.datas.Find(predicate) : null;
        }

        public List<Group> GetAll(Predicate<Group> predicate = null)
        {
            return predicate != null ? AppDpContext<Group>.datas.FindAll(predicate) : AppDpContext<Group>.datas;

        }

        public List<Group> Search(string searchText)
        {
            throw new NotImplementedException();
        }

        public void Update(Group data)
        {



            Group dpGroup = Get(g => g.Id == data.Id);

            if (dpGroup == null) return;

            if (!string.IsNullOrEmpty(data.Name))
            {
                dpGroup.Name = data.Name;
            }

            if (data.Id > 0)
            {
                dpGroup.Id = data.Id;
            }

        }
    }
}

