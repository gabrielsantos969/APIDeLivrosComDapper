using CursoDapper.Models;

namespace CursoDapper.Services.LivroServices
{
    public interface ILivroInterface
    {
        Task<IEnumerable<Livro>> GetAllBooks();

        Task<Livro> GetBookById(int id);

        Task<IEnumerable<Livro>> CreateBook(Livro livro);

        Task<IEnumerable<Livro>> UpdateBook(int id, Livro livro);

        Task<IEnumerable<Livro>> DeleteBook(int id);
    }
}
