using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstagiosEtec.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Idade { get; set; }
        public decimal Telefone { get; set; }
        public decimal Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
       
    }
}