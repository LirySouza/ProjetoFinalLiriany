using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoFinalLiriany.Models;

namespace ProjetoFinalLiriany.Controllers
{
    public class ColaboradorController : Controller
    {
        private readonly Contexto _context;

        public ColaboradorController(Contexto context)
        {
            _context = context;
        }

        // GET: Colaborador
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Colaborador.Include(c => c.Cidade).Include(c => c.TipoColaborador);
            return View(await contexto.ToListAsync());
        }

        // GET: Colaborador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Colaborador == null)
            {
                return NotFound();
            }

            var colaborador = await _context.Colaborador
                .Include(c => c.Cidade)
                .Include(c => c.TipoColaborador)
                .FirstOrDefaultAsync(m => m.ColaboradorId == id);
            if (colaborador == null)
            {
                return NotFound();
            }

            return View(colaborador);
        }

        // GET: Colaborador/Create
        public IActionResult Create()
        {
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "CidadeId", "CidadeNome");
            ViewData["TipoColaboradorId"] = new SelectList(_context.TipoColaborador, "TipoColaboradorId", "TipoColaboradorNome");
            return View();
        }

        // POST: Colaborador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ColaboradorId,ColaboradorNome,ColaboradorCpf,ColaboradorSexo,ColaboradorTelefone,CidadeId,TipoColaboradorId")] Colaborador colaborador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colaborador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "CidadeId", "CidadeNome", colaborador.CidadeId);
            ViewData["TipoColaboradorId"] = new SelectList(_context.TipoColaborador, "TipoColaboradorId", "TipoColaboradorNome", colaborador.TipoColaboradorId);
            return View(colaborador);
        }

        // GET: Colaborador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Colaborador == null)
            {
                return NotFound();
            }

            var colaborador = await _context.Colaborador.FindAsync(id);
            if (colaborador == null)
            {
                return NotFound();
            }
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "CidadeId", "CidadeNome", colaborador.CidadeId);
            ViewData["TipoColaboradorId"] = new SelectList(_context.TipoColaborador, "TipoColaboradorId", "TipoColaboradorNome", colaborador.TipoColaboradorId);
            return View(colaborador);
        }

        // POST: Colaborador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Colaboradorid, [Bind("ColaboradorId,ColaboradorNome,ColaboradorCpf,ColaboradorSexo,ColaboradorTelefone,CidadeId,TipoColaboradorId")] Colaborador colaborador)
        {
            if (Colaboradorid != colaborador.ColaboradorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colaborador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColaboradorExists(colaborador.ColaboradorId))
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
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "CidadeId", "CidadeNome", colaborador.CidadeId);
            ViewData["TipoColaboradorId"] = new SelectList(_context.TipoColaborador, "TipoColaboradorId", "TipoColaboradorNome", colaborador.TipoColaboradorId);
            return View(colaborador);
        }

        // GET: Colaborador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Colaborador == null)
            {
                return NotFound();
            }

            var colaborador = await _context.Colaborador
                .Include(c => c.Cidade)
                .Include(c => c.TipoColaborador)
                .FirstOrDefaultAsync(m => m.ColaboradorId == id);
            if (colaborador == null)
            {
                return NotFound();
            }

            return View(colaborador);
        }

        // POST: Colaborador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int Colaboradorid)
        {
            if (_context.Colaborador == null)
            {
                return Problem("Entity set 'Contexto.Colaborador'  is null.");
            }
            var colaborador = await _context.Colaborador.FindAsync(Colaboradorid);
            if (colaborador != null)
            {
                _context.Colaborador.Remove(colaborador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColaboradorExists(int id)
        {
          return (_context.Colaborador?.Any(e => e.ColaboradorId == id)).GetValueOrDefault();
        }
    }
}
