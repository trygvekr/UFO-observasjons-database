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
    public class DetailsModel : PageModel
    {
        private readonly UFO_Webapp.Data.UFO_ImageContext _context;

        public DetailsModel(UFO_Webapp.Data.UFO_ImageContext context)
        {
            _context = context;
        }

      public Image Image { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Image == null)
            {
                return NotFound();
            }

            var image = await _context.Image.FirstOrDefaultAsync(m => m.ImageID == id);
            if (image == null)
            {
                return NotFound();
            }
            else 
            {
                Image = image;
            }
            return Page();
        }
    }
}
