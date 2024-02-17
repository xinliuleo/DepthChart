using DepthChart.UnitTests.FakeData;
using FluentAssertions;

namespace DepthChart.UnitTests;

public class NflDepthChartTests
{
  [Fact]
  public void ShouldAddPlayer()
  {
    // Arrange
    var depthChart = new NflDepthChart();
    var testPlayer = new NflPlayerFaker().Generate();
    var expectedChart = new Dictionary<NflPosition, List<NflPlayer>>()
    {
      { NflPosition.C, [testPlayer] }
    };

    // Act
    depthChart.AddPlayerToDepthChart("C", testPlayer, 0);

    // Assert
    depthChart.GetFullDepthChart().Should().BeEquivalentTo(expectedChart);
  }

  [Fact]
  public void ShouldNotAddDuplicatePlayerToSamePosition()
  {
    // Arrange
    var depthChart = new NflDepthChart();
    var testPlayer = new NflPlayerFaker().Generate();
    var expectedChart = new Dictionary<NflPosition, List<NflPlayer>>()
    {
      { NflPosition.C, [testPlayer] }
    };

    // Act
    depthChart.AddPlayerToDepthChart("C", testPlayer, 0);
    depthChart.AddPlayerToDepthChart("C", testPlayer, 1);

    // Assert
    depthChart.GetFullDepthChart().Should().BeEquivalentTo(expectedChart);
  }

  [Fact]
  public void ShouldAddPlayerToGivenPositionDepth()
  {
    // Arrange
    var depthChart = new NflDepthChart();
    var testPlayer = new NflPlayerFaker().Generate();
    var testPlayerTwo = new NflPlayerFaker().Generate();

    var expectedChart = new Dictionary<NflPosition, List<NflPlayer>>()
    {
      { NflPosition.C, [testPlayerTwo, testPlayer] }
    };

    // Act
    depthChart.AddPlayerToDepthChart("C", testPlayer, 0);
    depthChart.AddPlayerToDepthChart("C", testPlayerTwo, 0);

    // Assert
    depthChart.GetFullDepthChart().Should().BeEquivalentTo(expectedChart);
  }

  [Fact]
  public void ShouldNotAddPlayerToPositionNotExist()
  {
    // Arrange
    var depthChart = new NflDepthChart();
    var testPlayer = new NflPlayerFaker().Generate();
    var expectedChart = new Dictionary<NflPosition, List<NflPlayer>>();

    // Act
    depthChart.AddPlayerToDepthChart("Notexist", testPlayer, 0);

    // Assert
    depthChart.GetFullDepthChart().Should().BeEquivalentTo(expectedChart);
  }

  [Fact]
  public void ShouldAddPlayerToDifferenctPosition()
  {
    // Arrange
    var depthChart = new NflDepthChart();
    var testPlayer = new NflPlayerFaker().Generate();
    var expectedChart = new Dictionary<NflPosition, List<NflPlayer>>()
    {
      { NflPosition.C , [testPlayer]},
      { NflPosition.Qb, [testPlayer]}
    };

    // Act
    depthChart.AddPlayerToDepthChart("C", testPlayer, 0);
    depthChart.AddPlayerToDepthChart("QB", testPlayer, 0);

    // Assert
    depthChart.GetFullDepthChart().Should().BeEquivalentTo(expectedChart);
  }

  [Fact]
  public void ShouldRemovePlayerFromGivenPositionAndReturnPlayer()
  {
    // Arrange
    var testPlayer = new NflPlayerFaker().Generate();
    var testPlayerTwo = new NflPlayerFaker().Generate();
    var testPlayerThree = new NflPlayerFaker().Generate();
    var chart = new Dictionary<NflPosition, List<NflPlayer>>()
    {
      { NflPosition.C, [testPlayer, testPlayerTwo] },
      { NflPosition.Qb, [testPlayerThree]}
    };
    var depthChart = new NflDepthChart(chart);
    var expectedChart = new Dictionary<NflPosition, List<NflPlayer>>()
    {
      { NflPosition.C, [testPlayerTwo] },
      { NflPosition.Qb, [testPlayerThree]}
    };

    // Act
    var result = depthChart.RemovePlayerFromDepthChart("C", testPlayer);

    // Assert
    result.Should().BeEquivalentTo(testPlayer);
    depthChart.GetFullDepthChart().Should().BeEquivalentTo(expectedChart);
  }

