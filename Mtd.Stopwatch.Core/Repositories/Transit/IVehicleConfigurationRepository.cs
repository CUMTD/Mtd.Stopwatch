using Mtd.Core.Repositories;
using Mtd.Stopwatch.Core.Entities.Transit;

namespace Mtd.Stopwatch.Core.Repositories.Transit;

public interface IVehicleConfigurationRepository<T_Collection> : IAsyncReadable<VehicleConfiguration, T_Collection>, IAsyncWriteable<VehicleConfiguration, T_Collection>, IAsyncIdentifiable<string, VehicleConfiguration>, IDisposable
	where T_Collection : IEnumerable<VehicleConfiguration>
{
	Task<T_Collection> GetAllActiveAsync(CancellationToken cancellationToken);
}
