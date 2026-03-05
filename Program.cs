
namespace FinysPractice;
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

      CustomerUIService.CreateCustomerUI(customerService);
      PolicyUIService.CreatePolicyUI(policyService, customerService);

      while(running)
      {
        Console.WriteLine("\n--- Insurance System Menu ---"); 
        Console.WriteLine("1. Create Customer");
        Console.WriteLine("2. Create Policy");
        Console.WriteLine("3. Manage Existing Policies");
        Console.WriteLine("4. Manage Existing Customers");
        Console.WriteLine("5. Exit");
        Console.Write("Choose an option (input number): ");

        string? choice = Console.ReadLine();
        Console.WriteLine($"This is your choice: {choice}");
      }
      
  }

}