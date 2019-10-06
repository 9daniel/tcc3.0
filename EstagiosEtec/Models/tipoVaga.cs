using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EstagiosEtec.Models;
using System.ComponentModel.DataAnnotations;


namespace EstagiosEtec.Models
{
    public class tipoVaga
    {
        [Key]
        public int id { get; set; }

        public string Nome { get; set; }
    }
}