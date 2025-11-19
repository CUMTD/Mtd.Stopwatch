using Mtd.Infrastructure.EFCore.Bulk.Repository;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Core.Repositories.Bulk.Transit;
using Mtd.Stopwatch.Core.Repositories.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Bulk.Repository;

public class BulkChildStopRepository(IChildStopRepository<IReadOnlyCollection<ChildStop>> childStopRepository, StopwatchContext dbContext)
	: AsyncBulkEFIdentifiableRepository<string, ChildStop>(dbContext), IBulkChildStopRepository<IReadOnlyCollection<ChildStop>>
{
	private readonly IChildStopRepository<IReadOnlyCollection<ChildStop>> _childStopRepository = childStopRepository ?? throw new ArgumentNullException(nameof(childStopRepository));
	public Task<IReadOnlyCollection<ChildStop>> GetAllActiveAsync(CancellationToken cancellationToken) =>
		_childStopRepository.GetAllActiveAsync(cancellationToken);
	public Task<IReadOnlyCollection<ChildStop>> GetAllWithParentAsync(CancellationToken cancellationToken) =>
		_childStopRepository.GetAllWithParentAsync(cancellationToken);
}
