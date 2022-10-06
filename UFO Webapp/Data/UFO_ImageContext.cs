using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UFO_Webapp.Pages.Models;

namespace UFO_Webapp.Data
{
    public class UFO_ImageContext : DbContext
    {
        public UFO_ImageContext (DbContextOptions<UFO_ImageContext> options)
            : base(options)
        {
        }

        public DbSet<UFO_Webapp.Pages.Models.Image> Image { get; set; } = default!;
    }
}
