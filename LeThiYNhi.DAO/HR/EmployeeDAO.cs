using LeThiYNhi.DTO.HR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeThiYNhi.DAO.HR
{
    public class EmployeeDAO : DBConnection
    {
        public CommandType CommandType { get; private set; }
        public List<EmployeeDTO> ReadEm()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("Create proc GetDepartment as select * from Employee", conn);
            cmd.CommandText = "GetEmployee";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = cmd.ExecuteReader();



            List<EmployeeDTO> lstEm = new List<EmployeeDTO>();
            DepartmentDAO dep = new DepartmentDAO();
            while (reader.Read())
            {
                EmployeeDTO em = new EmployeeDTO();
                em.IdEm = reader["idemploy"].ToString();
                em.Name = reader["name"].ToString();
                em.Date = reader["datebirth"].ToString();
                em.Gender = (bool)reader["gender"];
                em.Department = dep.ReadDep(reader["iddepart"].ToString());
                em.Playbirth = reader["playbirth"].ToString();
                
                lstEm.Add(em);
            }
            conn.Close();
            return lstEm;
        }

        public void NewEmployee(EmployeeDTO em)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand();

            //Chỗ này tạm thời có thể gán cứng chuỗi kết nối
            try
            {

                //sử dụng thuộc tính CommandText để chỉ định tên Proc
                cmd.CommandText = "InsertEmployee";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                //khai báo các thông tin của tham số truyền vào
                cmd.Parameters.Add("@idemploy", SqlDbType.Int).Value = em.IdEm;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = em.Name;
                cmd.Parameters.Add("@datebirth", SqlDbType.NVarChar).Value = em.Date;
                cmd.Parameters.Add("@gender", SqlDbType.Bit).Value = em.Gender;
                cmd.Parameters.Add("@iddepart", SqlDbType.NVarChar).Value = em.Department.Id;
                cmd.Parameters.Add("@playbirth", SqlDbType.NVarChar).Value = em.Playbirth;
                

                //mở chuỗi kết nối
                conn.Open();
                //sử dụng ExecuteNonQuery để thực thi
                cmd.ExecuteNonQuery();
                //đóng chuỗi kết nối.
                conn.Close();

                Console.WriteLine("Them khach hang thanh cong !!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            // dóng chuỗi kết nối
            finally
            {
                conn.Close();
            }

        }

        public void EditEmployee(EmployeeDTO em)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand();

            //Chỗ này tạm thời có thể gán cứng chuỗi kết nối
            try
            {

                //sử dụng thuộc tính CommandText để chỉ định tên Proc
                cmd.CommandText = "UpdateEmployee";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                //khai báo các thông tin của tham số truyền vào
                cmd.Parameters.Add("@idemploy", SqlDbType.Int).Value = em.IdEm;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = em.Name;
                cmd.Parameters.Add("@datebirth", SqlDbType.NVarChar).Value = em.Date;
                cmd.Parameters.Add("@iddepart", SqlDbType.Int).Value = em.Department.Id;
                cmd.Parameters.Add("@playbirth", SqlDbType.NVarChar).Value = em.Playbirth;
                
                //mở chuỗi kết nối
                conn.Open();
                //sử dụng ExecuteNonQuery để thực thi
                cmd.ExecuteNonQuery();
                //đóng chuỗi kết nối.
                conn.Close();

                Console.WriteLine("Sua khach hang thanh cong !!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            // dóng chuỗi kết nối
            finally
            {
                conn.Close();
            }

        }

        public void DeleteEmployee(EmployeeDTO em)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand();

            //Chỗ này tạm thời có thể gán cứng chuỗi kết nối
            try
            {

                //sử dụng thuộc tính CommandText để chỉ định tên Proc
                cmd.CommandText = "DeleteEmployee";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                //khai báo các thông tin của tham số truyền vào
                cmd.Parameters.Add("@idemploy", SqlDbType.Int).Value = em.IdEm;
                //mở chuỗi kết nối
                conn.Open();
                //sử dụng ExecuteNonQuery để thực thi
                cmd.ExecuteNonQuery();
                //đóng chuỗi kết nối.
                conn.Close();



            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            // dóng chuỗi kết nối
            finally
            {
                conn.Close();
            }
        }
    }
}
