using System;
using Madness.Project;

namespace Madness
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Console.Clear();
      GameService gameService = new GameService();
      gameService.Setup();
      gameService.StartGame();
    }
  }
}
