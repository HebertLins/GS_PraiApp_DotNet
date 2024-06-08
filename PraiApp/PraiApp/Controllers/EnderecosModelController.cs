using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PraiApp.Models;
using PraiApp.Repository;

namespace PraiApp.Controllers
{
    public class EnderecosModelController : Controller
    {
        private readonly PraiAppContext _context;

        public EnderecosModelController(PraiAppContext context)
        {
            _context = context;
        }

        // GET: EnderecosModel
        public async Task<IActionResult> Index()
        {
            return _context.EnderecoModel != null ?
                View(await _context.EnderecoModel.ToListAsync()) :
                Problem("Entity set 'PraiAppContext.EnderecoModel' is null.");
        }

        // GET: EnderecosModel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EnderecoModel == null)
            {
                return NotFound();
            }

            var enderecoModel = await _context.EnderecoModel
                .FirstOrDefaultAsync(m => m.IdEndereco == id);
            if (enderecoModel == null)
            {
                return NotFound();
            }

            return View(enderecoModel);
        }

        // GET: EnderecosModel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EnderecosModel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEndereco,RuaEndereco,CidadeEndereco,UfEndereco,CepEndereco")] EnderecoModel enderecoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enderecoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enderecoModel);
        }

        // GET: EnderecosModel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EnderecoModel == null)
            {
                return NotFound();
            }

            var enderecoModel = await _context.EnderecoModel.FindAsync(id);
            if (enderecoModel == null)
            {
                return NotFound();
            }
            return View(enderecoModel);
        }

        // POST: EnderecosModel/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEndereco,RuaEndereco,CidadeEndereco,UfEndereco,CepEndereco")] EnderecoModel enderecoModel)
        {
            if (id != enderecoModel.IdEndereco)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enderecoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnderecoModelExists(enderecoModel.IdEndereco))
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
            return View(enderecoModel);
        }

        // GET: EnderecosModel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EnderecoModel == null)
            {
                return NotFound();
            }

            var enderecoModel = await _context.EnderecoModel
                .FirstOrDefaultAsync(m => m.IdEndereco == id);
            if (enderecoModel == null)
            {
                return NotFound();
            }

            return View(enderecoModel);
        }

        // POST: EnderecosModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EnderecoModel == null)
            {
                return Problem("Entity set 'PraiAppContext.EnderecoModel' is null.");
            }
            var enderecoModel = await _context.EnderecoModel.FindAsync(id);
            if (enderecoModel != null)
            {
                _context.EnderecoModel.Remove(enderecoModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnderecoModelExists(int id)
        {
            return (_context.EnderecoModel?.Any(e => e.IdEndereco == id)).GetValueOrDefault();
        }
    }
}
