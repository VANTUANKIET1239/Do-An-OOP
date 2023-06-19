using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hehehehehe
{
   public class HangHoa
    {
        private int id;
        private string tenhang;
        private float giaban;
        private float chiphisx;
        private string danhmuc;
        private float soluong;
        int sophu = 0;
        
        public string Tenhang
        {
            get { return tenhang; }
        }       
        public float Giatien
        {
            get { return giaban; }
        }
        public float ChiPhi
        {
            get { return chiphisx; }
        }
        public float Soluong
        {
            get { return soluong; }
            set { soluong = value; }
        }
        public string Danhmuc
        {
            get { return danhmuc; }
        }
       public HangHoa( string tenhang,string danhmuc,float chiphisx,float giaban )
        {
            this.id = ++sophu;
            this.tenhang = tenhang;                     
            this.giaban = giaban;
            this.danhmuc = danhmuc;
            this.chiphisx = chiphisx;
            this.soluong = 0;
        }
        public HangHoa(HangHoa a)
        {
            this.id = a.id;
            this.tenhang = a.tenhang;
            this.giaban = a.giaban;
            this.chiphisx = a.chiphisx;
            this.soluong = a.soluong;
        }
        public HangHoa()
        {
            this.id = 0;
            this.tenhang = "";
            this.giaban = 0;
            this.chiphisx = 0;
            this.soluong = 0;
        }
       
        public string ShowBH()
        {
            return "Tên hàng : " + tenhang + " - Số lượng: " + Soluong + " - Tổng tiền: " + Soluong * Giatien;
        }
        public string ShowDH()
        {
            return "Tên hàng : " + tenhang + " - Số lượng: " + Soluong;
        }
        public void tangsl( float sl)
        {
            soluong += sl;
        }
         
        public void giamsl(float sl)
        {
            soluong -= sl;
        }
       
    }
}
