using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UFO_Webapp.Data;
using UFO_Webapp.Pages.Models;

namespace UFO_Webapp.Pages.ImageCRUD
{
    public class CreateModel : PageModel
    {
        private readonly UFO_Webapp.Data.UFO_ImageContext _context;

        private readonly IWebHostEnvironment _hostenvironment;

        public CreateModel(UFO_Webapp.Data.UFO_ImageContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _hostenvironment = webHostEnvironment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FileViewModel FileUpload { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }
          //Save image to database
          using (var memoryStream = new MemoryStream())
            {
                await FileUpload.FormFile.CopyToAsync(memoryStream);

                //Checks for filesize limit (2MB)
                if (memoryStream.Length < 2097152)
                {
                    var file = new Image()
                    {
                        Filename = FileUpload.FormFile.FileName,
                        Content = memoryStream.ToArray()
                    };
                    _context.Image.Add(file);

                    await _context.SaveChangesAsync();
                }
                else
                {
                    ModelState.AddModelError("File", "The file is too large.");
                }
            }


            return RedirectToPage("./Index");
        }
    }
}
