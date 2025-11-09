using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Group : BaseEntity
    {
       
        public string Teacher { get; set; }
        public string Room { get; set; }
        
    }
}
