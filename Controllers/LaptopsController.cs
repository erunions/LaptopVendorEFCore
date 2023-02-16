using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LaptopVendorEFCore.Data;
using LaptopVendorEFCore.Models;
using LaptopVendorEFCore.Models.ViewModels;

namespace LaptopVendorEFCore.Controllers
{
    public class LaptopsController : Controller
    {
        private readonly LaptopDBContext _context;

        public LaptopsController(LaptopDBContext context)
        {
            _context = context;
        }

        // GET: Laptops
        public async Task<IActionResult> Index()
        {
            var laptopDBContext = _context.Laptops.Include(l => l.Brand);
            return View(await laptopDBContext.ToListAsync());
        }

        // GET: Laptops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Laptops == null)
            {
                return NotFound();
            }

            var laptop = await _context.Laptops
                .Include(l => l.Brand)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (laptop == null)
            {
                return NotFound();
            }

            return View(laptop);
        }

        // GET: Laptops/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Id");
            return View();
        }

        // POST: Laptops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Model,BrandId,Price,Year")] Laptop laptop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(laptop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Id", laptop.BrandId);
            return View(laptop);
        }

        // GET: Laptops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Laptops == null)
            {
                return NotFound();
            }

            var laptop = await _context.Laptops.FindAsync(id);
            if (laptop == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Id", laptop.BrandId);
            return View(laptop);
        }

        // POST: Laptops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Model,BrandId,Price,Year")] Laptop laptop)
        {
            if (id != laptop.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(laptop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaptopExists(laptop.Id))
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
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Id", laptop.BrandId);
            return View(laptop);
        }

        // GET: Laptops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Laptops == null)
            {
                return NotFound();
            }

            var laptop = await _context.Laptops
                .Include(l => l.Brand)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (laptop == null)
            {
                return NotFound();
            }

            return View(laptop);
        }

        // POST: Laptops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Laptops == null)
            {
                return Problem("Entity set 'LaptopDBContext.Laptops'  is null.");
            }
            var laptop = await _context.Laptops.FindAsync(id);
            if (laptop != null)
            {
                _context.Laptops.Remove(laptop);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LaptopExists(int id)
        {
          return _context.Laptops.Any(e => e.Id == id);
        }

        public IActionResult ViewExpensiveLaptops()
        {
            Laptop[] result = _context.Laptops.OrderByDescending(l => l.Price).Take(2).ToArray();
            foreach (var l in result)
            {
                l.Brand = _context.Brands.First(b => b.Id == l.BrandId);
            }
            return View(result);
        }

        public IActionResult ViewCheapLaptops()
        {
            Laptop[] result = _context.Laptops.OrderBy(l => l.Price).Take(3).ToArray();
            foreach (var l in result)
            {
                l.Brand = _context.Brands.First(b => b.Id == l.BrandId);
            }
            return View(result);
        }

        public IActionResult ViewLaptopsInBudget()
        {
            ViewLaptopsInBudgetModel vm = new();
            return View(vm);
        }

        [HttpPost]
        public IActionResult ViewLaptopsInBudget(ViewLaptopsInBudgetModel vm)
        {
            vm.Results = _context.Laptops.Where(l => l.Price <= vm.Budget).ToList();
            foreach (var l in vm.Results)
            {
                l.Brand = _context.Brands.First(b => b.Id == l.BrandId);
            }
            return View(vm);
        }

        public IActionResult CompareLaptops()
        {
            CompareLaptopsModel vm = new();
            return View(vm);
        }

        [HttpPost]
        public IActionResult CompareLaptops(CompareLaptopsModel vm)
        {
            if (!string.IsNullOrEmpty(vm.ModelSelection1)) vm.Selection1 = _context.Laptops.First(l => l.Model == vm.ModelSelection1);
            if(vm.Selection1 != null) vm.Selection1.Brand = _context.Brands.First(b => b.Id == vm.Selection1.BrandId);
            if (!string.IsNullOrEmpty(vm.ModelSelection2)) vm.Selection2 = _context.Laptops.First(l => l.Model == vm.ModelSelection2);
            if(vm.Selection2 != null) vm.Selection2.Brand = _context.Brands.First(b => b.Id == vm.Selection2.BrandId);
            return View(vm);
        }
    }
}
