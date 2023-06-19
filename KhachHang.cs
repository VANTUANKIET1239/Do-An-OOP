using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hehehehehe
{
  
    public class KhachHang : INguoi
    {
        private string maso;
        private string hoten;
        private string sdt;        
        private string gmail;
        private double tongTien;
        public string hang;
        private List<List<HangHoa>>lsMuaHang = new List<List<HangHoa>>();

        public string GetMaso()
        {
            return maso;
        }    
        public KhachHang()
        {
            this.maso = "";
            this.hoten = "";
            this.sdt = "";
            this.gmail = "";
            this.hang = "";
        }
        public KhachHang(string maso, string hoten, string sdt, string gmail)
        {
            this.maso = maso;
            this.hoten = hoten;
            this.sdt = sdt;        
            this.gmail = gmail;
            this.hang = "than thiet";        
        }
        public KhachHang(KhachHang a)
        {
            this.maso = a.maso;
            this.hoten = a.hoten;
            this.sdt = a.sdt;        
            this.gmail = a.gmail;         
        }

        public void CapNhat()
        {
            if(DateTime.Now.Day == 1)
            {
                if(maso != "")
                {
                    if(tongTien < 500000)
                    hang = "than thiet";
                    else if(tongTien < 1500000)
                    hang = "dong";
                    else if (tongTien < 2500000)
                    hang = "bac";
                    else hang = "vang";
                }
                tongTien = 0;
            }
        }

        public void mua(List<HangHoa> s)
        {
            lsMuaHang.Add(s);
            foreach (HangHoa i in s)
            {
                tongTien += i.Giatien * i.Soluong;
            }
        }
        
        public void GetLsMuaHang()
        {
            int i = 0;
            string mathang = "";
            foreach (List<HangHoa> a in lsMuaHang)
            {
                foreach (HangHoa t in a)
                {
                    mathang += t.ShowBH() + "\n";                  
                }
                i++;
                Console.WriteLine($"{i}, {mathang}");
            }
        }

        public override string ToString()
        {
            return "MS: " +this.maso+ "\nTên: " +this.hoten+ "\nThành viên: " +this.hang;
        }

    }    
}
