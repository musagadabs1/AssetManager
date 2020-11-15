using Microsoft.Data.SqlClient;
using services.data.Helpers;
using services.data.Models;
using System.Collections;
using System.Collections.Generic;

namespace services.data.Translators
{
    public static class AssetTranslator
    {
        public static Asset TranslateAsAsset(this SqlDataReader reader,bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                
                reader.Read();
            }
            var item = new Asset();
            if (reader.IsColumnExists("Id"))
            {
                item.Id = SqlHelper.GetNullableInt32(reader, "Id");
            }
            if (reader.IsColumnExists("Name"))
            {
                item.Name = SqlHelper.GetNullableString(reader, "Name");
            }
            if (reader.IsColumnExists("Description"))
            {
                item.Description = SqlHelper.GetNullableString(reader, "Description");
            }
            if (reader.IsColumnExists("Location"))
            {
                item.Location = SqlHelper.GetNullableString(reader, "Location");
            }
            if (reader.IsColumnExists("Condition"))
            {
                item.Condition = SqlHelper.GetNullableString(reader, "Condition");
            }
            if (reader.IsColumnExists("Status"))
            {
                item.Status = SqlHelper.GetNullableString(reader, "Status");
            }
            if (reader.IsColumnExists("SerialNumber"))
            {
                item.SerialNumber = SqlHelper.GetNullableString(reader, "SerialNumber");
            }
            if (reader.IsColumnExists("EmployeeId"))
            {
                item.EmployeeId = SqlHelper.GetNullableString(reader, "EmployeeId");
            }
            if (reader.IsColumnExists("AssignedOn"))
            {
                item.AssignedOn = SqlHelper.GetNullableDateTime(reader, "AssignedOn");
            }
            if (reader.IsColumnExists("Signature"))
            {
                item.Signature = SqlHelper.GetNullableString(reader, "Signature");
            }
            if (reader.IsColumnExists("ReturnedOn"))
            {
                item.ReturnedOn = SqlHelper.GetNullableDateTime(reader, "ReturnedOn");
            }
            if (reader.IsColumnExists("DepartmentId"))
            {
                item.DepartmentId = SqlHelper.GetNullableInt32(reader, "DepartmentId");
            }
            return item;
        }
        public static List<Asset> TranslateAsAssets(this SqlDataReader reader)
        {
            var list = new List<Asset>();
            while(reader.Read())
            {
                list.Add(TranslateAsAsset(reader, true));
            }
            return list;
        }
    }
}
