using AgendaApi.Models;
using AgendaApi.Repository;

namespace AgendaApi.Services
{
    public class PessoaService
    {
        private readonly RepoPessoa _repo;
        public PessoaService(RepoPessoa repo)
        {
            _repo = repo;
        }

        public Pessoa Save(Pessoa pessoa) {
            if (pessoa.Nome.Equals("")){
                throw new Exception("O nome deve ser informado");
            }
            return _repo.Save(pessoa);
        }
    }
}
