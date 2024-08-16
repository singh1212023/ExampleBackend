using Microsoft.Data.SqlClient;
using RoleBasedAuthenticateProject.Models;
using RoleBasedAuthenticateProject.RequestModels;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static RoleBasedAuthenticateProject.RequestModels.EmployeeViewModel;

namespace RoleBasedAuthenticateProject.Repository
{
    public class StudentClass:IStudentInterface
    {
        private readonly sdirectdbContext sdirectdbContext = new sdirectdbContext();

        public ResponseModel GetStudent()
        {
            ResponseModel response = new ResponseModel();
            var data = (from std in sdirectdbContext.SatyamStudents
                        where std.IsDeleted == false
                        select new GetStudent

                        {
                            StudentId   = std.StudentId,
                            StudentName = std.StudentName,
                            StudentEmail= std.StudentEmail,
                            StudentPhone= std.StudentPhone,
                            City= std.City,
                            CreatedBy= std.CreatedBy,
                            CreatedOn= std.CreatedOn,
                            Dob= std.Dob,
                            IsDeleted= std.IsDeleted,
                            IsActive= std.IsActive,
                             
                        }).ToList();
            response.ResponseMessage = "Data Fetched Successfully";
            response.StatusCode = 200;
            response.Studentlist = data;
            return response;
        }
     

