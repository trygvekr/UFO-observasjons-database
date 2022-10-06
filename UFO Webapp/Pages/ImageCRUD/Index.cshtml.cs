using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UFO_Webapp.Data;
using UFO_Webapp.Pages.Models;

namespace UFO_Webapp.Pages.ImageCRUD
{
    public class IndexModel : PageModel
    {
        private readonly UFO_Webapp.Data.UFO_ImageContext _context;

        public IndexModel(UFO_Webapp.Data.UFO_ImageContext context)
        {
            _context = context;
        }

        public IList<Image> Image { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Image != null)
            {
                Image = await _context.Image.ToListAsync();
            }
        }
    }
}
