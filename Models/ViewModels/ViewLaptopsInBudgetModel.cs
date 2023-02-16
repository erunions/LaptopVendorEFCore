namespace LaptopVendorEFCore.Models.ViewModels
{
    public class ViewLaptopsInBudgetModel
    {
        public int Budget { get; set; } = 0;
        public List<Laptop> Results { get; set; } = new();

        public  ViewLaptopsInBudgetModel() 
        {
            
        }
    }
}
