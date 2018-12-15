using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionaleConferenze.Models;
using GestionaleConferenze.Models.EF_DataBase;
using GestionaleConferenze.ViewModels;

namespace GestionaleConferenze.Controllers
{
    public class PresentazioniController : Controller
    {
        private readonly GestionaleConferenzeContesto _context;

        public PresentazioniController(GestionaleConferenzeContesto context)
        {
            _context = context;
        }

        // GET: Presentazioni
        public async Task<IActionResult> Index()
        {
            return View(await _context.Presentazioni.ToListAsync());
        }

        // GET: Presentazioni/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presentazione = await _context.Presentazioni
                .FirstOrDefaultAsync(m => m.PresentazioneId == id);
            if (presentazione == null)
            {
                return NotFound();
            }

            return View(presentazione);
        }

        // GET: Presentazioni/Create
        public IActionResult Create()
        {
            VMPresentazioni vmp = new VMPresentazioni();

            var autori = _context.Autori.Select(a => new VMAutori { AutoreId = a.AutoreId, Nome = a.Nome + " " + a.Cognome }).ToList();
            vmp.Autori = autori;
            

            return View(vmp);
        }

        // POST: Presentazioni/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PresentazioneId,Titolo,DataInizio,DataFine,Livello")] VMPresentazioni vmp)
        {
            
            if (ModelState.IsValid)
            {
                Presentazione presentazione = new Presentazione
                {
                    Titolo = vmp.Titolo,
                    DataInizio = vmp.DataInizio,
                    DataFine = vmp.DataFine,
                    Livello = vmp.Livello,
                    PresentazioneId = vmp.PresentazioneId,                    
                    
                };

                foreach (var vma in vmp.Autori)
                {
                    var reg = new Registrazione
                    {
                        AutoreId = vma.AutoreId
                    };

                    presentazione.Registrazioni.Add(reg);
                    reg.Presentazione = presentazione;
                }
                _context.Add(vmp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vmp);
        }

        // GET: Presentazioni/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presentazione = await _context.Presentazioni.FindAsync(id);
            if (presentazione == null)
            {
                return NotFound();
            }
            return View(presentazione);
        }

        // POST: Presentazioni/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PresentazioneId,Titolo,DataInizio,DataFine,Livello")] VMPresentazioni vmp)
        {
            if (id != vmp.PresentazioneId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vmp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PresentazioneExists(vmp.PresentazioneId))
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
            return View(vmp);
        }

        // GET: Presentazioni/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presentazione = await _context.Presentazioni
                .FirstOrDefaultAsync(m => m.PresentazioneId == id);
            if (presentazione == null)
            {
                return NotFound();
            }

            return View(presentazione);
        }

        // POST: Presentazioni/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var presentazione = await _context.Presentazioni.FindAsync(id);
            _context.Presentazioni.Remove(presentazione);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PresentazioneExists(int id)
        {
            return _context.Presentazioni.Any(e => e.PresentazioneId == id);
        }
    }
}
