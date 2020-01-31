using System.Collections.Generic;
using ConsoleAdventure.Project.Controllers;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project
{
  public class GameService : IGameService
  {
    private IGame _game { get; set; }

    public List<string> Messages { get; set; } = new List<string>();
    public GameService()
    {
      _game = new Game();
      Messages = new List<string>();
    }
    public void Go(string direction)
    {
      if (_game.CurrentRoom.Exits.ContainsKey(direction))
      {
        System.Console.Clear();
        _game.CurrentRoom = _game.CurrentRoom.Exits[direction];
        System.Console.WriteLine($"You have entered {_game.CurrentRoom.Name}");
      }
    }
    public void Help()
    {
      System.Console.WriteLine("type (go 'direction') to move to a different room");
      System.Console.WriteLine("type (look) to get the current rooms description");
      System.Console.WriteLine("type (reset) to start the game over");
      System.Console.WriteLine("type (inventory) to view your inventory");
      System.Console.WriteLine("type (Take 'item') to take an accesable item");
      System.Console.WriteLine("type (use 'item') to use an item in your inventory");

    }

    public void Inventory()
    {
      Messages.Add("_-Inventory-_");
      foreach (var item in _game.CurrentPlayer.Inventory)
      {
        System.Console.Clear();
        Messages.Add($"{item.Name}-------{item.Description}");

      }
    }

    public void Look()
    {
      System.Console.WriteLine(_game.CurrentRoom.Description);
      if (_game.CurrentRoom.Items.Count > 0)
      {
        foreach (var item in _game.CurrentRoom.Items)
        {
          Messages.Add($"There is also {item.Name} in here.");
        }
      }

    }
    ///<summary>
    ///Restarts the game 
    ///</summary>
    public void Reset()
    {
      System.Console.Clear();
      _game.Setup();
      Messages.Add("you just restared... way to go");
    }

    public void Setup(string playerName)
    {
      playerName = _game.CurrentPlayer.Name;
    }
    ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
    public void TakeItem(string itemName)
    {
      var item = _game.CurrentRoom.Items.Find(i => i.Name.ToLower() == itemName.ToLower());
      _game.CurrentPlayer.Inventory.Add(item);
      _game.CurrentRoom.Items.Remove(item);
      Messages.Add($"you have snagged {item.Name}");

    }
    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    public void UseItem(string itemName)
    {
      var tool = _game.CurrentPlayer.Inventory.Find(t => t.Name.ToLower() == itemName.ToLower());
      _game.CurrentPlayer.Inventory.Remove(tool);
      if (itemName.ToLower() == "slippers")
      {
        Messages.Add("You are now a slippery snake");
      }
      else if (itemName.ToLower() == "mystery item")
      {
        Messages.Add("Way to go this is the only way to win");
      }
      else if (itemName.ToLower() == "squeaker")
      {
        Messages.Add("UHHH OHHHH!!! you made to much noice and mom and dad put your ass to bed");
        _game.Setup();
      }
      else if (itemName.ToLower() == "cookie")
      {
        System.Console.Clear();
        Messages.Add("THATS WHAT IM TALKING ABOUT BABY!!!");
        Messages.Add("THATS WHAT IM TALKING ABOUT BABY!!!");
        Messages.Add("THATS WHAT IM TALKING ABOUT BABY!!!");
        Messages.Add("THATS WHAT IM TALKING ABOUT BABY!!!");
        Messages.Add("THATS WHAT IM TALKING ABOUT BABY!!!");
        Messages.Add("THATS WHAT IM TALKING ABOUT BABY!!!");
        Messages.Add("THATS WHAT IM TALKING ABOUT BABY!!!");
        Messages.Add("THATS WHAT IM TALKING ABOUT BABY!!!");
        Messages.Add("THATS WHAT IM TALKING ABOUT BABY!!!");
        Messages.Add("THATS WHAT IM TALKING ABOUT BABY!!!");
        Messages.Add("THATS WHAT IM TALKING ABOUT BABY!!!");
        Messages.Add("THATS WHAT IM TALKING ABOUT BABY!!!");
        Messages.Add("THATS WHAT IM TALKING ABOUT BABY!!!");
        Messages.Add("THATS WHAT IM TALKING ABOUT BABY!!!");
        Messages.Add("THATS WHAT IM TALKING ABOUT BABY!!!");
        Messages.Add("THATS WHAT IM TALKING ABOUT BABY!!!");
        Messages.Add("THATS WHAT IM TALKING ABOUT BABY!!!");
        Messages.Add("THATS WHAT IM TALKING ABOUT BABY!!!");
        Messages.Add("THATS WHAT IM TALKING ABOUT BABY!!!");
        Messages.Add("THATS WHAT IM TALKING ABOUT BABY!!!");
        Messages.Add("THATS WHAT IM TALKING ABOUT BABY!!!");
        Messages.Add("THATS WHAT IM TALKING ABOUT BABY!!!");
        Messages.Add("THATS WHAT IM TALKING ABOUT BABY!!!");
        Messages.Add("THATS WHAT IM TALKING ABOUT BABY!!!");
        Messages.Add("THATS WHAT IM TALKING ABOUT BABY!!!");
        Messages.Add("THATS WHAT IM TALKING ABOUT BABY!!!");
        Messages.Add("THATS WHAT IM TALKING ABOUT BABY!!!");
        Messages.Add("THATS WHAT IM TALKING ABOUT BABY!!!");
        Messages.Add("THATS WHAT IM TALKING ABOUT BABY!!!");
      }
    }
    public void Start()
    {
      Messages.Add($"Starting in the : {_game.CurrentRoom.Name}");
      Messages.Add($"{_game.CurrentRoom.Description}");
    }
  }
}