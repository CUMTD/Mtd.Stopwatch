using Mtd.Core.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Mtd.Stopwatch.Core.Entities.Transit;

public abstract class Stop : Entity, IIdentity<string>, IImportable
{
	public required string Id { get; set; }
	public string? SmsCode { get; private set; }

	private string _name;
	public required string Name
	{
		get => _name;
		set => _name = value?.Replace(" and ", " & ") ?? string.Empty;
	}

	protected string? _city;
	public virtual string? City
	{
		get => _city;
		set => _city = value;
	}

	public string? Description { get; set; }
	public required double Latitude { get; set; }
	public required double Longitude { get; set; }
	public string? Url { get; set; }
	public required string Timezone { get; set; }
	public bool? Accessible { get; set; }
	public bool Active { get; set; }
	public string? PlatformCode { get; set; }
	public DateTime ImportTime { get; set; }

	protected Stop()
	{
		_name = string.Empty;
		Accessible = null;
	}

	[SetsRequiredMembers]
	protected Stop(string id, string name, double latitude, double longitude, string? city, DateTime importTime, string timezone = "America/Chicago", bool accessible = true, bool active = true) : this()
	{
		Id = id;
		Name = name;
		City = city;
		Timezone = timezone;
		Accessible = accessible;
		Active = active;
		ImportTime = importTime;
		Latitude = latitude;
		Longitude = longitude;
	}

	public void SetSmsCode(string code)
	{
		if (string.IsNullOrEmpty(code))
		{
			SmsCode = null;
			return;
		}

		code = code.ToUpper();
		if (code.StartsWith("MTD") && code.Length == 7)
		{
			// strip MTD off the front
			SmsCode = code[3..];
			return;
		}
		else if (code.Length == 4)
		{
			SmsCode = code;
			return;
		}

		throw new ArgumentException(code, nameof(code));
	}

	public static bool StopCodeIsParent(string stopCode) => !(string.IsNullOrEmpty(stopCode) || stopCode.Contains(':') || stopCode.Contains('-'));

	public double Distance(Stop other) => Distance(this, other);

	public static double Distance(double latitude, double longitude, double otherLatitude, double otherLongitude)
	{
		var d1 = latitude * (Math.PI / 180.0);
		var num1 = longitude * (Math.PI / 180.0);
		var d2 = otherLatitude * (Math.PI / 180.0);
		var num2 = (otherLongitude * (Math.PI / 180.0)) - num1;
		var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) + (Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0));
		return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
	}

	public static double Distance(Stop stop, Stop other)
	{
		var d1 = stop.Latitude * (Math.PI / 180.0);
		var num1 = stop.Longitude * (Math.PI / 180.0);
		var d2 = other.Latitude * (Math.PI / 180.0);
		var num2 = (other.Longitude * (Math.PI / 180.0)) - num1;
		var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) + (Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0));
		return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
	}

	internal void SetLocation(double stop_lat, double stop_lon)
	{
		Latitude = stop_lat;
		Longitude = stop_lon;
	}
}
