using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace hehehehehe
{
    
    public abstract class ANv
    {
       
        protected string maso;
        protected string hoten;
        protected bool gioitinh;
        protected DateTime ngaysinh, ngayvaolam = new DateTime();
        protected string sdt;
        protected string email;
        protected ChiNhanh cn;
        protected Array caLam;
        protected bool [,] caLamTheoThang;
        protected bool [,] thucLam;
        protected byte tangCa, vang;
        protected float thuong, phat;
        public string GetMaso()
        {
            return maso;
        }       
        public string Ten
        {
            get { return hoten;}
        }
        public string SDT
        {
            get { return sdt; }
        }
        public string TenCN
        {
            get { return cn.Tencn; }
        }
        public string Machinhanh
        {
            get { return cn.Macn; }
        }
        public ANv()
        {
            //o++;
            this.maso = "";
            this.hoten = "";
            this.ngaysinh = DateTime.ParseExact("01/01/1555", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            this.gioitinh = false;
            this.sdt = "";
            this.email = "";
            this.cn = new ChiNhanh() ;
            //edit
            this.ngayvaolam = DateTime.ParseExact("01/01/1555", "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
        public ANv(string maso, string hoten, DateTime ngaysinh, 
            string gioitinh, string sdt, string email, ChiNhanh cn)
        {
            this.maso = maso;
            this.hoten = hoten;
            this.ngaysinh = ngaysinh;
            if(gioitinh.ToLower() == "nam")
            this.gioitinh = true;
            else this.gioitinh = false;
            //this.gioitinh = gioitinh;
            this.sdt = sdt;
            this.email = email;
            this.cn = cn;
            //edit
            this.ngayvaolam = DateTime.Now;
        }
        public abstract void CaLam(Array a);
        public abstract void CaLamTheoThang_Mau(bool[,] a);
        public abstract void ThucLam_Mau(bool[,]a);

        public abstract void SetCaLam();

        public virtual bool[,] CaLamTheoThang()
        {
            int thu = 0;
           
            switch(DateTime.Now.DayOfWeek.ToString())
            {
                case "Sunday": thu = 8; break;
                case "Monday": thu = 2; break;
                case "Tueday": thu = 3; break;
                case "Wednesday": thu= 4; break;
                case "Thursday": thu = 5; break;
                case "Friday": thu = 6; break;
                case "Saturday": thu = 7; break;
                default: Console.WriteLine("error thucLam");
                break;
            }
            for(int i = caLam.GetLowerBound(0); i<=caLam.GetUpperBound(0); i++)
            {
                if((bool)caLam.GetValue(i,thu))
                    caLamTheoThang[i,DateTime.Now.Day] = true;
            }
            return caLamTheoThang;
        }
        public abstract void ThucLam();

        

        public abstract float TinhThuong();

        public abstract float TinhPhat();
        public abstract float TinhLuong();

    }
}
