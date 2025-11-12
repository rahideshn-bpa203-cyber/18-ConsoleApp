using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IStudentService
    {
        Students Create(int GroupId, Students students);
        void Delete(int id);
        Students Update(int id, Students students);
        Students GetById(int GroupId);
    }
}
