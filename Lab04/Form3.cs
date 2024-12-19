using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Lab04.Models;

namespace Lab04
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void FillFalcultyCombobox(List<Faculty> listFalcultys)
        {
            this.cmbFaculty.DataSource = listFalcultys;
            this.cmbFaculty.DisplayMember = "FacultyName";
            this.cmbFaculty.ValueMember = "FacultyID";
            this.cmbFaculty.SelectedIndex = -1;
        }

        private void BindGrid(List<Student> students)
        {
            dgvStudents.Rows.Clear();
            foreach (var item in students)
            {
                int index = dgvStudents.Rows.Add();
                dgvStudents.Rows[index].Cells[0].Value = item.StudentID;
                dgvStudents.Rows[index].Cells[1].Value = item.FullName;
                dgvStudents.Rows[index].Cells[2].Value = item.Gender;
                if (item.Faculty != null)
                {
                    dgvStudents.Rows[index].Cells[3].Value = item.Faculty.FacultyName;
                }
                else
                {
                    dgvStudents.Rows[index].Cells[3].Value = string.Empty;
                }
                dgvStudents.Rows[index].Cells[4].Value = item.AverageScore;
            }
        }
        private void cmbFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                StudentContextDB context = new StudentContextDB();
                List<Faculty> listFalcultys = context.Faculties.ToList(); 
                List<Student> listStudent = context.Students.ToList(); 
                
                FillFalcultyCombobox(listFalcultys);
                BindGrid(listStudent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                StudentContextDB context = new StudentContextDB();

                string studentID = txtStudentID.Text.Trim();
                string fullName = txtFullname.Text.Trim();
                int? facultyID = cmbFaculty.SelectedIndex > -1 ? (int?)cmbFaculty.SelectedValue : null;

                // Tìm kiếm điều kiện
                var query = context.Students.AsQueryable();

                if (!string.IsNullOrEmpty(studentID))
                    query = query.Where(s => s.StudentID.Contains(studentID));
                if (!string.IsNullOrEmpty(fullName))
                    query = query.Where(s => s.FullName.Contains(fullName));
                if (facultyID.HasValue)
                    query = query.Where(s => s.FacultyID == facultyID.Value);

                List<Student> students = query.ToList();
                BindGrid(students);

                //số kết quả tìm ra
                txtResult.Text = ($"{students.Count}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            StudentContextDB context = new StudentContextDB();
            List<Student> listStudent = context.Students.ToList();
            txtStudentID.Text = string.Empty;
            txtFullname.Text = string.Empty;
            cmbFaculty.SelectedIndex = -1;
            txtResult.Text = string.Empty;
            BindGrid(listStudent);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
