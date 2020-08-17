using System.Threading.Tasks;
using Framework.Desafio.Model.Entidade;
using Framework.Desafio.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class EstadosController : Controller
    {
        private readonly IEstadoRepositorio _estadoRepositorio;
        private readonly IPaisRepositorio _paisRepositorio;

        public EstadosController(IEstadoRepositorio estadoRepositorio,
                                 IPaisRepositorio paisRepositorio)
        {
            _estadoRepositorio = estadoRepositorio;
            _paisRepositorio = paisRepositorio;
        }

        // GET: Estados
        public async Task<IActionResult> Index()
        {
            var estados = await _estadoRepositorio.GetAll();
            return View(estados);
        }

        // GET: Estados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estado = await _estadoRepositorio.GetById(id.Value);
            if (estado == null)
            {
                return NotFound();
            }

            return View(estado);
        }

        // GET: Estados/Create
        public async Task<IActionResult> Create()
        {
            var paises = await _paisRepositorio.GetAll();
            //ViewData["PaisId"] = new SelectList(_context.Paises, "Id", "Id");
            ViewData["PaisId"] = new SelectList(paises, "Id", "Descricao");
            return View();
        }

        // POST: Estados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,PaisId")] Estado estado)
        {
            if (ModelState.IsValid)
            {
                _estadoRepositorio.Insert(estado);
                _estadoRepositorio.Save();
                return RedirectToAction(nameof(Index));
            }
            var paises = await _paisRepositorio.GetAll();
            ViewData["PaisId"] = new SelectList(paises, "Id", "Descricao", estado.PaisId);
            return View(estado);
        }

        // GET: Estados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estado = await _estadoRepositorio.GetById(id.Value);
            if (estado == null)
            {
                return NotFound();
            }
            var paises = await _paisRepositorio.GetAll();
            ViewData["PaisId"] = new SelectList(paises, "Id", "Descricao", estado.PaisId);
            return View(estado);
        }

        // POST: Estados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,PaisId")] Estado estado)
        {
            if (id != estado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _estadoRepositorio.Update(estado);
                    _estadoRepositorio.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoExists(estado.Id))
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
            var paises = await _paisRepositorio.GetAll();
            ViewData["PaisId"] = new SelectList(paises, "Id", "Descricao", estado.PaisId);
            return View(estado);
        }

        // GET: Estados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estado = await _estadoRepositorio.GetById(id.Value);
            if (estado == null)
            {
                return NotFound();
            }

            return View(estado);
        }

        // POST: Estados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estado = await _estadoRepositorio.GetById(id);
            _estadoRepositorio.Delete(estado);
            _estadoRepositorio.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoExists(int id)
        {
            return _estadoRepositorio.Find(id);
        }       
    }
}
