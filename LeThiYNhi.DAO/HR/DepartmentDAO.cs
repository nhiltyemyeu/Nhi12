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
    public class DepartmentDAO : DBConnection
    {
        public CommandType CommandType { get; private set; }
        public List<DepartmentDTO> ReadDepList()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("Create Proc GetDepartment as select * from Department", conn);
            cmd.CommandText = "GetDepartment";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();


            List<DepartmentDTO> lstDep = new List<DepartmentDTO>();
            while (reader.Read())
            {
                DepartmentDTO dep = new DepartmentDTO();
                dep.Id = int.Parse(reader["id"].ToString());
                dep.Name = reader["name"].ToString();
                lstDep.Add(dep);
            }
            conn.Close();
            return lstDep;
        }

        public DepartmentDTO ReadDep(int id)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("Create Proc GetDepartment as select * from Department where id=" + id.ToString(), conn);
            cmd.CommandText = "GetDepartment";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            DepartmentDTO dep = new DepartmentDTO();
            if (reader.HasRows && reader.Read())
            {
                dep.Id = int.Parse(reader["id"].ToString());
                dep.Name = reader["name"].ToString();
            }
            conn.Close();
            return dep;

        }
    }
}
