using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Social_Solutions.Data;
using Social_Solutions.Models;

namespace Social_Solutions.Controllers
{
    public class ImoveisController : Controller
    {
        private readonly Social_SolutionsContext _context;

        public ImoveisController(Social_SolutionsContext context)
        {
            _context = context;
        }

        // GET: Imoveis
        public async Task<IActionResult> Index()
        {
              return _context.Imoveis != null ? 
                          View(await _context.Imoveis.ToListAsync()) :
                          Problem("Entity set 'Social_SolutionsContext.Imoveis'  is null.");
        }

        // GET: Imoveis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Imoveis == null)
            {
                return NotFound();
            }

            var imoveis = await _context.Imoveis
                .FirstOrDefaultAsync(m => m.Id_Imovel == id);
            if (imoveis == null)
            {
                return NotFound();
            }

            return View(imoveis);
        }

        // GET: Imoveis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Imoveis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Imovel,Tipo_Negocio,Valor,Descricao,Imovel_Ativo,Id_Cliente")] Imoveis imoveis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(imoveis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(imoveis);
        }

        // GET: Imoveis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Imoveis == null)
            {
                return NotFound();
            }

            var imoveis = await _context.Imoveis.FindAsync(id);
            if (imoveis == null)
            {
                return NotFound();
            }
            return View(imoveis);
        }

        // POST: Imoveis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Imovel,Tipo_Negocio,Valor,Descricao,Imovel_Ativo,Id_Cliente")] Imoveis imoveis)
        {
            if (id != imoveis.Id_Imovel)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imoveis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImoveisExists(imoveis.Id_Imovel))
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
            return View(imoveis);
        }

        // GET: Imoveis/Delete/5
        public async Task<IActionResult> Delete(int? id, int? idcli)
        {
            if (id == null || _context.Imoveis == null)
            {
                return NotFound();
            }

            if (idcli == null)
            {
                return NotFound();
            }

            var imoveis = await _context.Imoveis
                .FirstOrDefaultAsync(m => m.Id_Imovel == id);
            if (imoveis == null)
            {
                return NotFound();
            }

            return View(imoveis);
        }

        // POST: Imoveis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Imoveis == null)
            {
                return Problem("Entity set 'Social_SolutionsContext.Imoveis'  is null.");
            }
            var imoveis = await _context.Imoveis.FindAsync(id);
            if (imoveis != null)
            {
                _context.Imoveis.Remove(imoveis);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImoveisExists(int id)
        {
          return (_context.Imoveis?.Any(e => e.Id_Imovel == id)).GetValueOrDefault();
        }
    }
}
