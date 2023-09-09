using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos
{
    public class UpdateFilmeDto
    {
        [Key]
        [Required]
        public int Id { get; internal set; }

        [Required(ErrorMessage = "O Titulo do filme é obrigatorio")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O Genero do filme é obrigatorio")]
        public string Genero { get; set; }
        [Required]
        [Range(70, 600, ErrorMessage = "A duração em minutos deve ter entre 70 a 600 minutos")]
        public int Duracao { get; set; }
    }
}
