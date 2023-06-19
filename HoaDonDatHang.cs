using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hehehehehe
{
    public class HoaDonDatHang
    {
        public delegate void hoadon(HoaDonDatHang hdbh);
        public event hoadon TruyenHoaDonDatHang;

        private string id = "DH";
        private DateTime ngayhoadon;
        private string nhanviendat;
        private string tencn;
        private List<HangHoa> lshoadondathang;
        int idphu = 0;


        public HoaDonDatHang() 
        {
            this.id += (idphu++).ToString();
            this.nhanviendat = "";
            this.tencn = "";
            this.lshoadondathang = new List<HangHoa>();
            this.ngayhoadon = DateTime.Now;
        }
        public HoaDonDatHang(string nhanviendat, string tencn, List<HangHoa> lshoadondathang)
        {
            this.id += (idphu++).ToString();
            this.nhanviendat = nhanviendat;
            this.tencn = tencn;
            this.ngayhoadon = DateTime.Now;
            this.lshoadondathang = new List<HangHoa>(lshoadondathang);
        }
        public string Nhanviendat
        {
            get { return nhanviendat; } 
        }

        public void sub(ChiNhanh a)
        {
            a.HDDH += showhoadon;
        }
        public List<HangHoa> LShoadon
        {
            get { return lshoadondathang; }
        }
        public void lamsachls()
        {
            lshoadondathang.Clear();
        }
        public void showhoadon(List<HangHoa> k,ANv nv)
        {
            HoaDonDatHang A = new HoaDonDatHang();
            float chiphi  = 0f;
            Console.WriteLine("======================");
            Console.WriteLine("<<HÓA ĐƠN ĐẶT HÀNG>>");
            Console.WriteLine($"Ngày hóa đơn:{ngayhoadon.ToString("dddd, dd MMMM yyyy HH:mm:ss")}");
            Console.WriteLine($"ma phieu: {id}");
            Console.WriteLine($" Mã chi nhánh: {nv.Machinhanh} - Chi nhánh Đặt: {nv.TenCN} ");
            Console.WriteLine("nhân viên đặt hàng: ");
            foreach (HangHoa i in k)
            {
                chiphi += i.ChiPhi * i.Soluong;
                Console.WriteLine(i.ShowDH());
            }
            Console.WriteLine("Tổng chi phí: {0}", chiphi);
            HoaDonDatHang hoadon2 = new HoaDonDatHang(nv.Ten,nv.TenCN,k);

            if (TruyenHoaDonDatHang != null)
            {
                TruyenHoaDonDatHang(hoadon2);
            }
            Console.WriteLine("===========================");
        }
        public void showhoadon()
        {
            string tenmathang = "";
            double chiphi = 0;
            for (int i = 0; i < lshoadondathang.Count; i++)
            {
                tenmathang += "/ " + lshoadondathang[i].Tenhang+"#" +lshoadondathang[i].Soluong;
                chiphi += lshoadondathang[i].Soluong * lshoadondathang[i].ChiPhi;
            }

            Console.WriteLine($"Mã phiếu: {id} - Chi nhánh: {tencn} - Nhân viên: {nhanviendat} - {tenmathang} - Tổng chi phí:{chiphi}");
        }
    }
}

