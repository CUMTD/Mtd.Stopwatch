using Mtd.Core.Repositories;
using Mtd.Stopwatch.Core.Entities.Schedule;
using Mtd.Stopwatch.Core.Entities.Transit;

namespace Mtd.Stopwatch.Core.Repositories.Transit;

public interface IStopTimeRepository<T_Collection> : IAsyncReadable<StopTime, T_Collection>, IAsyncWriteable<StopTime, T_Collection>, IDisposable
	where T_Collection : IEnumerable<StopTime>
{
	Task<StopTime> GetByIdentityAsync(string tripId, short stopSequence, CancellationToken cancellationToken);

	Task<StopTime?> GetByIdentityOrDefaultAsync(string tripId, short stopSequence, CancellationToken cancellationToken);

	Task<IReadOnlyCollection<PublicRouteGroup>> GetPublicRouteGroupsByStopId(string stopId, CancellationToken cancellationToken);

}
