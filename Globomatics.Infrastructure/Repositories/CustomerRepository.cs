using Globomantics.Domain.Models;
using Globomatics.Infrastructure.Data;

namespace Globomatics.Infrastructure.Repositories;

public class CustomerRepository(GlobomanticsContext context) : GenericRepository<Customer>(context);
