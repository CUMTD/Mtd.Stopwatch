using Mtd.Core.Repositories;
using Mtd.Stopwatch.Core.Entities.Api;
using Mtd.Stopwatch.Core.Repositories.Api;

namespace Mtd.Stopwatch.Core.Repositories.Bulk.Api;

public interface IBulkApiKeyRepository<T_Collection> : IApiKeyRepository<T_Collection>, IAsyncBulkWriteable<ApiKey, T_Collection>
where T_Collection : IEnumerable<ApiKey>
{
}
