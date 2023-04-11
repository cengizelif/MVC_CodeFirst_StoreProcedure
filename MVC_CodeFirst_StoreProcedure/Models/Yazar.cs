using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MVC_CodeFirst_StoreProcedure.Models
{
    [Table("Yazar")]
    public class Yazar
    {
        [Key]
        public int Id { get; set; }

        [Required,StringLength(30)]
        public string Ad { get; set; }

        [Required, StringLength(30)]
        public string Soyad { get; set; }

        [Required, StringLength(30)]
        public string Aciklama { get; set; }

        public int Aciklama2 { get; set; }
        public string Aciklama3 { get; set; }
        public DateTime DogumTarihi { get; set; }

    }
}