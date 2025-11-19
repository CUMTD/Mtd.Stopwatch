using Mtd.Infrastructure.EFCore.Bulk.Repository;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Core.Repositories.Bulk.Transit;
using Mtd.Stopwatch.Core.Repositories.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Bulk.Repository;

public class BulkShapePointRepository(IShapePointRepository<IReadOnlyCollection<ShapePoint>> shapePointRepository, StopwatchContext dbContext) : AsyncBulkEFRepository<ShapePoint>(dbContext), IBulkShapePointRepository<IReadOnlyCollection<ShapePoint>>
{
	private readonly IShapePointRepository<IReadOnlyCollection<ShapePoint>> _shapePointRepository = shapePointRepository ?? throw new ArgumentNullException(nameof(shapePointRepository));
}
