using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaptopVendorEFCore.Models.ViewModels
{
    public class ViewLaptopsByBrandModel
    {
        public static List<SelectListItem> OrderingOptions = new()
        {
            new("Default", "default"),
            new("Price Ascending", "priceAscending"),
            new("Price Descending", "priceDescending"),
            new("Newest", "newest"),
            new("Oldest", "oldest")
        };

        public static List<SelectListItem> FilterOptions = new()
        {
            new("No Filtering", "none"),
            new("Above Price", "abovePrice"),
            new("Below Price", "belowPrice"),
            new("Before Year", "beforeYear"),
            new("After Year", "afterYear")
        };

        public List<SelectListItem> BrandOptions = new();

        public string BrandSelection { get; set; } = "";
        public string Ordering { get; set; } = "default";
        public string Filtering { get; set; } = "none";
        public int FilterValue { get; set; } = 0;
        public List<Laptop> Results { get; set; } = new();

        public ViewLaptopsByBrandModel() { }
    }
}
