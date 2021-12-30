using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeThiYNhi.DTO.HR
{
    public class EmployeeDTO
    {
        public string IdEm { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public bool Gender { get; set; }
        public string Playbirth { get; set; }
        public DepartmentDTO Department { get; set; }
        public string DepartmentName
        {
            get { return Department.Name; }
        }
    }
}
