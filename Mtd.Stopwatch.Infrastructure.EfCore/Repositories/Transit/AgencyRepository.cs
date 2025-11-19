using Mtd.Infrastructure.EFCore.Repositories;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Core.Repositories.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Repositories.Transit;

public class AgencyRepository(StopwatchContext context)
	: AsyncEFIdentifiableRepository<string, Agency>(context), IAgencyRepository<IReadOnlyCollection<Agency>>
{
}
