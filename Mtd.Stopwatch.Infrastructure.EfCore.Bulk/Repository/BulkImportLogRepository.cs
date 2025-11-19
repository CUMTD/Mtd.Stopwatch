using Mtd.Infrastructure.EFCore.Bulk.Repository;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Core.Repositories.Bulk.Transit;
using Mtd.Stopwatch.Core.Repositories.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Bulk.Repository;

public class BulkImportLogRepository(IImportLogRepository<IReadOnlyCollection<ImportLog>> importLogRepository, StopwatchContext dbContext)
	: AsyncBulkEFIdentifiableRepository<string, ImportLog>(dbContext), IBulkImportLogRepository<IReadOnlyCollection<ImportLog>>
{
	private readonly IImportLogRepository<IReadOnlyCollection<ImportLog>> _importLogRepository = importLogRepository ?? throw new ArgumentNullException(nameof(importLogRepository));

	public Task<IReadOnlyCollection<ImportLog>> GetLastNLogsAsync(int n, CancellationToken cancellationToken) =>
		_importLogRepository.GetLastNLogsAsync(n, cancellationToken);
	public Task<ImportLog> GetMostRecentSuccessAsync(CancellationToken cancellationToken) =>
		_importLogRepository.GetMostRecentSuccessAsync(cancellationToken);
}
