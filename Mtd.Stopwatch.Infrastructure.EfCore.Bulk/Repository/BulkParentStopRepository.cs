using Mtd.Infrastructure.EFCore.Bulk.Repository;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Core.Repositories.Bulk.Transit;
using Mtd.Stopwatch.Core.Repositories.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Bulk.Repository;

public class BulkParentStopRepository(IParentStopRepository<IReadOnlyCollection<ParentStop>> parentStopRepository, StopwatchContext dbContext)
	: AsyncBulkEFIdentifiableRepository<string, ParentStop>(dbContext), IBulkParentStopRepository<IReadOnlyCollection<ParentStop>>
{
	private readonly IParentStopRepository<IReadOnlyCollection<ParentStop>> _parentStopRepository = parentStopRepository ?? throw new ArgumentNullException(nameof(parentStopRepository));

	public Task<IReadOnlyCollection<ParentStop>> GetAllActiveAsync(CancellationToken cancellationToken) =>
		_parentStopRepository.GetAllActiveAsync(cancellationToken);
	public Task<IReadOnlyCollection<ParentStop>> GetAllWithChildStopsAsync(CancellationToken cancellationToken) =>
		_parentStopRepository.GetAllWithChildStopsAsync(cancellationToken);
	public Task<ParentStop?> GetByIdentityOrDefaultWithChildStopsAsync(string id, CancellationToken cancellationToken) =>
		_parentStopRepository.GetByIdentityOrDefaultWithChildStopsAsync(id, cancellationToken);
	public Task<ParentStop> GetByIdentityWithChildStopsAsync(string id, CancellationToken cancellationToken) =>
		_parentStopRepository.GetByIdentityWithChildStopsAsync(id, cancellationToken);
	public Task<IReadOnlyCollection<ParentStop>> GetWithoutIStopsAsync(CancellationToken cancellationToken) =>
		_parentStopRepository.GetWithoutIStopsAsync(cancellationToken);
}
