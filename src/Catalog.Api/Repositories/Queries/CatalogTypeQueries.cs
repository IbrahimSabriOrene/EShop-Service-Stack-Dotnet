using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Repositories.Queries
{
    public static class CatalogTypeQueries
    {
        public static string Get => "SELECT * FROM CatalogType";
        public static string GetById => "SELECT * FROM CatalogType WHERE Id = @id";
        public static string Insert => "INSERT INTO CatalogType (Type) VALUES (@Type) RETURNING Id"; // fix id return
        public static string UpdateById => "UPDATE CatalogType SET Type = @Type WHERE Id = @Id";


    }
}