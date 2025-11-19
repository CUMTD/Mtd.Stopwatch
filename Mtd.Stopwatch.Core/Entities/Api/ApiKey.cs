using Mtd.Core.Entities;

namespace Mtd.Stopwatch.Core.Entities.Api;
public class ApiKey : Entity
{
	public string Key { get; init; }
	public string DeveloperId { get; protected set; }
	public string Name { get; protected set; }
	public string? Notes { get; protected set; }
	public bool IsActive { get; protected set; }
	public virtual Developer? Developer { get; protected set; }

	protected ApiKey()
	{
		Key = GuidEntity.FormatGuid(Guid.NewGuid());
		DeveloperId = string.Empty;
		Name = string.Empty;
		Notes = null;
		IsActive = true;
	}

	public ApiKey(string name, string? notes = null) : this()
	{
		Name = name;
		Notes = notes;
	}

	public ApiKey(Guid developerId, string name, string? notes = null) : this()
	{
		DeveloperId = GuidEntity.FormatGuid(developerId);
		Name = name;
		Notes = notes;
	}

	public void SetActive(bool isActive) => IsActive = isActive;
}
