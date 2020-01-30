using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project.Controllers
{

  public class GameController : IGameController
  {
    private GameService _gameService = new GameService();
    public bool _running = true;

    //NOTE Makes sure everything is called to finish Setup and Starts the Game loop
    public void Run()
    {

      Console.Clear();
      Console.Beep();
      System.Console.WriteLine("WELCOME TO THE BABYRUNNER!");
      System.Console.WriteLine(""); //LINEBREAK
      _gameService.Start();
      while (_running)
      {
        Print();
        System.Console.WriteLine("");//LINEBREAK
        GetUserInput();
      }

    }

    //NOTE Gets the user input, calls the appropriate command, and passes on the option if needed.
    public void GetUserInput()
    {
      Console.WriteLine("What would you like to do?");
      string input = Console.ReadLine().ToLower() + " ";
      string command = input.Substring(0, input.IndexOf(" "));
      string option = input.Substring(input.IndexOf(" ") + 1).Trim();
      //NOTE this will take the user input and parse it into a command and option.
      //IE: take silver key => command = "take" option = "silver key"
      switch (command)
      {
        case "go":
          _gameService.Go(option);
          break;
        case "look":
          _gameService.Look();
          break;
        case "quit":
          _running = false;
          break;
        case "help":
          _gameService.Help();
          break;
        case "reset":
          _gameService.Reset();
          break;
        default:
          System.Console.WriteLine("INVALID INPUT");
          break;
      }

    }

    //NOTE this should print your messages for the game.
    private void Print()
    {
      foreach (string message in _gameService.Messages)
      {
        System.Console.WriteLine(message);
      }
      _gameService.Messages.Clear();

    }

  }
}