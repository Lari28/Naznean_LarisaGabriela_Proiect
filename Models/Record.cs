using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Naznean_LarisaGabriela_Proiect.Models
{
    public class Record
    {
        public int ID { get; set; }
        public string RecordName { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
}
