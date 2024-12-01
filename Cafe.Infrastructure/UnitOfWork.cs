﻿using Cafe.Domain.Abstractions;
using Cafe.Infrastructure.Repositories;

namespace Cafe.Infrastructure;

internal class UnitOfWork : IUnitOfWork
{
    private readonly string _connectionString;

    private IUserRepository? _users;

    private IFeedbackRepository? _feedbacks;

    private IDessertRepository? _desserts;

    private IDrinkRepository? _drinks;

    private IPriceRepository? _prices;

    public UnitOfWork(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IUserRepository UserRepository => _users ??= new UserRepository(_connectionString);

    public IFeedbackRepository FeedbackRepository => _feedbacks ??= new FeedbackRepository(_connectionString);

    public IDessertRepository DessertRepository => _desserts ??= new DessertRepository(_connectionString);

    public IDrinkRepository DrinkRepository => _drinks ??= new DrinkRepository(_connectionString);

    public IPriceRepository PriceRepository => _prices ??= new PriceRepository(_connectionString);
}
