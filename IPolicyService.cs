namespace FinysPractice.Services.Interfaces;
using FinysPractice.Models;
public interface IPolicyService
{
    public bool CreatePolicy (int id, decimal premium, bool active, int customerId);
    public List<Policy> GetAllPolicies();
    public Policy? GetPolicyById(int id);
    public bool UpdatePremium(int id, decimal newPremium);
    public bool UpdateActiveStatus(int id, bool newStatus);
    public bool UpdateCustomer(int id, Customer newCustomer);
    public bool DeletePolicy(int id);
}