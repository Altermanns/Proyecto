using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class TransaccionsController : Controller
    {
        private readonly ProyectoContext _context;

        public TransaccionsController(ProyectoContext context)
        {
            _context = context;
        }

        // GET: Transaccions
        public async Task<IActionResult> Index()
        {
            var proyectoContext = _context.Transaccion.Include(t => t.Comprador).Include(t => t.Vehiculo).Include(t => t.Vendedor);
            return View(await proyectoContext.ToListAsync());
        }

        // GET: Transaccions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaccion = await _context.Transaccion
                .Include(t => t.Comprador)
                .Include(t => t.Vehiculo)
                .Include(t => t.Vendedor)
                .FirstOrDefaultAsync(m => m.IdTransaccion == id);
            if (transaccion == null)
            {
                return NotFound();
            }

            return View(transaccion);
        }

        // GET: Transaccions/Create
        public IActionResult Create()
        {
            ViewData["CompradorId"] = new SelectList(_context.Usuario, "Id", "Correo");
            ViewData["VehiculoId"] = new SelectList(_context.Vehiculo, "IdVehiculo", "Marca");
            ViewData["VendedorId"] = new SelectList(_context.Usuario, "Id", "Correo");
            return View();
        }

        // POST: Transaccions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTransaccion,VehiculoId,CompradorId,VendedorId,FechaTransaccion,PrecioVenta")] Transaccion transaccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompradorId"] = new SelectList(_context.Usuario, "Id", "Correo", transaccion.CompradorId);
            ViewData["VehiculoId"] = new SelectList(_context.Vehiculo, "IdVehiculo", "Marca", transaccion.VehiculoId);
            ViewData["VendedorId"] = new SelectList(_context.Usuario, "Id", "Correo", transaccion.VendedorId);
            return View(transaccion);
        }

        // GET: Transaccions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaccion = await _context.Transaccion.FindAsync(id);
            if (transaccion == null)
            {
                return NotFound();
            }
            ViewData["CompradorId"] = new SelectList(_context.Usuario, "Id", "Correo", transaccion.CompradorId);
            ViewData["VehiculoId"] = new SelectList(_context.Vehiculo, "IdVehiculo", "Marca", transaccion.VehiculoId);
            ViewData["VendedorId"] = new SelectList(_context.Usuario, "Id", "Correo", transaccion.VendedorId);
            return View(transaccion);
        }

        // POST: Transaccions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTransaccion,VehiculoId,CompradorId,VendedorId,FechaTransaccion,PrecioVenta")] Transaccion transaccion)
        {
            if (id != transaccion.IdTransaccion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransaccionExists(transaccion.IdTransaccion))
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
            ViewData["CompradorId"] = new SelectList(_context.Usuario, "Id", "Correo", transaccion.CompradorId);
            ViewData["VehiculoId"] = new SelectList(_context.Vehiculo, "IdVehiculo", "Marca", transaccion.VehiculoId);
            ViewData["VendedorId"] = new SelectList(_context.Usuario, "Id", "Correo", transaccion.VendedorId);
            return View(transaccion);
        }

        // GET: Transaccions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaccion = await _context.Transaccion
                .Include(t => t.Comprador)
                .Include(t => t.Vehiculo)
                .Include(t => t.Vendedor)
                .FirstOrDefaultAsync(m => m.IdTransaccion == id);
            if (transaccion == null)
            {
                return NotFound();
            }

            return View(transaccion);
        }

        // POST: Transaccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaccion = await _context.Transaccion.FindAsync(id);
            if (transaccion != null)
            {
                _context.Transaccion.Remove(transaccion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransaccionExists(int id)
        {
            return _context.Transaccion.Any(e => e.IdTransaccion == id);
        }
    }
}
