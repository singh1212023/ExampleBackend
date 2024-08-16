using Microsoft.Data.SqlClient;
using RoleBasedAuthenticateProject.Models;
using RoleBasedAuthenticateProject.RequestModels;
using System.Data;

namespace RoleBasedAuthenticateProject.Repository
{
    public class TeacherClass:ITeacherInterface
    {
        private readonly sdirectdbContext sdirectdbContext = new sdirectdbContext();

        public ResponseModel GetTeacher()
        {
            ResponseModel response = new ResponseModel();
            var data = (from tch in sdirectdbContext.SatyamTeachers
                        where tch.IsDeleted == false
                        select new GetTeacher

                        {
                            TeacherId = tch.TeacherId,
                            TeacherName = tch.TeacherName,
                            TeacherEmail = tch.TeacherEmail,
                            TeacherPhone = tch.TeacherPhone,
                            City = tch.City,
                            CreatedBy = tch.CreatedBy,
                            CreatedOn = tch.CreatedOn,
                            Dob = tch.Dob,
                            IsDeleted = tch.IsDeleted,
                            IsActive = tch.IsActive,

                        }).ToList();
            response.ResponseMessage = "Data Fetched Successfully";
            response.StatusCode = 200;
            response.TeacherList = data;
            return response;
        }
        public ResponseModel AddTeacherData(Addteacher add)
        {
            ResponseModel response = new ResponseModel();
            var data = sdirectdbContext.SatyamTeachers.FirstOrDefault(i => i.TeacherEmail == add.TeacherEmail && i.TeacherPhone == add.TeacherPhone);

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
                SqlCommand cmd = new SqlCommand("PostSatyamTeacher", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@TeacherName", SqlDbType.VarChar).Value = add.TeacherName;
                cmd.Parameters.Add("@TeacherEmail", SqlDbType.VarChar).Value = add.TeacherEmail;
                cmd.Parameters.Add("@Dob", SqlDbType.VarChar).Value = add.Dob;
                cmd.Parameters.Add("@TeacherPhone", SqlDbType.VarChar).Value = add.TeacherPhone;
                cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = add.City;

                int iReturn = cmd.ExecuteNonQuery();
                if (iReturn > 0)
                {
                    response.StatusCode = 200;
                    response.ResponseMessage = " Teacher Added Successfuly";
                    return response;
                }
                else
                {
                    response.StatusCode = 400;
                    response.ResponseMessage = "Teacher not added";
                    return response;
                }
            }

        }

        public ResponseModel UpdateTeacher(UpdateTeacher update)
        {
            ResponseModel response = new ResponseModel();

            var builder = WebApplication.CreateBuilder();
            String ConnecStr = builder.Configuration.GetConnectionString("AppConn");
            SqlConnection conn = new SqlConnection(ConnecStr);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("UpdateSatyamTeacher", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = update.TeacherId;
            cmd.Parameters.Add("@TeacherName", SqlDbType.VarChar).Value = update.TeacherName;
            cmd.Parameters.Add("@TeacherEmail", SqlDbType.VarChar).Value = update.TeacherEmail;
            cmd.Parameters.Add("@Dob", SqlDbType.VarChar).Value = update.Dob;
            cmd.Parameters.Add("@TeacherPhone", SqlDbType.VarChar).Value = update.TeacherPhone;
            cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = update.City;

            int iReturn = cmd.ExecuteNonQuery();
            if (iReturn > 0)
            {
                response.StatusCode = 200;
                response.ResponseMessage = "Teacher Updated Successfuly";
                return response;
            }
            else
            {
                response.StatusCode = 400;
                response.ResponseMessage = "Teacher not Updated";
                return response;
            }
        }

        public ResponseModel GetTeacherById(int tchId)
        {
            ResponseModel response = new ResponseModel();
            var data = (from tch in sdirectdbContext.SatyamTeachers
                        where tch.TeacherId == tchId
                        select new GetTeacher
                        {

                            TeacherId = tch.TeacherId,
                            TeacherEmail = tch.TeacherEmail,
                            TeacherName = tch.TeacherName,
                            Dob = tch.Dob,
                            TeacherPhone = tch.TeacherPhone,
                            City = tch.City,
                            IsActive = tch.IsActive,
                            IsDeleted = tch.IsDeleted,
                            CreatedBy = tch.CreatedBy,
                            CreatedOn = tch.CreatedOn

                        }).FirstOrDefault();
            response.ResponseMessage = "Data of Teacher  Fetched";
            response.StatusCode = 200;
            response.Teacher = data;
            return response;
        }

        public ResponseModel DeleteTeacher(int id)
        {
            ResponseModel response = new ResponseModel();
            var data = sdirectdbContext.SatyamTeachers.FirstOrDefault(i => i.TeacherId == id);
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
