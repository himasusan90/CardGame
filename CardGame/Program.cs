// See https://aka.ms/new-console-template for more information
Game game = new Game();
string[] segs = Console.ReadLine().Split(' ');
game.AddCard(segs[0], segs[1]);
Console.WriteLine(game.CardString(0));
segs = Console.ReadLine().Split(' ');
game.AddCard(segs[0], segs[1]);
Console.WriteLine(game.CardString(1));
Console.WriteLine(game.CardBeats(0, 1) ? "true" : "false");