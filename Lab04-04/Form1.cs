using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab04_04.Models;

namespace Lab04_04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void LoadData(DateTime startDate, DateTime endDate)
        {
            try
            {
                using (var context = new ProductOrderDB())
                {
                    var invoices = context.Invoices
                        .Where(i => i.DeliveryDate >= startDate && i.DeliveryDate <= endDate)
                        .Select(i => new
                        {
                            i.InvoiceNo,
                            i.OrderDate,
                            i.DeliveryDate,
                            TotalAmount = i.Orders.Sum(o => o.Price * o.Quantity)
                        }).ToList();

                    if (invoices.Count > 0)
                    {
                        dgvQLGH.Rows.Clear();
                        int stt = 1;
                        foreach (var invoice in invoices)
                        {
                            int rowIndex = dgvQLGH.Rows.Add();
                            dgvQLGH.Rows[rowIndex].Cells[0].Value = stt++;
                            dgvQLGH.Rows[rowIndex].Cells[1].Value = invoice.InvoiceNo;
                            dgvQLGH.Rows[rowIndex].Cells[2].Value = invoice.OrderDate.ToString("dd/MM/yyyy");
                            dgvQLGH.Rows[rowIndex].Cells[3].Value = invoice.DeliveryDate.ToString("dd/MM/yyyy");
                            dgvQLGH.Rows[rowIndex].Cells[4].Value = invoice.TotalAmount;
                        }
                        txtTotal.Text = invoices.Sum(i => i.TotalAmount).ToString("N0");
                    }
                    else
                    {
                        dgvQLGH.Rows.Clear();
                        txtTotal.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dtpDaugiao.Value = DateTime.Today;
            dtpCuoigiao.Value = DateTime.Today;

            LoadData(dtpDaugiao.Value, dtpCuoigiao.Value);

        }

        private void chkCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCheck.Checked)
            {
                int month = dtpDaugiao.Value.Month;
                int year = dtpDaugiao.Value.Year;

                DateTime startDate = new DateTime(year, month, 1);
                DateTime endDate = new DateTime(year, month, DateTime.DaysInMonth(year, month));

                if (startDate > endDate)
                {
                    MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                LoadData(startDate, endDate);
            }
            else
            {
                dtpDat_ValueChanged(sender, e);
                dtpGiao_ValueChanged(sender, e);
            }
        }

        private void dgvQLGH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtpGiao_ValueChanged(object sender, EventArgs e)
        {
            DateTime startDate = dtpDaugiao.Value;
      DateTime endDate = dtpCuoigiao.Value;

      if (startDate > endDate)
      {
          MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          return;
      }

      LoadData(startDate, endDate);
        }

        private void dtpDat_ValueChanged(object sender, EventArgs e)
        {
            DateTime startDate = dtpDaugiao.Value;
            DateTime endDate = dtpCuoigiao.Value;

            if (startDate > endDate)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadData(startDate, endDate);
        }
    }
}
