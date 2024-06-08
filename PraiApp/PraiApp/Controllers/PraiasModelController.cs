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
    public class PraiasModelController : Controller
    {
        private readonly PraiAppContext _context;
        private readonly IEnderecoRepository _enderecoRepository;

        public PraiasModelController(PraiAppContext context, IEnderecoRepository enderecoRepository)
        {
            _context = context;
            _enderecoRepository = enderecoRepository;
        }

        // GET: PraiasModel
        public async Task<IActionResult> Index()
        {
              return _context.PraiaModel != null ? 
                          View(await _context.PraiaModel.ToListAsync()) :
                          Problem("Entity set 'PraiAppContext.PraiaModel'  is null.");
        }

        // GET: PraiasModel/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.PraiaModel == null)
            {
                return NotFound();
            }

            var praiaModel = await _context.PraiaModel
                .FirstOrDefaultAsync(m => m.IdPraia == id);
            if (praiaModel == null)
            {
                return NotFound();
            }

            return View(praiaModel);
        }

        // GET: PraiasModel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PraiasModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPraia,NomePraia,DescPraia,TotLimpezaPraia,TotEstruturaPraia,TotSinalizacaoPraia,TotMonitoramentoPraia,TotPoluicaoPraia,TotConservacaoPraia,TotalPraia,IdEndereco")] PraiaModel praiaModel)
        {
            if (ModelState.IsValid)
            {
                var endereco = await _enderecoRepository.GetEnderecoByIdAsync(praiaModel.IdEndereco);
                

                if (endereco == null)
                {
                    ModelState.AddModelError("Endereco.IdEndereco", "Invalid Endereco ID.");
                    return View(praiaModel);
                }


                praiaModel.Endereco = endereco;


                _context.Add(praiaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(praiaModel);
        }

        // GET: PraiasModel/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.PraiaModel == null)
            {
                return NotFound();
            }

            var praiaModel = await _context.PraiaModel.FindAsync(id);
            if (praiaModel == null)
            {
                return NotFound();
            }
            return View(praiaModel);
        }

        // POST: PraiasModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdPraia,NomePraia,DescPraia,TotLimpezaPraia,TotEstruturaPraia,TotSinalizacaoPraia,TotMonitoramentoPraia,TotPoluicaoPraia,TotConservacaoPraia,TotalPraia")] PraiaModel praiaModel)
        {
            if (id != praiaModel.IdPraia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(praiaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PraiaModelExists(praiaModel.IdPraia))
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
            return View(praiaModel);
        }

        // GET: PraiasModel/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.PraiaModel == null)
            {
                return NotFound();
            }

            var praiaModel = await _context.PraiaModel
                .FirstOrDefaultAsync(m => m.IdPraia == id);
            if (praiaModel == null)
            {
                return NotFound();
            }

            return View(praiaModel);
        }

        // POST: PraiasModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.PraiaModel == null)
            {
                return Problem("Entity set 'PraiAppContext.PraiaModel'  is null.");
            }
            var praiaModel = await _context.PraiaModel.FindAsync(id);
            if (praiaModel != null)
            {
                _context.PraiaModel.Remove(praiaModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PraiaModelExists(long id)
        {
          return (_context.PraiaModel?.Any(e => e.IdPraia == id)).GetValueOrDefault();
        }
    }
}
