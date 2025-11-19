using Microsoft.EntityFrameworkCore;
using Mtd.Core.Entities;
using Mtd.Infrastructure.EFCore.Repositories;
using Mtd.Stopwatch.Core.Entities.Api;
using Mtd.Stopwatch.Core.Repositories.Api;
using System.Collections.Immutable;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Repositories.Api;

public class DeveloperRepository(StopwatchContext context)
	: AsyncEFIdentifiableRepository<string, Developer>(context), IDeveloperRepository<IReadOnlyCollection<Developer>>
{
	public async Task<IReadOnlyCollection<Developer>> GetAllActiveWithApiKeys(CancellationToken cancellationToken)
	{
		var set = await _dbSet
			.AsQueryable()
			.Where(d => d.IsActive)
			.Include(d => d.ApiKeys.Where(ak => ak.IsActive))
			.ToArrayAsync(cancellationToken)
			.ConfigureAwait(false);
		return set
			.ToImmutableArray();
	}

	public async Task<Developer> GetDeveloperByApiKey(string apiKey, CancellationToken cancellationToken)
	{
		var data = await _dbSet
			.AsQueryable()
			.Include(d => d.ApiKeys)
			.SingleAsync(d => d.ApiKeys.Any(ak => ak.Key == apiKey), cancellationToken)
			.ConfigureAwait(false);
		return data;
	}

	public async Task<Developer> GetDeveloperByApiKey(Guid apiKey, CancellationToken cancellationToken)
	{
		var key = GuidEntity.FormatGuid(apiKey);
		var data = await _dbSet
			.AsQueryable()
			.Include(d => d.ApiKeys)
			.SingleAsync(d => d.ApiKeys.Any(ak => ak.Key == key), cancellationToken)
			.ConfigureAwait(false);
		return data;
	}

	public async Task<Developer?> GetDeveloperByApiKeyOrDefault(string apiKey, CancellationToken cancellationToken)
	{
		var data = await _dbSet
			.AsQueryable()
			.Include(d => d.ApiKeys)
			.SingleOrDefaultAsync(d => d.ApiKeys.Any(ak => ak.Key == apiKey), cancellationToken)
			.ConfigureAwait(false);
		return data;
	}
	public async Task<Developer?> GetDeveloperByApiKeyOrDefault(Guid apiKey, CancellationToken cancellationToken)
	{
		var key = GuidEntity.FormatGuid(apiKey);
		var data = await _dbSet
			.AsQueryable()
			.Include(d => d.ApiKeys)
			.SingleOrDefaultAsync(d => d.ApiKeys.Any(ak => ak.Key == key), cancellationToken)
			.ConfigureAwait(false);
		return data;
	}
}
