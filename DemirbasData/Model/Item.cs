using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemirbasData.Model
{
    public class Item : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemType ItemType { get; set; }
        public int? ItemTypeId { get; set; }
        public string SerialNumber { get; set; }
        public User User { get; set; }
        public int? UserId { get; set; }
    }
}
