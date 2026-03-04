namespace FinysPractice.Services;
using FinysPractice.Models;
using FinysPractice.Services.Interfaces;

public class CustomerService : ICustomerService
{
    private readonly List<Customer> _customers = new List<Customer>();
    public Customer CreateCustomer(int id, string name, int age, string state)
    {
      var customer = new Customer
      {
        Id = id,
        Name = name,
        Age = age,
        State = state
      };

      _customers.Add(customer);
      return customer;
    }
    public Customer? GetCustomerById(int id)
    {
      if(_customers.Count == 0||id <= 0||_customers.FirstOrDefault(c => c.Id == id) == null)
      {
        Console.WriteLine($"Customer with id {id} not found.");
        return null;
      }
      return _customers.FirstOrDefault(c => c.Id == id);
    }
    public bool UpdateCustomerState(int id, string newState)
    {
      var customer = GetCustomerById(id);
      if(customer == null)
      {
        Console.WriteLine($"Customer with id {id} not found, could not update state.");
        return false;
      }
      customer.State = newState;
      return true;
    }
    public bool UpdateCustomerAge(int id, int newAge)
    {
      var customer = GetCustomerById(id);
      if(customer == null)
      {
        Console.WriteLine($"Customer with {id} not found, could not update age.");
        return false;
      }
      customer.Age = newAge;
      return true;
    }
    public bool UpdateCustomerName(int id, string newName)
    {
      var customer = GetCustomerById(id);
      if(customer == null)
      {
        Console.WriteLine($"Customer with {id} not found, could not update name.");
        return false;
      } 
      customer.Name = newName;
      return true;
    }
    public bool DeleteCustomer(int id)
    {
      var customer = GetCustomerById(id);
      if(customer == null)
      {
        Console.WriteLine($"Customer with id {id} not found, could not delete.");
        return false;
      }
      _customers.Remove(customer);
      return true;
    }
}