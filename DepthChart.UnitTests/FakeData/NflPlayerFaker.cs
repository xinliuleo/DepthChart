using Bogus;

namespace DepthChart.UnitTests.FakeData;

public sealed class NflPlayerFaker: Faker<NflPlayer>
{
  public NflPlayerFaker()
  {
    StrictMode(true);
    RuleFor(r => r.FirstName, f => f.Random.String2(10));
    RuleFor(r => r.LastName, f => f.Random.String2(10));
    RuleFor(r => r.Number, f => f.Random.Int(100));
  }
}
