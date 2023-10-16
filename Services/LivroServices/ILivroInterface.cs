using CursoDapper.Models;

namespace CursoDapper.Services.LivroServices
{
    public interface ILivroInterface
    {
        Task<IEnumerable<Livro>> GetAllLivros();

        Task<Livro> GetLivroById(int id);

        Task<IEnumerable<Livro>> CreateLivro(Livro livro);

        Task<IEnumerable<Livro>> UpdateLivro(int id, Livro livro);

        Task<IEnumerable<Livro>> DeleteLivro(int id);
    }
}
