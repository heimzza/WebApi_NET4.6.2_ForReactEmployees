using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();

            string query = @"SELECT EmployeeID, EmployeeName, Department, MailID, CONVERT(varchar(10), DOJ, 120) as DOJ FROM dbo.Employees";

            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDB"].ConnectionString);
            var command = new SqlCommand(query, con);

            using (var dataAdapter = new SqlDataAdapter(command))
            {
                command.CommandType = CommandType.Text;
                dataAdapter.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(Employee employee)
        {
            try
            {
                DataTable table = new DataTable();

                string query = $"insert into dbo.Employees (EmployeeName, Department, MailID, DOJ) values('{employee.EmployeeName}', " +
                    $"'{employee.Department}', '{employee.MailID}', '{employee.DOJ?.ToString("yyyy-MM-dd")}')";

                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDB"].ConnectionString);
                var command = new SqlCommand(query, con);

                using (var dataAdapter = new SqlDataAdapter(command))
                {
                    command.CommandType = CommandType.Text;
                    dataAdapter.Fill(table);
                }

                return "Added successfully";
            }
            catch (Exception)
            {
                return "And error occured during action";
            }
        }
    }
}