using LeThiYNhi.DAO.HR;
using LeThiYNhi.DTO.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeThiYNhi.BLL.HR
{
    public class DepartmentBLL
    {
        DepartmentDAO dal = new DepartmentDAO();
        public List<DepartmentDTO> ReadDepList()
        {
            List<DepartmentDTO> lstDep = dal.ReadDepList();
            return lstDep;
        }
    }
}
