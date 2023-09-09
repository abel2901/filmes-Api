using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Data
{
    public class Seed
    {
        public static void Initalize(IServiceProvider serviceProvider)
        {
            using (var context = new FilmeContext(serviceProvider.GetRequiredService<DbContextOptions<FilmeContext>>()))
            {
                if (context.Filmes.Any()) { return; }


                List<Filme> filmes = new List<Filme>()
                {
                    new Filme()
                    {
                        Id = 1, Titulo = "Star Wars", Genero = "Aventura", Duracao = 120
                    },
                    new Filme()
                    {
                        Id = 2, Titulo = "Velozes e Furiosos", Genero = "Aventura", Duracao = 120
                    }
                };

                context.Filmes.AddRange(filmes);
                context.SaveChanges();
            }
        }
    }
}
