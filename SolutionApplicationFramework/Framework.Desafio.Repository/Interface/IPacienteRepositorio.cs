using Framework.Desafio.Model.Entidade;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Framework.Desafio.Repository.Interface
{
    public interface IPacienteRepositorio
    {
        Task<List<Paciente>> GetAll();
        Task<Paciente> GetById(int id);
        void Insert(Paciente obj);
        void Update(Paciente obj);
        void Delete(Paciente obj);
        void Save();
        bool Find(int id);
    }
}
