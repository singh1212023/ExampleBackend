using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RoleBasedAuthenticateProject.Models;
using RoleBasedAuthenticateProject.RequestModels;
using System.Data;

namespace RoleBasedAuthenticateProject.Repository
{
    public class UserClass:IUserInterface
    {

        public readonly sdirectdbContext _context;
        public UserClass(sdirectdbContext context)
        {
            _context = context;
        }
        public ResponseModel GetUser()
        {
            ResponseModel response = new ResponseModel();
            try
            {

                var data = (from user in _context.MyLoginTable227s

                            select new GetUser
                            {
                                UserEmail = user.UserEmail,
                                UserPassword = user.UserPassword


                            }).ToList();
                response.ResponseMessage = "User Data Fetched Successfully";
                response.StatusCode = 200;
                response.UserList = data;
                return response;
            }
            catch (Exception ex)
            {
                response.ResponseMessage = ex.Message;
                response.StatusCode = 500;
                return response;
            }
        }

        public ResponseModel AddUserDetails(AddUserViewModel add)
        {
            ResponseModel response = new ResponseModel();
            try
            {

                var data = _context.MyLoginTable227s.FirstOrDefault(i => i.UserEmail == add.UserEmail);

                if (data != null)
                {
                    response.StatusCode = 400;
                    response.ResponseMessage = "Enter Unique Details";
                    return response;
                }
                else
                {
                    var builder = WebApplication.CreateBuilder();
                    String ConnecStr = builder.Configuration.GetConnectionString("AppConn");
                    SqlConnection conn = new SqlConnection(ConnecStr);
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("PostMyLoginTable227", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = add.UserName;
                    cmd.Parameters.Add("@UserEmail", SqlDbType.VarChar).Value = add.@UserEmail;
                    cmd.Parameters.Add("@UserPassword", SqlDbType.VarChar).Value = add.@UserPassword;
                    cmd.Parameters.Add("@UserPhone", SqlDbType.VarChar).Value = add.UserPhone;
                    


                    int iReturn = cmd.ExecuteNonQuery();
                    if (iReturn > 0)
                    {
                        response.StatusCode = 200;
                        response.ResponseMessage = "User Added Successfuly";
                        return response;
                    }
                    else
                    {
                        response.StatusCode = 400;
                        response.ResponseMessage = "User not added";
                        return response;
                    }



                }
            }
            catch (Exception ex)
            {
                response.ResponseMessage = ex.Message;
                response.StatusCode = 500;
                return response;
            }
        }
    }
}
