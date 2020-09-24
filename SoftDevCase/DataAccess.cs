using SoftDevCase.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;

namespace SoftDevCase
{
    public class DataAccess
    {
        public DataTable GetUserDetails(UserEnt userDetail)
        {
            DataTable userList = new DataTable();
            try
            {
                using (var context = new labo_salesEntities())
                {
                    var userResult = context.sp_GetUserDetails(userDetail.username, userDetail.password);
                    userList = DataTransformer.CreateDataTable(userResult.ToList());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return userList;
        }
        public DataTable GetErrorCodeDescription(string errorCode)
        {
            DataTable errorMessageInfo = new DataTable();
            try
            {
                using (var context = new labo_salesEntities())
                {
                    var errorMessage = context.sp_GetErrorMessage(errorCode);
                    errorMessageInfo = DataTransformer.CreateDataTable(errorMessage.ToList());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return errorMessageInfo;
        }

        public DataTable GetSalesRecordsData()
        {
            DataTable salesRecords = new DataTable();
            try
            {
                using (var context = new labo_salesEntities())
                {
                    var salesData = context.sp_GetSalesReportDetails();
                    salesRecords = DataTransformer.CreateDataTable(salesData.ToList());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return salesRecords;
        }

        public string InsertLoadedDatatoDB(DataTable uplrecords)
        {
            string result = "OK";
            try
            {
                using (var DB = new labo_salesEntities())
                {
                    SqlParameter Parameter = new SqlParameter("@param1", uplrecords);
                    Parameter.TypeName = "salesDetailType";
                    DB.Database.ExecuteSqlCommand("exec sp_InsertSalesDetails @param1", Parameter);
                }
            }
            catch (Exception ex)
            {
                result=ex.Message;
            }
            return result;
        }
    }
}