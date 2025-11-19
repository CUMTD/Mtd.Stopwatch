using Mtd.Core.Repositories;
using Mtd.Stopwatch.Core.Entities.Api;

namespace Mtd.Stopwatch.Core.Repositories.Api;

public interface IDeveloperRepository<T_Collection> : IAsyncReadable<Developer, T_Collection>, IAsyncWriteable<Developer, T_Collection>, IAsyncIdentifiable<string, Developer>, IDisposable
where T_Collection : IEnumerable<Developer>
{
	public Task<T_Collection> GetAllActiveWithApiKeys(CancellationToken cancellationToken);
	public Task<Developer> GetDeveloperByApiKey(string apiKey, CancellationToken cancellationToken);
	public Task<Developer> GetDeveloperByApiKey(Guid apiKey, CancellationToken cancellationToken);
	public Task<Developer?> GetDeveloperByApiKeyOrDefault(string apiKey, CancellationToken cancellationToken);
	public Task<Developer?> GetDeveloperByApiKeyOrDefault(Guid apiKey, CancellationToken cancellationToken);
}
