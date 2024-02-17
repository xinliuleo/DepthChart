namespace DepthChart.helpers;

public static class DepthChartExtensions
{
  public static void PrintDepthChart<TPosition,TPlayer>(this Dictionary<TPosition, List<TPlayer>> depthChart) where TPosition : notnull where TPlayer : Player
  {
    foreach (var chartForPosition in depthChart)
    {
      var playerList = chartForPosition.Value.ConvertAll(x => $"(#{x.Number}, {x.FirstName} {x.LastName})");
      Console.WriteLine($"{chartForPosition.Key.ToString()?.ToUpper()} - {string.Join(", ", playerList)}");
    }
  }
}
