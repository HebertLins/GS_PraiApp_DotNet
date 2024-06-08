using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using PraiApp.Models;
using PraiApp.Repository;

namespace PraiApp.Controllers
{
    
    public class AvaliacoesModelController : Controller
    {
        private readonly PraiAppContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IPraiaRepository _praiaRepository;

        public AvaliacoesModelController(PraiAppContext context, IUserRepository userRepository, IPraiaRepository praiaRepository)
        {
            _context = context;
            _userRepository = userRepository;
            _praiaRepository = praiaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return _context.AvaliacaoModel != null ?
                View(await _context.AvaliacaoModel.ToListAsync()) :
                Problem("Entity set 'PraiAppContext.AvaliacaoModel' is null.");
        }

        // GET: OrganizacoesModel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AvaliacaoModel == null)
            {
                return NotFound();
            }

            var avaliacaoModel = await _context.AvaliacaoModel
                .FirstOrDefaultAsync(m => m.IdAvaliacao == id);
            if (avaliacaoModel == null)
            {
                return NotFound();
            }

            return View(avaliacaoModel);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAvaliacao,LimpezaAvaliacao,EstruturaAvaliacao,SinalizacaoAvaliacao,MonitoramentoAvaliacao,PoluicaoAvaliacao,ConservacaoAvaliacao,IdUser,IdPraia")] AvaliacaoModel avaliacaoModel)
        {

            if (ModelState.IsValid)
            {
                var user = await _userRepository.GetUserByIdAsync(avaliacaoModel.IdUser);
                var praia = await _praiaRepository.GetPraiaByIdAsync(avaliacaoModel.IdPraia);

                if (user == null)
                {
                    ModelState.AddModelError("User.IdUser", "Invalid Endereco ID.");
                    return View(avaliacaoModel);
                }

                if (praia == null)
                {
                    ModelState.AddModelError("Praia.IdPraia", "Invalid Responsavel ID.");
                    return View(avaliacaoModel);
                }


                avaliacaoModel.User = user;
                avaliacaoModel.Praia = praia;

                _context.Add(avaliacaoModel);
                await _context.SaveChangesAsync();

                var avaliacoesPraia = await _context.AvaliacaoModel
                .Where(a => a.IdPraia == praia.IdPraia)
                .ToListAsync();

                var mediaLimpeza = Math.Round(avaliacoesPraia.Average(a => a.LimpezaAvaliacao), 1);
                var mediaEstrutura = Math.Round(avaliacoesPraia.Average(a => a.EstruturaAvaliacao), 1);
                var mediaSinalizacao = Math.Round(avaliacoesPraia.Average(a => a.SinalizacaoAvaliacao), 1);
                var mediaMonitoramento = Math.Round(avaliacoesPraia.Average(a => a.MonitoramentoAvaliacao), 1);
                var mediaPoluicao = Math.Round(avaliacoesPraia.Average(a => a.PoluicaoAvaliacao), 1);
                var mediaConservacao = Math.Round(avaliacoesPraia.Average(a => a.ConservacaoAvaliacao), 1);
                var mediaGeral = Math.Round((mediaLimpeza + mediaEstrutura + mediaSinalizacao + mediaMonitoramento + mediaPoluicao + mediaConservacao) / 6, 1);

                praia.TotLimpezaPraia = mediaLimpeza;
                praia.TotEstruturaPraia = mediaEstrutura;
                praia.TotSinalizacaoPraia = mediaSinalizacao;
                praia.TotMonitoramentoPraia = mediaMonitoramento;
                praia.TotPoluicaoPraia = mediaPoluicao;
                praia.TotConservacaoPraia = mediaConservacao;
                praia.TotalPraia = mediaGeral;

                _context.Update(praia);
                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            }

            return View(avaliacaoModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AvaliacaoModel == null)
            {
                return NotFound();
            }

            var avaliacaoModel = await _context.AvaliacaoModel.FindAsync(id);
            if (avaliacaoModel == null)
            {
                return NotFound();
            }
            return View(avaliacaoModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAvaliacao,LimpezaAvaliacao,EstruturaAvaliacao,SinalizacaoAvaliacao,MonitoramentoAvaliacao,PoluicaoAvaliacao,ConservacaoAvaliacao,IdUser,IdPraia")] AvaliacaoModel avaliacaoModel)
        {
            if (id != avaliacaoModel.IdAvaliacao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userRepository.GetUserByIdAsync(avaliacaoModel.IdUser);
                    var praia = await _praiaRepository.GetPraiaByIdAsync(avaliacaoModel.IdPraia);

                    if (user == null)
                    {
                        ModelState.AddModelError("User.IdUser", "Invalid Endereco ID.");
                        return View(avaliacaoModel);
                    }

                    if (praia == null)
                    {
                        ModelState.AddModelError("Praia.IdPraia", "Invalid Responsavel ID.");
                        return View(avaliacaoModel);
                    }


                    avaliacaoModel.User = user;
                    avaliacaoModel.Praia = praia;


                    _context.Update(avaliacaoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvaliacaoModelExists(avaliacaoModel.IdAvaliacao))
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
            return View(avaliacaoModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AvaliacaoModel == null)
            {
                return NotFound();
            }

            var avaliacaoModel = await _context.AvaliacaoModel
                .FirstOrDefaultAsync(m => m.IdAvaliacao == id);
            if (avaliacaoModel == null)
            {
                return NotFound();
            }

            return View(avaliacaoModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AvaliacaoModel == null)
            {
                return Problem("Entity set 'PraiAppContext.AvaliacaoModel'  is null.");
            }
            var avaliacaoModel = await _context.AvaliacaoModel.FindAsync(id);
            if (avaliacaoModel != null)
            {
                _context.AvaliacaoModel.Remove(avaliacaoModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }






        private bool AvaliacaoModelExists(int id)
        {
            return (_context.AvaliacaoModel?.Any(e => e.IdAvaliacao == id)).GetValueOrDefault();
        }
    }
}
