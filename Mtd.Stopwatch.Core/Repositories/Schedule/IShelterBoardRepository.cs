using Mtd.Core.Repositories;
using Mtd.Stopwatch.Core.Entities.Schedule;

namespace Mtd.Stopwatch.Core.Repositories.Schedule;

public interface IShelterBoardRepository<T_Collection> : IAsyncReadable<ShelterBoard, T_Collection>, IAsyncWriteable<ShelterBoard, T_Collection>, IAsyncIdentifiable<string, ShelterBoard>, IDisposable
	where T_Collection : IEnumerable<ShelterBoard>
{
	Task<T_Collection> GetAllWithStopAsync(CancellationToken cancellationToken);
	Task<ShelterBoard?> GetByIdentityWithStopAsync(string id, CancellationToken cancellationToken);
}
