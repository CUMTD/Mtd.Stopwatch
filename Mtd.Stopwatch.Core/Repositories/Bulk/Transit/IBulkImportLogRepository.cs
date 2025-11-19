using Mtd.Core.Repositories;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Core.Repositories.Transit;

namespace Mtd.Stopwatch.Core.Repositories.Bulk.Transit;

public interface IBulkImportLogRepository<T_Collection> : IImportLogRepository<T_Collection>, IAsyncBulkWriteable<ImportLog, T_Collection>
	where T_Collection : IEnumerable<ImportLog>
{
}
