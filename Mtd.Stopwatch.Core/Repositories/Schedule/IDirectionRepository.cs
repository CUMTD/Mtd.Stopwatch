using Mtd.Core.Repositories;
using Mtd.Stopwatch.Core.Entities.Schedule;

namespace Mtd.Stopwatch.Core.Repositories.Schedule;

public interface IDirectionRepository<T_Collection> : IAsyncReadable<Direction, T_Collection>, IAsyncWriteable<Direction, T_Collection>, IAsyncIdentifiable<string, Direction>, IDisposable
	where T_Collection : IEnumerable<Direction>
{
}
