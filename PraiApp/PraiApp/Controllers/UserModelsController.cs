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
    public class UserModelsController : Controller
    {
        private readonly PraiAppContext _context;
        private readonly IOrganizacaoRepository _organizacaoRepository;

        public UserModelsController(PraiAppContext context, IOrganizacaoRepository organizacaoRepository)
        {
            _context = context;
            _organizacaoRepository = organizacaoRepository;
        }

        // GET: UserModels
        public async Task<IActionResult> Index()
        {
              return _context.UserModel != null ? 
                          View(await _context.UserModel.ToListAsync()) :
                          Problem("Entity set 'PraiAppContext.UserModel'  is null.");
        }

        // GET: UserModels/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.UserModel == null)
            {
                return NotFound();
            }

            var userModel = await _context.UserModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userModel == null)
            {
                return NotFound();
            }

            return View(userModel);
        }

        // GET: UserModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserModels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Senha,IdOrganizacao")] UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var organizacao = await _organizacaoRepository.GetOrganizacaoByIdAsync(userModel.IdOrganizacao);


                if (organizacao == null)
                {
                    ModelState.AddModelError("Organizacao.IdOrganizacao", "Invalid Endereco ID.");
                    return View(userModel);
                }


                userModel.Organizacao = organizacao;

                _context.Add(userModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userModel);
        }

        // GET: UserModels/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.UserModel == null)
            {
                return NotFound();
            }

            var userModel = await _context.UserModel.FindAsync(id);
            if (userModel == null)
            {
                return NotFound();
            }
            return View(userModel);
        }

        // POST: UserModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Email,Senha")] UserModel userModel)
        {
            if (id != userModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserModelExists(userModel.Id))
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
            return View(userModel);
        }

        // GET: UserModels/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.UserModel == null)
            {
                return NotFound();
            }

            var userModel = await _context.UserModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userModel == null)
            {
                return NotFound();
            }

            return View(userModel);
        }

        // POST: UserModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.UserModel == null)
            {
                return Problem("Entity set 'PraiAppContext.UserModel'  is null.");
            }
            var userModel = await _context.UserModel.FindAsync(id);
            if (userModel != null)
            {
                _context.UserModel.Remove(userModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserModelExists(long id)
        {
          return (_context.UserModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
