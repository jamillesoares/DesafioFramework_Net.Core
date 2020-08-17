using Framework.Desafio.Model.Entidade;
using Framework.Desafio.Repository.Contexto;
using Framework.Desafio.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Desafio.Repository
{
    public class CidadeRepositorio : ICidadeRepositorio
    {
        private AppDbContext _context;

        public CidadeRepositorio(AppDbContext context)
        {
            _context = context;
        }
        public void Delete(Cidade obj)
        {
            _context.Cidades.Remove(obj);
        }

        public bool Find(int id)
        {
            return _context.Cidades.Any(c => c.Id == id);
        }

        public async Task<List<Cidade>> GetAll()
        {
            return await _context.Cidades
                .Include(e => e.Estado)
                .ToListAsync();
        }

        public async Task<List<Cidade>> GetCidadeEstado(int estadoId)
        {
            return await _context.Cidades
                .Include(e => e.Estado)
                .Where(m => m.EstadoId == estadoId)
                .ToListAsync();
        }
        

        public async Task<Cidade> GetById(int id)
        {
            return await _context.Cidades
                .Include(e => e.Estado)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Insert(Cidade obj)
        {
            _context.Cidades.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Cidade obj)
        {
            _context.Cidades.Update(obj);
        }
    }
}
