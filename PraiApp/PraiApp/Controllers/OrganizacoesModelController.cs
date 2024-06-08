using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PraiApp.Models;
using PraiApp.Repository;

namespace PraiApp.Controllers
{
    public class OrganizacoesModelController : Controller
    {
        private readonly PraiAppContext _context;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IResponsavelRepository _responsavelRepository;

        public OrganizacoesModelController(PraiAppContext context, IEnderecoRepository enderecoRepository, IResponsavelRepository responsavelRepository)
        {
            _context = context;
            _enderecoRepository = enderecoRepository;
            _responsavelRepository = responsavelRepository;
        }

        // GET: OrganizacoesModel
        public async Task<IActionResult> Index()
        {

            return _context.OrganizacaoModel != null ?
                        View(await _context.OrganizacaoModel.ToListAsync()) :
                        Problem("Entity set 'PraiAppContext.OrganizacaoModel'  is null.");
        }

        // GET: OrganizacoesModel/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.OrganizacaoModel == null)
            {
                return NotFound();
            }

            var organizacaoModel = await _context.OrganizacaoModel
                .FirstOrDefaultAsync(m => m.IdOrganizacao == id);
            if (organizacaoModel == null)
            {
                return NotFound();
            }

            return View(organizacaoModel);
        }

        // GET: OrganizacoesModel/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOrganizacao,NomeOrganizacao,DescricaoOrganizacao,TipoOrganizacao,CnpjOrganizacao,IdEndereco,IdResponsavel")] OrganizacaoModel organizacaoModel)
        {

            if (ModelState.IsValid)
            {
                var endereco = await _enderecoRepository.GetEnderecoByIdAsync(organizacaoModel.IdEndereco);
                var responsavel = await _responsavelRepository.GetResponsavelByIdAsync(organizacaoModel.IdResponsavel);

                if (endereco == null)
                {
                    ModelState.AddModelError("Endereco.IdEndereco", "Invalid Endereco ID.");
                    return View(organizacaoModel);
                }

                if (responsavel == null)
                {
                    ModelState.AddModelError("Responsavel.IdResponsavel", "Invalid Responsavel ID.");
                    return View(organizacaoModel);
                }


                organizacaoModel.Endereco = endereco;
                organizacaoModel.Responsavel = responsavel;

                _context.Add(organizacaoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(organizacaoModel);
        }


        // GET: OrganizacoesModel/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.OrganizacaoModel == null)
            {
                return NotFound();
            }

            var organizacaoModel = await _context.OrganizacaoModel.FindAsync(id);
            if (organizacaoModel == null)
            {
                return NotFound();
            }
            return View(organizacaoModel);
        }

        // POST: OrganizacoesModel/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdOrganizacao,NomeOrganizacao,DescricaoOrganizacao,TipoOrganizacao,CnpjOrganizacao,Endereco.IdEndereco,Responsavel.IdResponsavel")] OrganizacaoModel organizacaoModel)
        {
            if (id != organizacaoModel.IdOrganizacao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    organizacaoModel.Endereco = await _enderecoRepository.GetEnderecoByIdAsync(organizacaoModel.Endereco.IdEndereco);
                    organizacaoModel.Responsavel = await _responsavelRepository.GetResponsavelByIdAsync(organizacaoModel.Responsavel.IdResponsavel);

                    _context.Update(organizacaoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizacaoModelExists(organizacaoModel.IdOrganizacao))
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
            return View(organizacaoModel);
        }

        // GET: OrganizacoesModel/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.OrganizacaoModel == null)
            {
                return NotFound();
            }

            var organizacaoModel = await _context.OrganizacaoModel
                .FirstOrDefaultAsync(m => m.IdOrganizacao == id);
            if (organizacaoModel == null)
            {
                return NotFound();
            }

            return View(organizacaoModel);
        }

        // POST: OrganizacoesModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.OrganizacaoModel == null)
            {
                return Problem("Entity set 'PraiAppContext.OrganizacaoModel'  is null.");
            }
            var organizacaoModel = await _context.OrganizacaoModel.FindAsync(id);
            if (organizacaoModel != null)
            {
                _context.OrganizacaoModel.Remove(organizacaoModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganizacaoModelExists(long id)
        {
            return (_context.OrganizacaoModel?.Any(e => e.IdOrganizacao == id)).GetValueOrDefault();
        }
    }
}
