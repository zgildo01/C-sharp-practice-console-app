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
    public static void UpdatePolicyUI(IPolicyService policyService, ICustomerService customerService)
    {
      
    }
    public static void DeletePolicyUI(IPolicyService policyService)
    {
      
    }
    public static void GetPolicyUI(IPolicyService policyService)
    {
      
    }
    public static void ShowPolicyMenu(IPolicyService policyService, ICustomerService customerService)
    {
      bool running = true;

      while (running)
      {
        Console.WriteLine("1. Delete A Policy");
        Console.WriteLine("2. Update A Policy");
        Console.WriteLine("3. Get Details Of Policy");
        Console.WriteLine("4. Return");
        int choice = InputHelper.ReadInt("Choose an option (input number)");

        switch (choice)
        {
          case 1:
          DeletePolicyUI(policyService);
          break;
          case 2:
          UpdatePolicyUI(policyService, customerService);
          break;
          case 3:
          GetPolicyUI(policyService);
          break;
          case 4:
          running = false;
          break;
        }
      }
    }
}