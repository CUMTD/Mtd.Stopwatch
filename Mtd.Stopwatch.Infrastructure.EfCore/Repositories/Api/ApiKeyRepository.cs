using Microsoft.EntityFrameworkCore;
using Mtd.Core.Entities;
using Mtd.Infrastructure.EFCore.Repositories;
using Mtd.Stopwatch.Core.Entities.Api;
using Mtd.Stopwatch.Core.Repositories.Api;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Repositories.Api;

public class ApiKeyRepository(StopwatchContext context)
	: AsyncEFRepository<ApiKey>(context), IApiKeyRepository<IReadOnlyCollection<ApiKey>>
{
	public Task<IReadOnlyCollection<ApiKey>> GetAllActiveWithDevelopers(CancellationToken cancellationToken) => throw new NotImplementedException();
	public async Task<ApiKey> GetApiKey(Guid apiKey, CancellationToken cancellationToken)
	{
		var data = await _dbSet
			.AsQueryable()
			.SingleAsync(ak => ak.Key == GuidEntity.FormatGuid(apiKey), cancellationToken)
			.ConfigureAwait(false);
		return data;
	}

	public async Task<ApiKey> GetApiKey(string apiKey, CancellationToken cancellationToken)
	{
		var data = await _dbSet
			.AsQueryable()
			.SingleAsync(ak => ak.Key == apiKey, cancellationToken)
			.ConfigureAwait(false);
		return data;
	}
	public async Task<ApiKey?> GetApiKeyOrDefault(Guid apiKey, CancellationToken cancellationToken)
	{
		var data = await _dbSet
			.AsQueryable()
			.SingleOrDefaultAsync(ak => ak.Key == GuidEntity.FormatGuid(apiKey), cancellationToken)
			.ConfigureAwait(false);
		return data;
	}
	public async Task<ApiKey?> GetApiKeyOrDefault(string apiKey, CancellationToken cancellationToken)
	{
		var data = await _dbSet
			.AsQueryable()
			.SingleOrDefaultAsync(ak => ak.Key == apiKey, cancellationToken)
			.ConfigureAwait(false);
		return data;
	}
	public async Task<ApiKey> GetApiKeyWithDeveloper(Guid apiKey, CancellationToken cancellationToken)
	{
		var data = await _dbSet
			.AsQueryable()
			.Where(ak => ak.Key == GuidEntity.FormatGuid(apiKey))
			.Include(ak => ak.Developer)
			.SingleAsync(cancellationToken)
			.ConfigureAwait(false);
		return data;
	}
	public async Task<ApiKey> GetApiKeyWithDeveloper(string apiKey, CancellationToken cancellationToken)
	{
		var data = await _dbSet
			.AsQueryable()
			.Where(ak => ak.Key == apiKey)
			.Include(ak => ak.Developer)
			.SingleAsync(cancellationToken)
			.ConfigureAwait(false);
		return data;
	}
	public async Task<ApiKey?> GetApiKeyWithDeveloperOrDefault(Guid apiKey, CancellationToken cancellationToken)
	{
		var data = await _dbSet
			.AsQueryable()
			.Where(ak => ak.Key == GuidEntity.FormatGuid(apiKey))
			.Include(ak => ak.Developer)
			.SingleOrDefaultAsync(cancellationToken)
			.ConfigureAwait(false);
		return data;
	}
	public async Task<ApiKey?> GetApiKeyWithDeveloperOrDefault(string apiKey, CancellationToken cancellationToken)
	{
		var data = await _dbSet
			.AsQueryable()
			.Where(ak => ak.Key == apiKey)
			.Include(ak => ak.Developer)
			.SingleOrDefaultAsync(cancellationToken)
			.ConfigureAwait(false);
		return data;
	}
}
