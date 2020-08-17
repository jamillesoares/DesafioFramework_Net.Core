using System.Threading.Tasks;
using Framework.Desafio.Model.Entidade;
using Framework.Desafio.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace WebApplication.Controllers
{
    [Authorize]
    public class PaisController : Controller
    {        
        private readonly IPaisRepositorio _paisRepositorio;

        public PaisController(IPaisRepositorio paisRepositorio)
        {
            _paisRepositorio = paisRepositorio;           
        }

        // GET: Pais 
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var paises = await _paisRepositorio.GetAll();
            return View(paises);
        }

        // GET: Pais/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pais = await _paisRepositorio.GetById(id.Value);
                
            if (pais == null)
            {
                return NotFound();
            }

            return View(pais);
        }

        // GET: Pais/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Descricao")] Pais pais)
        {
            if (ModelState.IsValid)
            {
                _paisRepositorio.Insert(pais);
                //_paisRepositorio.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(pais);
        }

        // GET: Pais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pais = await _paisRepositorio.GetById(id.Value);
            if (pais == null)
            {
                return NotFound();
            }
            return View(pais);
        }

        // POST: Pais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Descricao")] Pais pais)
        {
            if (id != pais.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _paisRepositorio.Update(pais);
                    //_paisRepositorio.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaisExists(pais.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pais);
        }

        // GET: Pais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pais = await _paisRepositorio.GetById(id.Value);
            if (pais == null)
            {
                return NotFound();
            }

            return View(pais);
        }

        // POST: Pais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pais = await _paisRepositorio.GetById(id);
            _paisRepositorio.Delete(pais);
            //_paisRepositorio.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool PaisExists(int id)
        {
            return _paisRepositorio.Find(id);
        }
    }
}
