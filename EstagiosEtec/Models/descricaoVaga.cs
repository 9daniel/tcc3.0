using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EstagiosEtec.Models
{
    public class descricaoVaga
    {
        [Key]
        public int id { get; set; }
        public string Titulo { get; set; }

        [Display(Name = "Data Inicial:")]
        public int diaPublicacao { get; set; }

        [Display(Name = "Data Limite:")]
        public int dataMaxima { get; set; }

        [Display(Name = "Empresa:")]
        public string empresa { get; set; }

        [Display(Name = "Valor a Pago:")]
        public decimal valor { get; set; }
        

        public tipoVaga tipoVaga { get; set; }
        public int tipoVagaid  { get; set; }
        
    }
}