using Domain;
using System;
using System.Linq;
namespace Services;

public class PenaltyCalculator
{
    public decimal Calculate(Rental rental)
    {
        if (!rental.ReturnDate.HasValue) return 0;

        int daysLate = (rental.ReturnDate.Value - rental.DueDate).Days;

        if (daysLate <= 0) return 0;

        return daysLate * 10;
    }
}