using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using ToolBox.Services.DBWorker.Domain.Models;
using ToolBox.Services.DBWorker.Helpers;

// https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/ado-net-code-examples
namespace ToolBox.Services.DBWorker.Services
{
    public class SqlService : ISQLService
    {
        public async Task<List<Dictionary<string, string>>> SendSqlServerRequest(string conncectionString,
                                                                                 string instruction,
                                                                                 bool isProcedure = false,
                                                                                 Dictionary<string, string> parameters = null)
        {
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            if (instruction.Contains("EXEC sp_spaceused"))
            {
                var d = 1;
            }
            try
            {


                using (SqlConnection connection = new SqlConnection(conncectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand(instruction, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);

                        adapter.SelectCommand.CommandType = isProcedure ? CommandType.StoredProcedure : CommandType.Text;

                        if (isProcedure == true && parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                adapter.SelectCommand.Parameters.AddWithValue(param.Key, Convert.ToInt32(param.Value));
                            }
                        }



                        DataTable dataTable = new DataTable();

                        adapter.Fill(dataTable);

                        foreach (DataRow dtRow in dataTable.Rows)
                        {
                            Dictionary<string, string> tempDictionarydic = new Dictionary<string, string>();

                            foreach (DataColumn dc in dataTable.Columns)
                            {
                                tempDictionarydic.Add(dc.ColumnName, dtRow[dc] == null ? String.Empty : dtRow[dc].ToString());
                            }

                            result.Add(tempDictionarydic);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return result;
        }


        public async Task<string> IsSqlConnected(ConnectionModel сonnectionModel)
        {
            var connectionString = ConnectionHelper.GetConncetionStringWithTimeout(сonnectionModel, 1);

            try
            {
                await using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                }

                var result = await SendSqlServerRequest(connectionString, "select  SERVERPROPERTY('Servername') as ServerName");

                return result[0]["ServerName"];
            }
            catch (Exception e)
            {
                return String.Empty;
            }
        }


    }

}
