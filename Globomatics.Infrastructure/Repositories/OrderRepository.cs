using Globomantics.Domain.Models;
using Globomatics.Infrastructure.Data;

namespace Globomatics.Infrastructure.Repositories;

public class OrderRepository(GlobomanticsContext context) : GenericRepository<Order>(context);
