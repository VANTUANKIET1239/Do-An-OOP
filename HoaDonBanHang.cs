using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hehehehehe
{     
    public class HoaDonBanHang
    {
        public delegate void hoadon(HoaDonBanHang hdbh);
        public event hoadon TruyenHoaDonBanHang;

        private string id = "BH";
        private DateTime ngayhoadon;
        private string nhanvienban;
        private string tenchinhanh;
        private List<HangHoa> lshoadonbanhang;
        int idphu = 0;
        
        public HoaDonBanHang(List<HangHoa> hanghoa, string nhanvienban, string tenchinhanh)
        {
            this.id += (++idphu).ToString();
            this.nhanvienban = nhanvienban;
            lshoadonbanhang = new List<HangHoa>(hanghoa);
            ngayhoadon = DateTime.Now;
            this.tenchinhanh = tenchinhanh;

        }
        public HoaDonBanHang() 
        {
            this.id += (++idphu).ToString();
            this.nhanvienban = "";
            lshoadonbanhang = new List<HangHoa>();
            ngayhoadon = DateTime.Now;
            this.tenchinhanh = "";

        }
        public string Nhanvienban
        {
            get { return nhanvienban; }
        }
        public  void sub(ChiNhanh a)
        {
            a.HDBH += showhoadon;
        }
        public  List<HangHoa> LShoadon
        {
            get { return lshoadonbanhang; }
        }       
        public void showhoadon(List<HangHoa> k,ANv nv, DataOfNguoi dsKH, string maso)
        {
            float thanhtien = 0f;
            Console.WriteLine("======================");
            Console.WriteLine(" <<HÓA ĐƠN BÁN HÀNG>>");
            Console.WriteLine("Mã phiếu:{0}", id);
            Console.WriteLine($"Ngày hóa đơn:{ngayhoadon.ToString("dddd, dd MMMM yyyy HH:mm:ss")}");
            Console.WriteLine($"Mã chi nhánh: {nv.Machinhanh} - Tên chi nhánh: {nv.TenCN}");
            Console.WriteLine($"Tên Nhân Viên: {nv.Ten} ");
            Console.WriteLine($"Mã số thẻ thành viên: {maso} ");
            KhachHang a = (KhachHang)dsKH.Tim(maso);
            float ck;
            switch (a.hang.ToLower())
            {
                case "than thiet": ck = 0.01f; break;
                case "dong": ck = 0.02f; break;
                case "bac": ck = 0.05f; break;
                case "vang": ck = 0.07f; break;
                default: ck = 0; break;
            }
            foreach (HangHoa i in k)
            {
                thanhtien += i.Giatien * i.Soluong;
                Console.WriteLine(i.ShowBH());
            }
            Console.WriteLine("Thành viên {0} nhận chiết khấu {1}" ,a.hang, ck);
            Console.WriteLine("Tổng giá tiền: {0}", thanhtien*(1-ck));

            HoaDonBanHang hoadon1 = new HoaDonBanHang(k,nv.Ten, nv.TenCN);
            if(TruyenHoaDonBanHang != null)
            {
                TruyenHoaDonBanHang(hoadon1);
            }
            Console.WriteLine("======================");
        }
        public void showhoadon()
        {
            string tenmathang = "";
            double thanhtien = 0;
            for (int i = 0; i < lshoadonbanhang.Count; i++)
            {
                tenmathang += "/ " + lshoadonbanhang[i].Tenhang;
                thanhtien += lshoadonbanhang[i].Giatien * lshoadonbanhang[i].Soluong;
            }

            Console.WriteLine($"Mã phiếu: {id} - Chi nhánh: {tenchinhanh} - Nhân viên: {nhanvienban} - ({tenmathang}) - Thành tiền: {thanhtien * (1 - 0.01)}");
        }
    }
}