using LaptopVendorEFCore.Data;
using System.Net.Http.Headers;
using LaptopVendorEFCore.Models;

namespace LaptopVendorEFCore
{
    public class PopulateDatabase
    {
        public static void Populate()
        {
            LaptopDBContext context = new LaptopDBContext();

            Brand zygo = new Brand()
            {
                Name = "ZygoTech"
            };
            context.Brands.Add(zygo);

            Brand octadex = new Brand()
            {
                Name = "Octadex Solutions"
            };
            context.Brands.Add(octadex);

            Brand innovix = new Brand()
            {
                Name = "Innovix Computing"
            };
            context.Brands.Add(innovix);

            Brand vortron = new Brand()
            {
                Name = "Vortron Technologies"
            };
            context.Brands.Add(vortron);

            Brand synergo = new Brand()
            {
                Name = "Synergo Systems"
            };
            context.Brands.Add(synergo);

            Brand nexusphere = new Brand()
            {
                Name = "Nexusphere Technologies"
            };
            context.Brands.Add(nexusphere);

            Brand techvibe = new Brand()
            {
                Name = "Techvibe Solutions"
            };
            context.Brands.Add(techvibe);

            Brand cybertron = new Brand()
            {
                Name = "Cybertronix"
            };
            context.Brands.Add(cybertron);

            Brand siliconix = new Brand()
            {
                Name = "Siliconix Innovations"
            };
            context.Brands.Add(siliconix);

            Brand digitech = new Brand()
            {
                Name = "Digitech Systems"
            };
            context.Brands.Add(digitech);

            Brand techspace = new Brand()
            {
                Name = "TechSpace Innovations"
            };
            context.Brands.Add(techspace);

            Brand orbinet = new Brand()
            {
                Name = "Orbinet Technologies"
            };
            context.Brands.Add(orbinet);

            Brand dynavolt = new Brand()
            {
                Name = "Dynavolt Computing"
            };
            context.Brands.Add(dynavolt);

            Brand techsphere = new Brand()
            {
                Name = "TechSphere Solutions"
            };
            context.Brands.Add(techsphere);

            Brand cybernaut = new Brand()
            {
                Name = "Cybernautics"
            };
            context.Brands.Add(cybernaut);

            Brand sysgenix = new Brand()
            {
                Name = "SysGenix Technologies"
            };
            context.Brands.Add(sysgenix);

            Brand techhive = new Brand()
            {
                Name = "TechHive Innovations"
            };
            context.Brands.Add(techhive);

            Brand infotech = new Brand()
            {
                Name = "InfoTech Solutions"
            };
            context.Brands.Add(infotech);

            Brand circuitron = new Brand()
            {
                Name = "Circuitronix"
            };
            context.Brands.Add(circuitron);

            Laptop laptop1 = new Laptop()
            {
                Model = "ApexBook Pro A7",
                Year = 2023,
                Brand = zygo,
                BrandId = zygo.Id,
                Price = 2999.99M
            };
            context.Laptops.Add(laptop1);

            Laptop laptop2 = new Laptop()
            {
                Model = "InnovaMate X1",
                Year = 2022,
                Brand = octadex,
                BrandId = octadex.Id,
                Price = 2499.99M
            };
            context.Laptops.Add(laptop2);

            Laptop laptop3 = new Laptop()
            {
                Model = "TechMate Pro",
                Year = 2010,
                Brand = innovix,
                BrandId = innovix.Id,
                Price = 799.99M
            };
            context.Laptops.Add(laptop3);

            Laptop laptop4 = new Laptop()
            {
                Model = "VortexPro Max",
                Year = 2015,
                Brand = vortron,
                BrandId = vortron.Id,
                Price = 1099.99M
            };
            context.Laptops.Add(laptop4);

            Laptop laptop5 = new Laptop()
            {
                Model = "CyberBook 9000",
                Year = 2021,
                Brand = synergo,
                BrandId = synergo.Id,
                Price = 1999.99M
            };
            context.Laptops.Add(laptop5);

            Laptop laptop6 = new Laptop()
            {
                Model = "NexusBook Pro",
                Year = 2018,
                Brand = nexusphere,
                BrandId = nexusphere.Id,
                Price = 1599.99M
            };
            context.Laptops.Add(laptop6);

            Laptop laptop7 = new Laptop()
            {
                Model = "Techvibe EliteBook",
                Year = 2019,
                Brand = techvibe,
                BrandId = techvibe.Id,
                Price = 1499.99M
            };
            context.Laptops.Add(laptop7);

            Laptop laptop8 = new Laptop()
            {
                Model = "Cybertronix TurboBook",
                Year = 2020,
                Brand = cybertron,
                BrandId = cybertron.Id,
                Price = 2199.99M
            };
            context.Laptops.Add(laptop8);

            Laptop laptop9 = new Laptop()
            {
                Model = "Siliconix Ultrabook",
                Year = 2014,
                Brand = siliconix,
                BrandId = siliconix.Id,
                Price = 1299.99M
            };
            context.Laptops.Add(laptop9);

            Laptop laptop10 = new Laptop()
            {
                Model = "Digitech StudioBook",
                Year = 2016,
                Brand = digitech,
                BrandId = digitech.Id,
                Price = 999.99M
            };
            context.Laptops.Add(laptop10);

            context.SaveChanges();
        }
    }
}
