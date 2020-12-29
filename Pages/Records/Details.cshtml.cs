using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Naznean_LarisaGabriela_Proiect.Data;
using Naznean_LarisaGabriela_Proiect.Models;

namespace Naznean_LarisaGabriela_Proiect.Pages.Records
{
    public class DetailsModel : PageModel
    {
        private readonly Naznean_LarisaGabriela_Proiect.Data.Naznean_LarisaGabriela_ProiectContext _context;

        public DetailsModel(Naznean_LarisaGabriela_Proiect.Data.Naznean_LarisaGabriela_ProiectContext context)
        {
            _context = context;
        }

        public Record Record { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Record = await _context.Record.FirstOrDefaultAsync(m => m.ID == id);

            if (Record == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
