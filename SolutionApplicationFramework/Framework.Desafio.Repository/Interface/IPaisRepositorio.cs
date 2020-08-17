using Framework.Desafio.Model.Entidade;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Framework.Desafio.Repository.Interface
{
    public interface IPaisRepositorio
    {
        Task<List<Pais>> GetAll();
        Task<Pais> GetById(int id);
        void Insert(Pais obj);
        void Update(Pais obj);
        void Delete(Pais obj);
        void Save();
        bool Find(int id);
    }
}
