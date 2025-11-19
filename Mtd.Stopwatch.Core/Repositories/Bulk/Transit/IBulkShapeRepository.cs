using Mtd.Core.Repositories;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Core.Repositories.Transit;

namespace Mtd.Stopwatch.Core.Repositories.Bulk.Transit;

public interface IBulkShapeRepository<T_Collection> : IShapeRepository<T_Collection>, IAsyncBulkWriteable<Shape, T_Collection>
	where T_Collection : IEnumerable<Shape>
{
	Task TruncateShapesAndShapePointsAsync(CancellationToken cancellationToken);
}
