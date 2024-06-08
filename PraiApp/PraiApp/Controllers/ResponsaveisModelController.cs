using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PraiApp.Models;
using PraiApp.Repository;

namespace PraiApp.Controllers
{
    public class ResponsaveisModelController : Controller
    {
        private readonly PraiAppContext _context;

        public ResponsaveisModelController(PraiAppContext context)
        {
            _context = context;
        }

        // GET: ResponsaveisModel
        public async Task<IActionResult> Index()
        {
              return _context.ResponsavelModel != null ? 
                          View(await _context.ResponsavelModel.ToListAsync()) :
                          Problem("Entity set 'PraiAppContext.ResponsavelModel'  is null.");
        }

        // GET: ResponsaveisModel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ResponsavelModel == null)
            {
                return NotFound();
            }

            var responsavelModel = await _context.ResponsavelModel
                .FirstOrDefaultAsync(m => m.IdResponsavel == id);
            if (responsavelModel == null)
            {
                return NotFound();
            }

            return View(responsavelModel);
        }

        // GET: ResponsaveisModel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResponsaveisModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdResponsavel,NomeResponsavel,CpfResponsavel")] ResponsavelModel responsavelModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(responsavelModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(responsavelModel);
        }

        // GET: ResponsaveisModel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ResponsavelModel == null)
            {
                return NotFound();
            }

            var responsavelModel = await _context.ResponsavelModel.FindAsync(id);
            if (responsavelModel == null)
            {
                return NotFound();
            }
            return View(responsavelModel);
        }

        // POST: ResponsaveisModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdResponsavel,NomeResponsavel,CpfResponsavel")] ResponsavelModel responsavelModel)
        {
            if (id != responsavelModel.IdResponsavel)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(responsavelModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResponsavelModelExists(responsavelModel.IdResponsavel))
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
            return View(responsavelModel);
        }

        // GET: ResponsaveisModel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ResponsavelModel == null)
            {
                return NotFound();
            }

            var responsavelModel = await _context.ResponsavelModel
                .FirstOrDefaultAsync(m => m.IdResponsavel == id);
            if (responsavelModel == null)
            {
                return NotFound();
            }

            return View(responsavelModel);
        }

        // POST: ResponsaveisModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ResponsavelModel == null)
            {
                return Problem("Entity set 'PraiAppContext.ResponsavelModel'  is null.");
            }
            var responsavelModel = await _context.ResponsavelModel.FindAsync(id);
            if (responsavelModel != null)
            {
                _context.ResponsavelModel.Remove(responsavelModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResponsavelModelExists(int id)
        {
          return (_context.ResponsavelModel?.Any(e => e.IdResponsavel == id)).GetValueOrDefault();
        }
    }
}
