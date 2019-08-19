using System;
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
      Console.Write("What do you want to do? (Enter \"help\" for help): ");
      string[] input = Console.ReadLine().ToLower().Split(' ');
      Console.Clear();
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
          break;
        case "inv":
          CurrentPlayer.ViewInventory();
          break;
        case "quit":
          Quit();
          break;
        case "take":
          TakeItem(option);
          break;
        case "use":
          UseItem(option);
          break;
        case "help":
          Console.WriteLine("Enter \"quit\" to quit the game.");
          Console.WriteLine("Enter \"go\" followed by a direction (i.e. \"north\", \"east\", \"south\", or \"west\") to move around the map. ");
          Console.WriteLine("Enter \"look\" to look at your surroundings.");
          Console.WriteLine("Enter \"take\" followed by the name of an item to put it in your inventory.");
          Console.WriteLine("Enter \"inv\" to check your inventory.");
          Console.WriteLine("Enter \"use\" followed by the name of an item to use the item.");
          break;
        default:
          Console.WriteLine("Unknown Command");
          break;
      }
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
      Playing = false;
      Console.WriteLine("Goodbye");
      Thread.Sleep(800);
      Console.Clear();
    }

    public void Reset()
    {

    }

    public void Setup()
    {
      Room room1 = new Room("Meadow", "A great place to start. Very soft ground. You see a castle to the East.");
      Room room2 = new Room("Castle", "This is a small castle with a door to the East, a door to the West, and a locked door to the North.");
      Room room3 = new Room("Closet", "A small closet with only 1 door; the one you just entered from.");
      // room4 & entrance to room4 are added in the AddCoutyard() method in the UseItem() method.
      room1.Exits.Add("east", room2);
      room2.Exits.Add("east", room3);
      room2.Exits.Add("west", room1);
      room3.Exits.Add("west", room2);
      Item key = new Item("key", "You see a key carelessly laying on the floor.");
      room3.Items.Add(key);
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
      Console.Clear();
      Console.WriteLine("");
      Console.WriteLine("You are falling.");
      Console.WriteLine("You've been falling for a while.");
      Console.WriteLine("You land with a thud.");
      Console.WriteLine("You bounced a few feet when you hit.");
      while (Playing)
      {
        Console.WriteLine("");
        Look();
        GetUserInput();
      }
    }

    public void TakeItem(string itemName)
    {
      Item item = CurrentRoom.Items.Find(Item => Item.Name.ToLower() == itemName);
      if (item == null)
      {
        Console.WriteLine("Nothing to take.");
      }
      else if (item.Name == "catapult")
      {
        Console.WriteLine("Cannot take the catapult. Try using it instead.");
      }
      else if (item.Name == "elevator")
      {
        Console.WriteLine("Cannot take the elevator. Try using it instead.");
      }
      else
      {
        CurrentRoom.Items.Remove(item);
        CurrentPlayer.Inventory.Add(item);
        CurrentPlayer.ViewInventory();
      }
    }
    public void UseItem(string itemName)
    {
      Item item = CurrentPlayer.Inventory.Find(Item => Item.Name.ToLower() == itemName);
      if (CurrentRoom.Name == "Courtyard")
      {
        if (itemName == "catapult")
        {
          Console.Clear();
          Console.WriteLine("You climb into the catapult and cut the restraining rope. You slam into the wall. You are now a meat pancake. You lose.");
          Thread.Sleep(6000);
          // FIXME fix reset method in code below
          // Console.WriteLine("Do you want to play again? (y/n)");
          // string input = Console.ReadLine().ToLower();
          // if (input == "y")
          // {
          //   Reset();
          // }
          // if (input == "n")
          // {
          Quit();
          // Playing = false;
          //   }
        }
        else if (itemName == "elevator")
        {
          Console.Clear();
          Console.WriteLine("You step into the elevator and press the only button. The doors close and you listen to \"The Girl from Ipanema\" playing softly as the elevator takes you back to your home. Congratulations. You win. Try to pay attention to where you are walking next time.");
          Thread.Sleep(7000);
          // FIXME fix reset method in code below
          //   Console.WriteLine("Do you want to play again? (y/n)");
          //   string input = Console.ReadLine().ToLower();
          //   if (input == "y")
          //   {
          //     Reset();
          //   }
          //   if (input == "n")
          //   {
          Quit();
          // Playing = false;
          //   }
        }
        else if (itemName == "key")
        {
          Console.WriteLine($"You do not have a {itemName}.");
        }
        else
        {
          Console.WriteLine($"No {itemName} here to use.");
        }
      }
      else if (CurrentRoom.Name == "Castle" && item != null && item.Name == "key")
      {
        AddCoutyard();
        Console.WriteLine("The door is now unlocked.");
        CurrentPlayer.Inventory.Remove(item);
        CurrentPlayer.ViewInventory();
      }
      else if (CurrentRoom.Name != "Castle" && item != null && item.Name == "key")
      {
        Console.WriteLine("The key does not fit any door here.");
      }
      else if (item == null)
      {
        Console.WriteLine($"You do not have a {itemName}.");
      }
    }

    private void AddCoutyard()
    {
      CurrentRoom.Description = "This is a small castle with a door to the East, a door to the West, and a door to the North.";
      Room room4 = new Room("Courtyard", "A small courtyard containing a catapult, an elevator, and a single door to the South from which you just entered.");
      Item catapault = new Item("catapault", "You see a catapult sitting in the corner.");
      room4.Items.Add(catapault);
      Item elevator = new Item("elevator", "You see an elevator built into the rear wall.");
      room4.Items.Add(elevator);
      CurrentRoom.Exits.Add("north", room4);
      room4.Exits.Add("south", CurrentRoom);
    }
  }
}
