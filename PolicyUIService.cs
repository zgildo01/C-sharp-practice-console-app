namespace FinysPractice.UI;
using FinysPractice.Helpers;
using FinysPractice.Models;
using FinysPractice.Services.Interfaces;
public static class PolicyUIService
{
    public static void CreatePolicyUI(IPolicyService policyService, ICustomerService customerService)
    {
      int id = InputHelper.ReadInt("Enter policy ID: ");
      decimal basePremium = InputHelper.ReadDecimal("Enter base premium: ");
      bool active = InputHelper.ReadBool("Active? (true/false): ");
      int customerId = InputHelper.ReadInt("Enter customer ID: ");

      try
      {
        bool policy = policyService.CreatePolicy(id, basePremium, active, customerId);
        if(!policy)
        {
            Console.WriteLine($"Error creating policy for: {customerId}");
            Console.WriteLine("Checking if customer exists...");

            Customer? customer = customerService.GetCustomerById(id);
            if (customer == null) 
            {
              Console.WriteLine($"Customer with the id {id} does exist.");
            }
        }
      } catch (Exception e)
      {
        Console.WriteLine($"Error: {e.Message}");
      }
    }
}