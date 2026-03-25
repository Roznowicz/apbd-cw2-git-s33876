using Domain;
using System;
using System.Linq;
namespace Services;

public class UserService
{
    private List<User> users = new();

    public void AddUser(User user)
    {
        users.Add(user);
    }

    public List<User> GetAll() => users;
}