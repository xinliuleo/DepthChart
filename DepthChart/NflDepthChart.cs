namespace DepthChart;

public class NflDepthChart
{
  private readonly Dictionary<NflPosition, List<NflPlayer>> _chart;

  public NflDepthChart()
  {
    _chart = new();
  }

  public NflDepthChart(Dictionary<NflPosition, List<NflPlayer>> chart)
  {
    _chart = chart;
  }

  public void AddPlayerToDepthChart(string position, NflPlayer player, short positionDepth)
  {
    if (!Enum.TryParse<NflPosition>(position, true, out var nflPosition))
    {
      return;
    }

    if (_chart.TryGetValue(nflPosition, out var list))
    {
      if (list.Any(x => x.Number == player.Number))
      {
        return;
      }

      list.Insert(positionDepth, player);
    }
    else
    {
      _chart.Add(nflPosition, [player]);
    }
  }

  public NflPlayer? RemovePlayerFromDepthChart(string position, NflPlayer player)
  {
    if (!Enum.TryParse<NflPosition>(position, true, out var nflPosition))
    {
      return null;
    }

    if (!_chart.TryGetValue(nflPosition, out var list))
    {
      return null;
    }

    var playerIndex = list.IndexOf(player);
    if (playerIndex == -1)
    {
      return null;
    }

    list.RemoveAt(playerIndex);
    return player;
  }

  public List<NflPlayer> GetBackups(string position, NflPlayer player)
  {
    if (!Enum.TryParse<NflPosition>(position, true, out var nflPosition))
    {
      return [];
    }

    if (!_chart.TryGetValue(nflPosition, out var list))
    {
      return [];
    }

    var playerIndex = list.IndexOf(player);
    return playerIndex == -1 ? [] : list.GetRange(playerIndex + 1, list.Count - playerIndex - 1);
  }

  public Dictionary<NflPosition, List<NflPlayer>> GetFullDepthChart()
  {
    return _chart;
  }
}
