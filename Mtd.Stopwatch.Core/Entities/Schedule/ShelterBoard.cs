using Mtd.Core.Entities;
using Mtd.Stopwatch.Core.Entities.Transit;
using System.Diagnostics.CodeAnalysis;

namespace Mtd.Stopwatch.Core.Entities.Schedule;

public class ShelterBoard : GuidEntity
{
	public required string StopId { get; set; }
	public required string Name { get; set; }
	public required decimal WidthInches { get; set; }
	public required decimal HeightInches { get; set; }
	public required FrameType FrameType { get; set; }
	public required ContentType ContentType { get; set; }
	public required bool Deleted { get; set; }
	public string? Notes { get; set; }

	public virtual required Stop Stop { get; set; }

	protected ShelterBoard()
	{
		Stop = null!;
	}

	[SetsRequiredMembers]
		public ShelterBoard(string stopId, string name, decimal widthInches, decimal heightInches, FrameType frameType, ContentType contentType, bool deleted) : this()
	{
		StopId = stopId;
		Name = name;
		WidthInches = widthInches;
		HeightInches = heightInches;
		FrameType = frameType;
		ContentType = contentType;
		Deleted = deleted;
		Stop = null!;
	}
}
