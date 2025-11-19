using Mtd.Core.Repositories;
using Mtd.Stopwatch.Core.Entities.Transit;

namespace Mtd.Stopwatch.Core.Repositories.Transit;

public interface IVehicleRepository<T_Collection> : IAsyncReadable<Vehicle, T_Collection>, IAsyncWriteable<Vehicle, T_Collection>, IAsyncIdentifiable<string, Vehicle>, IDisposable
	where T_Collection : IEnumerable<Vehicle>
{
	Task<T_Collection> GetAllActiveAsync(CancellationToken cancellationToken);
}
