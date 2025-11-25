using Mtd.Infrastructure.EFCore.Bulk.Repository;
using Mtd.Stopwatch.Core.Entities.Schedule;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Core.Repositories.Bulk.Transit;
using Mtd.Stopwatch.Core.Repositories.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Bulk.Repository;

public class BulkStopTimeRepository(IStopTimeRepository<IReadOnlyCollection<StopTime>> stopTimeRepository, StopwatchContext dbContext)
	: AsyncBulkEFRepository<StopTime>(dbContext), IBulkStopTimeRepository<IReadOnlyCollection<StopTime>>
{
	private readonly IStopTimeRepository<IReadOnlyCollection<StopTime>> _stopTimeRepository = stopTimeRepository ?? throw new ArgumentNullException(nameof(stopTimeRepository));

	public Task<StopTime> GetByIdentityAsync(string tripId, short stopSequence, CancellationToken cancellationToken) =>
		_stopTimeRepository.GetByIdentityAsync(tripId, stopSequence, cancellationToken);
	public Task<StopTime?> GetByIdentityOrDefaultAsync(string tripId, short stopSequence, CancellationToken cancellationToken) =>
		_stopTimeRepository.GetByIdentityOrDefaultAsync(tripId, stopSequence, cancellationToken);
	public Task<IReadOnlyCollection<PublicRouteGroup>> GetPublicRouteGroupsByStopId(string stopId, CancellationToken cancellationToken) => throw new NotImplementedException();
}
