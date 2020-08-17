using Framework.Desafio.Model.Entidade;
using Framework.Desafio.Repository.Contexto;
using Framework.Desafio.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Desafio.Repository
{
    public class PaisRepositorio : IPaisRepositorio
    {
        private AppDbContext _context;
        public PaisRepositorio(AppDbContext context)
        {
            _context = context;
        }
        public void Delete(Pais obj)
        {
            _context.Paises.Remove(obj);
            Save();
        }

        public bool Find(int id)
        {
            return _context.Paises.Any(e => e.Id == id);
        }

        public async Task<List<Pais>> GetAll()
        {
            return await _context.Paises.ToListAsync();
        }

        public async Task<Pais> GetById(int id)
        {
            return await _context.Paises
                 .FirstOrDefaultAsync(m => m.Id == id);
        }

        public void Insert(Pais obj)
        {
            _context.Paises.Add(obj);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Pais obj)
        {
            _context.Paises.Update(obj);
            Save();
        }
    }
}
