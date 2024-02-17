namespace DepthChart.helpers;

public static class PlayerExtensions
{
  public static void PrintPlayers(this IEnumerable<Player> players)
  {
    foreach (var player in players)
    {
      Console.WriteLine(player.GetInfo());
    }
  }

  public static void PrintPlayer(this Player? player)
  {
    if(player is not null)
      Console.WriteLine(player.GetInfo());
  }
}
