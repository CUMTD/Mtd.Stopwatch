using Mtd.Core.Entities;

namespace Mtd.Stopwatch.Core.Entities.Api;

public class Developer : GuidEntity
{
	public string Name { get; protected set; }
	public int TokensPerHour { get; protected set; }
	public float CurrentTokens { get; protected set; }
	public DateTimeOffset LastTokenCountUpdate { get; protected set; }
	public bool IsActive { get; protected set; }

	public virtual ICollection<ApiKey> ApiKeys { get; protected set; }

	protected Developer()
	{
		Name = string.Empty;
		TokensPerHour = 1000;
		CurrentTokens = 1000;
		LastTokenCountUpdate = DateTimeOffset.UtcNow;
		IsActive = true;
		ApiKeys = [];
	}

	public Developer(string name, int tokensPerHour = 1000) : this()
	{
		Name = name;
		TokensPerHour = tokensPerHour;
		CurrentTokens = tokensPerHour;
	}

	public void UpdateTokens(float currentTokens, DateTimeOffset lastTokenCountUpdate)
	{
		if (currentTokens < 0)
		{
			currentTokens = 0;
		}

		CurrentTokens = currentTokens;
		LastTokenCountUpdate = lastTokenCountUpdate;
	}

	public void SetActive(bool isActive) => IsActive = isActive;
}
