using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Beci_Helga_Proiect.Data;
using Beci_Helga_Proiect.Models;

namespace Beci_Helga_Proiect.Pages.CarCategories
{
    public class CreateModel : PageModel
    {
        private readonly Beci_Helga_Proiect.Data.Beci_Helga_ProiectContext _context;

        public CreateModel(Beci_Helga_Proiect.Data.Beci_Helga_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CarID"] = new SelectList(_context.Car, "ID", "ID");
        ViewData["CategoryID"] = new SelectList(_context.Category, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public CarCategory CarCategory { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CarCategory.Add(CarCategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
