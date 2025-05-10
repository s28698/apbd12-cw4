using WebApplication1.Models;

namespace WebApplication1.Data;

public static class Database
{
    public static List<Animal> Animals { get; } = new List<Animal>()
    {
        new Animal { Id = 1, Name = "Todi", Category = "pies",    Weight = 14.5, FurColor = "biały" },
        new Animal { Id = 2, Name = "Kitek", Category = "kot",   Weight = 2.2,  FurColor = "czarno-biały" },
        new Animal { Id = 3, Name = "Reks",   Category = "pies",  Weight = 19.3, FurColor = "brązowy" }
    };

    public static List<Visit> Visits { get; } = new List<Visit>()
    {
        new Visit { Id = 1, AnimalId = 1, VisitDate = DateTime.Now.AddDays(-10), Description = "Szczepienie", Price = 120 },
        new Visit { Id = 2, AnimalId = 2, VisitDate = DateTime.Now.AddDays(-5),  Description = "Profilaktyka", Price = 300 }
    };
}