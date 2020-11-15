using Microsoft.Data.SqlClient;
using services.data.Helpers;
using services.data.Interfaces;
using services.data.Models;
using services.data.Translators;
using System;
using System.Collections.Generic;
using System.Data;

namespace services.data.Repositories
{
    public class AssetSqlRepository : IAssetSqlRepository
    {
        public string DeleteAsset(int id,string connString)
        {
            try
            {
                var outParam = new SqlParameter("@returnCode", SqlDbType.NVarChar, 20)
                {
                    Direction = ParameterDirection.Output
                };
                SqlParameter[] param =
                {
                    new SqlParameter("@id",id),outParam
                };
                SqlHelper.ExecuteProcedureReturnString(connString, "DeleteAsset", param);
                return (string)outParam.Value;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Asset GetAsset(string connString)
        {
            try
            {
                //var outParam = new SqlParameter("@returnCode", SqlDbType.NVarChar, 20);
                return SqlHelper.ExtecuteProcedureReturnData(connString, "GetAssets", x => x.TranslateAsAsset());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IList<Asset> GetAssets(string connString)
        {
            try
            {
                //var outParam = new SqlParameter("@returnCode", SqlDbType.NVarChar, 20);
                return SqlHelper.ExtecuteProcedureReturnData(connString, "GetAssets", x => x.TranslateAsAssets());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string SaveAsset(Asset asset, string connString)
        {
            try
            {
                var outputParam = new SqlParameter("@returnCode", SqlDbType.NVarChar, 20)
                {
                    Direction = ParameterDirection.Output
                };
                SqlParameter[] param = {
                    new SqlParameter("@name", asset.Name),
                    new SqlParameter("@description", asset.Description),
                    new SqlParameter("@DepartmentId", asset.DepartmentId),
                    new SqlParameter("@AssignedOn", asset.AssignedOn),
                    new SqlParameter("@condition", asset.Condition),
                    new SqlParameter("@EmployeeId",asset.EmployeeId),
                    new SqlParameter("@location", asset.Location),
                    new SqlParameter("@ReturnedOn", asset.ReturnedOn),
                    new SqlParameter("@SerialNumber", asset.SerialNumber),
                    new SqlParameter("@Signature", asset.Signature),
                    new SqlParameter("@status", asset.Status),
                    outputParam
                };
                SqlHelper.ExecuteProcedureReturnString(connString, "SaveAsset", param);
                return (string)outputParam.Value;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
