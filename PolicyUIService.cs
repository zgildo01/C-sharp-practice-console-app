namespace FinysPractice.UI;
using FinysPractice.Helpers;
using FinysPractice.Services;
public static class PolicyUIService
{
  public static void CreatePolicyUI(PolicyService service)
  {
    int id = InputHelper.ReadInt("Enter policy ID: ");
    decimal basePremium = InputHelper.ReadDecimal("Enter base premium: ");
    bool active = InputHelper.ReadBool("Active? (true/false): ");
    int customerId = InputHelper.ReadInt("Enter customer ID: ");

    try
    {
      bool policy = service.CreatePolicy(id, basePremium, active, customerId);
      if(policy)
      {
        
      }
    } catch (Exception e)
    {
      Console.WriteLine($"Error: {e.Message}");
    }
  }
}