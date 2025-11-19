using Mtd.Core.Entities;

namespace Mtd.Stopwatch.Core.Entities.Schedule;

public class Reroute : GuidEntity
{
	public required string Title { get; set; }
	public string? BriefDescription { get; set; }
	public required string Body { get; set; }
	public string? InternalInstructions { get; set; }
	public required DateTime StartDate { get; set; }
	public DateTime? EndDate { get; set; }
	public string? DurationDescription { get; set; }
	public required string Reason { get; set; }
	public required string Effect { get; set; }
	public required string PostedBy { get; set; }
	public required DateTime Timestamp { get; set; }
	public string? UpdatedBy { get; set; }
	public DateTime? UpdatedTimestamp { get; set; }
	public DateTime LastTouched => UpdatedTimestamp ?? Timestamp;
	public virtual ICollection<PublicRoute> AffectedRoutes { get; set; }

	public string DisplayPosted => !string.IsNullOrEmpty(UpdatedBy) ? UpdatedBy : PostedBy;
	public DateTime DisplayTimestamp => UpdatedTimestamp ?? Timestamp;
	public string DisplayDuration => EndDate?.ToString("MMMM d, yyyy") ?? DurationDescription ?? "Unknown";

	protected Reroute()
	{
		Timestamp = DateTime.Now;
		AffectedRoutes = [];
	}

	public Reroute(string title, string brief, string body, DateTime startDate, string reason, string postedBy, string effect) : this()
	{
		Title = title;
		BriefDescription = brief;
		Body = body;
		StartDate = startDate;
		Reason = reason;
		PostedBy = postedBy;
		Effect = effect;
	}
}
