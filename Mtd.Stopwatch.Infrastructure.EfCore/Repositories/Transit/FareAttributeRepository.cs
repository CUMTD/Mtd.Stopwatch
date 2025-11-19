using Mtd.Infrastructure.EFCore.Repositories;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Core.Repositories.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Repositories.Transit;

public class FareAttributeRepository(StopwatchContext context)
	: AsyncEFIdentifiableRepository<string, FareAttribute>(context), IFareAttributeRepository<IReadOnlyCollection<FareAttribute>>
{
}
