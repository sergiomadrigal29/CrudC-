using System.Diagnostics;
using CrudNetMVC.Datos;
using CrudNetMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudNetMVC.Controllers
{
    public class InicioController : Controller
    {
        private readonly ApplicationDbContext _context; 

        public InicioController(ApplicationDbContext contexto)
        {
            _context = contexto;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contacto.ToListAsync());
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contacto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(contacto);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            var contacto = await _context.Contacto.FindAsync(id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                _context.Contacto.Update(contacto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(contacto);
        }

        [HttpGet]
        public async Task<IActionResult> Detalles(int? id)
        {
            var contacto = await _context.Contacto.FindAsync(id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }

        [HttpGet]
        public async Task<IActionResult> Borrar(int? id)
        {
            var contacto = await _context.Contacto.FindAsync(id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }

        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarContacto(int? id)
        {
            var contacto = await _context.Contacto.FindAsync(id);
            if (contacto != null)
            {
                _context.Contacto.Remove(contacto);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
