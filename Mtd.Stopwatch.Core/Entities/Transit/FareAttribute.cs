using Mtd.Core.Entities;

namespace Mtd.Stopwatch.Core.Entities.Transit;

public class FareAttribute : Entity, IIdentity<string>
{
	public required string Id { get; set; }
	public required decimal Price { get; set; }
	public required string Currency { get; set; } = "USD";
	public required bool CanPrepay { get; set; }
	public required byte Transfers { get; set; }
}
