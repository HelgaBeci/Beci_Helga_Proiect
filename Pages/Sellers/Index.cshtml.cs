using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Beci_Helga_Proiect.Data;
using Beci_Helga_Proiect.Models;

namespace Beci_Helga_Proiect.Pages.Sellers
{
    public class IndexModel : PageModel
    {
        private readonly Beci_Helga_Proiect.Data.Beci_Helga_ProiectContext _context;

        public IndexModel(Beci_Helga_Proiect.Data.Beci_Helga_ProiectContext context)
        {
            _context = context;
        }

        public IList<Seller> Seller { get;set; }

        public async Task OnGetAsync()
        {
            Seller = await _context.Seller.ToListAsync();
        }
    }
}
