using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionaleConferenze.Models;
using GestionaleConferenze.Models.EF_DataBase;

namespace GestionaleConferenze.Controllers
{
    public class AutoriController : Controller
    {
        private readonly GestionaleConferenzeContesto _context;

        public AutoriController(GestionaleConferenzeContesto context)
        {
            _context = context;
        }

        // GET: Autori
        public async Task<IActionResult> Index()
        {
            return View(await _context.Autori.ToListAsync());
        }

        // GET: Autori/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autore = await _context.Autori
                .FirstOrDefaultAsync(m => m.AutoreId == id);
            if (autore == null)
            {
                return NotFound();
            }

            return View(autore);
        }

        // GET: Autori/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autori/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AutoreId,Nome,Cognome,Email,Telefono,Skills")] Autore autore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(autore);
        }

        // GET: Autori/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autore = await _context.Autori.FindAsync(id);
            if (autore == null)
            {
                return NotFound();
            }
            return View(autore);
        }

        // POST: Autori/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AutoreId,Nome,Cognome,Email,Telefono,Skills")] Autore autore)
        {
            if (id != autore.AutoreId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoreExists(autore.AutoreId))
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
            return View(autore);
        }

        // GET: Autori/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autore = await _context.Autori
                .FirstOrDefaultAsync(m => m.AutoreId == id);
            if (autore == null)
            {
                return NotFound();
            }

            return View(autore);
        }

        // POST: Autori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autore = await _context.Autori.FindAsync(id);
            _context.Autori.Remove(autore);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutoreExists(int id)
        {
            return _context.Autori.Any(e => e.AutoreId == id);
        }
    }
}
