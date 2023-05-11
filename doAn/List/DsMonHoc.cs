﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace doAn.Object
{
    internal class DsMonHoc
    {
        #region Node cay nhi phan
        public class Node
        {
            public MonHoc monHoc;
            public Node left;
            public Node right;

            public Node(MonHoc monHoc) // khi khởi tạo thằng đầu tiên thì hiển nhiên 2 con trỏ left, right phải là null
            {
                this.monHoc = monHoc;
                this.left = null;
                this.right = null;
            }
        }
        #endregion

        public Node root { get; set; }
        public DsMonHoc()
        {
            this.root = null;
        }
        
        public bool insert(Node temproot, MonHoc e)
        {
            // bản chất ở đây ta cần 2 biến tạm là temp và temproot để chứa địa chỉ của root
            //  temproot dùng để tìm vị trí thích hợp khi chen, còn temp thì để liên kết 2 node lại vs nhau
            Node temp = null;
            
            while (temproot != null)
            {
                temp = temproot; // 2 thằng này giờ đang lưu trữ địa chỉ của root
                
                if (e.maMonHoc.CompareTo(temproot.monHoc.maMonHoc) == 0)//note
                {
                    MessageBox.Show(
                        "Mã môn học bị trùng!",
                        "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else if (e.tenMonHoc.CompareTo(temproot.monHoc.tenMonHoc) == -1) // phần tử x < gốc thì thêm vào trái
                {
                    temproot = temproot.left;
                }
                else if (e.tenMonHoc.CompareTo(temproot.monHoc.tenMonHoc) == 1) // phần tử x > gốc thì thêm vào trái
                {
                    temproot = temproot.right;
                }
            }

            Node n = new Node(e);
            if (root != null)
            {
                if (e.tenMonHoc.CompareTo(temp.monHoc.tenMonHoc) == -1)
                    temp.left = n;
                else if(e.tenMonHoc.CompareTo(temp.monHoc.tenMonHoc) == 1)
                    temp.right = n;
            }
            else
            {
                root = n;
            }
            return true;
        }

        // ở đây ta dùng inOrder là vì cây này sẽ duyệt từ bé đến lớn và ta chỉ cần thêm môn học dựa theo tên môn học
        // và thêm điều kiện ko đc trùng mã môn học là sẽ tự động sắp sếp tên môn học từ bé đến lớn
        public void displayInOrder(Node tmpRoot, ListViewItem a)
        {
            if (tmpRoot != null)
            {
                displayInOrder(tmpRoot.left, a);

                a = new ListViewItem(tmpRoot.monHoc.maMonHoc);
                // khởi tạo ô đầu tiên của dòng đầu tiên
                //them cac o tiep theo
                a.SubItems.Add(tmpRoot.monHoc.tenMonHoc); // ô2
                a.SubItems.Add(tmpRoot.monHoc.tinChiLT.ToString()); // ô3
                a.SubItems.Add(tmpRoot.monHoc.tinChiTH.ToString()); // ô4
                Program.formMain.lvDsMon.Items.Add(a);

                displayInOrder(tmpRoot.right, a);
            }
        }
    }
}
