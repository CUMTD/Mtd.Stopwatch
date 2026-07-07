using Microsoft.EntityFrameworkCore;
using Mtd.Infrastructure.EFCore.Repositories;
using Mtd.Stopwatch.Core.Entities.Schedule;
using Mtd.Stopwatch.Core.Repositories.Schedule;
using System.Collections.Immutable;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Repositories.Schedule;

public class ShelterBoardRepository(StopwatchContext context)
	: AsyncEFIdentifiableRepository<string, ShelterBoard>(context), IShelterBoardRepository<IReadOnlyCollection<ShelterBoard>>
{
	public async Task<IReadOnlyCollection<ShelterBoard>> GetAllWithStopAsync(CancellationToken cancellationToken)
	{
		var results = await Query()
			.Include(sb => sb.Stop)
			.ToArrayAsync(cancellationToken)
			.ConfigureAwait(false);

		return results.ToImmutableArray();
	}

	public Task<ShelterBoard?> GetByIdentityWithStopAsync(string id, CancellationToken cancellationToken) => Query()
		.Where(sb => sb.Id == id)
		.Include(sb => sb.Stop)
		.SingleOrDefaultAsync(cancellationToken);
}
