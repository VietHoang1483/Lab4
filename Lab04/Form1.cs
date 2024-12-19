using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Lab04.Models;

namespace Lab04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                StudentContextDB context = new StudentContextDB();
                List<Faculty> listFalcultys = context.Faculties.ToList(); //lấy các khoa 
                List<Student> listStudent = context.Students.ToList(); //lấy sinh viên 
                FillFalcultyCombobox(listFalcultys);
                BindGrid(listStudent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FillFalcultyCombobox(List<Faculty> listFalcultys)
        {
            this.cmbFaculty.DataSource = listFalcultys;
            this.cmbFaculty.DisplayMember = "FacultyName";
            this.cmbFaculty.ValueMember = "FacultyID";
        }
        private void BindGrid(List<Student> listStudent)
        {
            dgvStudent.Rows.Clear();
            foreach (var item in listStudent)
            {
                int index = dgvStudent.Rows.Add();
                dgvStudent.Rows[index].Cells[0].Value = item.StudentID;
                dgvStudent.Rows[index].Cells[1].Value = item.FullName;
                dgvStudent.Rows[index].Cells[2].Value = item.Gender;
                if (item.Faculty != null)
                {
                    dgvStudent.Rows[index].Cells[3].Value = item.Faculty.FacultyName;
                }
                else
                {
                    dgvStudent.Rows[index].Cells[3].Value = "Công nghệ thông tin"; // Giá trị mặc định
                }
                dgvStudent.Rows[index].Cells[4].Value = item.AverageScore;
            }
        }

        private void btbAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtStudentID.Text) ||
                    string.IsNullOrWhiteSpace(txtFullname.Text) ||
                    string.IsNullOrWhiteSpace(txtAverageScore.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin MSSV, Họ tên và Điểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra MSSV phải đúng 10 ký tự
                if (txtStudentID.Text.Length != 10)
                {
                    MessageBox.Show("Mã số sinh viên phải đúng 10 ký tự. Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                StudentContextDB db = new StudentContextDB();
                List<Student> studentLst = db.Students.ToList();
                if (studentLst.Any(s => s.StudentID == txtStudentID.Text))
                {
                    MessageBox.Show("Ma SV đa ton tại. Vui long nhap mot ma khac.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newStudent = new Student
                {
                    StudentID = txtStudentID.Text,
                    FullName = txtFullname.Text,
                    Gender = rdMale.Checked ? "Male" : "Female",
                    FacultyID = int.Parse(cmbFaculty.SelectedValue.ToString()),
                    AverageScore = double.Parse(txtAverageScore.Text)
                };
                // Thêm sinh viên vào CSDL
                db.Students.Add(newStudent);
                db.SaveChanges();

                // Hiển thị lại danh sách sinh viên
                BindGrid(db.Students.ToList());

                MessageBox.Show("Them sinh vien thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm dữ liệu: {ex.Message}", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtStudentID.Text) ||
                    string.IsNullOrWhiteSpace(txtFullname.Text) ||
                    string.IsNullOrWhiteSpace(txtAverageScore.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin MSSV, Họ tên và Điểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra MSSV phải đúng 10 ký tự
                if (txtStudentID.Text.Length != 10)
                {
                    MessageBox.Show("Mã số sinh viên phải đúng 10 ký tự. Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                StudentContextDB db = new StudentContextDB();
                List<Student> students = db.Students.ToList();
                var student = students.FirstOrDefault(s => s.StudentID == txtStudentID.Text);
                if (student != null)
                {
                    if (students.Any(s => s.StudentID == txtStudentID.Text && s.StudentID != student.StudentID))
                    {
                        MessageBox.Show("Ma SV đa ton tại. Vui long nhap mot ma khac.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    student.FullName = txtFullname.Text;
                    student.Gender = rdMale.Checked ? "Male" : "Female";
                    student.FacultyID = int.Parse(cmbFaculty.SelectedValue.ToString());
                    student.AverageScore = double.Parse(txtAverageScore.Text);

                    // Cập nhật sinh viên lưu vào CSDL
                    db.SaveChanges();

                    // Hiển thị lại danh sách sinh viên
                    BindGrid(db.Students.ToList());

                    MessageBox.Show("Chinh sua thong tin sinh viên thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sinh viên không tim thay!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Loi khi cập nhật dữ liệu: {ex.Message}", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtStudentID.Text) ||
                    string.IsNullOrWhiteSpace(txtFullname.Text) ||
                    string.IsNullOrWhiteSpace(txtAverageScore.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin MSSV, Họ tên và Điểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //MSSV phải đúng 10 ký tự
                if (txtStudentID.Text.Length != 10)
                {
                    MessageBox.Show("Mã số sinh viên phải đúng 10 ký tự. Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                StudentContextDB db = new StudentContextDB();
                List<Student> studentList = db.Students.ToList();

                // Tìm kiếm sinh viên có tổn tại trong CSDL hay không
                var student = studentList.FirstOrDefault(s => s.StudentID == txtStudentID.Text);
                if (student != null)
                {
                    // Xoá sinh viên khỏi CSDL
                    db.Students.Remove(student);
                    db.SaveChanges();

                    BindGrid(db.Students.ToList());

                    MessageBox.Show("Sinh vien đa được xoa thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sinh viên khong tim thay!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật dữ liệu: {ex.Message}", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dgvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvStudent.Rows[e.RowIndex];
                txtStudentID.Text = selectedRow.Cells[0].Value.ToString();
                txtFullname.Text = selectedRow.Cells[1].Value.ToString();
                string gender = selectedRow.Cells[2].Value.ToString();
                if (gender == "Male")
                {
                    rdMale.Checked = true;
                }
                else
                {
                    rdFemale.Checked = true;
                }
                cmbFaculty.Text = selectedRow.Cells[3].Value.ToString();
                txtAverageScore.Text = selectedRow.Cells[4].Value.ToString();
            }
        }

        private void quảnLýKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvStudent.Rows[e.RowIndex];
                txtStudentID.Text = selectedRow.Cells[0].Value.ToString();
                txtFullname.Text = selectedRow.Cells[1].Value.ToString();
                string gender = selectedRow.Cells[2].Value.ToString();
                if (gender == "Male")
                {
                    rdMale.Checked = true;
                }
                else
                {
                    rdFemale.Checked = true;
                }
                cmbFaculty.Text = selectedRow.Cells[3].Value.ToString();
                txtAverageScore.Text = selectedRow.Cells[4].Value.ToString();
            }
        }
    }
}
