using LeThiYNhi.DAO.HR;
using LeThiYNhi.DTO.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeThiYNhi.BLL.HR
{
    public class EmployeeBLL
    {
        EmployeeDAO dal = new EmployeeDAO();
        public List<EmployeeDTO> ReadEm()
        {
            List<EmployeeDTO> lstEm = dal.ReadEm();
            return lstEm;
        }

        public void NewEmployee(EmployeeDTO em)
        {
            dal.NewEmployee(em);
        }

        public void DeleteEmployee(EmployeeDTO em)
        {
            dal.DeleteEmployee(em);
        }

        public void EditEmployee(EmployeeDTO em)
        {
            dal.EditEmployee(em);
        }
    }
}
