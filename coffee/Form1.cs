using BALayer;
using coffee.DAO;
using coffee.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coffee
{
    public partial class Form1 : Form
    {
        //nhân viên
        MemoryStream ms;
        byte[] arrImage;
        public Form1()
        {
            InitializeComponent();
        }
        bool ThemNV = false;      //dùng đánh dấu nút cập nhật/thêm
        DBNhanVien dbkh = new DBNhanVien();
        
        // Đối tượng hiển thị dữ liệu lên Form 


        DataTable dtNhanvien = null;
        private void btnChonHinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog odlgOpenFile = new OpenFileDialog();
            odlgOpenFile.InitialDirectory = "C:\\";
            odlgOpenFile.Title = "Open File";
            odlgOpenFile.Filter = "Image files (*.jpg)|*.jpg|All files (*.*)|*.*";
            if (odlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                picBox.Image = System.Drawing.Image.FromFile(odlgOpenFile.FileName);
                //
                ms = new MemoryStream();
                picBox.Image.Save(ms, picBox.Image.RawFormat);
                arrImage = ms.GetBuffer();
                ms.Close();
                picBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
        private void stcNhanVien_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            dtNhanvien = new DataTable();
            dtNhanvien.Clear();
            dtNhanvien = dbkh.LayNhanVien().Tables[0];
            dtvNhanVien.DataSource = dtNhanvien;
            tbID.Enabled = false;
            tbTen.Enabled = false;
           tbChucVu.Enabled = false;
            tbSDT.Enabled = false;
            tbDiaChi.Enabled = false;
            dtpNgayNV.Enabled = false;
            btnChonHinh.Enabled = false;
              btnLuuNV.Enabled = false;
            tbTienThuong.Enabled = false;
            tbNgayNghi.Enabled = false;
            tbTienThuong.Enabled = false;
            tbLuong.Enabled = false;
            tbCaLam.Enabled = false;
            tbTuoi.Enabled = false;
        }
        private void dtvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dtvNhanVien.CurrentCell.RowIndex;
            this.tbID.Text = dtvNhanVien.Rows[r].Cells[0].Value.ToString();
            this.tbTen.Text = dtvNhanVien.Rows[r].Cells[1].Value.ToString();
            this.tbDiaChi.Text = dtvNhanVien.Rows[r].Cells[2].Value.ToString();
            this.tbSDT.Text = dtvNhanVien.Rows[r].Cells[4].Value.ToString();
            if (dtvNhanVien.Rows[r].Cells[3].Value.ToString().Equals("Nam"))
            {
                this.rbNu.Checked = false;
                this.rbNam.Checked = true;
            }
            else
            {
                this.rbNam.Checked = false;
                this.rbNu.Checked = true;
            }
            this.tbTienThuong.Text = dtvNhanVien.Rows[r].Cells[6].Value.ToString();
            this.picBox.Image = (System.Drawing.Image)
              dtvNhanVien.Rows[r].Cells[10].FormattedValue;
            this.dtpNgayNV.Text =
          dtvNhanVien.Rows[r].Cells[5].Value.ToString();
            ms = new MemoryStream();
            picBox.Image.Save(ms, picBox.Image.RawFormat);
            arrImage = ms.GetBuffer();
            ms.Close();
            picBox.SizeMode = PictureBoxSizeMode.Zoom;
            this.tbCaLam.Text = dtvNhanVien.Rows[r].Cells[7].Value.ToString();
            this.tbLuong.Text = dtvNhanVien.Rows[r].Cells[8].Value.ToString();
            this.tbNgayNghi.Text = dtvNhanVien.Rows[r].Cells[9].Value.ToString();
            this.tbTuoi.Text= dtvNhanVien.Rows[r].Cells[12].Value.ToString();
            this.tbChucVu.Text= dtvNhanVien.Rows[r].Cells[11].Value.ToString();

        }
        private void btnLuuNV_Click(object sender, EventArgs e)
        {
            bool f = false;
            // Thêm dữ liệu
            if (ThemNV)
            {
                string err = "";
                try
                {
                    // Lựa chọn giới tính
                    string GioiTinh = "Nam";
                    if (rbNam.Checked == false)
                    {
                        GioiTinh = "Nu";
                    }
                    // đưa vào StringBuider--> thông báo
                    StringBuilder output = new StringBuilder();
                    output.Append(" Tên:" + tbTen.Text + " Số Điện thoại:" + tbSDT.Text + " Giới tính" +
                        GioiTinh + " Địa chỉ" + tbDiaChi.Text);
                    //Kết quả chọn Yes/No -->rs
                    DialogResult rs = MessageBox.Show(output.ToString(), "Them khach hang", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rs == DialogResult.Yes)
                    {
                        try
                        {
                            // chọn Yes --> Thực thi 
                            f = dbkh.ThemNhanVien(ref err, tbTen.Text, tbDiaChi.Text,GioiTinh, Int32.Parse(tbSDT.Text),
                                DateTime.Parse(dtpNgayNV.Text),float.Parse(tbTienThuong.Text), 
                                tbCaLam.Text,float.Parse(tbLuong.Text),Int32.Parse( tbNgayNghi.Text), arrImage,tbChucVu.Text,Int32.Parse(tbTuoi.Text));
                            if (f)
                            {
                                LoadData();
                                MessageBox.Show("Đã thêm: " + output.ToString());
                                //btnXoa.Enabled = true;
                                //btnSua.Enabled = true;
                                bntXoaNV.Enabled = true;
                                bntXoaNV.Enabled = true;
                            }
                        }
                        catch (Exception)
                        {
                            StringBuilder errs = new StringBuilder();
                            errs.Append("Đã có lỗi, bạn xem lại:.\r\n" + "+Điền đầy đủ thông tin.\r\n" + "+Tuổi phải kiểu số nguyên.");
                            MessageBox.Show(errs.ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Thêm chưa xong!\n\r" + "Lỗi:" + err);
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi!");
                }

            }
            else
            {
                // Cập nhật dữ liệu
                string err = "";
                try
                {
                    string GioiTinh = "Nam";
                    if (rbNam.Checked == false)
                    {
                        GioiTinh = "Nu";
                    }
                    // đưa vào StringBuider--> thông báo
                    StringBuilder output = new StringBuilder();
                    output.Append(" Tên:" + tbTen.Text + " Số Điện thoại:" + tbSDT.Text + " Giới tính" +
                        GioiTinh + " Địa chỉ" + tbDiaChi.Text);
                    //Kết quả chọn Yes/No -->rs
                    DialogResult rs = MessageBox.Show(output.ToString(), "Sửa khách hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rs == DialogResult.Yes)
                    {
                        try
                        {
                            f = dbkh.CapNhatNhanVien(ref err, int.Parse(tbID.Text), tbTen.Text, tbDiaChi.Text, GioiTinh, Int32.Parse(tbSDT.Text),
                                DateTime.Parse(dtpNgayNV.Text), float.Parse(tbTienThuong.Text),
                                tbCaLam.Text, float.Parse(tbLuong.Text), Int32.Parse(tbNgayNghi.Text), arrImage, tbChucVu.Text, Int32.Parse(tbTuoi.Text));
                            if (f)
                            {
                                // Load lại dữ liệu trên DataGridView 
                                LoadData();
                                // Thông báo 
                                MessageBox.Show("Đã cập nhật xong!");
                                //btnXoa.Enabled = true;
                                //btnThem.Enabled = true;
                                bntXoaNV.Enabled = true;
                                bntThemNV.Enabled = true;
                            }

                            else
                            {
                                MessageBox.Show("Cập nhật chưa xong!\n\r" + "Lỗi:" + err);
                            }
                        }
                        catch (Exception)
                        {
                            StringBuilder errs = new StringBuilder();
                            errs.Append("Đã có lỗi, bạn xem lại:.\r\n" + "+Điền đầy đủ thông tin.\r\n" + "+Tuổi phải kiểu số nguyên.");
                            MessageBox.Show(errs.ToString());
                        }
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không cập nhật được. Lỗi rồi!");
                }

            }
        }
        private void bntThemNV_Click(object sender, EventArgs e)
        {
            btnLuuNV.Enabled = true;
            // txtMaKH.Enabled = true;
           
            tbTen.Clear();
            tbSDT.Clear();
            tbDiaChi.Clear();

            btnChonHinh.Enabled = true;
            dtpNgayNV.Enabled = true;
            
            tbTen.Enabled = true;
            tbSDT.Enabled = true;
            tbDiaChi.Enabled = true;
            //btnSua.Enabled = false;
            //btnXoa.Enabled = false;
            tbNgayNghi.Enabled = true;
            tbChucVu.Enabled = true;
            tbLuong.Enabled = true;
            tbTuoi.Enabled = true;
            tbCaLam.Enabled = true;
            tbTienThuong.Enabled = true;
            bntSuaNV.Enabled = false;
            bntXoaNV.Enabled = false;

            ThemNV = true;
            picBox.Image = picBox.ErrorImage;
            ms = new MemoryStream();
            picBox.Image.Save(ms, picBox.Image.RawFormat);
            arrImage = ms.GetBuffer();
            ms.Close();
            picBox.SizeMode = PictureBoxSizeMode.Zoom;
        }
        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
            bntXoaNV.Enabled = true;
            bntSuaNV.Enabled = true;
            bntThemNV.Enabled = true;
        }
        private void bntXoaNV_Click(object sender, EventArgs e)
        {
            bool f = false;
            string err = "";
            int r = dtvNhanVien.CurrentCell.RowIndex;
            string GioiTinh = "Nam";
            if (rbNam.Checked == false)
            {
                GioiTinh = "Nu";
            }
            //int id=Int32.Parse
            StringBuilder output = new StringBuilder();
            output.Append(" Tên:" + tbTen.Text + " Số Điện thoại:" + tbSDT.Text + " Giới tính" +
                        GioiTinh + " Địa chỉ" + tbDiaChi.Text);
            DialogResult rs = MessageBox.Show(output.ToString(), "Bạn muốn xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                try
                {
                    f = dbkh.XoaNhanVien(ref err, Int32.Parse(tbID.Text));
                    if (f)
                    {
                        MessageBox.Show("Đã xóa xong!!!!");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Nhân viên này đã lập hóa đơn, bạn không thể xóa!!!");
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show("Lỗi " + ee);
                }
            }
            else
                MessageBox.Show("Chưa xóa" + output.ToString());
        }
        private void bntSuaNV_Click(object sender, EventArgs e)
        {
            //btnLuu.Focus();
            btnLuuNV.Enabled = true;
            dtpNgayNV.Enabled = true;
           // txtHo.Enabled = true;
            tbTen.Enabled = true;
            tbSDT.Enabled = true;
            tbDiaChi.Enabled = true;
            tbCaLam.Enabled = true;
            tbChucVu.Enabled = true;
            tbLuong.Enabled = true;
            tbNgayNghi.Enabled = true;
            tbTienThuong.Enabled = true;
            tbTuoi.Enabled = true;
           
            //btnThem.Enabled = false;
            //btnXoa.Enabled = false;
            bntThemNV.Enabled = false;
            bntXoaNV.Enabled = false;
            ThemNV = false;
            btnChonHinh.Enabled = true;
        }
        // kết thúc nhân viên
        private void applicationButton1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void superTabControlPanel5_Click(object sender, EventArgs e)
        {

        }

        private void superTabControlPanel1_Click(object sender, EventArgs e)
        {


        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxX2_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void groupPanel4_Click(object sender, EventArgs e)
        {

        }

        private void stcTra_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// hóa đơn
        /// </summary>
        void LoadCategory()
        {
            CategoryDAO db = new CategoryDAO();
            // List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            List<Category> listCategory = db.GetListCategory();
             cbCategory.DataSource = listCategory;
            cbCategory.DisplayMember = "Name";
        }

        void LoadFoodListByCategoryID(int id)
        {
            DrinkDAO db = new DrinkDAO();
            //  List<Drink> listFood = FoodDAO.Instance.GetFoodByCategoryID(id);
            List<Drink> listDrink = db.GetFoodByCategoryID(id);
            cbFood.DataSource = listDrink;
            cbFood.DisplayMember = "Name";
        }
        public void LoadTable() {
            flpTable.Controls.Clear();
            TableDAO table = new TableDAO();
            List<Table> tableList = table.LoadTableList();
            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status;

                btn.Click += Btn_Click;
                btn.Tag = item;
                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.Aqua;
                        break;
                    default:
                        btn.BackColor = Color.LightPink;
                        break;
                }

                flpTable.Controls.Add(btn);
            }
        }
        private void stcHoaDon_Click(object sender, EventArgs e)
        {
            LoadTable();
            LoadCategory();
        }

        void ShowBill(int id)
        {
            lsvBill.Items.Clear();
            BillInfoDAO billinfo = new BillInfoDAO();
            BillDAO bill = new BillDAO();
            MenuDAO menu = new MenuDAO();
            List<DTO.Menu> list = menu.GetListMenuByTable(id);
            //List<QuanLyQuanCafe.DTO.Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
           // List<BillInfo> listbillinfo = billinfo.GetListBillInfo(bill.GetUncheckBillIDByTableID(id));
            float totalPrice = 0;
            foreach (DTO.Menu item in list)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                lsvBill.Items.Add(lsvItem);
            }
             CultureInfo culture = new CultureInfo("vi-VN");

             Thread.CurrentThread.CurrentCulture = culture;

              txbTotalPrice.Text = totalPrice.ToString("#,##", culture);
            //txbTotalPrice.Text = totalPrice.ToString();
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            lsvBill.Tag = (sender as Button).Tag;
            ShowBill(tableID);
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            Category selected = cb.SelectedItem as Category;
            id = selected.ID;

            LoadFoodListByCategoryID(id);
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            string err = "";
            DBBill dbbill = new DBBill();
            DBBillInfo dbBillInfo = new DBBillInfo();
            bool f = false;
            BillDAO db = new BillDAO();
            Table table = lsvBill.Tag as Table;

            if (table == null)
            {
                MessageBox.Show("Hãy chọn bàn");
                return;
            }

            //int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
            int idBill = db.GetUncheckBillIDByTableID(table.ID);
            int foodID = (cbFood.SelectedValue as Drink).ID;
            int count = (int)nmFoodCount.Value;

            if (idBill == -1)
            {
                //  BillDAO.Instance.InsertBill(table.ID);
                f = dbbill.InsertBill(ref err, table.ID, 1);
                // BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), foodID, count);
                f = dbBillInfo.thembliiInfo(ref err, dbbill.GetMaxIDBill(), foodID, count);

            }
            else
            {
                dbBillInfo.thembliiInfo(ref err,idBill, foodID, count);
            }

            ShowBill(table.ID);

            LoadTable();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            string err = "";
            DBBill dbBill = new DBBill();
            BillDAO dbbill = new BillDAO();
            
            Table table = lsvBill.Tag as Table;

            int idBill = dbbill.GetUncheckBillIDByTableID(table.ID);
           // int discount = (int)nmDisCount.Value;

            double totalPrice = Convert.ToDouble(txbTotalPrice.Text.Split(',')[0]);
           // double finalTotalPrice = totalPrice - (totalPrice / 100) * discount;

            if (idBill != -1)
            {
                if (MessageBox.Show(string.Format("Bạn có chắc thanh toán hóa đơn cho bàn {0}\nTổng tiền {1}", table.Name, totalPrice), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    //BillDAO.Instance.CheckOut(idBill, discount, (float)finalTotalPrice);
                    dbBill.updateBill(ref err, idBill);
                    ShowBill(table.ID);
                    LoadTable();
                }
            }
        }
    }
}
