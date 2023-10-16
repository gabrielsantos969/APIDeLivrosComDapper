using CursoDapper.Models;
using CursoDapper.Services.LivroServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Cms;

namespace CursoDapper.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {


        private readonly ILivroInterface _livroInterface;

        public LivroController(ILivroInterface livroInterface)
        {
            _livroInterface = livroInterface;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livro>>> GetAllLivros()
        {

            IEnumerable<Livro> livros = await _livroInterface.GetAllLivros();

            if (!livros.Any())
            {
                return NotFound("Nenhum Livro encontrado...");
            }

            return Ok(livros);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Livro>> GetLivroById(int id)
        {
            Livro livro = await _livroInterface.GetLivroById(id);

            if (livro == null)
            {
                return NotFound("Livro não encontrado...");
            }

            return Ok(livro);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Livro>>> CreateLivro(Livro livro)
        {
            IEnumerable<Livro> livros = await _livroInterface.CreateLivro(livro);
            return Ok(livros);

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<IEnumerable<Livro>>> UpdateLivro(int id, Livro livro)
        {
            Livro registro = await _livroInterface.GetLivroById(id);
            
            if (registro == null)
            {
                return NotFound("Livro não encontrado...");
            }

            IEnumerable<Livro> livros = await _livroInterface.UpdateLivro(id, livro);    
            return Ok(livros);

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<IEnumerable<Livro>>> DeleteLivro(int id)
        {
            Livro registro = await _livroInterface.GetLivroById(id);

            if(registro == null)
            {
                return NotFound("Livro não encontrado...");
            }

            IEnumerable<Livro> livros = await _livroInterface.DeleteLivro(id);
            return Ok(livros);
        }
    }
}
