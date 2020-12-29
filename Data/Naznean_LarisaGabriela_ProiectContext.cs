using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Naznean_LarisaGabriela_Proiect.Models;

namespace Naznean_LarisaGabriela_Proiect.Data
{
    public class Naznean_LarisaGabriela_ProiectContext : DbContext
    {
        public Naznean_LarisaGabriela_ProiectContext (DbContextOptions<Naznean_LarisaGabriela_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Naznean_LarisaGabriela_Proiect.Models.Album> Album { get; set; }

        public DbSet<Naznean_LarisaGabriela_Proiect.Models.Record> Record { get; set; }

        public DbSet<Naznean_LarisaGabriela_Proiect.Models.Category> Category { get; set; }
    }
}
