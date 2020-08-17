using Framework.Desafio.Model.Entidade;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Framework.Desafio.Repository.Interface
{
    public interface ICidadeRepositorio
    {
        Task<List<Cidade>> GetAll();
        Task<Cidade> GetById(int id);
        Task<List<Cidade>> GetCidadeEstado(int estadoId);
        void Insert(Cidade obj);
        void Update(Cidade obj);
        void Delete(Cidade obj);
        void Save();
        bool Find(int id);
    }
}
