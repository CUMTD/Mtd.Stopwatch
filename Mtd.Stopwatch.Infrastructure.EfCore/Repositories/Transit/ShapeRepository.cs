using Microsoft.EntityFrameworkCore;
using Mtd.Infrastructure.EFCore.Repositories;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Core.Repositories.Transit;
using System.Collections.Immutable;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Repositories.Transit;

public class ShapeRepository(StopwatchContext context)
	: AsyncEFIdentifiableRepository<string, Shape>(context), IShapeRepository<IReadOnlyCollection<Shape>>
{
	public async Task<IReadOnlyCollection<Shape>> GetAllWithShapePointsAsync(CancellationToken cancellationToken)
	{
		var results = await Query()
			.Include(s => s.Points)
			.ToArrayAsync(cancellationToken);

		return results.ToImmutableArray();
	}

	public async Task<Shape> GetByIdentityWithShapePointsAsync(string shapeId, CancellationToken cancellationToken)
	{
		var result = await GetByIdentityWithShapePointsOrDefaultAsync(shapeId, cancellationToken)
		.ConfigureAwait(false);

		return result ?? throw new InvalidOperationException($"{shapeId} not found.");
	}
	public Task<Shape?> GetByIdentityWithShapePointsOrDefaultAsync(string shapeId, CancellationToken cancellationToken) => Query()
		.Where(s => s.Id == shapeId)
		.Include(s => s.Points)
		.SingleOrDefaultAsync(cancellationToken);
}
