﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Naznean_LarisaGabriela_Proiect.Models
{
    public class Album
{ 
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Album Title")]
        public string Title { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Numele artistului trebuie sa fie de forma 'Prenume Nume'"), Required, StringLength(50, MinimumLength = 3)]


        public string Singer { get; set; }
        [Range(1, 300)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }

        public int RecordID { get; set; }
        public Record Record { get; set; }  //navigation property
        public ICollection<AlbumCategory> AlbumCategories { get; set; }
    }
}
