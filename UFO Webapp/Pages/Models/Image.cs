using Microsoft.EntityFrameworkCore;
using UFO_Webapp.Data;

namespace UFO_Webapp.Pages.Models
{
    public class Image
    {
        public int ImageID { get; set; }
        public string Filename { get; set; }
        public byte[] Content { get; set; }

    }

    public class ApplicationDbContext : UFO_ImageContext
    {
        public DbSet<Image>? File { get; set; }
        public ApplicationDbContext(DbContextOptions<UFO_ImageContext> options)
            : base(options)
        {
        }
       
    }
}
