using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;
        public EnderecoController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDto EnderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(EnderecoDto);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaEnderecosPorId), new { Id = endereco.Id }, EnderecoDto);
        }

        [HttpGet]
        public IEnumerable<ReadEnderecoDto> RecuperaEnderecos()
        {
            return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecosPorId(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(Endereco => Endereco.Id == id);
            if (endereco != null)
            {
                ReadEnderecoDto EnderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
                return Ok(EnderecoDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto EnderecoDto)
        {
            Endereco Endereco = _context.Enderecos.FirstOrDefault(Endereco => Endereco.Id == id);
            if (Endereco == null)
            {
                return NotFound();
            }
            _context.Remove(Endereco);
            _context.SaveChanges();
            return NoContent();
        }

        
    }
}
