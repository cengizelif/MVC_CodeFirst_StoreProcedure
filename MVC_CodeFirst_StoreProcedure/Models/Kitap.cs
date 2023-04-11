using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_CodeFirst_StoreProcedure.Models
{
    [Table("Kitap")]
    public class Kitap
    {
        [Key]
        public int Id { get; set; }

        [Required,StringLength(50)]
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public DateTime YayinTarihi { get; set; }

    }
}