
namespace FinysPractice;

using FinysPractice.Helpers;
using FinysPractice.Models;
using FinysPractice.Services;
using FinysPractice.Services.Interfaces;
using FinysPractice.UI;

public class Program
{
  public static void Main(string[] args)
  {
      Console.WriteLine("Hello, World!");
      bool running = true;
      
      ICustomerService customerService = new CustomerService();
      IPolicyService policyService = new PolicyService(customerService);

      PolicyUIService.CreatePolicyUI(policyService, customerService);

      while(running)
      {
        Console.WriteLine("\n--- Insurance System Menu ---"); 
        Console.WriteLine("1. Create Customer");
        Console.WriteLine("2. Create Policy");
        Console.WriteLine("3. Manage Existing Policies");
        Console.WriteLine("4. Manage Existing Customers");
        Console.WriteLine("5. Exit");
        int choice = InputHelper.ReadInt("Choose an option (input number): ");

        switch (choice)
        {
          case 1:
            CustomerUIService.CreateCustomerUI(customerService);
            break;
          case 2:
            PolicyUIService.CreatePolicyUI(policyService, customerService);
            break;
          case 3:
            PolicyUIService.ShowPolicyMenu(policyService, customerService);
            break;
          case 4:

            break;
          case 5:
            running = false;
            break;
        }
      }
      
  }

}