using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Room : IRoom
  {

    public void AddExit(Room exit, string dir)
    {
      Exits.Add(dir, exit);
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; } = new List<Item>();
    public Dictionary<string, IRoom> Exits { get; set; } = new Dictionary<string, IRoom>();
    public Room(string name, string description)
    {
      Name = name;
      Description = description;
    }
  }
}