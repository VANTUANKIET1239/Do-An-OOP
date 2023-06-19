using System;
using System.Collections.Generic;


namespace hehehehehe
{
    public class NvFulltime : ANv, INguoi
    {
        public float hsLuong;
        public int luongCs = 1200000;


        public NvFulltime() : base()
        {
        }

        public NvFulltime(NvFulltime a)
        {
            this.maso = a.maso;
            this.hoten = a.hoten;
            this.ngaysinh = a.ngaysinh;
            this.gioitinh = a.gioitinh;
            this.sdt = a.sdt;
            this.email = a.email;
            this.cn = a.cn;
            //edit
            this.ngayvaolam = a.ngayvaolam;
        }

        public NvFulltime(string maso, string hoten, DateTime ngaysinh,
        string gioitinh, string sdt, string email, ChiNhanh cn, float HsLuong)
        : base(maso, hoten, ngaysinh, gioitinh, sdt, email, cn)
        {
            this.hsLuong = HsLuong;
        }

        public void CapNhat()
        {
            if (DateTime.Now.Day == 1)
            {
                caLamTheoThang = new bool[3, 31];
                thucLam = new bool[3, 31];
                vang = 0;
                tangCa = 0;
            }
        }

        public override void CaLam(Array ad)
        {
            int[] a = { 3, 7 };
            int[] b = { 1, 1 };
            caLam = Array.CreateInstance(typeof(bool), a, b);
            for (int i = caLam.GetLowerBound(0); i <= caLam.GetUpperBound(0); i++)
            {
                for (int j = caLam.GetLowerBound(1); j <= caLam.GetUpperBound(1); j++)
                {
                    if ((bool)ad.GetValue(i, j))
                        caLam.SetValue(true, i, j);
                    else caLam.SetValue(false, i, j);
                }
            }
        }
        public override void CaLamTheoThang_Mau(bool[,] a)
        {
            caLamTheoThang = new bool[3, 31];
            for (int i = caLamTheoThang.GetLowerBound(0); i <= caLamTheoThang.GetUpperBound(0); i++)
            {
                for (int j = caLamTheoThang.GetLowerBound(1); j <= caLamTheoThang.GetUpperBound(1); j++)
                {
                    caLamTheoThang[i, j] = a[i, j];
                }
            }
        }
        public override void ThucLam_Mau(bool[,] a)
        {
            thucLam = new bool[3, 31];
            for (int i = thucLam.GetLowerBound(0); i <= thucLam.GetUpperBound(0); i++)
            {
                for (int j = thucLam.GetLowerBound(1); j <= thucLam.GetUpperBound(1); j++)
                {
                    thucLam[i, j] = a[i, j];
                }
            }
        }

        public override void SetCaLam()
        {
            //f co 3 ca/day
            //p co 4 ca/day
            int[] a = { 3, 7 };
            int[] b = { 1, 1 };
            caLam = Array.CreateInstance(typeof(bool), a, b);
            for (int i = caLam.GetLowerBound(0); i <= caLam.GetUpperBound(0); i++)
            {
                for (int j = caLam.GetLowerBound(1); j <= caLam.GetUpperBound(1); j++)
                {
                    //thêm nv vào danh sách thì thay console.readline thành đọc file.
                    if (byte.Parse(Console.ReadLine()) == 1)
                        caLam.SetValue(true, i, j);
                    else caLam.SetValue(false, i, j);
                }
            }
        }

        public void ShowCaLam()
        {
            for(int i = 0; i<= caLam.GetUpperBound(0); i++)
            {
                for (int j = 0; j<=caLam.GetUpperBound(1); j++)
                {
                    if(j == 0)
                    switch(i)
                    {
                        case 1: Console.Write("\nCa 1"); break;
                        case 2: Console.Write("\nCa 2"); break;
                        case 3: Console.Write("\nCa 3"); break;
                        default: Console.Write("     ");
                        break;
                    }
                    if(i ==0)
                    switch(j)
                    {
                        case 1: Console.Write(" Sunday"); break;
                        case 2: Console.Write(" Monday"); break;
                        case 3: Console.Write(" Tueday"); break;
                        case 4: Console.Write(" Wednesday"); break;
                        case 6: Console.Write(" Friday"); break;
                        case 5: Console.Write(" Thursday"); break;
                        case 7: Console.Write(" Saturday"); break;
                        default: break;
                    }
                    if(i!=0 && j!=0 && (bool)caLam.GetValue(i,j))
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("\tYes\t");
                    }

                  
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
        }
        public override bool[,] CaLamTheoThang()
        {
            caLamTheoThang = new bool[3, 31];
            base.CaLamTheoThang();
            return caLamTheoThang;
        }

        public override void ThucLam()
        {
            thucLam = new bool[3, 31];
            int ca = 0;
            int thu = 0;
            switch (DateTime.Now.Hour)
            {
                case 6: ca = 0; break;
                case 14: ca = 1; break;
                case 22: ca = 2; break;
                default:
                    Console.WriteLine("error thucLam_F");
                    return;
            }
            thucLam[ca, DateTime.Now.Day] = true;
            switch (DateTime.Now.DayOfWeek.ToString())
            {
                case "Sunday": thu = 8; break;
                case "Monday": thu = 2; break;
                case "Tueday": thu = 3; break;
                case "Wednesday": thu = 4; break;
                case "Thursday": thu = 5; break;
                case "Friday": thu = 6; break;
                case "Saturday": thu = 7; break;
                default:
                    Console.WriteLine("error thucLam");
                    return;
            }
            if (!(bool)caLam.GetValue(ca, thu))
                tangCa++;
        }

        public byte Vang()
        {

            for (int i = 0; i<thucLam.GetLength(0); i++)
            for (int j = 0; j<caLamTheoThang.GetLength(1); j++)
            {
                if (caLamTheoThang[i, j])
                if(!thucLam[i, j])
                vang++;
            }
            return vang;
        }

        public List<int[]> VangNgay()
        {
            List<int[]> vangNgay = new List<int[]>();
            for (int i = 0; i<thucLam.GetLength(0); i++)
            {
                for (int j = 0; j < caLamTheoThang.GetLength(1); j++)
                {
                    if (caLamTheoThang[i, j])
                        if (!thucLam[i, j]) 
                        {
                            int[] a = { i, j+1 };
                            vangNgay.Add(a);
                        }
                }
            }           
            return vangNgay;
        }

        public override float TinhLuong()
        {
            return luongCs * HsLuong() + TinhThuong() - TinhPhat();
        }
        public override float TinhPhat()
        {
            vang = Vang();
            while (vang > 2)
            {
                phat += 280000;
                vang--;
            }
            return phat;
        }
        public override float TinhThuong()
        {
            return tangCa * 280000;
        }
        public virtual float HsLuong()
        {
            TimeSpan thamnien = (DateTime.Now).Subtract(ngayvaolam);
            float x = thamnien.Days / 183f;

            while (x > 1)
            {
                hsLuong += (float)0.2;
                x--;
            }
            return hsLuong;
        }
    }
}