using Mtd.Core.Repositories;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Core.Repositories.Transit;

namespace Mtd.Stopwatch.Core.Repositories.Bulk.Transit;

public interface IBulkShapePointRepository<T_Collection> : IShapePointRepository<T_Collection>, IAsyncBulkWriteable<ShapePoint, T_Collection>
	where T_Collection : IEnumerable<ShapePoint>
{
}
