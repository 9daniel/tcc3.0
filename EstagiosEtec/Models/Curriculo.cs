using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstagiosEtec.Models
{
    public class Curriculo
    {
        public int Id { get; set; }
        public string Experiencia { get; set; }
        public string Formacao { get; set; }
        public string Competencia { get; set; }
        public int Nota { get; set; }

        public Aluno Aluno { get; set; }
        public int AlunoId { get; set; }
    }
}