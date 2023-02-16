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
    public class BrandsController : Controller
    {
        private readonly LaptopDBContext _context;

        public BrandsController(LaptopDBContext context)
        {
            _context = context;
        }

        // GET: Brands
        public async Task<IActionResult> Index()
        {
              return View(await _context.Brands.ToListAsync());
        }

        // GET: Brands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Brands == null)
            {
                return NotFound();
            }

            var brand = await _context.Brands
                .FirstOrDefaultAsync(m => m.Id == id);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // GET: Brands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Brands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                _context.Add(brand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }

        // GET: Brands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Brands == null)
            {
                return NotFound();
            }

            var brand = await _context.Brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }

        // POST: Brands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Brand brand)
        {
            if (id != brand.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(brand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrandExists(brand.Id))
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
            return View(brand);
        }

        // GET: Brands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Brands == null)
            {
                return NotFound();
            }

            var brand = await _context.Brands
                .FirstOrDefaultAsync(m => m.Id == id);
            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // POST: Brands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Brands == null)
            {
                return Problem("Entity set 'LaptopDBContext.Brands'  is null.");
            }
            var brand = await _context.Brands.FindAsync(id);
            if (brand != null)
            {
                _context.Brands.Remove(brand);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrandExists(int id)
        {
          return _context.Brands.Any(e => e.Id == id);
        }

        public IActionResult ViewBrandsAndLaptops()
        {
            Dictionary<Brand, List<Laptop>> result = new();
            foreach (Brand b in _context.Brands.ToList())
            {
                result.TryAdd(b, _context.Laptops.Where(l => l.Brand == b).ToList());
            }
            return View(result);
        }

        public IActionResult ViewLaptopsByBrand()
        {
            ViewLaptopsByBrandModel vm = new();
            vm.BrandOptions = _context.Brands.Select(b =>
                new SelectListItem
                {
                    Value = b.Name,
                    Text = b.Name
                }).ToList();
            vm.BrandOptions.Insert(0, new("All Brands", "allbrands"));
            return View(vm);
        }

        [HttpPost]
        public IActionResult ViewLaptopsByBrand(ViewLaptopsByBrandModel vm)
        {
            vm.BrandOptions = _context.Brands.Select(b =>
                new SelectListItem
                {
                    Value = b.Name,
                    Text = b.Name
                }).ToList();
            vm.BrandOptions.Insert(0, new("All Brands", "allbrands"));

            if (vm.BrandSelection != null)
            {
                //populate list of items with laptops depending on brand selection
                if (vm.BrandSelection == "allbrands")
                {
                    vm.Results = _context.Laptops.ToList();
                }
                else
                {
                    vm.Results = _context.Laptops.Where(l => l.Brand.Name == vm.BrandSelection).ToList();
                }
                //filter items based on selection
                switch (vm.Filtering)
                {
                    case "abovePrice":
                        vm.Results = vm.Results.Where(l => l.Price >= vm.FilterValue).ToList();
                        break;
                    case "belowPrice":
                        vm.Results = vm.Results.Where(l => l.Price <= vm.FilterValue).ToList();
                        break;
                    case "beforeYear":
                        vm.Results = vm.Results.Where(l => l.Year < vm.FilterValue).ToList();
                        break;
                    case "afterYear":
                        vm.Results = vm.Results.Where(l => l.Year > vm.FilterValue).ToList();
                        break;
                    default:
                        break;
                }
                //order items at the end
                switch (vm.Ordering)
                {
                    case "priceAscending":
                        vm.Results = vm.Results.OrderBy(l => l.Price).ToList();
                        break;
                    case "priceDescending":
                        vm.Results = vm.Results.OrderByDescending(l => l.Price).ToList();
                        break;
                    case "newest":
                        vm.Results = vm.Results.OrderByDescending(l => l.Year).ToList();
                        break;
                    case "oldest":
                        vm.Results = vm.Results.OrderBy(l => l.Year).ToList();
                        break;
                    default:
                        break;
                }
            }
            foreach (var l in vm.Results)
            {
                l.Brand = _context.Brands.First(b => b.Id == l.BrandId);
            }
            return View(vm);
        }
    }
}
