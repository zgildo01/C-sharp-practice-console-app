namespace FinysPractice.UI;
using FinysPractice.Helpers;
using FinysPractice.Services.Interfaces;

public static class CustomerUIService
{
    public static void CreateCustomerUI(ICustomerService service)
    {
      int id = InputHelper.ReadInt("Enter ID: ");
      string name = InputHelper.ReadString("Enter Name: ");
      int age = InputHelper.ReadInt("Enter age: ");
      string state = InputHelper.ReadString("Enter state: ");

      service.CreateCustomer(id, name, age, state);
      Console.WriteLine($"Customer {name} created.");
    }
    public static void GetCustomerUI(ICustomerService service)
    {
      
    }
    public static void DeleteCustomerUI(ICustomerService service)
    {
      
    }
    public static void UpdateCustomerUI(ICustomerService service)
    {
      
    }
    public static void ShowCustomerMenu(ICustomerService service)
    {
      bool running = true;
      
      while (running)
      {
        Console.WriteLine("1. Delete A Customer");
        Console.WriteLine("2. Update A Customer");
        Console.WriteLine("3. Get Details Of Customer");
        Console.WriteLine("4. Return");
        int choice = InputHelper.ReadInt("Choose an option (input number): ");

        switch (choice)
        {
          case 1:
          DeleteCustomerUI(service);
          break;
          case 2:
          UpdateCustomerUI(service);
          break;
          case 3:
          GetCustomerUI(service);
          break;
          case 4:
          running = false;
          break;
        }
      }
    }
}