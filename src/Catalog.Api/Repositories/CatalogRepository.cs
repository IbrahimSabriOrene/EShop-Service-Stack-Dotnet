using Dapper;
using Catalog.Api.Models;
using Catalog.Api.Helpers;
using Microsoft.Extensions.Options;
using System.Text;
using Npgsql;
using Catalog.Api.Repositories.Queries;

namespace Catalog.Api.Repositories
{
    public class CatalogRepository
    {
        // this will look like this.
        // If we choose IQueryAble instead IEnumerable we can filter the id's and not return the full code
        private readonly DbContext _dbContext;
        public CatalogRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

       

        public async Task<IEnumerable<CatalogItem?>> GetCatalogItems()
        {
            using var connection = _dbContext.CreateConnection();
            return await connection.QueryAsync<CatalogItem>(CatalogItemQueries.Get);
        }

        public async Task<CatalogItem?> GetCatalogItem(int id)
        {
            using var connection = _dbContext.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<CatalogItem>(CatalogItemQueries.GetById, new { id }) ?? throw new KeyNotFoundException();
        }

        public async Task<IEnumerable<CatalogItem?>> GetCatalogItemsByBrand(int brandId)
        {
            using var connection = _dbContext.CreateConnection();
            return await connection.QueryAsync<CatalogItem>(CatalogItemQueries.GetByBrandId, new { brandId });
        }

        public async Task<IEnumerable<CatalogItem?>> GetCatalogItemsByType(int typeId)
        {
            using var connection = _dbContext.CreateConnection();
            return await connection.QueryAsync<CatalogItem>(CatalogItemQueries.GetByTypeId, new { typeId });
        }

        public async Task<IEnumerable<CatalogBrand?>> GetCatalogBrands()
        {
            using var connection = _dbContext.CreateConnection();
            return await connection.QueryAsync<CatalogBrand>(CatalogBrandQueries.Get);
        }

        public async Task<CatalogBrand?> CreateCatalogBrand(CatalogBrand catalogBrand)
        {
            using var connection = _dbContext.CreateConnection();

            await connection.ExecuteAsync(CatalogBrandQueries.Insert, catalogBrand);
            return catalogBrand;
        }

        public async Task<IEnumerable<CatalogType?>> GetCatalogTypes()
        {
            using var connection = _dbContext.CreateConnection();
            return await connection.QueryAsync<CatalogType>(CatalogTypeQueries.Get);
        }

        public async Task<int?> CreateCatalogType(CatalogType catalogType)
        {
            using var connection = _dbContext.CreateConnection();
            var result = await connection.ExecuteAsync(CatalogTypeQueries.Insert, catalogType);
            return result;
        }

        public async Task<CatalogType?> GetCatalogType(int id)
        {
            using var connection = _dbContext.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<CatalogType>(CatalogItemQueries.GetById, new { id }) ?? throw new KeyNotFoundException();
        }

        public async Task<CatalogType?> UpdateCatalogType(CatalogType catalogType)
        {
            using var connection = _dbContext.CreateConnection();

            await connection.ExecuteAsync(CatalogItemQueries.GetById, catalogType);
            return catalogType;
        }

        public async Task<int?> CreateCatalogItem(CatalogItem catalogItem)
        {
            // Returning id part a bit problematic
            using var connection = _dbContext.CreateConnection();

            var id = await connection.ExecuteAsync(CatalogItemQueries.GetById, catalogItem);
            return id;
        }


        public async Task<bool> UpdateCatalogItem(CatalogItem catalogItem)
        {
            using var connection = _dbContext.CreateConnection();

            return await connection.ExecuteAsync(CatalogItemQueries.GetById, catalogItem) > 0;
        }

        public async Task<bool> DeleteCatalogItem(int id)
        {
            using var connection = _dbContext.CreateConnection();

            return await connection.ExecuteAsync(CatalogItemQueries.GetById, new { id }) > 0;
        }

        public async Task<IEnumerable<CatalogItem?>> GetCatalogItemsBrandAndTypeId(int typeId, int brandId)
        {
            using var connection = _dbContext.CreateConnection();
            return await connection.QueryAsync<CatalogItem>(CatalogItemQueries.GetById, new { typeId, brandId });

        }

        public async Task<CatalogItem?> GetCatalogItemByName(string name)
        {
            using var connection = _dbContext.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<CatalogItem>(CatalogItemQueries.GetById, new { name });
        }

        public async Task<IEnumerable<CatalogItem?>> GetCatalogItemsByIds(int[] ids)
        {
            using var connection = _dbContext.CreateConnection();
            return await connection.QueryAsync<CatalogItem>(CatalogItemQueries.GetById, new { ids }) ?? throw new NpgsqlException();
        }

        public async Task<CatalogBrand?> GetCatalogBrand(int id)
        {
            using var connection = _dbContext.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<CatalogBrand>(CatalogItemQueries.GetById, new { id });
        }

        internal async Task<bool> UpdateCatalogBrand(CatalogBrand brand)
        {
            using var connection = _dbContext.CreateConnection();
            return await connection.ExecuteAsync(CatalogItemQueries.GetById, brand) > 0;
        }
    }
}
