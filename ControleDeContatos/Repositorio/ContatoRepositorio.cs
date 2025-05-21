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

        public ContatoModel ListarPorId(int id)
        {
            return _applicationDbContext.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = ListarPorId(contato.Id);

            if (contatoDB == null) throw new Exception("Houve um erro na atualização do contato!");

            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

            _applicationDbContext.Contatos.Update(contatoDB);
            _applicationDbContext.SaveChanges();

            return contatoDB;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDB = ListarPorId(id);

            if (contatoDB == null) throw new Exception("Houve um erro na deleção do contato!");

            _applicationDbContext.Contatos.Remove(contatoDB);
            _applicationDbContext.SaveChanges();

            return true;
        }
    }
}
