using Mtd.Core.Repositories;
using Mtd.Stopwatch.Core.Entities.Transit;

namespace Mtd.Stopwatch.Core.Repositories.Transit;

public interface IImportLogRepository<T_Collection> : IAsyncReadable<ImportLog, T_Collection>, IAsyncWriteable<ImportLog, T_Collection>, IAsyncIdentifiable<string, ImportLog>, IDisposable
	where T_Collection : IEnumerable<ImportLog>
{
	Task<T_Collection> GetLastNLogsAsync(int n, CancellationToken cancellationToken);

	Task<ImportLog> GetMostRecentSuccessAsync(CancellationToken cancellationToken);
}
