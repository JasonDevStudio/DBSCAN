using System.Diagnostics;
using Dbscan.RBush;
using Spectre.Console;

namespace Dbscan.Tests;

internal class Program
{
	public static void Main(string[] args)
	{
		AnsiConsole.Write(new FigletText("DBSCAN TEST").Centered().Color(Color.Red));
		AnsiConsole.Write(new Rule($"[White] {DateTime.Now:yyyy-MM-dd hh:mm:ss} Create Data [/]").Centered());
		var data = DbscanTestData.BuildRingDataset(10, 50);
		AnsiConsole.Write(new Rule().Centered());
		AnsiConsole.Write(new Rule($"[White] {DateTime.Now:yyyy-MM-dd hh:mm:ss} Create data count {data.Count}，Calculate Clusters [/]").Centered());
		var st = Stopwatch.StartNew();
		var clusters = DbscanRBush.CalculateClusters(data, 1.3, 4);

		var index = 0;
		foreach (var item in clusters.Clusters)
		{
			Console.WriteLine($"[White] Cluster Index : {index++} : {item.Objects?.Count} [/]");
		}

		AnsiConsole.Write(new Rule().Centered());
		AnsiConsole.Write(new Rule($"[White] Times ${st.Elapsed.Seconds} s, Calculated. ClusterCount : {clusters.Clusters.Count} UnclusteredCount :{clusters.UnclusteredObjects.Count}[/]").Centered());
	}
}
