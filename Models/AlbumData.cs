using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Naznean_LarisaGabriela_Proiect.Models
{
    public class AlbumData
    {
        public IEnumerable<Album> Albums { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<AlbumCategory> AlbumCategories { get; set; }

    }
}
