using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemirbasData.Model
{
    public class Return : BaseEntity
    {
        public Item Item { get; set; } 
        public int? ItemId { get; set; }
        public Employee Employee { get; set; }
        public int? EmployeeId { get; set; }
        public string Description { get; set; }
    }
}
