using Dapper;
using Library.DAL.Constants;
using Library.DAL.Interfaces;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace Library.DAL
{
    public class TopRepository : IRepository<Book>
    {
        private readonly string connectionString;
        private string sql;
        public TopRepository()
        {
            connectionString = Connection.ConnectionString;
        }
        public List<Book> Get(int quantity)
        {
            try
            {
                List<Book> items;
                sql = "SELECT b.Id, b.Title, b.Category, b.Author " +
                    "FROM Book b " +
                    "INNER JOIN( " +
                        "SELECT TOP(@times) IdBook, COUNT(*) as SoldTimes " +
                        "FROM Sale " +
                        "GROUP BY IdBook " +
                        "ORDER BY SoldTimes DESC) s ON b.Id = s.IdBook; ";
                using (IDbConnection dbConnection = new SqlConnection(connectionString))
                {
                    items = dbConnection.Query<Book>(sql, new { times = quantity }).ToList();
                }
                return items;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
