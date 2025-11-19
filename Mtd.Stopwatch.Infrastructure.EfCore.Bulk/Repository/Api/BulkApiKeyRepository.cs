using Mtd.Infrastructure.EFCore.Bulk.Repository;
using Mtd.Stopwatch.Core.Entities.Api;
using Mtd.Stopwatch.Core.Repositories.Api;
using Mtd.Stopwatch.Core.Repositories.Bulk.Api;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Bulk.Repository.Api;

public class BulkApiKeyRepository(IApiKeyRepository<IReadOnlyCollection<ApiKey>> apiKeyRepository, StopwatchContext dbContext)
	: AsyncBulkEFRepository<ApiKey>(dbContext), IBulkApiKeyRepository<IReadOnlyCollection<ApiKey>>
{
	private readonly IApiKeyRepository<IReadOnlyCollection<ApiKey>> _apiKeyRepository = apiKeyRepository ?? throw new ArgumentNullException(nameof(apiKeyRepository));

	public Task<IReadOnlyCollection<ApiKey>> GetAllActiveWithDevelopers(CancellationToken cancellationToken) => _apiKeyRepository.GetAllActiveWithDevelopers(cancellationToken);
	public Task<ApiKey> GetApiKey(Guid apiKey, CancellationToken cancellationToken) => _apiKeyRepository.GetApiKey(apiKey, cancellationToken);
	public Task<ApiKey> GetApiKey(string apiKey, CancellationToken cancellationToken) => _apiKeyRepository.GetApiKey(apiKey, cancellationToken);
	public Task<ApiKey?> GetApiKeyOrDefault(Guid apiKey, CancellationToken cancellationToken) => _apiKeyRepository.GetApiKeyOrDefault(apiKey, cancellationToken);
	public Task<ApiKey?> GetApiKeyOrDefault(string apiKey, CancellationToken cancellationToken) => _apiKeyRepository.GetApiKeyOrDefault(apiKey, cancellationToken);
	public Task<ApiKey> GetApiKeyWithDeveloper(Guid apiKey, CancellationToken cancellationToken) => _apiKeyRepository.GetApiKey(apiKey, cancellationToken);
	public Task<ApiKey> GetApiKeyWithDeveloper(string apiKey, CancellationToken cancellationToken) => _apiKeyRepository.GetApiKey(apiKey, cancellationToken);
	public Task<ApiKey?> GetApiKeyWithDeveloperOrDefault(Guid apiKey, CancellationToken cancellationToken) => _apiKeyRepository.GetApiKeyOrDefault(apiKey, cancellationToken);
	public Task<ApiKey?> GetApiKeyWithDeveloperOrDefault(string apiKey, CancellationToken cancellationToken) => _apiKeyRepository.GetApiKeyOrDefault(apiKey, cancellationToken);
}
