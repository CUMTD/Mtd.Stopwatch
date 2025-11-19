using Mtd.Core.Repositories;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Core.Repositories.Transit;

namespace Mtd.Stopwatch.Core.Repositories.Bulk.Transit;

public interface IBulkFareAttributeRepository<T_Collection> : IFareAttributeRepository<T_Collection>, IAsyncBulkWriteable<FareAttribute, T_Collection>
	where T_Collection : IEnumerable<FareAttribute>
{
}
