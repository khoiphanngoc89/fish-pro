﻿using NFC.Application.Shared;
using NFC.Domain.Entities;
using NFC.Infrastructure.SharedKernel;

namespace NFC.Infrastructure.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMenuRepository : IGenericRepository<int, Menu>
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="NFC.Infrastructure.Repositories.IMenuRepository" />
    public class MenuRepository : GenericRepositoryBase<int, Menu>, IMenuRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuRepository"/> class.
        /// </summary>
        /// <param name="repository">The data access object.</param>
        /// <param name="builder">The builder.</param>
        public MenuRepository(IRepository repository, IParamsBuilder builder) : base(repository, builder)
        {
        }
    }
}
