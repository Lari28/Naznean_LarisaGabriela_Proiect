using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Naznean_LarisaGabriela_Proiect.Data;
using Naznean_LarisaGabriela_Proiect.Models;

namespace Naznean_LarisaGabriela_Proiect.Pages.Records
{
    public class CreateModel : PageModel
    {
        private readonly Naznean_LarisaGabriela_Proiect.Data.Naznean_LarisaGabriela_ProiectContext _context;

        public CreateModel(Naznean_LarisaGabriela_Proiect.Data.Naznean_LarisaGabriela_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Record Record { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Record.Add(Record);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
