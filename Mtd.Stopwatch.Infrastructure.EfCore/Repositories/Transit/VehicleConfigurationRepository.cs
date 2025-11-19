using Microsoft.EntityFrameworkCore;
using Mtd.Infrastructure.EFCore.Repositories;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Core.Repositories.Transit;
using System.Collections.Immutable;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Repositories.Transit;

public class VehicleConfigurationRepository(StopwatchContext context)
	: AsyncEFIdentifiableRepository<string, VehicleConfiguration>(context), IVehicleConfigurationRepository<IReadOnlyCollection<VehicleConfiguration>>
{
	public async Task<IReadOnlyCollection<VehicleConfiguration>> GetAllActiveAsync(CancellationToken cancellationToken)
	{
		var results = await Query()
			.Include(f => f.Vehicles)
		.ThenInclude(v => v.Attributes)
			.ToArrayAsync(cancellationToken);

		return results
			.Where(vc => vc.Vehicles.Any(v => v.IsActive))
			.ToImmutableArray();
	}
}
