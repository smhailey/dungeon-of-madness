using System.Collections.Generic;
using Madness.Project.Interfaces;
using Madness.Project.Models;

namespace Madness.Project
{
  public class GameService : IGameService
  {
    public IRoom CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }

    public void GetUserInput()
    {

    }

    public void Go(string direction)
    {

    }

    public void Help()
    {

    }

    public void Inventory()
    {

    }

    public void Look()
    {

    }

    public void Quit()
    {

    }

    public void Reset()
    {

    }

    public void Setup()
    {
      Room room1 = new Room("Meadow", "A great place to start. Very soft floor. You see a castle to the East");
      Room room2 = new Room("Castle", "This is a small castle with a door to the East and a locked door to the North.");
      Room room3 = new Room("Closet", "A small closet.");
      Room room4 = new Room("Courtyard", "A small courtyard with a catapult and an elevator.");

      room1.Exits("east", room2);
    }

    public void StartGame()
    {

    }

    public void TakeItem(string itemName)
    {

    }

    public void UseItem(string itemName)
    {

    }
  }
}