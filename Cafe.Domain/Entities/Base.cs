using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Domain.Entities;

public class Base
{
    public Guid Id { get; set; } = Guid.NewGuid();
}
