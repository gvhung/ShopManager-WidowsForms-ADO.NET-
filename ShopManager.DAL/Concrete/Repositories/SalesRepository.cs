using ShopManager.DAL.Abstraction.Repositories;
using ShopManager.DAL.Concrete.Repositories;
using ShopManager.Model.Entities;
using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using ShopManager.Parser.Parsers;

namespace ShopManager.DAL.Concrete.Repositories
{
    internal class SalesRepository:Repository<Sale>,ISaleRepository
    {
        public SalesRepository(string connection):base(connection)
        {

        }

        public IEnumerable<Sale> GetSalesByDateAndCode(DateTime searchDate , string searchProductCode )
        {

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@SalesDate",System.Data.SqlDbType.Date),
                    new SqlParameter("@ProductCode",System.Data.SqlDbType.NVarChar)
                };
            parameters[0].Value = searchDate;
            parameters[1].Value = searchProductCode;
            return ExecuteReader("spGetSales", SaleParser.GetInstance.MakeSaleResult,parameters);
        }

        public IEnumerable<Sale> GetSalesByCode(string searchProductCode)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("@ProductCode",System.Data.SqlDbType.NVarChar)
            };
            parameters[0].Value = searchProductCode;
            return ExecuteReader("spGetSales", SaleParser.GetInstance.MakeSaleResult, parameters);
        }

        public IEnumerable<Sale> GetSalesByDate(DateTime searchDate)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("@SalesDate",System.Data.SqlDbType.Date)
            };
            parameters[0].Value = searchDate;
            return ExecuteReader("spGetSales", SaleParser.GetInstance.MakeSaleResult, parameters);
        }
        public IEnumerable<Sale> GetSalesAll()
        {
            return ExecuteReader("spGetSales", SaleParser.GetInstance.MakeSaleResult);
        }
    }
    
}
