using Mtd.Core.Repositories;
using Mtd.Stopwatch.Core.Entities.Transit;

namespace Mtd.Stopwatch.Core.Repositories.Transit;

public interface IFareAttributeRepository<T_Collection> : IAsyncReadable<FareAttribute, T_Collection>, IAsyncWriteable<FareAttribute, T_Collection>, IAsyncIdentifiable<string, FareAttribute>, IDisposable
	where T_Collection : IEnumerable<FareAttribute>
{
}
