using Cafe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Domain.Abstractions
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync(CancellationToken token = default);
    }
}
