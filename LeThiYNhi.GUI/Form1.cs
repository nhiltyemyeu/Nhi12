using LeThiYNhi.BLL.HR;
using LeThiYNhi.DTO.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeThiYNhi.GUI
{
    public partial class Form1 : Form
    {
        EmployeeBLL emBLL = new EmployeeBLL();
        DepartmentBLL depBLL = new DepartmentBLL();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<EmployeeDTO> lstEm = emBLL.ReadEm();
            foreach (EmployeeDTO em in lstEm)
            {
                dgvEm.Rows.Add(em.IdEm, em.Name, em.Date,em.Gender,em.Playbirth,em.DepartmentName);
            }
            List<DepartmentDTO> lstDep = depBLL.ReadDepList();
            foreach (DepartmentDTO dep in lstDep)
            {
                cbDv.Items.Add(dep);
            }
            cbDv.DisplayMember = "name";
        }


        private void btNew_Click(object sender, EventArgs e)
        {
            EmployeeDTO em = new EmployeeDTO();
            tbId.Text = "";
            tbName.Text = "";
            dt.Value = em.Date;
            tbNs.Text = "";
            ckbGt.Checked = false;

        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            EmployeeDTO em = new EmployeeDTO();
            em.IdEm = tbId.Text;
            em.Name = tbName.Text;
            em.Playbirth = tbNs.Text;
            em.Department = (DepartmentDTO)cbDv.SelectedItem;

            //if (ckbGt.Checked)
            //{
            //    em.Gender = true;
            //}

            emBLL.DeleteEmployee(em);


            DialogResult dg = MessageBox.Show("Bạn có chắn chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                int idx = dgvEm.CurrentCell.RowIndex;
                dgvEm.Rows.RemoveAt(idx);
            }
            MessageBox.Show("Đã xóa nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            EmployeeDTO em = new EmployeeDTO();
            if (tbId.Text == "")
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbId.Focus();
            }
            else
            {
                
                em.IdEm = tbId.Text;
                em.Name = tbName.Text;
                em.Playbirth = tbNs.Text;
                em.Department = (DepartmentDTO)cbDv.SelectedItem;
                emBLL.EditEmployee(em);
                DataGridViewRow row = dgvEm.CurrentRow;
                row.Cells[0].Value = em.IdEm;
                row.Cells[1].Value = em.Name;
                row.Cells[4].Value = em.Playbirth;
                row.Cells[5].Value = em.DepartmentName;
                
                
                if (ckbGt.Checked)
                    {
                    row.Cells[3].Value = true;
                    }
                row.Cells[3].Value = ckbGt.Text;




                MessageBox.Show("Đã sửa khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void dgvEm_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;

            tbId.Text = dgvEm.Rows[idx].Cells[0].Value.ToString();
            tbName.Text = dgvEm.Rows[idx].Cells[1].Value.ToString();
            //dt.Text = dgvEm.Rows[idx].Cells[2].Value.ToString();
            //ckbGt.Text = dgvEm.Rows[idx].Cells[3].Value.ToString();
            
            tbNs.Text = dgvEm.Rows[idx].Cells[4].Value.ToString();
            cbDv.Text = dgvEm.Rows[idx].Cells[5].Value.ToString();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            EmployeeDTO em = new EmployeeDTO();
            if (tbId.Text.Length < 1)
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbId.Focus();
            }
            else
            {
                em.IdEm = tbId.Text;
                em.Name = tbName.Text;
                em.Playbirth = tbNs.Text;
                em.Department = (DepartmentDTO)cbDv.SelectedItem;
                em.Gender = ckbGt.Checked;
                if (ckbGt.Checked)
                {
                    em.Gender = true;
                }
                emBLL.NewEmployee(em);

                dgvEm.Rows.Add(em.IdEm, em.Name, em.Date, em.Gender, em.Playbirth, em.DepartmentName);
                //if (ckbGt.Checked)
                //{
                //    em.Gender = true;
                //}

                MessageBox.Show("Đã thêm mới khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
