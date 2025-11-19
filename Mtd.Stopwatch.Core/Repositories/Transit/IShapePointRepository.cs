using Mtd.Core.Repositories;
using Mtd.Stopwatch.Core.Entities.Transit;

namespace Mtd.Stopwatch.Core.Repositories.Transit;

public interface IShapePointRepository<T_Collection> : IAsyncReadable<ShapePoint, T_Collection>, IAsyncWriteable<ShapePoint, T_Collection>, IDisposable
	where T_Collection : IEnumerable<ShapePoint>
{

}
