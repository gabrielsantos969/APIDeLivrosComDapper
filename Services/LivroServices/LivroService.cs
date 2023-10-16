using CursoDapper.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace CursoDapper.Services.LivroServices
{
    public class LivroService: ILivroInterface
    {

        private readonly IConfiguration _configuration;
        private readonly string? getConnection;
        public LivroService(IConfiguration configuration)
        {

            _configuration = configuration;
            getConnection = _configuration.GetConnectionString("DefaultConnection");

        }

        public async Task<IEnumerable<Livro>> CreateBook(Livro livro)
        {
            using (var con = new MySqlConnection(getConnection))
            {
                var sql = "INSERT INTO `livrosdb`.`livros` (`titulo`, `autor`) VALUES (@titulo, @autor)";
                await con.ExecuteAsync(sql, livro);
                return await con.QueryAsync<Livro>("SELECT * FROM livros");
            }
        }

        public async  Task<IEnumerable<Livro>> DeleteBook(int id)
        {
            using (var con =new MySqlConnection(getConnection))
            {
                var sql = "DELETE FROM livros WHERE id=@id";
                await con.ExecuteAsync(sql, new {id = id});
                return await con.QueryAsync<Livro>("SELECT * FROM livros");
            }
        }

        public async Task<IEnumerable<Livro>> GetAllBooks() 
        {
            using (var con = new MySqlConnection(getConnection))
            {
                
                var sql = "SELECT * FROM livros";
                return await con.QueryAsync<Livro>(sql);
            }
        }

        public async Task<Livro> GetBookById(int id)
        {
            using (var con = new MySqlConnection(getConnection))
            {
                var sql = "SELECT * FROM livros WHERE id = @id";
                return await con.QueryFirstOrDefaultAsync<Livro>(sql, new { id });
            }
        }

        public async Task<IEnumerable<Livro>> UpdateBook(int id, Livro livro)
        {
            using (var con = new MySqlConnection(getConnection))
            {
                var sql = "UPDATE livros SET titulo = @titulo, autor= @autor WHERE id = @id";
                await con.ExecuteAsync(sql, new { titulo = livro.Titulo, autor = livro.Autor, id = id});
                return await con.QueryAsync<Livro>("SELECT * FROM livros");
            }
        }
    }
}
 