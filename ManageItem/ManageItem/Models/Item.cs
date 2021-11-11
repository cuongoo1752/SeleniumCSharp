using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManageItem.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string  Description { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
