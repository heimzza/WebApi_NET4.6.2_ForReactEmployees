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
    public class DepartmentController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();

            string query = @"SELECT DepartmentID, DepartmentName FROM dbo.Departments";

            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDB"].ConnectionString);
            var command = new SqlCommand(query, con);

            using (var dataAdapter = new SqlDataAdapter(command))
            {
                command.CommandType = CommandType.Text;
                dataAdapter.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(Department department)
        {
            try
            {
                DataTable table = new DataTable();

                string query = $"insert into dbo.Departments values('{department.DepartmentName}')";

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
        public string Put(Department department)
        {
            try
            {
                DataTable table = new DataTable();

                string query = $"update dbo.Departments set DepartmentName='{department.DepartmentName}' " +
                    $"where DepartmentID={department.DepartmentId}";

                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDB"].ConnectionString);
                var command = new SqlCommand(query, con);

                using (var dataAdapter = new SqlDataAdapter(command))
                {
                    command.CommandType = CommandType.Text;
                    dataAdapter.Fill(table);
                }

                return "Updated successfully";
            }
            catch (Exception)
            {

                return "And error occured during action";
            }
        }
    }
}
