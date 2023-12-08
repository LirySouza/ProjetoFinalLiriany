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
    public class ProcedimentoRealizacaoController : Controller
    {
        private readonly Contexto _context;

        public ProcedimentoRealizacaoController(Contexto context)
        {
            _context = context;
        }

        // GET: ProcedimentoRealizacao
        public async Task<IActionResult> Index( string pesquisa)
        {
            // var contexto = _context.ProcedimentoRealizacao.Include(p => p.Cliente).Include(p => p.Colaborador).Include(p => p.LocalRealizacao).Include(p => p.Procedimento);
            // return View(await contexto.ToListAsync());
            if (pesquisa == null)
            {
                return _context.ProcedimentoRealizacao.Include(d => d.Cliente).Include(d => d.Procedimento).Include(r => r.Colaborador).Include(r => r.LocalRealizacao) != null ?
                          View(await _context.ProcedimentoRealizacao.Include(d => d.Cliente).Include(d => d.Procedimento).Include(r => r.Colaborador).Include(r => r.LocalRealizacao).ToListAsync()) :
                          Problem("Entity set 'Contexto.Exame'  is null.");
            }
            else
            {
                var resultado =
                    _context.ProcedimentoRealizacao.Include(d => d.Cliente).Include(d => d.Procedimento).Include(r => r.Colaborador).Include(r => r.LocalRealizacao)
                    .Where(x => x.Cliente.ClienteNome.Contains(pesquisa));

                return View(resultado);
            }
        }


        // GET: ProcedimentoRealizacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProcedimentoRealizacao == null)
            {
                return NotFound();
            }

            var procedimentoRealizacao = await _context.ProcedimentoRealizacao
                .Include(p => p.Cliente)
                .Include(p => p.Colaborador)
                .Include(p => p.LocalRealizacao)
                .Include(p => p.Procedimento)
                .FirstOrDefaultAsync(m => m.ProcedimentoRealizacaoId == id);
            if (procedimentoRealizacao == null)
            {
                return NotFound();
            }

            return View(procedimentoRealizacao);
        }

        // GET: ProcedimentoRealizacao/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "ClienteNome");
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "ColaboradorId", "ColaboradorNome");
            ViewData["LocalRealizacaoId"] = new SelectList(_context.LocalRealizacao, "LocalRealizacaoId", "LocalRealizacaoNome");
            ViewData["ProcedimentoId"] = new SelectList(_context.Procedimento, "ProcedimentoId", "ProcedimentoNome");
            return View();
        }

        // POST: ProcedimentoRealizacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProcedimentoRealizacaoId,ClienteId,ProcedimentoId,ColaboradorId,LocalRealizacaoId,DataRealizacao,ObservacaoRealizacao")] ProcedimentoRealizacao procedimentoRealizacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(procedimentoRealizacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "ClienteNome", procedimentoRealizacao.ClienteId);
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "ColaboradorId", "ColaboradorNome", procedimentoRealizacao.ColaboradorId);
            ViewData["LocalRealizacaoId"] = new SelectList(_context.LocalRealizacao, "LocalRealizacaoId", "LocalRealizacaoNome", procedimentoRealizacao.LocalRealizacaoId);
            ViewData["ProcedimentoId"] = new SelectList(_context.Procedimento, "ProcedimentoId", "ProcedimentoNome", procedimentoRealizacao.ProcedimentoId);
            return View(procedimentoRealizacao);
        }

        // GET: ProcedimentoRealizacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProcedimentoRealizacao == null)
            {
                return NotFound();
            }

            var procedimentoRealizacao = await _context.ProcedimentoRealizacao.FindAsync(id);
            if (procedimentoRealizacao == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "ClienteNome", procedimentoRealizacao.ClienteId);
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "ColaboradorId", "ColaboradorNome", procedimentoRealizacao.ColaboradorId);
            ViewData["LocalRealizacaoId"] = new SelectList(_context.LocalRealizacao, "LocalRealizacaoId", "LocalRealizacaoNome", procedimentoRealizacao.LocalRealizacaoId);
            ViewData["ProcedimentoId"] = new SelectList(_context.Procedimento, "ProcedimentoId", "ProcedimentoNome", procedimentoRealizacao.ProcedimentoId);
            return View(procedimentoRealizacao);
        }

        // POST: ProcedimentoRealizacao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int ProcedimentoRealizacaoid, [Bind("ProcedimentoRealizacaoId,ClienteId,ProcedimentoId,ColaboradorId,LocalRealizacaoId,DataRealizacao,ObservacaoRealizacao")] ProcedimentoRealizacao procedimentoRealizacao)
        {
            if (ProcedimentoRealizacaoid != procedimentoRealizacao.ProcedimentoRealizacaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procedimentoRealizacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcedimentoRealizacaoExists(procedimentoRealizacao.ProcedimentoRealizacaoId))
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "ClienteNome", procedimentoRealizacao.ClienteId);
            ViewData["ColaboradorId"] = new SelectList(_context.Colaborador, "ColaboradorId", "ColaboradorNome", procedimentoRealizacao.ColaboradorId);
            ViewData["LocalRealizacaoId"] = new SelectList(_context.LocalRealizacao, "LocalRealizacaoId", "LocalRealizacaoNome", procedimentoRealizacao.LocalRealizacaoId);
            ViewData["ProcedimentoId"] = new SelectList(_context.Procedimento, "ProcedimentoId", "ProcedimentoNome", procedimentoRealizacao.ProcedimentoId);
            return View(procedimentoRealizacao);
        }

        // GET: ProcedimentoRealizacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProcedimentoRealizacao == null)
            {
                return NotFound();
            }

            var procedimentoRealizacao = await _context.ProcedimentoRealizacao
                .Include(p => p.Cliente)
                .Include(p => p.Colaborador)
                .Include(p => p.LocalRealizacao)
                .Include(p => p.Procedimento)
                .FirstOrDefaultAsync(m => m.ProcedimentoRealizacaoId == id);
            if (procedimentoRealizacao == null)
            {
                return NotFound();
            }

            return View(procedimentoRealizacao);
        }

        // POST: ProcedimentoRealizacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int ProcedimentoRealizacaoid)
        {
            if (_context.ProcedimentoRealizacao == null)
            {
                return Problem("Entity set 'Contexto.ProcedimentoRealizacao'  is null.");
            }
            var procedimentoRealizacao = await _context.ProcedimentoRealizacao.FindAsync(ProcedimentoRealizacaoid);
            if (procedimentoRealizacao != null)
            {
                _context.ProcedimentoRealizacao.Remove(procedimentoRealizacao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcedimentoRealizacaoExists(int id)
        {
          return (_context.ProcedimentoRealizacao?.Any(e => e.ProcedimentoRealizacaoId == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> Imprimir(int? id)
        {
            if (id == null || _context.ProcedimentoRealizacao == null)
            {
                return NotFound();
            }

            var resultado = await _context.ProcedimentoRealizacao
                .Include(r => r.Cliente)
                .Include(r => r.Procedimento)
                .Include(r => r.Colaborador)
                .Include(r => r.Colaborador.TipoColaborador)
                .Include(r => r.LocalRealizacao)
                .FirstOrDefaultAsync(m => m.ProcedimentoRealizacaoId == id);

            if (resultado == null)
            {
                return NotFound();
            }
            return View(resultado);
        }
    }
}
