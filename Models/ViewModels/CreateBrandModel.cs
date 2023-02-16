namespace LaptopVendorEFCore.Models.ViewModels
{
    public class CreateBrandModel
    {
        public string Name { get; set; } = "";
        public Brand? FinishedBrand { get; set; } = null;

        public CreateBrandModel() { }
    }
}
