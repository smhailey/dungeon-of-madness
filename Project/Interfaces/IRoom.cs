using System.Collections.Generic;
using Madness.Project.Models;

namespace Madness.Project.Interfaces
{

  public interface IRoom
  {
    void ViewItems();
    string Name { get; set; }
    string Description { get; set; }
    bool Locked { get; set; }
    List<Item> Items { get; set; }
    Dictionary<string, IRoom> Exits { get; set; }
    IRoom Go(string direction, bool locked);
  }
}
