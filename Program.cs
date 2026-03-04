
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
        Console.WriteLine("3. View Policy by ID"); 
        Console.WriteLine("4. Update Policy Premium"); 
        Console.WriteLine("5. Delete Policy"); 
        Console.WriteLine("6. List Active Policies"); 
        Console.WriteLine("7. Exit"); 
        Console.Write("Choose an option: ");

        string? choice = Console.ReadLine();
        Console.WriteLine($"This is your choice: {choice}");
      }
      
  }

}