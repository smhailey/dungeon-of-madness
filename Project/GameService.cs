using System;
using System.Collections.Generic;
using System.Threading;
using Madness.Project.Interfaces;
using Madness.Project.Models;

namespace Madness.Project
{
  public class GameService : IGameService
  {
    public IRoom CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }

    private bool Playing { get; set; } = true;
    public void GetUserInput()
    {

    }

    public void Go(string direction)
    {
      CurrentRoom = CurrentRoom.Go(direction);
    }

    public void Help()
    {
      Console.WriteLine("Enter \"go\" and the direction (e.g. \"n\", \"e\", \"s\", or \"w\") to go.");
      Console.WriteLine("Enter \"look\" to look around.");
      Console.WriteLine("Enter \"take\" and the name of the item you want to take.");
      Console.WriteLine("Enter \"quit\" to quit the game.");
    }

    public void Inventory()
    {

      Console.WriteLine($"{CurrentPlayer.Inventory}");
    }


    public void Look()
    {
      Console.WriteLine($"You are in the {CurrentRoom.Name}. {CurrentRoom.Description}");
      CurrentRoom.ViewItems();
    }


    public void Quit()
    {

    }

    public void Reset()
    {

    }

    public void Setup()
    {
      Room room1 = new Room("Meadow", "A great place to start. Very soft ground. You see a castle to the East.");
      Room room2 = new Room("Castle", "This is a small castle with a door to the East and a door to the North.");
      Room room3 = new Room("Closet", "A small closet.");
      Room room4 = new Room("Courtyard", "A small courtyard with a catapult and an elevator.");
      room1.Exits.Add("east", room2);
      room2.Exits.Add("east", room3);
      room2.Exits.Add("west", room1);
      room3.Exits.Add("west", room2);
      room4.Exits.Add("south", room2);
      Item key = new Item("key", "You see a key carelessly laying on the floor.");
      room3.Items.Add(key);
      Item catapault = new Item("catapault", "You see a catapult sitting in the corner.");
      room4.Items.Add(catapault);
      Item elevator = new Item("elevator", "You see an elevator built into the rear wall.");
      room4.Items.Add(elevator);
      CurrentRoom = room1;
      CurrentPlayer = new Player("Bob");
    }

    public void StartGame()
    {
      string greet = "Welcome to Bork";
      foreach (char letter in greet)
      {
        Console.Write(letter);
        Thread.Sleep(100);
      }
      Thread.Sleep(700);
      // Console.Clear();
      Console.WriteLine("");
      Console.WriteLine("You are falling.");
      Console.WriteLine("You've been falling for a while.");
      Console.WriteLine("You land with a thud.");
      Console.WriteLine("You bounced a few feet when you hit.");
      while (Playing)
      {
        Console.WriteLine("");
        Look();
        Console.Write("What do you want to do? (Type \"help\" for help): ");
        string[] input = Console.ReadLine().ToLower().Split(' ');
        // Console.Clear();
        string command = input[0];
        string option = "";
        if (input.Length > 1)
        {
          option = input[1];
        }
        switch (command)
        {
          case "go":
            Go(option);
            break;
          case "look":
            Look();
            break;
          case "inv":
            CurrentPlayer.ViewInventory();
            break;
          case "quit":
            Playing = false;
            Console.WriteLine("Goodbye");
            Thread.Sleep(800);
            // Console.Clear();
            break;
          case "take":
            TakeItem(option);
            break;
          case "help":
            break;
          default:
            Console.WriteLine("Unknown Command");
            break;
        }
      }
    }

    public void TakeItem(string itemName)
    {
      Item item = CurrentRoom.Items.Find(Item => Item.Name.ToLower() == itemName);
      if (item != null)
      {
        CurrentRoom.Items.Remove(item);
        CurrentPlayer.Inventory.Add(item);
        CurrentPlayer.ViewInventory();
        // Console.WriteLine($"Inventory: {CurrentPlayer.Inventory}");
      }
      else
      {
        Console.WriteLine("Nothing to take.");
      }
    }

    public void UseItem(string itemName)
    {
      Item item = CurrentPlayer.Inventory.Find(Item => Item.Name.ToLower() == itemName);
      // if (item != null && item.Name.ToLower() == Item.key)
      // {
      //   if (CurrentRoom == Room.room2)
      //   {
      //     Console.WriteLine("Door is unlocked.");
      //     room2.Exits.Add("north", room4);
      //   }
      //   else
      //   {
      //     Console.WriteLine("The key does not fit any door here.");
      //   }
      // }
      // if (item != null && item.Name.ToLower() == room4.Item.catapault)
      // {
      //   Console.WriteLine("You climb into the catapult and cut the restraining rope. You slam into the wall.  You are now a meat pancake.  You lose.");
      //   Console.WriteLine("Do you want to play again? (y/n)");
      //   string input = Console.ReadLine().ToLower();
      //   if (input == "y")
      //   {
      //     Reset();
      //   }
      //   if (input == "n")
      //   {
      //     Playing = false;
      //   }
      // }
      // if (item != null && item.Name.ToLower() == room4.Item.elevator)
      // {
      //   Console.WriteLine("You step into the elevator and press the only button. The doors close and you listen to \"The Girl from Ipanema\" playing softly as the elevator takes to back to your home. Congratulations. You win. Try to pay attention to where you are walking next time.");
      //   Console.WriteLine("Do you want to play again? (y/n)");
      //   string input = Console.ReadLine().ToLower();
      //   if (input == "y")
      //   {
      //     Reset();
      //   }
      //   if (input == "n")
      //   {
      //     Playing = false;
      //   }
      // }
    }
  }
}
