using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Data.Dtos
{
    public class ReadEnderecoDto
    {
        public int Id { get; set; }
        public string Logadouro { get; set; }
        public int Numero { get; set; }
    }
}
