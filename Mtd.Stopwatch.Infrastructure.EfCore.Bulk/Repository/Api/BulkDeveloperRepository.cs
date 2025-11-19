using Mtd.Infrastructure.EFCore.Bulk.Repository;
using Mtd.Stopwatch.Core.Entities.Api;
using Mtd.Stopwatch.Core.Repositories.Api;
using Mtd.Stopwatch.Core.Repositories.Bulk.Api;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Bulk.Repository.Api;

public class BulkDeveloperRepository(IDeveloperRepository<IReadOnlyCollection<Developer>> developerRepository, StopwatchContext dbContext)
	: AsyncBulkEFIdentifiableRepository<string, Developer>(dbContext), IBulkDeveloperRepository<IReadOnlyCollection<Developer>>
{
	private readonly IDeveloperRepository<IReadOnlyCollection<Developer>> _developerRepository = developerRepository ?? throw new ArgumentNullException(nameof(developerRepository));

	public Task<IReadOnlyCollection<Developer>> GetAllActiveWithApiKeys(CancellationToken cancellationToken) => _developerRepository.GetAllActiveWithApiKeys(cancellationToken);
	public Task<Developer> GetDeveloperByApiKey(string apiKey, CancellationToken cancellationToken) => _developerRepository.GetDeveloperByApiKey(apiKey, cancellationToken);
	public Task<Developer> GetDeveloperByApiKey(Guid apiKey, CancellationToken cancellationToken) => _developerRepository.GetDeveloperByApiKey(apiKey, cancellationToken);
	public Task<Developer?> GetDeveloperByApiKeyOrDefault(string apiKey, CancellationToken cancellationToken) => _developerRepository.GetDeveloperByApiKeyOrDefault(apiKey, cancellationToken);
	public Task<Developer?> GetDeveloperByApiKeyOrDefault(Guid apiKey, CancellationToken cancellationToken) => _developerRepository.GetDeveloperByApiKeyOrDefault(apiKey, cancellationToken);
}
