using Microsoft.EntityFrameworkCore;
using Mtd.Infrastructure.EFCore.Bulk.Repository;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Core.Repositories.Bulk.Transit;
using Mtd.Stopwatch.Core.Repositories.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Bulk.Repository;

public class BulkShapeRepository(IShapeRepository<IReadOnlyCollection<Shape>> shapeRepository, StopwatchContext dbContext) : AsyncBulkEFIdentifiableRepository<string, Shape>(dbContext), IBulkShapeRepository<IReadOnlyCollection<Shape>>
{
	private readonly IShapeRepository<IReadOnlyCollection<Shape>> _shapeRepository = shapeRepository ?? throw new ArgumentNullException(nameof(shapeRepository));

	public Task<IReadOnlyCollection<Shape>> GetAllWithShapePointsAsync(CancellationToken cancellationToken) => _shapeRepository.GetAllWithShapePointsAsync(cancellationToken);
	public Task<Shape> GetByIdentityWithShapePointsAsync(string shapeId, CancellationToken cancellationToken) => _shapeRepository.GetByIdentityWithShapePointsAsync(shapeId, cancellationToken);
	public Task<Shape?> GetByIdentityWithShapePointsOrDefaultAsync(string shapeId, CancellationToken cancellationToken) => _shapeRepository.GetByIdentityWithShapePointsOrDefaultAsync(shapeId, cancellationToken);
	public async Task TruncateShapesAndShapePointsAsync(CancellationToken cancellationToken)
	{
		await _dbContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE [ShapePoint]", cancellationToken);
		await _dbContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE [Shape]", cancellationToken);
	}
}
