using Mtd.Infrastructure.EFCore.Repositories;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Core.Repositories.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Repositories.Transit
{
	public class ShapePointRepository(StopwatchContext context)
		: AsyncEFRepository<ShapePoint>(context), IShapePointRepository<IReadOnlyCollection<ShapePoint>>
	{

	}
}
