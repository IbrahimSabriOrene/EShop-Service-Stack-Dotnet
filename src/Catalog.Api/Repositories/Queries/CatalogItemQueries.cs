using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Repositories.Queries
{
    public static class CatalogItemQueries
    {
        public static string Get => "SELECT * FROM CatalogItem";
        public static string GetById => "SELECT * FROM CatalogItem WHERE Id = @id";
        public static string GetByIds => "SELECT * FROM CatalogItem WHERE Id = ANY(@ids)"; // fix
        public static string GetByBrandId => "SELECT * FROM CatalogItem WHERE CatalogBrandId = @brandId";
        public static string GetByTypeId => "SELECT * FROM CatalogItem WHERE CatalogTypeId = @typeId";
        public static string Delete => "DELETE FROM CatalogItem WHERE Id = @id";
        public static string Update => @"UPDATE CatalogItem SET Name = @Name, Description = @Description, 
        Price = @Price, ImageFile = @ImageFile, 
        CatalogTypeId = @CatalogTypeId, CatalogBrandId = @CatalogBrandId WHERE Id = @Id";
        public static string Insert => @"INSERT INTO CatalogItem (Name, Description,
        Price, ImageFile, CatalogTypeId, CatalogBrandId) VALUES
        (@Name, @Description, @Price, @ImageFile, @CatalogTypeId, @CatalogBrandId) RETURNING Id";
        public static string GetByTypeAndBrand => "SELECT * FROM CatalogItem WHERE CatalogTypeId = @typeId AND CatalogBrandId = @brandId";
        public static string GetByName => "SELECT * FROM CatalogItem WHERE Name = @name";
    }

}