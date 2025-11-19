namespace Mtd.Stopwatch.Core.Entities.Realtime;

public class Message : IRealtimeData
{
	public required string Id { get; set; }
	public string? DisplayId { get; set; }
	public required string Text { get; set; }
	public required DateTimeOffset StartTime { get; set; }
	public required DateTimeOffset? EndTime { get; set; }
	public required bool BlockRealtime { get; set; }
	public required IEnumerable<string> StopIds { get; set; }

	public Message()
	{
		StopIds = new List<string>();
	}
}
