namespace FinysPractice.Services;
using FinysPractice.Models;
using FinysPractice.Services.Interfaces;
public class PolicyService : IPolicyService
{
  private readonly List<Policy> _policies = new List<Policy>();
  private readonly ICustomerService _customerService;
  public PolicyService(ICustomerService customerService)
    {
      _customerService = customerService;
    }
  public bool CreatePolicy (int id, decimal premium, bool active, int customerId)
    {
      Customer? customer = _customerService.GetCustomerById(customerId);

      if (customer == null)
      {
        return false;
      }
      
      var policy = new Policy
      {
        Id = id,
        Premium = premium,
        Active = active,
        Customer = customer
      };

      if (customer.Age < 25)
      {
        policy.Premium += 200m;
      }
      if (customer.State == "MI")
      {
        policy.Premium += 50m;
      }  
      if(_policies.Count(p => p.Customer.Id == p.Customer.Id && p.Active) >= 3)
      {
        throw new InvalidOperationException("Customer cannot have more than 3 active policies");
      }
      if (policy.Premium <= 0)
      {
        throw new ArgumentException("Premium must be greater than zero.");
      }
      
      _policies.Add(policy);
      return true;
    }
  public List<Policy> GetAllPolicies()
    {
      return _policies;
    }
  public Policy? GetPolicyById(int id)
    {
      if(_policies.Count == 0||id <= 0||_policies.FirstOrDefault(p => p.Id == id) == null)
      {
        return null;
      }  else
      {
        return _policies.FirstOrDefault(p => p.Id == id);
      }
    }
  public bool UpdatePremium(int id, decimal newPremium)
    {
      var policy = GetPolicyById(id);
      if(policy == null)
      {
        Console.WriteLine($"Policy with id {id} not found, cannot update premium.");
        return false;
      }
      policy.Premium = newPremium;
      return true;
    }
  public bool UpdateActiveStatus(int id, bool newStatus)
    {
      var policy = GetPolicyById(id);
      if (policy == null)
      {
        Console.WriteLine($"Policy with id {id} not found, cannot update active status.");
        return false;
      }
      policy.Active = newStatus;
      return true;
    }
  public bool UpdateCustomer(int id, Customer newCustomer)
    {
      var policy = GetPolicyById(id);
      if(policy == null)
      {
        Console.WriteLine($"Policy with {id} not found, cannot update customer.");
        return false;
      }
      policy.Customer = newCustomer;
      return true;
    }
  public bool DeletePolicy(int id)
    {
      var policy = GetPolicyById(id);
      if(policy == null)
      {
        Console.WriteLine($"Policy with id {id} not found, cannot delete.");
        return false;
      }
      _policies.Remove(policy);
      return true;
    }
  public List<Policy> GetActivePolicies()
    {
      return _policies
            .Where(p => p.Active)
            .ToList();
    }
  public List<Policy> GetPoliciesByState(string state)
    {
      return _policies
            .Where(p => p.Customer != null && p.Customer.State == state)
            .ToList();
    }
  public List<Policy> GetPoliciesForOlderCustomers(int age)
  {
    return _policies
          .Where(p => p.Customer != null && p.Customer.Age > age)
          .ToList();
  }
  public decimal GetTotalActivePremium()
  {
    return _policies
          .Where(p => p.Active)
          .Sum(p => p.Premium);
  }
  public Dictionary<string, List<Policy>> GetPoliciesGroupedByState()
  {
    return _policies
          .Where(p => p.Customer != null)
          .GroupBy(p => p.Customer.State)
          .ToDictionary(g => g.Key, g => g.ToList());
  }
}