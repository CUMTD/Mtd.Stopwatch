using Mtd.Core.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Mtd.Stopwatch.Core.Entities.Transit;

public class Vehicle : Entity, IIdentity<string>
{
	public required string Id { get; set; }
	public string? VehicleNumber { get; set; }
	public required string VehicleConfigurationId { get; set; }
	public required bool IsActive { get; set; }
	public string? VIN { get; set; }
	public string? LicensePlateNumber { get; set; }
	public DateOnly? DateInService { get; set; }
	public virtual VehicleConfiguration VehicleConfiguration { get; set; } = default!;
	public virtual ICollection<VehicleAttribute> Attributes { get; set; }

	protected Vehicle()
	{
		Attributes = [];
	}

	[SetsRequiredMembers]
	public Vehicle(string id, string vehicleNumber, string vehicleConfigurationId, bool isActive, string vin, string licensePlateNumber, DateOnly dateInService) : this()
	{
		Id = id;
		VehicleNumber = vehicleNumber;
		VehicleConfigurationId = vehicleConfigurationId;
		IsActive = isActive;
		VIN = vin;
		LicensePlateNumber = licensePlateNumber;
		DateInService = dateInService;
	}
}
