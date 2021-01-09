using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Beci_Helga_Proiect.Data;
using Beci_Helga_Proiect.Models;

namespace Beci_Helga_Proiect.Pages.CarCategories
{
    public class EditModel : PageModel
    {
        private readonly Beci_Helga_Proiect.Data.Beci_Helga_ProiectContext _context;

        public EditModel(Beci_Helga_Proiect.Data.Beci_Helga_ProiectContext context)
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
           ViewData["CarID"] = new SelectList(_context.Car, "ID", "ID");
           ViewData["CategoryID"] = new SelectList(_context.Category, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CarCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarCategoryExists(CarCategory.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CarCategoryExists(int id)
        {
            return _context.CarCategory.Any(e => e.ID == id);
        }
    }
}
