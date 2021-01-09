using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Beci_Helga_Proiect.Data;
using Beci_Helga_Proiect.Models;

namespace Beci_Helga_Proiect.Pages.CarCategories
{
    public class DeleteModel : PageModel
    {
        private readonly Beci_Helga_Proiect.Data.Beci_Helga_ProiectContext _context;

        public DeleteModel(Beci_Helga_Proiect.Data.Beci_Helga_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CarCategory CarCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarCategory = await _context.CarCategory
                .Include(c => c.Car)
                .Include(c => c.Category).FirstOrDefaultAsync(m => m.ID == id);

            if (CarCategory == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarCategory = await _context.CarCategory.FindAsync(id);

            if (CarCategory != null)
            {
                _context.CarCategory.Remove(CarCategory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
