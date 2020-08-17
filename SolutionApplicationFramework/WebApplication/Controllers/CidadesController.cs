using System.Threading.Tasks;
using Framework.Desafio.Model.Entidade;
using Framework.Desafio.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class CidadesController : Controller
    {
        private readonly IEstadoRepositorio _estadoRepositorio;
        private readonly ICidadeRepositorio _cidadeRepositorio;

        public CidadesController(IEstadoRepositorio estadoRepositorio,
                                 ICidadeRepositorio cidadeRepositorio)
        {
            _estadoRepositorio = estadoRepositorio;
            _cidadeRepositorio = cidadeRepositorio;
        }

        // GET: Cidades
        public async Task<IActionResult> Index()
        {
            var cidades = await _cidadeRepositorio.GetAll();
            return View(cidades);
        }

        // GET: Cidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidade = await _cidadeRepositorio.GetById(id.Value);
            if (cidade == null)
            {
                return NotFound();
            }

            return View(cidade);
        }

        // GET: Cidades/Create
        public async Task<IActionResult> Create()
        {
            var estados = await _estadoRepositorio.GetAll();
            ViewData["EstadoId"] = new SelectList(estados, "Id", "Descricao");
            return View();
        }

        // POST: Cidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,EstadoId")] Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                _cidadeRepositorio.Insert(cidade);
                _cidadeRepositorio.Save();
                return RedirectToAction(nameof(Index));
            }
            var estados = await _estadoRepositorio.GetAll();
            ViewData["EstadoId"] = new SelectList(estados, "Id", "Descricao", cidade.EstadoId);
            return View(cidade);
        }

        // GET: Cidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidade = await _cidadeRepositorio.GetById(id.Value);
            if (cidade == null)
            {
                return NotFound();
            }
            var estados = await _estadoRepositorio.GetAll();
            ViewData["EstadoId"] = new SelectList(estados, "Id", "Descricao", cidade.EstadoId);
            return View(cidade);
        }

        // POST: Cidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,EstadoId")] Cidade cidade)
        {
            if (id != cidade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _cidadeRepositorio.Update(cidade);
                    _cidadeRepositorio.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CidadeExists(cidade.Id))
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
            var estados = await _estadoRepositorio.GetAll();
            ViewData["EstadoId"] = new SelectList(estados, "Id", "Descricao", cidade.EstadoId);
            return View(cidade);
        }

        // GET: Cidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidade = await _cidadeRepositorio.GetById(id.Value);
            if (cidade == null)
            {
                return NotFound();
            }

            return View(cidade);
        }

        // POST: Cidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cidade = await _cidadeRepositorio.GetById(id);
            _cidadeRepositorio.Delete(cidade);
            _cidadeRepositorio.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool CidadeExists(int id)
        {
            return _cidadeRepositorio.Find(id);
        }
    }
}
