using Mtd.Infrastructure.EFCore.Bulk.Repository;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Core.Repositories.Bulk.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Bulk.Repository;

public class BulkFareAttributeRepository(StopwatchContext dbContext)
	: AsyncBulkEFIdentifiableRepository<string, FareAttribute>(dbContext), IBulkFareAttributeRepository<IReadOnlyCollection<FareAttribute>>
{
}
