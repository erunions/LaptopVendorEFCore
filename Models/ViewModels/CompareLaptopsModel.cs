using LaptopVendorEFCore.Data;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace LaptopVendorEFCore.Models.ViewModels
{
    public class CompareLaptopsModel
    {
        private readonly HashSet<Laptop> Laptops = new LaptopDBContext().Laptops.ToHashSet();


        public static List<SelectListItem> LaptopNames = new();

        public string ModelSelection1 { get; set; } = "";

        public string ModelSelection2 { get; set; } = "";

        public Laptop? Selection1 { get; set; } = null;

        public Laptop? Selection2 { get; set; } = null;

        public CompareLaptopsModel() 
        {
            HashSet<Brand> brands = new LaptopDBContext().Brands.ToHashSet();
            foreach(Laptop l in Laptops)
            {
                l.Brand = brands.First(b => b.Id == l.BrandId);
            }
            LaptopNames = Laptops.Select(l =>
            new SelectListItem
            {
                Value = l.Model,
                Text = $"{l.Brand.Name} {l.Model}"
            }).ToList();
        }
    }
}
