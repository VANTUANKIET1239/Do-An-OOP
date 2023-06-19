using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hehehehehe
{
    public class ChiNhanh
    {
        public delegate void ban(List<HangHoa> a);
        public event ban congsl;
        public delegate void hoadonbh(List<HangHoa> hh, ANv nv, DataOfNguoi dsKH, string maso);
        public event hoadonbh HDBH;
        public delegate void hoadondh(List<HangHoa> hh, ANv nv);
        public event hoadondh HDDH;
        public delegate void khachhang(List<HangHoa> hh, string maKh);
        public event khachhang thaydoilsmuahang;
        
        private string macn;
        private string tencn;
        private List<ANv> nhanvienfcn;
        private List<ANv> nhanvienpcn;
        private List<HangHoa> KhoHang;
        private List<HangHoa> Hangban;
        private List<HangHoa> Hangnhap;
        private float doanhthu;
        private float chiphi;
        public ChiNhanh(string macn, string tencn)
        {
            this.macn = macn;
            this.tencn = tencn;
            nhanvienfcn = new List<ANv>();
            nhanvienpcn = new List<ANv>();
            KhoHang = new List<HangHoa>();
            Hangban = new List<HangHoa>();
            Hangnhap = new List<HangHoa>();
             doanhthu = 0f;
             chiphi = 0f;
        }
        public ChiNhanh(ChiNhanh a)
        {
            this.macn = a.macn;
            this.tencn = a.tencn;
            nhanvienfcn = new List<ANv>(a.Nhanvienfcn);
            nhanvienpcn = new List<ANv>(a.Nhanvienpcn);        
            Hangban = new List<HangHoa>(a.HANBAN);
            Hangnhap = new List<HangHoa>(a.HANNHAP);
            KhoHang = new List<HangHoa>(a.KHOHAN);
            doanhthu = a.DOANHTHU;
             chiphi = a.CHIPHI;
        }

        public ChiNhanh()
        {
            this.macn = "";
            this.tencn = "";
        }
        public List<ANv> Nhanvienpcn
        {
            get { return nhanvienpcn; }
        }
        public List<ANv> Nhanvienfcn
        {
            get { return nhanvienfcn; }
        }
        public string Tencn
        {
            get { return tencn; }
        }
        public string Macn
        {
            get { return macn; }
        }
        public List<HangHoa> HANBAN
        {
            get { return Hangban; }
        }
        public List<HangHoa> HANNHAP
        {
            get { return Hangnhap; }
        }
        public float DOANHTHU
        {
            get { return doanhthu; }
        }
        public float CHIPHI
        {
            get { return chiphi; }
        }
        public List<HangHoa> KHOHAN
        {
            get { return KhoHang; }
        }


        public void ThemNhanVien(ANv a, DataOfNguoi nv)
        {
            if(a.GetMaso().Substring(0,1) == "F")
            {
                nhanvienfcn.Add((NvFulltime)a);
                nv = nv + (NvFulltime)a;
            }
            else
            {
                nhanvienpcn.Add((NvParttime)a);
                nv = nv + (NvParttime)a;
            }
        }
        public void XoaNhanVien(string id, DataOfNguoi nv)
        {
            if (id.Substring(0, 1) == "F")
            {
                for (int i = 0; i < nhanvienfcn.Count; i++)
                {
                    if (id == nhanvienfcn[i].GetMaso())
                    {
                        nhanvienfcn.RemoveAt(i);
                        nv = nv - id;
                    }
                }
            }
            else
            {
                for (int i = 0; i < nhanvienpcn.Count; i++)
                {
                    if (id == nhanvienfcn[i].GetMaso())
                    {
                        nhanvienpcn.RemoveAt(i);
                        nv = nv - id;
                    }
                }
            }
        }
        public ANv timnhanvien(string code, int n)
        {        
            if (n == 1)
            {
                
                for (int i = 0; i < nhanvienfcn.Count; i++)
                {
                    if (code == nhanvienfcn[i].GetMaso())
                    {
                        return nhanvienfcn[i];
                    }
                }
            }
            else
            {
                for (int i = 0; i < nhanvienpcn.Count; i++)
                {
                    if (code == nhanvienpcn[i].GetMaso())
                    {
                        return nhanvienpcn[i];
                    }
                }
            }           
          return null;                       
        }
        public void nhaphang(CacMH cacmathang)
        {
            List<HangHoa> hanghoachodathang= new List<HangHoa>();
            string tenhang = "";
            ANv a = new NvFulltime();
            ANv b = new NvParttime();
            Console.WriteLine("Nhập mã nhân viên nhập: ");
            string manhanvien = Console.ReadLine();
            if (manhanvien.Substring(0, 1) == "F")
            {
                a = new NvFulltime((NvFulltime)timnhanvien(manhanvien, 1));
            }
            else
            {
                b = new NvParttime((NvParttime)timnhanvien(manhanvien, 2));
            }
            Console.WriteLine("Nhập loại nhân viên:Part-time(1) và Full-time(2): ");
            int t = int.Parse(Console.ReadLine());
        nhap:
            Console.WriteLine("nhập tên hàng bạn muốn nhập: ");
            tenhang = Console.ReadLine();
            if (tenhang != "HUY")
            {
                Console.WriteLine("so luong mua: ");
                int sl = int.Parse(Console.ReadLine());
                int dem = 0;
                foreach (HangHoa i in KhoHang)
                {
                    if (tenhang == i.Tenhang)
                    {
                        dem++;
                        HangHoa demo = new HangHoa(i);
                        demo.Soluong = sl;
                        i.tangsl(sl);
                        chiphi += demo.Soluong * demo.ChiPhi;
                        hanghoachodathang.Add(demo);
                        Hangnhap.Add(demo);
                    }
                }
                if (dem == 0)
                {                   
                    HangHoa demo = new HangHoa(cacmathang.timhang(tenhang));
                    demo.Soluong = sl;
                    KhoHang.Add(demo);
                    chiphi += demo.Soluong * demo.ChiPhi;
                    hanghoachodathang.Add(demo);
                    Hangnhap.Add(demo);
                }
                goto nhap;
            }
            if (t == 1)
            {
                if (HDDH != null) HDDH(hanghoachodathang, b);
            }
            else
            {
                if (HDDH != null) HDDH(hanghoachodathang, a);
            }


        }
    
         //   if ( congsl != null) congsl(slnuoc);                      
            
    
    public void banhang(DataOfNguoi dsKH, CacMH bt)
    {
            
            ANv a = new NvFulltime();
            ANv b = new NvParttime();
            Console.WriteLine("Nhập mã nhân viên: ");
            string manhanvien = Console.ReadLine();
            if (manhanvien.Substring(0, 1) == "F")
            {
                a = new NvFulltime((NvFulltime)timnhanvien(manhanvien, 1));
            }
            else
            {
                b = new NvParttime((NvParttime)timnhanvien(manhanvien, 2));
            }
            Console.WriteLine("Nhập loại nhân viên:Part-time(1) và Full-time(2): ");
            int t = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhập mã khách hàng trên thẻ thành viên: ");
            string maso = Console.ReadLine();
            KhachHang c = (KhachHang)dsKH.Tim(maso);
            float ck;
            switch (c.hang.ToLower())
            {
                case "than thiet": ck = 0.01f; break;
                case "dong": ck = 0.02f; break;
                case "bac": ck = 0.05f; break;
                case "vang": ck = 0.07f; break;
                default: ck =0; break;
            }
            List<HangHoa> hanghoachohoadon = new List<HangHoa>();
            string tenhang = "";
            HangHoa demo = new HangHoa();
        nhap:
        Console.WriteLine("Nhập tên mặt hàng mua: ");
        tenhang = Console.ReadLine();
        if (tenhang != "HUY")
        {
            Console.WriteLine("Số lượng: ");
            int sl = int.Parse(Console.ReadLine());
            foreach (HangHoa i in KhoHang)
            {
                if (tenhang == i.Tenhang)
                {
                    demo = new HangHoa(i); 
                    
                    demo.Soluong = sl;
                    i.giamsl(sl);
                    doanhthu += demo.Soluong * demo.Giatien *(1-ck);
                    hanghoachohoadon.Add(demo);
                    Hangban.Add(demo);
                   
                }
            }
            goto nhap;
        }
            if(t == 1)
            {
                if (HDBH != null) HDBH(hanghoachohoadon, b, dsKH, maso);
            }
            else
            {
                if (HDBH != null) HDBH(hanghoachohoadon, a, dsKH, maso);
            }
            if (thaydoilsmuahang != null) thaydoilsmuahang(hanghoachohoadon, maso);
            if (congsl != null) congsl(hanghoachohoadon);

        }  
         //   if ( congsl != null) congsl(slnuoc);                      
        public float Thanhtoanluong(){
            float tienluong = 0;
          for(int i = 0; i < nhanvienfcn.Count; i++)
            {
                tienluong += nhanvienfcn[i].TinhLuong() + nhanvienfcn[i].TinhThuong() - nhanvienfcn[i].TinhPhat();
            }
            for (int i = 0; i < nhanvienpcn.Count; i++)
            {
                tienluong += nhanvienpcn[i].TinhLuong() + nhanvienpcn[i].TinhThuong() - nhanvienpcn[i].TinhPhat();
            }
            return chiphi += tienluong;
        }
      
            
        public void LichsuHangHoa()
        {
            Console.WriteLine("Lựa chọn in lịch sử : 1. Hàng bán trong ngày; 2. Hàng nhập");
            int i = int.Parse(Console.ReadLine());
            switch (i)
            {
                case 1:
                    Console.WriteLine("Lịch sử hàng hóa bán trong ngày: ");
                    foreach (HangHoa r in Hangban)
                    {
                        Console.WriteLine(r.ShowBH());
                    }
                    break;
                case 2:
                    Console.WriteLine("Lịch sử hàng nhập trong tháng: ");
                    foreach (HangHoa k in Hangnhap)
                    {
                        Console.WriteLine(k.ShowDH());
                    }
                    break;
            }
        }
        public void loinhuan()
        {
            float loi = doanhthu - chiphi - Thanhtoanluong();
            Console.WriteLine("Lợi nhuận của cửa hàng {0}", loi);
        }
    }
}
  

