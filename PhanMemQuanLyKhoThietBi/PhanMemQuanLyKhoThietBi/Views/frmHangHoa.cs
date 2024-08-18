using PhanMemQuanLyKhoThietBi.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemQuanLyKhoThietBi.Views
{
    public partial class frmHangHoa : Form
    {
        public frmHangHoa()
        {
            InitializeComponent();
        }
        HangHoaControllers db = new HangHoaControllers();
        NCCControllers dbNCC = new NCCControllers();
        LHHControllers dbLHH = new LHHControllers();
        private bool luu;
        private void frmHangHoa_Load(object sender, EventArgs e)
        {
            HienThiHangHoa("");
            boolcontrols(true);
            DanhSachLHH();
            DanhSachNCC();
            if (gridview.Rows.Count == 0)
            {
                return;
            }
            var row = this.gridview.Rows[0];
            txtMaHH.Text = row.Cells[0].Value.ToString();
            txtTenHH.Text = row.Cells[1].Value.ToString();
            txtTonKho.Value = decimal.Parse(row.Cells[2].Value.ToString());
            txtDonGia.Value = decimal.Parse(row.Cells[3].Value.ToString());
            cboMaNCC.SelectedValue = row.Cells[4].Value.ToString();
            cboMaLHH.SelectedValue = row.Cells[5].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DanhSachLHH();
            DanhSachNCC();
            txtMaHH.Text = "";
            txtTenHH.Text = "";
            txtTonKho.Value = 1;
            txtDonGia.Value = 1;

            boolcontrols(false);
            luu = true;
        }
        private void boolcontrols(bool iss)
        {
            btnThem.Enabled = iss;
            btnSua.Enabled = iss;
            btnXoa.Enabled = iss;
            btnLuu.Enabled = !iss;
            btnHuy.Enabled = !iss;
            btnLamMoi.Enabled = iss;
            btnThoat.Enabled = iss;
            btnTim.Enabled = iss;
            txtMaHH.Enabled = !iss;
            txtTenHH.Enabled = !iss;
            txtTonKho.Enabled = !iss;
            txtDonGia.Enabled = !iss;
            cboMaNCC.Enabled = !iss;
            cboMaLHH.Enabled = !iss;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (gridview.Rows.Count == 0)
            {
                return;
            }
            luu = false;
            txtMaHH.Enabled = false;
            boolcontrols(false);
            txtMaHH.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (gridview.Rows.Count == 0)
            {
                return;
            }
            DialogResult dr = MessageBox.Show("Có chắc chắn xóa hàng hóa này không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                db.Xoa(gridview.Rows[gridview.CurrentCell.RowIndex].Cells[0].Value.ToString());
                MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                HienThiHangHoa("");
                boolcontrols(true);
            }
            else
                return;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaHH.Text == "")
            {
                MessageBox.Show("Mã hàng hóa không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaHH.Focus();
                return;
            }
            if (txtTenHH.Text == "")
            {
                MessageBox.Show("Tên hàng hóa không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenHH.Focus();
                return;
            }

            if (luu == true)
            {
                try
                {
                    db.Them(txtMaHH.Text.Trim(), txtTenHH.Text.Trim(), txtTonKho.Value, txtDonGia.Value, cboMaNCC.SelectedValue.ToString(), cboMaLHH.SelectedValue.ToString());
                    MessageBox.Show("Thêm thành công.");
                    HienThiHangHoa("");
                    boolcontrols(true);
                }
                catch (Exception)
                {
                    MessageBox.Show("Mã hàng hóa đã tồn tại, vui lòng tạo mã khác.", "Thông báo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaHH.Focus();
                    return;
                }
            }
            else
            {
                try
                {
                    db.Sua(txtMaHH.Text.Trim(), txtTenHH.Text.Trim(), txtTonKho.Value, txtDonGia.Value, cboMaLHH.SelectedValue.ToString(), cboMaNCC.SelectedValue.ToString());
                    MessageBox.Show("Sửa thành công.");
                    HienThiHangHoa("");
                    boolcontrols(true);
                }
                catch (Exception)
                {
                    MessageBox.Show("Mã hàng hóa đã tồn tại, vui lòng tạo mã khác.", "Thông báo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaHH.Focus();
                    return;
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            HienThiHangHoa("");
            boolcontrols(true);
            if (gridview.Rows.Count == 0)
            {
                return;
            }
            var row = this.gridview.Rows[0];
            txtMaHH.Text = row.Cells[0].Value.ToString();
            txtTenHH.Text = row.Cells[1].Value.ToString();
            txtTonKho.Value = decimal.Parse(row.Cells[2].Value.ToString());
            txtDonGia.Value = decimal.Parse(row.Cells[3].Value.ToString());
            cboMaNCC.SelectedValue = row.Cells[4].Value.ToString();
            cboMaLHH.SelectedValue = row.Cells[5].Value.ToString();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            HienThiHangHoa("");
            boolcontrols(true);
            if (gridview.Rows.Count == 0)
            {
                return;
            }
            var row = this.gridview.Rows[0];
            txtMaHH.Text = row.Cells[0].Value.ToString();
            txtTenHH.Text = row.Cells[1].Value.ToString();
            txtTonKho.Value = decimal.Parse(row.Cells[2].Value.ToString());
            txtDonGia.Value = decimal.Parse(row.Cells[3].Value.ToString());
            cboMaNCC.SelectedValue = row.Cells[4].Value.ToString();
            cboMaLHH.SelectedValue = row.Cells[5].Value.ToString();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            HienThiHangHoa(txtTenSearch.Text);
        }
        private void HienThiHangHoa(string TenHH)
        {
            gridview.DataSource = db.HienThi(TenHH);
            gridview.Columns[0].HeaderText = "Mã hàng hóa";
            gridview.Columns[1].HeaderText = "Tên hàng hóa";
            gridview.Columns[2].HeaderText = "Tồn kho";
            gridview.Columns[3].HeaderText = "Đơn giá";
            gridview.Columns[4].HeaderText = "Nhà cung cấp";
            gridview.Columns[5].HeaderText = "Loại hàng hóa";
        }
        private void DanhSachLHH()
        {
            DataTable dt = dbLHH.HienThi("");
            cboMaLHH.DataSource = dt;
            cboMaLHH.DisplayMember = "TenLHH";
            cboMaLHH.ValueMember = "MaLHH";
        }
        private void DanhSachNCC()
        {
            DataTable dt = dbNCC.HienThi("");
            cboMaNCC.DataSource = dt;
            cboMaNCC.DisplayMember = "TenNCC";
            cboMaNCC.ValueMember = "MaNCC";
        }
        private void gridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.gridview.Rows[e.RowIndex];
                txtMaHH.Text = row.Cells[0].Value.ToString();
                txtTenHH.Text = row.Cells[1].Value.ToString();
                txtTonKho.Value = decimal.Parse(row.Cells[2].Value.ToString());
                txtDonGia.Value = decimal.Parse(row.Cells[3].Value.ToString());
                cboMaNCC.SelectedValue = row.Cells[4].Value.ToString();
                cboMaLHH.SelectedValue = row.Cells[5].Value.ToString();
            }
        }
    }
}
