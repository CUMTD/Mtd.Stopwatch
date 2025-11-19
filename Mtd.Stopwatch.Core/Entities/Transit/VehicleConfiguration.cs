using Mtd.Core.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Mtd.Stopwatch.Core.Entities.Transit;

public class VehicleConfiguration : Entity, IIdentity<string>
{
	public required string Id { get; set; }
	public required VehicleType VehicleType { get; set; }
	public required int Year { get; set; }
	public required string Make { get; set; }
	public required string Model { get; set; }
	public int? LengthFeet { get; set; }
	public required VehiclePowertrainType Powertrain { get; set; }
	public required bool IsPublic { get; set; }

	public virtual ICollection<Vehicle> Vehicles { get; set; }

	protected VehicleConfiguration()
	{
		Vehicles = [];

	}

	[SetsRequiredMembers]
	public VehicleConfiguration(string id, VehicleType vehicleType, int year, string make, string model, int? lengthFeet, VehiclePowertrainType powertrain, bool isPublic) : this()
	{
		Id = id;
		VehicleType = vehicleType;
		Year = year;
		Make = make;
		Model = model;
		LengthFeet = lengthFeet;
		Powertrain = powertrain;
		IsPublic = isPublic;
	}
}
