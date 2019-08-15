using System.Collections.Generic;
using Madness.Project.Interfaces;

namespace Madness.Project.Models
{
  public class Item : IItem
  {
    public string Name { get; set; }
    public string Description { get; set; }
  }
}