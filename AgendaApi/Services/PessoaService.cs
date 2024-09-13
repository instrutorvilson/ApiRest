using AgendaApi.Models;
using AgendaApi.Repository;

namespace AgendaApi.Services
{
    public class PessoaService
    {
        private readonly PessoaRepositorio _repo;
        public PessoaService(PessoaRepositorio repo)
        {
            _repo = repo;
        }

        public Pessoa Save(Pessoa pessoa) {
            ValidaDados(pessoa);
            return _repo.Save(pessoa);
        }

        public List<Pessoa> GetAll() { 
            return (List<Pessoa>)_repo.GetAll();
        }

        public void Delete(int id) {
           /* if (Get(id) != null)
            {
                _repo.Delete(id);
            }
            else {
                throw new Exception();
            }   */
           Get(id);
           _repo.Delete(id);
        }

        public void Update(Pessoa pessoa)
        {
             ValidaDados(pessoa);
             Get(pessoa.Id);
            _repo.Update(pessoa);
        }

        public Pessoa Get(int id) { 
            var pessoaExistente = _repo.Get(id);
            if (pessoaExistente == null)
            {
                throw new Exception("Pessoa não existe");
            }
           return _repo.Get(id); 
        }

        private void ValidaDados(Pessoa pessoa)
        {
            if (pessoa.Nome.Equals(""))
            {
                throw new Exception("O nome deve ser informado");
            }

            if (pessoa.Email.Equals(""))
            {
                throw new Exception("O email deve ser informado");
            }
        }
    }
}
