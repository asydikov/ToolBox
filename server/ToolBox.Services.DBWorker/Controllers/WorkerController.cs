using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ToolBox.Services.DBWorker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {

        public WorkerController()
        {

        }

        [AllowAnonymous]
        [HttpGet("test-connection")]
        public async Task<IActionResult> TestConnection()
        {
            var conncectionString = "Server=localhost, 1455; User Id=sa; Password=Pass_w0rd12; Database=master; MultipleActiveResultSets=true";
            var parameters = new Dictionary<string, string>();
            parameters.Add("@oneresultset", "1");

            var query = @"select * from [Identity].[dbo].[Users]";

            //List<Dictionary<string, string>> res = MakeRSQLServerequest(conncectionString, query);
            List<Dictionary<string, string>> res = MakeRSQLServerequest(conncectionString, "sp_spaceused", true, parameters);

            return Ok(res);
        }


        // https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/ado-net-code-examples
        private List<Dictionary<string, string>> MakeRSQLServerequest(string conncectionString, string instruction, bool isProcedure = false, Dictionary<string, string> parameters = null)
        {
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            DataTable dataTable;

            using (SqlConnection connection = new SqlConnection(conncectionString))

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

                dataTable = new DataTable();

                adapter.Fill(dataTable);
            }

            foreach (DataRow dtRow in dataTable.Rows)
            {
                Dictionary<string, string> tempDictionarydic = new Dictionary<string, string>();

                foreach (DataColumn dc in dataTable.Columns)
                {
                    tempDictionarydic.Add(dc.ColumnName, dtRow[dc].ToString());
                }

                result.Add(tempDictionarydic);
            }

            return result;
        }

    }

}