﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
    }
}