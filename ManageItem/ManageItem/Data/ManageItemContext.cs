using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ManageItem.Models;

namespace ManageItem.Data
{
    public class ManageItemContext : DbContext
    {
        public ManageItemContext (DbContextOptions<ManageItemContext> options)
            : base(options)
        {
        }

        public DbSet<ManageItem.Models.Item> Item { get; set; }
    }
}
