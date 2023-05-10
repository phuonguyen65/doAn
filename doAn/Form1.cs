﻿using doAn.formCon;
using doAn.formSua;
using doAn.List;
using doAn.Object;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace doAn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
               "Bạn có chắc muốn thoát?",
               "Thông báo",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnNhapLop_Click(object sender, EventArgs e)
        {
            frmInputLop frmLop = new frmInputLop(); // tạo 1 đối tượng từ class frmInputLop
            frmLop.Show();
        }

        private void btnNhapSv_Click(object sender, EventArgs e)
        {
            frmInputSV frmSV = new frmInputSV(); // tạo 1 đối tượng từ class frmInputLop
            frmSV.Show();
        }

        private void btnNhapMon_Click(object sender, EventArgs e)
        {
            frmInputMon frmMon = new frmInputMon(); // tạo 1 đối tượng từ class frmInputLop
            frmMon.Show();
        }

        private void btnNhapDiem_Click(object sender, EventArgs e)
        {
            frmInputDiem frmDiem = new frmInputDiem(); // tạo 1 đối tượng từ class frmInputLop
            frmDiem.Show();
        }

        private void btnXoaSv_Click(object sender, EventArgs e) // làm tới đây chưa xong
        {
            if(lvSinhVien.SelectedItems.Count > 0)// kiem tra xe co dong nao dc chon ko
            {
                while (lvSinhVien.SelectedItems.Count > 0) //trong khi còn lựa chọn thì cứ xóa thằng đầu tiên
                {

                    Program.objectDsSinhVien.remove(lvSinhVien.SelectedItems[0].Index); // trong ngoặc nó trả về index dòng đâu tien dc chon
                    lvSinhVien.Items.Remove(lvSinhVien.SelectedItems[0]); // nó sẽ trực tiếp xóa luôn đối tượng đó không cần thông qua index
                                                                        //SelectedItems[0]: trả về dòng đầu tiên dược chọn
                }
            }
            else
            {
               MessageBox.Show(
               "Bạn chưa chọn ô cần xóa!",
               "Thông báo",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSuaSv_Click(object sender, EventArgs e)
        {
            // mã sv là duy nhat nen ko đc sửa chỉ sửa nhug thog tin khác
            if(lvSinhVien.SelectedItems.Count > 0)
            {
                // nếu ng dùng chọn vào 1 dòng và ấn sửa thì nó se hien lại cái form sửa cho ng dung nhap
                Program.lvItem = lvSinhVien.SelectedItems[0];
                frmEditSv a = new frmEditSv();
               
                a.txtInPutHo.Text = Program.lvItem.SubItems[1].Text;
                a.txtInPutTen.Text = Program.lvItem.SubItems[2].Text;
                a.txtInputSDT.Text = Program.lvItem.SubItems[4].Text;
                a.Show();
            }
            else
            {
               MessageBox.Show(
              "Bạn chưa chọn ô cần sửa!",
              "Thông báo",
              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoaLop_Click(object sender, EventArgs e)
        {
            
            if (lvLop.SelectedItems.Count > 0)// kiem tra xem co dong nao dc chon ko
            {
                while (lvLop.SelectedItems.Count > 0) //trong khi còn lựa chọn thì cứ xóa thằng đầu tiên
                {
                    Program.objectDslop.remove(lvLop.SelectedItems[0].Index); // trong ngoặc nó trả về index dòng đâu tien dc chon
                    lvLop.Items.Remove(lvLop.SelectedItems[0]); // nó sẽ trực tiếp xóa luôn đối tượng đó không cần thông qua index
                                                                          //SelectedItems[0]: trả về dòng đầu tiên dược chọn
                }
            }
            else
            {
                MessageBox.Show(
                "Bạn chưa chọn ô cần xóa!",
                "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSuaLop_Click(object sender, EventArgs e)
        {
            // tương tự ma sv thi ma lop la duy nhat nen chi sua thong tin lop do thoi
            if (lvLop.SelectedItems.Count > 0)
            {
                // nếu ng dùng chọn vào 1 dòng và ấn sửa thì nó se hien lại cái form sửa cho ng dung nhap
                Program.lvItem = lvLop.SelectedItems[0];
                frmEditLop a = new frmEditLop();

                a.txtInPuTenLop.Text = Program.lvItem.SubItems[1].Text;
                a.txtInPuNam.Text = Program.lvItem.SubItems[2].Text;
                a.Show(); // show form eidt sv ra
            }
            else
            {
                MessageBox.Show(
               "Bạn chưa chọn ô cần sửa!",
               "Thông báo",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

