using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Repositories.Queries
{
    public static class CatalogBrandQueries
    {
        //SELECT * FROM CatalogBrand
        // INSERT INTO CatalogBrand (Brand) VALUES (@Brand)
        // SELECT * FROM CatalogBrand WHERE Id = @id
        //UPDATE CatalogBrand SET Brand = @Brand WHERE Id = @Id

        public static string Get => "SELECT * FROM CatalogBrand";
        public static string GetById => "SELECT * FROM CatalogBrand WHERE Id = @id";
        public static string Insert => "INSERT INTO CatalogBrand (Brand) VALUES (@Brand) RETURNING Id";
        public static string UpdateById => "UPDATE CatalogBrand SET Brand = @Brand WHERE Id = @Id";


    }
}