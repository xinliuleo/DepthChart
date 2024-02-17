namespace DepthChart;

public abstract class Player
{
  public string FirstName { get; init; } = "";
  public string LastName { get; init; } = "";
  public int Number { get; init; }

  public virtual string GetInfo()
  {
    return $"#{Number} - {FirstName} {LastName}";
  }
}
