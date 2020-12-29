using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Naznean_LarisaGabriela_Proiect.Models
{
    public class AlbumCategory
    {
        public int ID { get; set; }
        public int AlbumID { get; set; }
        public Album Album { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
