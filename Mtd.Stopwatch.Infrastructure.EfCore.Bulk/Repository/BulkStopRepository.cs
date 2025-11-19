using Mtd.Infrastructure.EFCore.Bulk.Repository;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Core.Repositories.Bulk.Transit;
using Mtd.Stopwatch.Core.Repositories.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Bulk.Repository;

public class BulkStopRepository(IStopRepository<Stop, IReadOnlyCollection<Stop>> stopRepository, StopwatchContext dbContext) : AsyncBulkEFIdentifiableRepository<string, Stop>(dbContext), IBulkStopRepository<Stop, IReadOnlyCollection<Stop>>
{
	private readonly IStopRepository<Stop, IReadOnlyCollection<Stop>> _stopRepository = stopRepository ?? throw new ArgumentNullException(nameof(stopRepository));
	public Task<IReadOnlyCollection<Stop>> GetAllActiveAsync(CancellationToken cancellationToken) => _stopRepository.GetAllActiveAsync(cancellationToken);
}
