using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ContatoRepositorio(ApplicationDbContext applicationDbContext)
        { 
            _applicationDbContext = applicationDbContext;
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _applicationDbContext.Contatos.ToList();
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            _applicationDbContext.Contatos.Add(contato);
            _applicationDbContext.SaveChanges();

            return contato;
        }
    }
}
