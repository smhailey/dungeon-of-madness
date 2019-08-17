using System.Collections.Generic;
using Madness.Project.Models;

namespace Madness.Project.Interfaces
{
  public interface IPlayer
  {
    // IPlayer ViewInventory();
    string PlayerName { get; set; }
    List<Item> Inventory { get; set; }
  }
}
