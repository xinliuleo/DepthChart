// See https://aka.ms/new-console-template for more information

using DepthChart;
using DepthChart.helpers;

var tomBrady = new NflPlayer { Number = 12, FirstName = "Tom", LastName = "Brady" };
var blaineGabbert = new NflPlayer { Number = 11, FirstName = "Blaine", LastName = "Gabbert" };
var kyleTrask = new NflPlayer { Number = 2, FirstName = "Kyle", LastName = "Trask" };
var mikeEvans = new NflPlayer { Number = 13, FirstName = "Mike", LastName = "Evans" };
var jaelonDarden = new NflPlayer { Number = 1, FirstName = "Jaelon", LastName = "Darden" };
var scottMiller = new NflPlayer { Number = 10, FirstName = "Scott", LastName = "Miller" };

var depthChart = new NflDepthChart();
depthChart.AddPlayerToDepthChart("QB", tomBrady, 0);
depthChart.AddPlayerToDepthChart("QB", blaineGabbert, 1);
depthChart.AddPlayerToDepthChart("QB", kyleTrask, 2);
depthChart.AddPlayerToDepthChart("LWR", mikeEvans, 0);
depthChart.AddPlayerToDepthChart("LWR", jaelonDarden, 1);
depthChart.AddPlayerToDepthChart("LWR", scottMiller, 2);

Console.WriteLine($"Back ups of {tomBrady.FirstName} {tomBrady.LastName} - QB:");
var tomBradyBackups = depthChart.GetBackups("QB", tomBrady);
tomBradyBackups.PrintPlayers();

Console.WriteLine($"Back ups of {jaelonDarden.FirstName} {jaelonDarden.LastName} - LWR:");
var jaelonDardenBackups = depthChart.GetBackups("LWR", jaelonDarden);
jaelonDardenBackups.PrintPlayers();

Console.WriteLine($"Back ups of {mikeEvans.FirstName} {mikeEvans.LastName} - QB:");
var mikeEvansBackups = depthChart.GetBackups("QB", mikeEvans);
mikeEvansBackups.PrintPlayers();

Console.WriteLine($"Back ups of {blaineGabbert.FirstName} {blaineGabbert.LastName} - QB:");
var blaineGabbertBackups = depthChart.GetBackups("QB", blaineGabbert);
blaineGabbertBackups.PrintPlayers();

Console.WriteLine($"Back ups of {kyleTrask.FirstName} {kyleTrask.LastName} - QB:");
var kyleTraskBackups = depthChart.GetBackups("QB", kyleTrask);
kyleTraskBackups.PrintPlayers();

Console.WriteLine("Full Depth Chart:");
depthChart.GetFullDepthChart().PrintDepthChart();

Console.WriteLine($"Remove {mikeEvans.FirstName} {mikeEvans.LastName} from depth chart:");
var removedPlayer = depthChart.RemovePlayerFromDepthChart("LWR", mikeEvans);
removedPlayer.PrintPlayer();

Console.WriteLine("Full Depth Chart:");
depthChart.GetFullDepthChart().PrintDepthChart();

