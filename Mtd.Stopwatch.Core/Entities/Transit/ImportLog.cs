using Mtd.Core.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Mtd.Stopwatch.Core.Entities.Transit;

public class ImportLog : GuidEntity
{
	public required DateTime Start { get; set; }
	public DateTime? Finish { get; set; }

	public long? Ticks { get; protected set; }

	public string? FileName { get; set; }
	public required string ImportedBy { get; set; }
	public required string ImportedMachine { get; set; }
	public TimeSpan ElapsedTime
	{
		get => Ticks.HasValue ? TimeSpan.FromTicks(Ticks.Value) : DateTime.Now - Start;
		set => Ticks = value.Ticks;
	}

	public required bool Success { get; set; }

	public bool LikelyInProgress => !Finish.HasValue && Start.AddMinutes(20) > DateTime.Now;
	public bool LikelyFailed => !Success && !LikelyInProgress;

	protected ImportLog()
	{
		Id = Guid
			.NewGuid()
			.ToString();
		Success = false;
	}

	[SetsRequiredMembers]
	public ImportLog(DateTime start, string fileName) : this()
	{
		Start = start;
		FileName = fileName;
		ImportedBy = Environment.UserName;
		ImportedMachine = Environment.MachineName;
	}
}
