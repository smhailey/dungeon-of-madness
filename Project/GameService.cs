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
      CurrentRoom = CurrentRoom.Go(direction);
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
      room1.Exits.Add("east", room2);
      room2.Exits.Add("north", room4);
      room2.Exits.Add("east", room3);
      room2.Exits.Add("west", room1);
      room3.Exits.Add("west", room2);
      room4.Exits.Add("south", room2);
      Item key = new Item("key", "Ooooo, shiny");
      room3.Items.Add(key);
      Item catapault = new Item("catapault", "Get ready to launch");
      room4.Items.Add(catapault);
      Item elevator = new Item("elevator", " Going up?");
      room4.Items.Add(elevator);
      CurrentRoom = room1;
    }

    public void StartGame()
    {

    }

    public void TakeItem(string itemName)
    {
      if (CurrentRoom is Room.room3)
      {
        var CurrentRoom = (Room)CurrentRoom;
        System.Console.Write("You take the key");
        return;
      }

    }

    public void UseItem(string itemName)
    {

    }
  }
}