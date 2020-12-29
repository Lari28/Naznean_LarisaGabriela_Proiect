using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Naznean_LarisaGabriela_Proiect.Data;
using Naznean_LarisaGabriela_Proiect.Models;

namespace Naznean_LarisaGabriela_Proiect.Pages.Albums
{
    public class IndexModel : PageModel
    {
        private readonly Naznean_LarisaGabriela_Proiect.Data.Naznean_LarisaGabriela_ProiectContext _context;

        public IndexModel(Naznean_LarisaGabriela_Proiect.Data.Naznean_LarisaGabriela_ProiectContext context)
        {
            _context = context;
        }

        public IList<Album> Album { get; set; }

        public AlbumData AlbumD { get; set; }
        public int AlbumID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            AlbumD = new AlbumData();

            AlbumD.Albums = await _context.Album
            .Include(b => b.Record)
            .Include(b => b.AlbumCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Title)
            .ToListAsync();
            if (id != null)
            {
                AlbumID = id.Value;
                Album Album = AlbumD.Albums
                .Where(i => i.ID == id.Value).Single();
                AlbumD.Categories = Album.AlbumCategories.Select(s => s.Category);
            }
        }
    }
}
