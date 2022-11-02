using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;
using Sport.Data;
using Sport.Data.Repositories;
using Sport.Models;
using SportData.Data.Domain.Interfaces;

namespace MVC.Controllers
{
    public class AdressController : Controller
    {
        private readonly SportContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public AdressController(SportContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: _ShowEdit
        public async Task<IActionResult> ShowEdit(int? id)
        {
            if (id == null) return NotFound();

            var viewAdress = (AdressViewModel)_unitOfWork.Adress.Get((int)id);

            if (viewAdress != null)
                return View(viewAdress);
            else
                return NotFound();
        }

        // POST _ShowEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ShowEdit([Bind("AdressId,Street,StreetNumber,StreetNumberAddition,Zipcode,City,PhoneNumber,Edit")] AdressViewModel adress)
        {
            if (adress.AdressId == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdressExists(adress.AdressId))
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
            return View(adress);
        }

        // GET: Adress
        public async Task<IActionResult> Index()
        {
              return _context.Adress != null ? 
                          View(await _context.Adress.ToListAsync()) :
                          Problem("Entity set 'SportContext.Adress'  is null.");
        }

        // GET: Adress/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Adress == null)
            {
                return NotFound();
            }

            var adress = await _context.Adress
                .FirstOrDefaultAsync(m => m.AdressId == id);
            if (adress == null)
            {
                return NotFound();
            }

            return View(adress);
        }

        // GET: Adress/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Adress/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdressId,Street,StreetNumber,StreetNumberAddition,Zipcode,City,PhoneNumber")] Adress adress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adress);
        }

        // GET: Adress/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Adress == null)
            {
                return NotFound();
            }

            var adress = await _context.Adress.FindAsync(id);
            if (adress == null)
            {
                return NotFound();
            }
            return View(adress);
        }

        // POST: Adress/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdressId,Street,StreetNumber,StreetNumberAddition,Zipcode,City,PhoneNumber")] Adress adress)
        {
            if (id != adress.AdressId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdressExists(adress.AdressId))
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
            return View(adress);
        }

        // GET: Adress/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Adress == null)
            {
                return NotFound();
            }

            var adress = await _context.Adress
                .FirstOrDefaultAsync(m => m.AdressId == id);
            if (adress == null)
            {
                return NotFound();
            }

            return View(adress);
        }

        // POST: Adress/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Adress == null)
            {
                return Problem("Entity set 'SportContext.Adress'  is null.");
            }
            var adress = await _context.Adress.FindAsync(id);
            if (adress != null)
            {
                _context.Adress.Remove(adress);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdressExists(int id)
        {
          return (_context.Adress?.Any(e => e.AdressId == id)).GetValueOrDefault();
        }
    }
}
