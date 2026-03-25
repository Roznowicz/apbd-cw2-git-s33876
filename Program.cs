using System;
using Domain;
using Services;

var equipmentService = new EquipmentService();
var userService = new UserService();
var rentalService = new RentalService();
var penaltyCalculator = new PenaltyCalculator();
var reportService = new ReportService();

Console.WriteLine("=== SYSTEM WYPOŻYCZALNI ===");

// =====================
// 1. Dodanie sprzętu
// =====================
var laptop1 = new Laptop { Name = "Dell", Ram = 16, Cpu = "i7" };
var laptop2 = new Laptop { Name = "HP", Ram = 8, Cpu = "i5" };
var laptop3 = new Laptop { Name = "Lenovo", Ram = 8, Cpu = "i5" };

var projector = new Projector { Name = "Epson", Lumens = 3000, IsPortable = true };
var camera = new Camera { Name = "Canon", Resolution = 24, HasFlash = true };

equipmentService.AddEquipment(laptop1);
equipmentService.AddEquipment(laptop2);
equipmentService.AddEquipment(laptop3);
equipmentService.AddEquipment(projector);
equipmentService.AddEquipment(camera);

// =====================
// 2. Dodanie użytkowników
// =====================
var student = new Student { FirstName = "Jan", LastName = "Kowalski" };
var employee = new Employee { FirstName = "Anna", LastName = "Nowak" };

userService.AddUser(student);
userService.AddUser(employee);

// =====================
// 3. Poprawne wypożyczenie
// =====================
Console.WriteLine("\n[OK] Wypożyczenie sprzętu:");
rentalService.Rent(student, laptop1, 2);
Console.WriteLine("Student wypożyczył laptop Dell");

// =====================
// 4. Próba błędu (sprzęt niedostępny)
// =====================
Console.WriteLine("\n[ERROR] Próba wypożyczenia tego samego sprzętu:");
try
{
    rentalService.Rent(student, laptop1, 2);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

// =====================
// 5. Test limitu użytkownika
// =====================
Console.WriteLine("\n[ERROR] Test limitu wypożyczeń:");

rentalService.Rent(student, laptop2, 2);

try
{
    rentalService.Rent(student, laptop3, 2);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

// =====================
// 6. Zwrot w terminie
// =====================
Console.WriteLine("\n[OK] Zwrot w terminie:");
rentalService.Return(laptop1);
Console.WriteLine("Laptop Dell zwrócony");

// =====================
// 7. Zwrot po terminie + kara
// =====================
Console.WriteLine("\n[OK] Zwrot po terminie + kara:");

rentalService.Rent(employee, projector, 1);

// symulacja opóźnienia
var rental = rentalService.GetAll().First(r => r.Equipment == projector);
rental.DueDate = DateTime.Now.AddDays(-3);

rentalService.Return(projector);

var penalty = penaltyCalculator.Calculate(rental);
Console.WriteLine($"Kara za spóźnienie: {penalty} zł");

// =====================
// 8. Lista dostępnego sprzętu
// =====================
Console.WriteLine("\n=== Dostępny sprzęt ===");
foreach (var e in equipmentService.GetAvailable())
{
    Console.WriteLine(e.Name);
}

// =====================
// 9. Raport końcowy
// =====================
Console.WriteLine("\n=== RAPORT KOŃCOWY ===");

reportService.Generate(
    equipmentService.GetAll(),
    rentalService.GetAll()
);