        public ResponseModel AddUpdateStudent(AddUpdate addupate)
        {
            ResponseModel response = new ResponseModel();
            if (addupate.StudentId == 0)
            {
                var data = sdirectdbContext.SatyamStudents.FirstOrDefault(i => i.StudentEmail == addupate.StudentEmail && i.StudentPhone == addupate.StudentPhone);

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
                    SqlCommand cmd = new SqlCommand("PostSatyamStudent", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@StudentName", SqlDbType.VarChar).Value = addupate.StudentName;
                    cmd.Parameters.Add("@StudentEmail", SqlDbType.VarChar).Value = addupate.StudentEmail;
                    cmd.Parameters.Add("@Dob", SqlDbType.VarChar).Value = addupate.Dob;
                    cmd.Parameters.Add("@StudentPhone", SqlDbType.VarChar).Value = addupate.StudentPhone;
                    cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = addupate.City;

                    int iReturn = cmd.ExecuteNonQuery();
                    if (iReturn > 0)
                    {
                        response.StatusCode = 200;
                        response.ResponseMessage = "Student Added Successfuly";
                        return response;
                    }
                    else
                    {
                        response.StatusCode = 400;
                        response.ResponseMessage = "Student not added";
                        return response;
                    }
                }
            }
            else if (addupate.StudentId > 0)
            {
                var builder = WebApplication.CreateBuilder();
                String ConnecStr = builder.Configuration.GetConnectionString("AppConn");
                SqlConnection conn = new SqlConnection(ConnecStr);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("UpdateSatymStudent", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = addupate.StudentId;
                cmd.Parameters.Add("@StudentName", SqlDbType.VarChar).Value = addupate.StudentName;
                cmd.Parameters.Add("@StudentEmail", SqlDbType.VarChar).Value = addupate.StudentEmail;
                cmd.Parameters.Add("@Dob", SqlDbType.VarChar).Value = addupate.Dob;
                cmd.Parameters.Add("@StudentPhone", SqlDbType.VarChar).Value = addupate.StudentPhone;
                cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = addupate.City;

                int iReturn = cmd.ExecuteNonQuery();
                if (iReturn > 0)
                {
                    response.StatusCode = 200;
                    response.ResponseMessage = "Student Updated Successfuly";
                    return response;
                }
                else
                {
                    response.StatusCode = 400;
                    response.ResponseMessage = "Student not Updated";
                    return response;
                }
            }
            else
            {
                response.ResponseMessage = " Id cannot be null";
                response.StatusCode = 500;
                return response;
            }
            //new comment to check change reflected to satyam sdd
            //new comment to check change reflected to main 

        }



























































        //public ResponseModel AddStudentData(AddStudent add)
        //{
        //    ResponseModel response = new ResponseModel();
        //    var data = sdirectdbContext.SatyamStudents.FirstOrDefault(i => i.StudentEmail == add.StudentEmail && i.StudentPhone == add.StudentPhone);

        //    if (data != null)
        //    {
        //        response.StatusCode = 400;
        //        response.ResponseMessage = "Enter Unique Details";
        //        return response;
        //    }
        //    else
        //    {
        //        var builder = WebApplication.CreateBuilder();
        //        String ConnecStr = builder.Configuration.GetConnectionString("AppConn");
        //        SqlConnection conn = new SqlConnection(ConnecStr);
        //        if (conn.State == ConnectionState.Closed)
        //        {
        //            conn.Open();
        //        }
        //        SqlCommand cmd = new SqlCommand("PostSatyamStudent", conn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("@StudentName", SqlDbType.VarChar).Value = add.StudentName;
        //        cmd.Parameters.Add("@StudentEmail", SqlDbType.VarChar).Value = add.StudentEmail;
        //        cmd.Parameters.Add("@Dob", SqlDbType.VarChar).Value = add.Dob;
        //        cmd.Parameters.Add("@StudentPhone", SqlDbType.VarChar).Value = add.StudentPhone;
        //        cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = add.City;

        //        int iReturn = cmd.ExecuteNonQuery();
        //        if (iReturn > 0)
        //        {
        //            response.StatusCode = 200;
        //            response.ResponseMessage = "Student Added Successfuly";
        //            return response;
        //        }
        //        else
        //        {
        //            response.StatusCode = 400;
        //            response.ResponseMessage = "Student not added";
        //            return response;
        //        }
        //    }

        //}


        //public ResponseModel UpdateStudent(UpdateStudent update)
        //{
        //    ResponseModel response = new ResponseModel();

        //    var builder = WebApplication.CreateBuilder();
        //    String ConnecStr = builder.Configuration.GetConnectionString("AppConn");
        //    SqlConnection conn = new SqlConnection(ConnecStr);
        //    if (conn.State == ConnectionState.Closed)
        //    {
        //        conn.Open();
        //    }
        //    SqlCommand cmd = new SqlCommand("UpdateSatymStudent", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = update.StduentId;
        //    cmd.Parameters.Add("@StudentName", SqlDbType.VarChar).Value = update.StudentName;
        //    cmd.Parameters.Add("@StudentEmail", SqlDbType.VarChar).Value = update.StudentEmail;
        //    cmd.Parameters.Add("@Dob", SqlDbType.VarChar).Value = update.Dob;
        //    cmd.Parameters.Add("@StudentPhone", SqlDbType.VarChar).Value = update.StudentPhone;
        //    cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = update.City;

        //    int iReturn = cmd.ExecuteNonQuery();
        //    if (iReturn > 0)
        //    {
        //        response.StatusCode = 200;
        //        response.ResponseMessage = "Student Updated Successfuly";
        //        return response;
        //    }
        //    else
        //    {
        //        response.StatusCode = 400;
        //        response.ResponseMessage = "Student not Updated";
        //        return response;
        //    }
        //}













        public ResponseModel GetStudentDataById(int stdId)
        {
            ResponseModel response = new ResponseModel();
            var data = (from e in sdirectdbContext.SatyamStudents
                        where e.StudentId == stdId
                        select new GetStudent
                        {

                            StudentId = e.StudentId,
                            StudentEmail = e.StudentEmail,
                            StudentName = e.StudentName,

                            Dob = e.Dob,
                            StudentPhone = e.StudentPhone,
                            City = e.City,
                            IsActive = e.IsActive,
                            IsDeleted=e.IsDeleted,
                            CreatedBy = e.CreatedBy,
                            CreatedOn = e.CreatedOn

                        }).FirstOrDefault();
            response.ResponseMessage = "Data of Student  Fetched";
            response.StatusCode = 200;
            response.Student = data;
            return response;
        }
        public ResponseModel DeletStudent(int id)
        {
            ResponseModel response = new ResponseModel();
            var data = sdirectdbContext.SatyamStudents.FirstOrDefault(i => i.StudentId == id);
            if (data != null)
            {
                data.IsDeleted = true;
                sdirectdbContext.Update(data);
                sdirectdbContext.SaveChanges();
                response.ResponseMessage = "Data Deleted Successfully";
                response.StatusCode = 200;
                return response;
            }
            return response;
        }


    }
}
