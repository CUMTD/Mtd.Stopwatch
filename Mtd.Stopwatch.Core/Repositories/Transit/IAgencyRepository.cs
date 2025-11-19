using Mtd.Core.Repositories;
using Mtd.Stopwatch.Core.Entities.Transit;

namespace Mtd.Stopwatch.Core.Repositories.Transit;

public interface IAgencyRepository<T_Collection> : IAsyncReadable<Agency, T_Collection>, IAsyncWriteable<Agency, T_Collection>, IAsyncIdentifiable<string, Agency>, IDisposable
	where T_Collection : IEnumerable<Agency>
{
}
