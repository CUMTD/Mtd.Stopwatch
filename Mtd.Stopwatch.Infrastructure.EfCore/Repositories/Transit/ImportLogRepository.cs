using Microsoft.EntityFrameworkCore;
using Mtd.Infrastructure.EFCore.Repositories;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Core.Repositories.Transit;
using System.Collections.Immutable;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Repositories.Transit;

public class ImportLogRepository(StopwatchContext context)
	: AsyncEFIdentifiableRepository<string, ImportLog>(context), IImportLogRepository<IReadOnlyCollection<ImportLog>>
{
	public async Task<IReadOnlyCollection<ImportLog>> GetLastNLogsAsync(int n, CancellationToken cancellationToken)
	{
		var result = await Query()
		.OrderByDescending(il => il.Start)
		.Take(n)
		.ToArrayAsync(cancellationToken);

		return result.ToImmutableArray();
	}

	public Task<ImportLog> GetMostRecentSuccessAsync(CancellationToken cancellationToken) => Query()
		.Where(il => il.Success)
		.OrderByDescending(il => il.Finish)
		.FirstAsync(cancellationToken);
}
