using Mtd.Core.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Mtd.Stopwatch.Core.Entities.Transit;

[method: SetsRequiredMembers]
public class VehicleAttribute(string vehicleId, string name, string value) : Entity
{
	public required string VehicleId { get; set; } = vehicleId;
	public required string Name { get; set; } = name;
	public required string Value { get; set; } = value;

	public virtual Vehicle Vehicle { get; set; } = default!;
}
