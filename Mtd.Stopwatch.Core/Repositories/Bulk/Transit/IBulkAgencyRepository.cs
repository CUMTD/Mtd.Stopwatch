using Mtd.Core.Repositories;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Core.Repositories.Transit;

namespace Mtd.Stopwatch.Core.Repositories.Bulk.Transit;

public interface IBulkAgencyRepository<T_Collection> : IAgencyRepository<T_Collection>, IAsyncBulkWriteable<Agency, T_Collection>
	where T_Collection : IEnumerable<Agency>
{
}
