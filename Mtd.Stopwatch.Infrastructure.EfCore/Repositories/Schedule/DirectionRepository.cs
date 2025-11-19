using Mtd.Infrastructure.EFCore.Repositories;
using Mtd.Stopwatch.Core.Entities.Schedule;
using Mtd.Stopwatch.Core.Repositories.Schedule;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Repositories.Schedule;

public class DirectionRepository(StopwatchContext context) : AsyncEFIdentifiableRepository<string, Direction>(context), IDirectionRepository<IReadOnlyCollection<Direction>>
{

}
