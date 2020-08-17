using Framework.Desafio.Model.Entidade;
using Framework.Desafio.Repository.Contexto;
using Framework.Desafio.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Desafio.Repository
{
    public class EstadoRepositorio : IEstadoRepositorio
    {
        private AppDbContext _context;
        public EstadoRepositorio(AppDbContext context)
        {
            _context = context;
        }
        public void Delete(Estado obj)
        {
            _context.Estados.Remove(obj);
        }

        public bool Find(int id)
        {
            return _context.Estados.Any(x => x.Id == id);
        }

        public async Task<List<Estado>> GetAll()
        {
            return await _context.Estados
                .Include(e => e.Pais)
                .ToListAsync();
        }

        public async Task<Estado> GetById(int id)
        {
            return await _context.Estados
                .Include(e => e.Pais)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Estado>> GetEstadoPais(int idPais)
        {
            return await _context.Estados
                .Include(e => e.Pais)
                .Where(p => p.PaisId == idPais)
                .ToListAsync();
        }

        public void Insert(Estado obj)
        {
            _context.Estados.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Estado obj)
        {
            _context.Update(obj);
        }
    }
}
