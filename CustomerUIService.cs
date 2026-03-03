namespace FinysPractice.Services;
using FinysPractice.Helpers;

public static class CustomerUIService
{ 
  static void CreateCustomerUI(CustomerService service)
  {
    int id = InputHelper.ReadInt("Enter ID: ");
    string name = InputHelper.ReadString("Enter Name: ");
    int age = InputHelper.ReadInt("Enter age: ");
    string state = InputHelper.ReadString("Enter state: ");

    CustomerService customerService = new();
    customerService.CreateCustomer(id, name, age, state);
    Console.WriteLine($"Customer {name} created.");
  }
}