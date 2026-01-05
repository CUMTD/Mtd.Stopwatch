using Microsoft.EntityFrameworkCore;

using Mtd.Infrastructure.EFCore.Bulk.Repository;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Core.Repositories.Bulk.Transit;
using Mtd.Stopwatch.Core.Repositories.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Bulk.Repository;

public class BulkTripRepository(ITripRepository<IReadOnlyCollection<Trip>> tripRepository, StopwatchContext dbContext)
	: AsyncBulkEFIdentifiableRepository<string, Trip>(dbContext), IBulkTripRepository<IReadOnlyCollection<Trip>>
{
	private readonly ITripRepository<IReadOnlyCollection<Trip>> _tripRepository = tripRepository ?? throw new ArgumentNullException(nameof(tripRepository));

	public Task<IReadOnlyCollection<Trip>> GetAllWithRoutesAsync(CancellationToken cancellationToken) => _tripRepository.GetAllWithRoutesAsync(cancellationToken);
	public Task<IReadOnlyCollection<Trip>> GetTripsForStopIdAsync(string stopId, CancellationToken cancellationToken) => throw new NotImplementedException();
	public Task TruncateTripToCalendarDateBridgeTable(CancellationToken cancellationToken) => _dbContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE transit.TripToCalendarDate;"
, cancellationToken: cancellationToken);
}
