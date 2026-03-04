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
}