using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab04.Models;

namespace Lab04
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnAddUp_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(txtFacultyID.Text) ||
                    string.IsNullOrWhiteSpace(txtFacultyName.Text) ||
                    string.IsNullOrWhiteSpace(txtTotalProfessor.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin Mã khoa, Tên khoa và Tổng giảng viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int facultyID;
                if (int.TryParse(txtFacultyID.Text, out facultyID))
                {
                    using (StudentContextDB db = new StudentContextDB())
                    {
                        List<Faculty> facultyList = db.Faculties.ToList();

                        var existingFaculty = facultyList.FirstOrDefault(f => f.FacultyID == facultyID);
                        if (existingFaculty != null) // sưa khoa
                        {
                            existingFaculty.FacultyName = txtFacultyName.Text;
                            existingFaculty.TotalProfessor = int.Parse(txtTotalProfessor.Text);

                            db.SaveChanges();

                            MessageBox.Show("Chỉnh sửa thông tin khoa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else //thêm khoa 
                        {
                            if (facultyList.Any(f => f.FacultyID == facultyID))
                            {
                                MessageBox.Show("Mã khoa đã tồn tại. Vui lòng nhập một mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            var newFaculty = new Faculty
                            {
                                FacultyID = facultyID,
                                FacultyName = txtFacultyName.Text,
                                TotalProfessor = int.Parse(txtTotalProfessor.Text) // Giá trị hợp lệ cho TotalProfessor
                            };

                            db.Faculties.Add(newFaculty);
                            db.SaveChanges();

                            MessageBox.Show("Thêm khoa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Mã khoa không hợp lệ. Vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                using (StudentContextDB db = new StudentContextDB())
                {
                    BindGrid(db.Faculties.ToList());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xử lý dữ liệu: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                using (StudentContextDB context = new StudentContextDB())
                {
                    List<Faculty> faculties = context.Faculties.ToList(); 
                    BindGrid(faculties);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BindGrid(List<Faculty> faculties)
        {
            dgvFaculty.Rows.Clear();
            if (faculties != null && faculties.Count > 0)
            {
                foreach (var faculty in faculties)
                {
                    int index = dgvFaculty.Rows.Add();
                    dgvFaculty.Rows[index].Cells[0].Value = faculty.FacultyID;
                    dgvFaculty.Rows[index].Cells[1].Value = faculty.FacultyName;
                    dgvFaculty.Rows[index].Cells[2].Value = faculty.TotalProfessor;
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu khoa nào để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvFaculty_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvFaculty.Rows[e.RowIndex];
                txtFacultyID.Text = selectedRow.Cells[0].Value.ToString();
                txtFacultyName.Text = selectedRow.Cells[1].Value.ToString();
                txtTotalProfessor.Text = selectedRow.Cells[2].Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFacultyID.Text))
                {
                    MessageBox.Show("Vui lòng nhập Mã khoa để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (StudentContextDB db = new StudentContextDB()) 
                {
                    List<Faculty> faculties = db.Faculties.ToList();

                    var faculty = faculties.FirstOrDefault(f => f.FacultyID == int.Parse(txtFacultyID.Text));

                    if (faculty != null)
                    {

                        db.Faculties.Remove(faculty);
                        db.SaveChanges();

                        BindGrid(db.Faculties.ToList());

                        MessageBox.Show("Khoa đã được xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Khoa không tìm thấy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa dữ liệu: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dgvFaculty_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvFaculty.Rows[e.RowIndex];
                txtFacultyID.Text = selectedRow.Cells[0].Value.ToString();
                txtFacultyName.Text = selectedRow.Cells[1].Value.ToString();
                txtTotalProfessor.Text = selectedRow.Cells[2].Value.ToString();
            }
        }
    }
}
    

