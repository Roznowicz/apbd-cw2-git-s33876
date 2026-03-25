using Domain;
using System;
using System.Linq;
namespace Services;

public class ReportService
{
    public void Generate(List<Equipment> equipment, List<Rental> rentals)
    {
        Console.WriteLine($"Całkowita liczba sprzętu: {equipment.Count}");
        Console.WriteLine($"Dostępne: {equipment.Count(e => e.IsAvailable)}");
        Console.WriteLine($"Wypożyczone: {rentals.Count(r => !r.IsReturned)}");
        Console.WriteLine($"Przeterminowane: {rentals.Count(r => !r.IsReturned && r.DueDate < DateTime.Now)}");
    }
}