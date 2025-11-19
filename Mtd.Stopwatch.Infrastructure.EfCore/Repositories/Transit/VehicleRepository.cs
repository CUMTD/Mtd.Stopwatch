using Microsoft.EntityFrameworkCore;
using Mtd.Infrastructure.EFCore.Repositories;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Core.Repositories.Transit;
using System.Collections.Immutable;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Repositories.Transit;

public class VehicleRepository(StopwatchContext context)
	: AsyncEFIdentifiableRepository<string, Vehicle>(context), IVehicleRepository<IReadOnlyCollection<Vehicle>>
{
	public async Task<IReadOnlyCollection<Vehicle>> GetAllActiveAsync(CancellationToken cancellationToken)
	{
		var results = await Query()
		.Where(v => v.IsActive)
			.Include(fv => fv.Attributes)
			.Include(fv => fv.VehicleConfiguration)
			.ToArrayAsync(cancellationToken);

		return results.ToImmutableArray();
	}
}
