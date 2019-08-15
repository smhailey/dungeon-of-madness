using System.Collections.Generic;
using Madness.Project.Interfaces;

namespace Madness.Project.Models
{
  public class Player : IPlayer
  {
    public string PlayerName { get; set; }
    public List<Item> Inventory { get; set; }
  }
}