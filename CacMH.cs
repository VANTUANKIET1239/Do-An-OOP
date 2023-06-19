using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hehehehehe
{
    public class CacMH : IKinhDoanh
    {
        
        private List<HangHoa> KhoMatHan;
        private List<HoaDonBanHang> khohoadonbanhang;
        private List<HoaDonDatHang> khohoadondathang;
        private List<string> danhmuchanghoa;
        private List<HangHoa> kho = new List<HangHoa>();


        public CacMH(List<HangHoa> a)
        {
            KhoMatHan = new List<HangHoa>();
            KhoMatHan.AddRange(a);
            khohoadonbanhang = new List<HoaDonBanHang>();
            khohoadondathang = new List<HoaDonDatHang>();
            danhmuchanghoa = new List<string>() { "Nước giải khát", "Bánh Kẹo", "Dụng cụ học tập", "Dụng cụ vệ sinh", "Vật dụng ăn uống", "Nấu ăn", "Thức ăn nhanh" };

         }
        public List<HangHoa> KHOMATHANG
        {
            get { return KhoMatHan; }
            set { KhoMatHan = value; }
        }

        public void addhangmoi()
        {
            int dem = 0;
            Console.WriteLine("Nhập tên hàng hóa muốn thêm");
            string ten = Console.ReadLine();
            Console.WriteLine("Nhập danh mục");
            string danhmuc = Console.ReadLine();
            for( int i = 0; i < danhmuchanghoa.Count; i++)
            {
                if (danhmuc == danhmuchanghoa[i])
                {
                    dem++;
                }
            }
            if(dem == 0)
            {
                danhmuchanghoa.Add(danhmuc);
            }
            Console.WriteLine("Nhập chi phí sx");
            float cpsx = float.Parse(Console.ReadLine());
            Console.WriteLine("Nhập chi phí bán");
            float giaban = float.Parse(Console.ReadLine());
            HangHoa a = new HangHoa(ten, danhmuc,  cpsx,  giaban);
            KhoMatHan.Add(a);
            Console.WriteLine("Thêm thành công!");
        }    
        public void xoamathang()
        {
            int dem1 = 0;
            string ten = "";
            Console.WriteLine("Nhập tên hàng hóa cần xóa: ");
            string hh = Console.ReadLine();
            foreach(HangHoa i in KhoMatHan)
            {
               if(i.Tenhang == hh)
                {
                    for( int j = 0; j < KhoMatHan.Count; j++)
                    {
                        if (i.Danhmuc == KhoMatHan[j].Danhmuc)
                        {
                            dem1++;
                            ten = i.Danhmuc;
                        }
                    }
                    KhoMatHan.Remove(i);
                    break;
                }
            }
            if(dem1 == 1)
            {
                danhmuchanghoa.Remove(ten);
            }
            Console.WriteLine("Xóa thành công!");
           
        }
        public HangHoa timhang(string ten)
        {
            HangHoa x = new HangHoa("","",0,0);
            foreach(HangHoa i in KhoMatHan)
            {
                if (i.Tenhang == ten)
                {
                    x = new HangHoa(i);
                }            
            }
            return x;
        }
        
        public float tongsoluongdaban()
        {
            float soluong = 0;
            foreach(HangHoa s in kho)
            {
                soluong += s.Soluong;
            }
            return soluong;
        }
        public float tongdoanhthucacmathang()
        {
            float tong = 0;
            foreach (HangHoa s in kho)
            {
                tong += s.Soluong * s.Giatien;
            }
            return tong;
        }
        public void thongkedoanhso()
        {          
            Console.WriteLine($"Tổng só lượng đã bán:{tongsoluongdaban()}");
            Console.WriteLine($"Tổng doanh thu các mặt hàng đã bán:{tongdoanhthucacmathang()}");
            Console.WriteLine($"Lợi nhuận từ các mặt hàng: {loinhuan()}");
            string k = "";
            string dt = "";
            Console.WriteLine("========================================================================================================");
            for (int i = 0; i < kho.Count; i++)
            {
                for (float j = kho[i].Soluong; j >= 0; j -= 10)
                {
                    k += "/";
                }            
                Console.WriteLine($"{kho[i].Tenhang}:");
                Console.WriteLine($"{k} ({kho[i].Soluong})");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{dt} ({((kho[i].Giatien - kho[i].ChiPhi) * kho[i].Soluong) / loinhuan() * 100}%)");
                Console.ForegroundColor = ConsoleColor.White;
                k = "";
                dt = "";
            }
            Console.WriteLine("========================================================================================================");
        }       
        public float loinhuan()
        {
            float a = 0;           
            for ( int i = 0; i < kho.Count; i++)
            {
                a += (kho[i].Giatien - kho[i].ChiPhi) * kho[i].Soluong;
            }
            return a;
        }
        public void sub(HoaDonBanHang a)
       {
          a.TruyenHoaDonBanHang += themhoadonbanhang;
       }
        public void sub(HoaDonDatHang a)
        {
            a.TruyenHoaDonDatHang += themhoadondathang;
        }
        public void themhoadonbanhang( HoaDonBanHang a)
        {
            khohoadonbanhang.Add(a);
        }
        public void themhoadondathang(HoaDonDatHang a)
        {
            khohoadondathang.Add(a);
        }

        public void phanloaidanhmuc()
        {
            Console.WriteLine("Danh mục các mặt hàng:");
            for (int i = 0; i < danhmuchanghoa.Count; i++)
            {
                List<string> tendemo = new List<string>();
                for (int j = 0; j < KhoMatHan.Count; j++)
                {
                    if(danhmuchanghoa[i] == KhoMatHan[j].Danhmuc)
                    {
                        tendemo.Add(KhoMatHan[j].Tenhang);
                    }
                }
                Console.WriteLine($"<{danhmuchanghoa[i]}>");
                for ( int u = 0; u < tendemo.Count; u++)
                {
                    Console.WriteLine($"- {tendemo[u]}");
                }
            }
        }
        public void adddoanhso(List<HangHoa> a)
        {
            kho.AddRange(a);
        }
        public void sub(ChiNhanh a)
        {
            a.congsl += adddoanhso;
        }
        public void intoanbohoadon(string a)
        {
            if(a == "HDBH")
            {
                foreach (HoaDonBanHang s in khohoadonbanhang)
                {
                    s.showhoadon();
                }
            }
            else
            {
                foreach (HoaDonDatHang s in khohoadondathang)
                {
                    s.showhoadon();
                }
            }
        }
        public void lamsachHD(string a)
        {
            try
            {
                if (a == "HDBH")
                {
                    khohoadonbanhang.Clear();
                }
                else
                {
                    khohoadondathang.Clear();
                }
                Console.WriteLine("Xóa HĐ thàng công!");
            }
            catch (Exception)
            {
                Console.WriteLine("Xóa thất bại, đã có lỗi xảy ra");
            }            
        }
        public void timhoadontheotennhanvien(string a)
        {
            int dem1 = 0;
            int dem2 = 0;
            Console.WriteLine("hóa đơn bán hàng:");
            for( int i = 0; i < khohoadonbanhang.Count; i++)
            {
                if(khohoadonbanhang[i].Nhanvienban == a)
                {
                    khohoadonbanhang[i].showhoadon();
                    dem1++;
                }
            }
            if (dem1 == 0)
            {
                Console.WriteLine("Trống");
            }
            Console.WriteLine("hóa đơn nhập hàng:");
            for (int i = 0; i < khohoadondathang.Count; i++)
            {
                if (khohoadondathang[i].Nhanviendat== a)
                {
                    khohoadondathang[i].showhoadon();
                    dem2++;
                }
            }
            if(dem2 == 0)
            {
                Console.WriteLine("Trống");
            }
        }

        


    }
}