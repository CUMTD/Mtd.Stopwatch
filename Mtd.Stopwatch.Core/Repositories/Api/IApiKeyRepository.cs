using Mtd.Core.Repositories;
using Mtd.Stopwatch.Core.Entities.Api;

namespace Mtd.Stopwatch.Core.Repositories.Api;

public interface IApiKeyRepository<T_Collection> : IAsyncReadable<ApiKey, T_Collection>, IAsyncWriteable<ApiKey, T_Collection>, IDisposable
where T_Collection : IEnumerable<ApiKey>
{
	public Task<T_Collection> GetAllActiveWithDevelopers(CancellationToken cancellationToken);
	public Task<ApiKey> GetApiKey(Guid apiKey, CancellationToken cancellationToken);
	public Task<ApiKey> GetApiKey(string apiKey, CancellationToken cancellationToken);
	public Task<ApiKey?> GetApiKeyOrDefault(Guid apiKey, CancellationToken cancellationToken);
	public Task<ApiKey?> GetApiKeyOrDefault(string apiKey, CancellationToken cancellationToken);
	public Task<ApiKey> GetApiKeyWithDeveloper(Guid apiKey, CancellationToken cancellationToken);
	public Task<ApiKey> GetApiKeyWithDeveloper(string apiKey, CancellationToken cancellationToken);
	public Task<ApiKey?> GetApiKeyWithDeveloperOrDefault(Guid apiKey, CancellationToken cancellationToken);
	public Task<ApiKey?> GetApiKeyWithDeveloperOrDefault(string apiKey, CancellationToken cancellationToken);
}
