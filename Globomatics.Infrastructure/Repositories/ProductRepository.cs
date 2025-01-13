using Globomantics.Domain.Models;
using Globomatics.Infrastructure.Data;

namespace Globomatics.Infrastructure.Repositories;

public class ProductRepository(GlobomanticsContext context) : GenericRepository<Product>(context);
