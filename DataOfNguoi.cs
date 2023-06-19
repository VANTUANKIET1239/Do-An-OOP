using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace hehehehehe
{
    public class DataOfNguoi
    {
        private Hashtable ds;

        public Hashtable Ds
        {
            get { return ds; }
        }

        public DataOfNguoi()
        {
            ds = new Hashtable();
        }


        public static DataOfNguoi operator +(DataOfNguoi a, INguoi x)
        {
            a.Ds.Add(x.GetMaso(), x);
            return a;
        }
        public static DataOfNguoi operator -(DataOfNguoi a, string maso)
        {
            if (a.Ds.ContainsKey(maso))
            {
                foreach (DictionaryEntry t in a.Ds)
                {
                    if (t.Key.ToString() == maso)
                        a.Ds.Remove(maso);
                }
            }
            return a;
        }

        public INguoi Tim(string maso)
        {
            INguoi a = new KhachHang();
            if (maso.Substring(0, 1) == "P")
                return TimNVp(maso);

            if (maso.Substring(0, 1) == "F")
                return TimNVf(maso);

            if (maso.Substring(0, 1) == "K")
                return TimKH(maso);
            return a;
        }

        private NvFulltime TimNVf(string maso)
        {
            if (ds.ContainsKey(maso))
            {
                foreach (DictionaryEntry t in ds)
                {
                    if (t.Key.ToString() == maso)
                        return (NvFulltime)t.Value;
                }
            }
            return new NvFulltime();
        }
        private NvParttime TimNVp(string maso)
        {
            if (ds.ContainsKey(maso))
            {
                foreach (DictionaryEntry t in ds)
                {
                    if (t.Key.ToString() == maso)
                        return (NvParttime)t.Value;
                }
            }
            return new NvParttime();
        }
        public KhachHang TimKH(string mst)
        {
            if (ds.ContainsKey(mst))
            {
                foreach (DictionaryEntry t in ds)
                {
                    if (t.Key.ToString() == mst)
                        return (KhachHang)t.Value;
                }
            }
            return new KhachHang();
        }

        public void sub(ChiNhanh a)//Kiệt làm
        {
            a.thaydoilsmuahang += muaHang;
        }
        public void muaHang(List<HangHoa> s, string a)
        {
            TimKH(a).mua(s);
        }//

    }
}
