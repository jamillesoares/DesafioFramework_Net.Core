using Framework.Desafio.Model.Entidade;
using Framework.Desafio.Repository.Contexto;
using Framework.Desafio.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Desafio.Repository
{
    public class PacienteRepositorio : IPacienteRepositorio
    {
        private AppDbContext _context;

        public PacienteRepositorio(AppDbContext context)
        {
            _context = context;
        }
        public void Delete(Paciente obj)
        {
            _context.Pacientes.Remove(obj);
        }

        public bool Find(int id)
        {
            return _context.Pacientes.Any(x => x.Id == id);
        }

        public async Task<List<Paciente>> GetAll()
        {
            return await _context.Pacientes
                .Include(p => p.Cidade)
                .Include(e => e.Estado)
                .Include(c => c.Pais)
                .ToListAsync();
        }

        public async Task<Paciente> GetById(int id)
        {
            return await _context.Pacientes
                .Include(p => p.Cidade)
                .Include(e => e.Estado)
                .Include(c => c.Pais)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public void Insert(Paciente obj)
        {
            _context.Pacientes.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Paciente obj)
        {
            _context.Pacientes.Update(obj);
        }
    }
}
