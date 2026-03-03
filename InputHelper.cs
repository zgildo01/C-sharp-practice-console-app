namespace FinysPractice.Helpers;

public static class InputHelper
{
  public static int ReadInt(string prompt)
  {
    Console.Write(prompt);
    int value;

    while (!int.TryParse(Console.ReadLine(), out value))
    {
      Console.Write("Invalid number. Try again: ");
    }

    return value;
  }
  public static bool ReadBool(string prompt)
  {
    Console.Write(prompt);
    bool value;
    
    while (!bool.TryParse(Console.ReadLine(), out value))
    {
      Console.Write("Invalid input. Enter true or false: ");
    }

    return value;
  }
  public static decimal ReadDecimal(string prompt)
  {
    Console.Write(prompt);
    decimal value;

    while (!decimal.TryParse(Console.ReadLine(), out value))
    {
      Console.Write("Invalid decimal. Try again: ");
    }

    return value;
  }
  public static string ReadString(string prompt)
  {
    Console.Write(prompt);
    string? input = Console.ReadLine();

    while (string.IsNullOrEmpty(input))
    {
      Console.Write("Input cannot be empty. Try again: ");
      input = Console.ReadLine();
    }

    return input.Trim();
  }
  public static int ReadDigitsOnly(string prompt)
  {
    Console.Write(prompt);
    var buffer = new List<char>();

    while (true)
    {
      var key = Console.ReadKey(intercept: true);

      if(key.Key == ConsoleKey.Enter)
      {
        Console.WriteLine();
        break;
      }

      if (char.IsDigit(key.KeyChar))
      {
        buffer.Add(key.KeyChar);
        Console.Write(key.KeyChar);
      }
    }

    return int.Parse(new string(buffer.ToArray()));
  }
}