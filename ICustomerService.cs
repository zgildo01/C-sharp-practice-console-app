namespace FinysPractice.Services.Interfaces;
using FinysPractice.Models;
public interface ICustomerService
{
    public Customer CreateCustomer(int id, string name, int age, string state);
    public Customer? GetCustomerById(int id);
    public bool UpdateCustomerState(int id, string newState);
    public bool UpdateCustomerAge(int id, int newAge);
    public bool UpdateCustomerName(int id, string newName);
    public bool DeleteCustomer(int id);
}