using EstagiosEtec.AcessoDados;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EstagiosEtec.Models
{
    public class vagas : CreateDatabaseIfNotExists<vagasContexto>
    {
        protected override void Seed(vagasContexto contexto)
        {
            List<tipoVaga> tipoVagas = new List<tipoVaga>()
            {
                new tipoVaga() { Nome = "Administração" },
                new tipoVaga() { Nome = "Informática" },
                new tipoVaga() { Nome = "Logística" },
                new tipoVaga() { Nome = "Marketing" },
                new tipoVaga() { Nome = "Contabilidade" },
                new tipoVaga() { Nome = "Secretariado" },
                new tipoVaga() { Nome = "Desenvolvimento de Sistemas" },
                new tipoVaga() { Nome = "Banco de Dados" },
            };

            tipoVagas.ForEach(g => contexto.tipoVagas.Add(g));

            List<descricaoVaga> descricaoVagas = new List<descricaoVaga>()
            {
                new descricaoVaga() {
                    Titulo = "Criação do Banco de dados",
                    diaPublicacao = 12/10/2018,
                    dataMaxima = 30/10/2018,
                    empresa = "Sialog",
                    valor = 900.00m,
                    tipoVaga = tipoVagas.FirstOrDefault(g => g.Nome == "Banco de Dados")
                },
                new descricaoVaga() {
                    Titulo = "Desenvolvimento de Sistemas",
                    diaPublicacao = 12/09/2018,
                    dataMaxima = 01/10/2018,
                    empresa = "Sialog",
                    valor = 900.00m, 
                    tipoVaga = tipoVagas.FirstOrDefault(g => g.Nome == "Desenvolvimento de Sistemas")
                },
                new descricaoVaga() {
                    Titulo = "Marketing digital",
                    diaPublicacao = 12/10/2018,
                    dataMaxima = 30/10/2018,
                    empresa = "Sialog",
                    valor = 900.00m,
                    tipoVaga = tipoVagas.FirstOrDefault(g => g.Nome == "Informática")
                },

                 new descricaoVaga() {
                        Titulo = "Gerente de sistemas",
                        diaPublicacao = 12/09/2018,
                        dataMaxima = 01/10/2018,
                        empresa = "Sialog",
                        valor = 900.00m,
                        tipoVaga = tipoVagas.FirstOrDefault(g => g.Nome == "Informática")
                },

                     new descricaoVaga() {
                        Titulo = "Gerente contabil",
                        diaPublicacao = 12/09/2018,
                        dataMaxima = 01/10/2018,
                        empresa = "Sialog",
                        valor = 900.00m,
                        tipoVaga = tipoVagas.FirstOrDefault(g => g.Nome == "Contabilidade")
                }
            };
            
            descricaoVagas.ForEach(f => contexto.descricaoVagas.Add(f));

            contexto.SaveChanges();
        
        }
    }
}