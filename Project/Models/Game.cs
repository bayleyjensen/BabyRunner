using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Game : IGame
  {
    public IRoom CurrentRoom { get; set; }
    public IPlayer CurrentPlayer { get; set; }

    //NOTE Make yo rooms here...
    public void Setup()
    {
      //Rooms

      Room BabyRoom = new Room("Babys Room", "You are in your crib but nothing will hold you back from you true desires of wanting a choco choco chunk cookie. You see the door is open and the lights are off");

      Room ParentsRoom = new Room("Mom and Dads Room.", "You have made it to the parents room, mom is on the bed with her nose burried in a book... You see the door is wide open.");

      Room LivingRoom = new Room("Living room", "You just made it down stairs to the living room. Dads on the couch watching TV. His back is turned but Dad is all knowing. Distract dad to make the dash to the Kitchen...");

      Room Kitchen = new Room("Kitchen", "You have made it to the kitchen, eyes set on the cookie jar... However the cookie jar is on the counter and you are not tall enough to reach it.");

      Room Dungun = new Room("Dungun", "down Here you will find your deepest fears")

      CurrentRoom = BabyRoom;
      //Items
      Item Slippers = new Item("Slippers", "Make your movement quieter");

      Item MysteryTool = new Item("Mystery Tool", "This may or may not help you win");

      Item Squeaker = new Item("Squeaker", "Useful for making noise but will alert any dogs near");

      Item Cookie = new Item("Cookie", "Hooray you WON!!!");

      //Players
      Player Me = new Player("");
      CurrentPlayer = Me;



      //Creating Relationships

      BabyRoom.AddExit(ParentsRoom, "east");
      ParentsRoom.AddExit(BabyRoom, "west");
      ParentsRoom.AddExit(LivingRoom, "east");
      LivingRoom.AddExit(ParentsRoom, "west");
      LivingRoom.AddExit(Kitchen, "east");
      Kitchen.AddExit(LivingRoom, "west");
      LivingRoom.AddExit(Dungun, "east");

      BabyRoom.Items.Add(Slippers);
      ParentsRoom.Items.Add(MysteryTool);
      LivingRoom.Items.Add(Squeaker);
      Kitchen.Items.Add(Cookie);
    }
    public Game()
    {
      Setup();
    }
  }
}