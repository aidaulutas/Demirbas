using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemirbasData.Model
{
    public class ItemType : BaseEntity
    {
        public string Name { get; set; }
      
        public List<Item> Item { get; set; }
    }
}
