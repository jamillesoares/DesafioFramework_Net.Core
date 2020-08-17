using System.Threading.Tasks;
using Framework.Desafio.Model.Entidade;
using Framework.Desafio.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class PacientesController : Controller
    {
        private readonly IPaisRepositorio _paisRepositorio;
        private readonly IEstadoRepositorio _estadoRepositorio;
        private readonly ICidadeRepositorio _cidadeRepositorio;
        private readonly IPacienteRepositorio _pacienteRepositorio;

        public PacientesController(IPaisRepositorio paisRepositorio,
                                   IEstadoRepositorio estadoRepositorio,
                                   ICidadeRepositorio cidadeRepositorio,
                                  IPacienteRepositorio pacienteRepositorio)
        {

            _paisRepositorio = paisRepositorio;
            _estadoRepositorio = estadoRepositorio;
            _cidadeRepositorio = cidadeRepositorio;
            _pacienteRepositorio = pacienteRepositorio;
        }

        private async Task<bool> DropDownList()
        {
            var cidades = await _cidadeRepositorio.GetAll();
            ViewData["CidadeId"] = new SelectList(cidades, "Id", "Descricao");
            var estados = await _estadoRepositorio.GetAll();
            ViewData["EstadoId"] = new SelectList(estados, "Id", "Descricao");
            var paises = await _paisRepositorio.GetAll();
            ViewData["PaisId"] = new SelectList(paises, "Id", "Descricao");

            return true;
        }

        
        public async Task<IActionResult> Index()
        {
            var pacientes = await _pacienteRepositorio.GetAll();
            return View(pacientes);
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _pacienteRepositorio.GetById(id.Value);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // GET: Pacientes/Create
        public async Task<IActionResult> Create()
        {
            await DropDownList();

            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,CPF,PaisId,EstadoId,CidadeId")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _pacienteRepositorio.Insert(paciente);
                _pacienteRepositorio.Save();
                return RedirectToAction(nameof(Index));
            }

            await DropDownList();

            return View(paciente);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _pacienteRepositorio.GetById(id.Value);
            if (paciente == null)
            {
                return NotFound();
            }

            await DropDownList();

            return View(paciente);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,CPF,PaisId,EstadoId,CidadeId")] Paciente paciente)
        {
            if (id != paciente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _pacienteRepositorio.Update(paciente);
                    _pacienteRepositorio.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacienteExists(paciente.Id))
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

            await DropDownList();

            return View(paciente);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _pacienteRepositorio.GetById(id.Value);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paciente = await _pacienteRepositorio.GetById(id);
            _pacienteRepositorio.Delete(paciente);
            _pacienteRepositorio.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool PacienteExists(int id)
        {
            return _pacienteRepositorio.Find(id);
        }

        [HttpPost]
        public async Task<ActionResult> CarregaEstadoPais(int paisId)
        {
            var estados = await _estadoRepositorio.GetEstadoPais(paisId);
            ViewData["EstadoId"] = new SelectList(estados, "Id", "Descricao");
            return Json(ViewData["EstadoId"]);
        }

        [HttpPost]
        public async Task<ActionResult> CarregaCidadeEstado(int estadoId)
        {
            var estados = await _cidadeRepositorio.GetCidadeEstado(estadoId);
            ViewData["CidadeId"] = new SelectList(estados, "Id", "Descricao");
            return Json(ViewData["CidadeId"]);
        }
    }
}
