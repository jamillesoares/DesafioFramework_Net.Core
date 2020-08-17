using Framework.Desafio.Model.Entidade;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Framework.Desafio.Repository.Interface
{
    public interface IEstadoRepositorio
    {
        Task<List<Estado>> GetAll();
        Task<Estado> GetById(int id);
        Task<List<Estado>> GetEstadoPais(int idPais);
        void Insert(Estado obj);
        void Update(Estado obj);
        void Delete(Estado obj);
        void Save();
        bool Find(int id);
    }
}
