using LaptopVendorEFCore.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaptopVendorEFCore.Models.ViewModels
{
    public class CreateLaptopModel
    {
        private static readonly HashSet<Laptop> Laptops = new LaptopDBContext().Laptops.ToHashSet();
        private static readonly HashSet<Brand> Brands = new LaptopDBContext().Brands.ToHashSet();
        public string Model { get; set; } = "";
        public string Brand { get; set; } = "";
        public float Price { get; set; } = 0;
        public int Year { get; set; } = 0;
        public List<SelectListItem> BrandOptions { get; set; } = Brands.Select(b =>
            new SelectListItem
            {
                Value = b.Name,
                Text = b.Name
            }).ToList();

        public CreateLaptopModel() { }
    }
}
