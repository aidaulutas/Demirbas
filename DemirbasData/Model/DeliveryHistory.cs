using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemirbasData.Model
{
    public class DeliveryHistory : BaseEntity
    {
        public DateTime DeliveryDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public Item Item { get; set; }
        public int ItemId { get; set; }
        public Department Department { get; set; }
        public int? DepartmentId { get; set; }
        

    }
}
