using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Naznean_LarisaGabriela_Proiect.Data;
using Naznean_LarisaGabriela_Proiect.Models;

namespace Naznean_LarisaGabriela_Proiect.Pages.Albums
{
    public class CreateModel : AlbumCategoriesPageModel

    {
        private readonly Naznean_LarisaGabriela_Proiect.Data.Naznean_LarisaGabriela_ProiectContext _context;

        public CreateModel(Naznean_LarisaGabriela_Proiect.Data.Naznean_LarisaGabriela_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["RecordID"] = new SelectList(_context.Set<Record>(), "ID", "RecordName");
            var Album = new Album();
            Album.AlbumCategories = new List<AlbumCategory>();
            PopulateAssignedCategoryData(_context, Album);
            return Page();

        }

        [BindProperty]
        public Album Album { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newAlbum = new Album();
            if (selectedCategories != null)
            {
                newAlbum.AlbumCategories = new List<AlbumCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new AlbumCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newAlbum.AlbumCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Album>(
            newAlbum,
            "Album",
            i => i.Title, i => i.Singer,
            i => i.Price, i => i.PublishingDate, i => i.RecordID))
            {
                _context.Album.Add(newAlbum);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newAlbum);
            return Page();
        }
    }
}