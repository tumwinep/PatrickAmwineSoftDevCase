using SoftDevCase.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Data.Entity.Core.Objects;

namespace SoftDevCase
{
    public class DataAccess
    {
        public DataTable GetUserDetails(UserEnt userDetail)
        {
            DataTable userList = new DataTable();
            BusinessLogic bl = new BusinessLogic();
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

    }
}