using Domain;
using System;
using System.Linq;
namespace Services;

public class EquipmentService
{
    private List<Equipment> equipmentList = new();

    public void AddEquipment(Equipment equipment)
    {
        equipmentList.Add(equipment);
    }

    public List<Equipment> GetAll() => equipmentList;

    public List<Equipment> GetAvailable() =>
        equipmentList.Where(e => e.IsAvailable).ToList();
}