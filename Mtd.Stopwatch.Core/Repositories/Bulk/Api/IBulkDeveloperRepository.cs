using Mtd.Core.Repositories;
using Mtd.Stopwatch.Core.Entities.Api;
using Mtd.Stopwatch.Core.Repositories.Api;

namespace Mtd.Stopwatch.Core.Repositories.Bulk.Api;

public interface IBulkDeveloperRepository<T_Collection> : IDeveloperRepository<T_Collection>, IAsyncBulkWriteable<Developer, T_Collection>
where T_Collection : IEnumerable<Developer>
{
}
