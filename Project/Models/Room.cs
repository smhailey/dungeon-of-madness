using System;
using System.Collections.Generic;
using System.Threading;
using Madness.Project.Interfaces;

namespace Madness.Project.Models
{
  public class Room : IRoom
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Locked { get; set; }
    public List<Item> Items { get; set; }
    public Dictionary<string, IRoom> Exits { get; set; }

    public IRoom Go(string direction, bool locked)
    {
      if (Exits.ContainsKey(direction))
      {
        if (Locked == true)
        {
          Console.WriteLine("You cannot go that way");
          return this;
        }
        else
        {
          Console.WriteLine("Traveling....");
          Thread.Sleep(1000);
          Console.Clear();
          return Exits[direction];
        }
      }
      else
      {
        Console.WriteLine("You cannot go that way");
        return this;
      }
    }

    public void UseItem(Item item)
    { }

    public void ViewItems()
    {
      Items.ForEach(Item =>
      {
        Console.WriteLine(Item.Description);
      });
    }

    public Room(string name, string description, bool locked)
    {
      Name = name;
      Description = description;
      Locked = locked;
      Items = new List<Item>();
      Exits = new Dictionary<string, IRoom>();
    }
  }
}