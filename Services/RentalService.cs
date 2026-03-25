using Domain;
using System;
using System.Linq;
namespace Services;

public class RentalService
{
    private List<Rental> rentals = new();

    public void Rent(User user, Equipment equipment, int days)
    {
        if (!equipment.IsAvailable)
            throw new Exception("Equipment not available");

        int active = rentals.Count(r => r.User == user && !r.IsReturned);

        if (active >= user.MaxRentals)
            throw new Exception("User exceeded limit");

        var rental = new Rental
        {
            User = user,
            Equipment = equipment,
            RentDate = DateTime.Now,
            DueDate = DateTime.Now.AddDays(days)
        };

        equipment.IsAvailable = false;
        rentals.Add(rental);
    }

    public void Return(Equipment equipment)
    {
        var rental = rentals.FirstOrDefault(r => r.Equipment == equipment && !r.IsReturned);

        if (rental == null)
            throw new Exception("Rental not found");

        rental.ReturnDate = DateTime.Now;
        equipment.IsAvailable = true;
    }

    public List<Rental> GetActive(User user) =>
        rentals.Where(r => r.User == user && !r.IsReturned).ToList();

    public List<Rental> GetOverdue() =>
        rentals.Where(r => !r.IsReturned && r.DueDate < DateTime.Now).ToList();
    public List<Rental> GetAll() => rentals.ToList();
}