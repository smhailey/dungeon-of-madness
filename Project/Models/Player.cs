using System;
using System.Collections.Generic;
using Madness.Project.Interfaces;

namespace Madness.Project.Models
{
  public class Player : IPlayer
  {

    public void ViewInventory()
    {
      if (Inventory.Count != 0)
      {
        Inventory.ForEach(Item =>
        {
          Console.WriteLine(Item.Name);
        });
      }
      else
        Console.WriteLine("Nothing in inventory");
    }

    public string PlayerName { get; set; }
    public List<Item> Inventory { get; set; }

    public Player(string playerName)
    {
      PlayerName = playerName;
      Inventory = new List<Item>();
    }
  }
}