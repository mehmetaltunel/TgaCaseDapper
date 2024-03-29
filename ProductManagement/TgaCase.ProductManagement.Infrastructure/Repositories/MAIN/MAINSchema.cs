using System.Data;
using TgaCase.ProductManagement.Domain.Schemas.MAIN;
using TgaCase.ProductManagement.Domain.Schemas.MAIN.CategoryAggregates;
using TgaCase.ProductManagement.Domain.Schemas.MAIN.CommentsAggregates;
using TgaCase.ProductManagement.Domain.Schemas.MAIN.ProductAggregates;
using TgaCase.ProductManagement.Domain.Schemas.MAIN.ProductDetailAggregates;
using TgaCase.ProductManagement.Domain.Schemas.MAIN.ProductImagesAggregates;
using TgaCase.ProductManagement.Domain.Schemas.MAIN.RoleAggregates;
using TgaCase.ProductManagement.Domain.Schemas.MAIN.UserAggregates;
using TgaCase.ProductManagement.Infrastructure.Repositories.MAIN.Implementations;

namespace TgaCase.ProductManagement.Infrastructure.Repositories.MAIN
{

    public class MAINSchema : IMAINSchema
    {
        private readonly IDbConnection  _connection;
        private readonly IDbTransaction _transaction;
        private readonly int            _commandTimeout;
        private readonly string _schemaName;
        
        public MAINSchema(IDbConnection connection, IDbTransaction transaction, int commandTimeout, string schemaName)
        {
            _connection = connection;
            _transaction = transaction;
            _commandTimeout = commandTimeout;
            _schemaName = schemaName;
        }
            
        public IProductRepository Product  => new ProductRepository(_connection, _transaction,_schemaName, _commandTimeout);
        public ICategoryRepository Category => new CategoryRepository(_connection, _transaction,_schemaName, _commandTimeout);
        public IUserRepository User => new UserRepository(_connection, _transaction, _schemaName, _commandTimeout);
        public IRoleRepository Role => new RoleRepository(_connection, _transaction, _schemaName, _commandTimeout);
        public ICommentsRepository Comments => new CommentsRepository(_connection, _transaction, _schemaName, _commandTimeout);
        public IProductDetailRepository ProductDetail => new ProductDetailRepository(_connection, _transaction, _schemaName, _commandTimeout);
        public IProductImagesRepository ProductImages => new ProductImagesRepository(_connection, _transaction, _schemaName, _commandTimeout);
    }
}
