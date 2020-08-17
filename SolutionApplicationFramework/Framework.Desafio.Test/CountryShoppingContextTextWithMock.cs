using Framework.Desafio.Model.Entidade;
using Framework.Desafio.Repository;
using Framework.Desafio.Repository.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Desafio.Test
{
    [TestClass]
    public class CountryShoppingContextTextWithMock
    {
        private Mock<DbSet<Pais>> _dbSet = new Mock<DbSet<Pais>>();
        private Mock<AppDbContext> _context = new Mock<AppDbContext>();
        

        [TestMethod]
        public void ShouldCreateNewCountry()
        {
            _dbSet = new Mock<DbSet<Pais>>();
            _context = new Mock<AppDbContext>();
            _context.Setup(x => x.Paises).Returns(_dbSet.Object);

            PaisRepositorio _repository = new PaisRepositorio(_context.Object);

            Pais pais = new Pais()
            {
                Id = 1,
                Descricao = "Alemanha"
            };

            _repository.Insert(pais);

            _dbSet.Verify(p => p.Add(It.IsAny<Pais>()), Times.Once());
            _context.Verify(p => p.SaveChanges(), Times.Once());

        }

        //public void ShouldGetAllCountry()
        //{
        //    List<Pais> pais = new List<Pais>()
        //    {
        //        new Pais(){ Id = 1, Descricao = "Brasil"},
        //        new Pais(){ Id = 2, Descricao = "Alemanha"},
        //        new Pais(){ Id = 3, Descricao = "Inglaterra"},
        //        new Pais(){ Id = 4, Descricao = "Itália"}
        //    };

        //    _dbSet = new Mock<DbSet<Pais>>();

        //    _dbSet.As<List<Pais>>().Setup(x => x.GetEnumerator()).Returns(_dbSet.Object);

            
        //    _context = new Mock<AppDbContext>();
        //    _context.Setup(x => x.Paises).Returns(_dbSet.Object);

        //    PaisRepositorio _repository = new PaisRepositorio(_context.Object);

        //    Task<List<Pais>> listaPais = _repository.GetAll();

        //    Assert.IsNotNull(listaPais);
        //    Assert.IsTrue(listaPais.Result.Count() > 0);

        //}
    }
}
