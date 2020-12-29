using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Naznean_LarisaGabriela_Proiect.Data;
using Naznean_LarisaGabriela_Proiect.Models;

namespace Naznean_LarisaGabriela_Proiect.Pages.Albums
{
    public class EditModel : AlbumCategoriesPageModel
    {
        private readonly Naznean_LarisaGabriela_Proiect.Data.Naznean_LarisaGabriela_ProiectContext _context;

        public EditModel(Naznean_LarisaGabriela_Proiect.Data.Naznean_LarisaGabriela_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Album Album { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Album = await _context.Album
  .Include(b => b.Record)
  .Include(b => b.AlbumCategories).ThenInclude(b => b.Category)
  .AsNoTracking()
  .FirstOrDefaultAsync(m => m.ID == id);

            if (Album == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Album);

            ViewData["RecordID"] = new SelectList(_context.Set<Record>(), "ID", "RecordName");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var AlbumToUpdate = await _context.Album
            .Include(i => i.Record)
            .Include(i => i.AlbumCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (AlbumToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Album>(
            AlbumToUpdate,
            "Album",
            i => i.Title, i => i.Singer,
            i => i.Price, i => i.PublishingDate, i => i.Record))
            {
                UpdateAlbumCategories(_context, selectedCategories, AlbumToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateAlbumCategories pentru a aplica informatiile din checkboxuri la entitatea Albums care
            //este editata
            UpdateAlbumCategories(_context, selectedCategories, AlbumToUpdate);
            PopulateAssignedCategoryData(_context, AlbumToUpdate);
            return Page();
        }
    }
}