  [Fact]
  public void ShouldNotRemovePlayerAndReturnNullIfPlayerNotExist()
  {
    // Arrange
    var testPlayer = new NflPlayerFaker().Generate();
    var testPlayerTwo = new NflPlayerFaker().Generate();
    var testPlayerThree = new NflPlayerFaker().Generate();
    var chart = new Dictionary<NflPosition, List<NflPlayer>>()
    {
      { NflPosition.C, [testPlayer] },
      { NflPosition.Qb, [testPlayerThree]}
    };
    var depthChart = new NflDepthChart(chart);
    var expectedChart = new Dictionary<NflPosition, List<NflPlayer>>()
    {
      { NflPosition.C, [testPlayer] },
      { NflPosition.Qb, [testPlayerThree]}
    };

    // Act
    var result = depthChart.RemovePlayerFromDepthChart("C", testPlayerTwo);

    // Assert
    result.Should().BeNull();
    depthChart.GetFullDepthChart().Should().BeEquivalentTo(expectedChart);
  }

  [Fact]
  public void ShouldNotRemovePlayerAndReturnNullIfPositionNotExist()
  {
    // Arrange
    var testPlayer = new NflPlayerFaker().Generate();
    var testPlayerTwo = new NflPlayerFaker().Generate();
    var chart = new Dictionary<NflPosition, List<NflPlayer>>()
    {
      { NflPosition.C, [testPlayer] },
      { NflPosition.Qb, [testPlayerTwo]}
    };
    var depthChart = new NflDepthChart(chart);
    var expectedChart = new Dictionary<NflPosition, List<NflPlayer>>()
    {
      { NflPosition.C, [testPlayer] },
      { NflPosition.Qb, [testPlayerTwo]}
    };

    // Act
    var result = depthChart.RemovePlayerFromDepthChart("Notexist", testPlayerTwo);

    // Assert
    result.Should().BeNull();
    depthChart.GetFullDepthChart().Should().BeEquivalentTo(expectedChart);
  }

  [Fact]
  public void ShouldReturnFullChart()
  {
    // Arrange
    var testPlayer = new NflPlayerFaker().Generate();
    var testPlayerTwo = new NflPlayerFaker().Generate();
    var chart = new Dictionary<NflPosition, List<NflPlayer>>()
    {
      { NflPosition.C, [testPlayer] },
      { NflPosition.Qb, [testPlayerTwo]}
    };
    var depthChart = new NflDepthChart(chart);
    var expectedChart = chart;

    // Act
    var result = depthChart.GetFullDepthChart();

    // Assert
    depthChart.GetFullDepthChart().Should().BeEquivalentTo(expectedChart);
  }

  [Fact]
  public void ShouldReturnBackupPlayers()
  {
    // Arrange
    var testPlayer = new NflPlayerFaker().Generate();
    var testPlayerTwo = new NflPlayerFaker().Generate();
    var testPlayerThree = new NflPlayerFaker().Generate();
    var chart = new Dictionary<NflPosition, List<NflPlayer>>()
    {
      { NflPosition.C, [testPlayer, testPlayerTwo, testPlayerThree] }
    };
    var depthChart = new NflDepthChart(chart);
    List<NflPlayer> expectPlayers = [testPlayerTwo, testPlayerThree];

    // Act
    var result = depthChart.GetBackups("C", testPlayer);

    // Assert
    result.Should().BeEquivalentTo(expectPlayers);
  }

  [Fact]
  public void ShouldReturnEmptyListIfPositionNotExist()
  {
    // Arrange
    var testPlayer = new NflPlayerFaker().Generate();
    var testPlayerTwo = new NflPlayerFaker().Generate();
    var testPlayerThree = new NflPlayerFaker().Generate();
    var chart = new Dictionary<NflPosition, List<NflPlayer>>()
    {
      { NflPosition.C, [testPlayer, testPlayerTwo, testPlayerThree] }
    };
    var depthChart = new NflDepthChart(chart);

    // Act
    var result = depthChart.GetBackups("NotExist", testPlayer);

    // Assert
    result.Should().BeEquivalentTo(new List<NflPlayer>());
  }

  [Fact]
  public void ShouldReturnEmptyListIfGivenPlayerHasNoBackup()
  {
    // Arrange
    var testPlayer = new NflPlayerFaker().Generate();
    var testPlayerTwo = new NflPlayerFaker().Generate();
    var testPlayerThree = new NflPlayerFaker().Generate();
    var chart = new Dictionary<NflPosition, List<NflPlayer>>()
    {
      { NflPosition.C, [testPlayer, testPlayerTwo, testPlayerThree] }
    };
    var depthChart = new NflDepthChart(chart);

    // Act
    var result = depthChart.GetBackups("C", testPlayerThree);

    // Assert
    result.Should().BeEquivalentTo(new List<NflPlayer>());
  }
}
