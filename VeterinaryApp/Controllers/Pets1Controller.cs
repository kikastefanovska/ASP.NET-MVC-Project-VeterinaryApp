using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeterinaryApp.Data;
using VeterinaryApp.Models;

namespace VeterinaryApp.Controllers
{
    public class Pets1Controller : Controller
    {
        private readonly VeterinaryAppContext _context;

        public Pets1Controller(VeterinaryAppContext context)
        {
            _context = context;
        }

        // GET: Pets1
        public async Task<IActionResult> Index()
        {
            var veterinaryAppContext = _context.Pets.Include(p => p.Owner);
            return View(await veterinaryAppContext.ToListAsync());
        }

        // GET: Pets1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _context.Pets
                .Include(p => p.Owner)
                .Include(p => p.Vaccines)
                .FirstOrDefaultAsync(m => m.PetId == id);

            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        // GET: Pets1/Create
        public IActionResult Create()
        {

            ViewData["OwnerId"] = new SelectList(_context.Owners, "OwnerId", "FullName");
            ViewData["VaccineId"] = new MultiSelectList(_context.Vaccines, "VaccineId", "Name");

            return View();
        }

        // POST: Pets1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PetId,Name,Age,OwnerId,VaccineIds")] Pet pet)
        {

            //_context.Add(pet);
            if (ModelState.IsValid)
            {
                var vaccines = _context.Vaccines.Where(x => pet.VaccineIds.Contains(x.Id)).ToList();
                pet.Vaccines.AddRange(vaccines);
                _context.Add(pet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "Name", pet.OwnerId);
            return View(pet);

        }

        // GET: Pets1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _context.Pets.Include(s => s.Vaccines).FirstOrDefaultAsync(x => x.PetId == id);
            if (pet == null)
            {
                return NotFound();
            }
            ViewData["OwnerId"] = new SelectList(_context.Owners, "OwnerId", "Name", pet.OwnerId);

            var vaccineIds = pet.Vaccines.Select(x => x.Id).ToList();
            ViewData["VaccineId"] = new MultiSelectList(_context.Vaccines, "VaccineId", "Name", vaccineIds);

            return View(pet);
            


        }

        // POST: Pets1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PetId,Name,Age,OwnerId,VaccineIds")] Pet pet)
        {
            if (id != pet.PetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pet);
                    if (pet.VaccineIds != null && pet.VaccineIds.Any())
                    {
                        var vaccines = await _context.Vaccines.Where(v => pet.VaccineIds.Contains(v.Id)).ToListAsync();
                        pet.Vaccines = vaccines;
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetExists(pet.PetId))
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
            ViewData["OwnerId"] = new SelectList(_context.Owners, "OwnerId", "Name", pet.OwnerId);
            ViewData["VaccineIds"] = new MultiSelectList(_context.Vaccines, "VaccineIds", "Name", pet.VaccineIds);

            return View(pet);
        }

        // GET: Pets1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _context.Pets
                .Include(p => p.Owner)
                .FirstOrDefaultAsync(m => m.PetId == id);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        // POST: Pets1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet != null)
            {
                _context.Pets.Remove(pet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PetExists(int id)
        {
            return _context.Pets.Any(e => e.PetId == id);
        }


    }
}
