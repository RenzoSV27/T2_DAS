using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using T2_Salazar_Renzo.Datos;
using T2_Salazar_Renzo.Models;
using Microsoft.EntityFrameworkCore;

namespace T2_Salazar_Renzo.Controllers
{
    public class DistribuidorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DistribuidorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Distribuidor
        public async Task<IActionResult> Index()
        {
            var distribuidores = await _context.Distribuidores.ToListAsync();
            return View(distribuidores);
        }

        // GET: Distribuidor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distribuidor = await _context.Distribuidores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (distribuidor == null)
            {
                return NotFound();
            }

            return View(distribuidor);
        }

        // GET: Distribuidor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Distribuidor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreDistribuidor,RazonSocial,Telefono,AnioInicioOperacion,Contacto")] Distribuidor distribuidor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(distribuidor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(distribuidor);
        }

        // GET: Distribuidor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distribuidor = await _context.Distribuidores.FindAsync(id);
            if (distribuidor == null)
            {
                return NotFound();
            }
            return View(distribuidor);
        }

        // POST: Distribuidor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreDistribuidor,RazonSocial,Telefono,AnioInicioOperacion,Contacto")] Distribuidor distribuidor)
        {
            if (id != distribuidor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(distribuidor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DistribuidorExists(distribuidor.Id))
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
            return View(distribuidor);
        }

        // GET: Distribuidor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distribuidor = await _context.Distribuidores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (distribuidor == null)
            {
                return NotFound();
            }

            return View(distribuidor);
        }

        // POST: Distribuidor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var distribuidor = await _context.Distribuidores.FindAsync(id);
            _context.Distribuidores.Remove(distribuidor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DistribuidorExists(int id)
        {
            return _context.Distribuidores.Any(e => e.Id == id);
        }
        public IActionResult Tabs()
        {
            return View();
        }

    }
}
