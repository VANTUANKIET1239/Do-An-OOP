using System;
using System.Collections.Generic;
using System.Collections;
using System.Globalization;
namespace hehehehehe
{
    class program
    {
        public static void HDCN(List<ChiNhanh> a, CacMH k, DataOfNguoi DsKH, DataOfNguoi DsNV)
        {
        hien:
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nĐề tài: QUẢN LÝ KINH DOANH CỬA HÀNG TIỆN LỢI\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Danh mục quản lý: ");
            Console.WriteLine("1. Thực hiện kinh doanh");
            Console.WriteLine("2. Quản lý hàng hoá");
            Console.WriteLine("3. Quản lý nhân viên");
            Console.WriteLine("4. Quản lý khách hàng");
            Console.WriteLine("0. Kết thúc chương trình");
            Console.WriteLine("Lựa chọn các mục");
            int luachon = int.Parse(Console.ReadLine());
            if (luachon == 1)
            {
            nhap1:
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nĐề tài: QUẢN LÝ KINH DOANH CỬA HÀNG TIỆN LỢI\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=== THỰC HIỆN KINH DOANH ===");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Chi nhánh thực hiện kinh doanh: ");
                string su = Console.ReadLine();
                ChiNhanh cn = new ChiNhanh();
                int demm = 0;
                foreach (ChiNhanh Cn in a)
                {
                    if (Cn.Macn == su)
                        cn = Cn;
                    else
                    {
                        demm++;
                    }
                }
                if (demm == 3)
                {
                    Console.WriteLine("Nhập sai mã chi nhánh! Vui lòng nhập lại.");
                    goto nhap1;
                }
            nhap1a:
                Console.WriteLine("1. Bán Hàng ");
                Console.WriteLine("2. Đặt Hàng");
                Console.WriteLine("3. Lịch sử hàng hoá trong ngày");
                Console.WriteLine("4. Lợi nhuận cửa hàng");
                Console.WriteLine("5. Trở về");
                Console.WriteLine("Nhập lựa chọn: ");
                int chon1 = int.Parse(Console.ReadLine());
                if (chon1 != 5)
                {
                    switch (chon1)
                    {
                        case 1: cn.banhang(DsKH, k); break;
                        case 2: cn.nhaphang(k); break;
                        case 3: cn.LichsuHangHoa(); break;
                        case 4: cn.loinhuan(); break;

                    }
                    goto nhap1a;
                }
            }
            if (luachon == 2)
            {
            nhap2:
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nĐề tài: QUẢN LÝ KINH DOANH CỬA HÀNG TIỆN LỢI\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=== QUẢN LÝ HÀNG HÓA ===");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1. Thêm mặt hàng ");
                Console.WriteLine("2. Xoá mặt hàng");
                Console.WriteLine("3. Tìm hàng");
                Console.WriteLine("4. Danh mục hàng hoá");
                Console.WriteLine("5. Thống kê doanh số");
                Console.WriteLine("6. In lịch sử hóa đơn");
                Console.WriteLine("7. Làm sạch hóa đơn");
                Console.WriteLine("8. Tìm hóa đơn theo nhân viên");
                Console.WriteLine("9. Thoát");

                Console.WriteLine("Nhập lựa chọn: ");
                int chon2 = int.Parse(Console.ReadLine());
                if (chon2 != 9)
                {
                    switch (chon2)
                    {
                        case 1: k.addhangmoi(); break;
                        case 2: k.xoamathang(); break;
                        case 3:
                            Console.WriteLine("nhập tên mặt hàng muốn tìm: ");
                            string g = Console.ReadLine();
                            if (k.timhang(g).Tenhang == "") Console.WriteLine("mặt hàng này không tồn tại");
                            else Console.WriteLine("mặt hàng này đang được bán trong chuỗi chi nhánh");
                            break;
                        case 4: k.phanloaidanhmuc(); break;
                        case 5: k.thongkedoanhso(); break;
                        case 6:
                            Console.WriteLine("Chọn lịch sử hóa đơn của chuỗi CH bạn muốn in: HĐ bán hàng(HDBH) / HĐ đặt hàng(HDDH)");
                            string f = Console.ReadLine();
                            k.intoanbohoadon(f); break;
                        case 7:
                            Console.WriteLine("Nhập loại hóa đơn muốn làm sạch lịch sử: HĐ bán hàng(HDBH) / HĐ đặt hàng(HDDH)");
                            string hd = Console.ReadLine();
                            k.lamsachHD(hd);
                            break;
                        case 8:
                            Console.WriteLine("Nhập tên nhân viên bạn muốn xem ");
                            string ten1 = Console.ReadLine();
                            k.timhoadontheotennhanvien(ten1);
                            break;
                    }
                    goto nhap2;
                }
            }
            if (luachon == 3)
            {
            nhap3:

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nĐề tài: QUẢN LÝ KINH DOANH CỬA HÀNG TIỆN LỢI\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=== QUẢN LÝ NHÂN VIÊN ===");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1. Thêm nhân viên");
                Console.WriteLine("2. Xóa nhân viên");
                Console.WriteLine("3. Nhân viên Fulltime");
                Console.WriteLine("4. Nhân viên Parttime");
                Console.WriteLine("5. Thoát");
                Console.WriteLine("Nhập lựa chọn: ");
                int chon3 = int.Parse(Console.ReadLine());
            nhap3a:
                Console.Write("Nhân viên thuộc chi nhánh: ");
                string su = Console.ReadLine();
                ChiNhanh cn = new ChiNhanh();
                int demmmm = 0;
                foreach (ChiNhanh Cn in a)
                {
                    if (Cn.Macn == su)
                        cn = new ChiNhanh(Cn);
                    else
                    {
                        demmmm++;
                    }
                }
                if(demmmm == 3)
                    {
                        Console.WriteLine("Nhập sai mã chi nhánh! Vui lòng nhập lại.");
                        goto nhap3a;
                    }
                if (chon3 != 5)
                {
                    switch (chon3)
                    {
                        case 1:
                            string maso1, ten, gt, sdt, email;
                            DateTime ngay; float hsluong;
                            Console.WriteLine("Nhập dữ liệu nhân viên cần thêm: ");
                            Console.Write("Nhập mã số: "); maso1 = Console.ReadLine();
                            Console.WriteLine("Nhập tên nv: "); ten = Console.ReadLine();
                            Console.WriteLine("Giới tính: "); gt = Console.ReadLine();
                            Console.WriteLine("Ngày sinh: "); ngay = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            Console.WriteLine("SĐT: "); sdt = Console.ReadLine();
                            Console.WriteLine("Email: "); email = Console.ReadLine();
                            Console.WriteLine("Hệ số lương: "); hsluong = float.Parse(Console.ReadLine());
                            ANv x = new NvFulltime(maso1, ten, ngay, gt, sdt, email, cn, hsluong);
                            cn.ThemNhanVien(x, DsNV);
                          
                            if(maso1.Substring(0,1) == "F")
                            {
                                Console.WriteLine($"danh sách nhân viên full time của chi nhánh {cn.Tencn} ");
                                for ( int i = 0; i < cn.Nhanvienfcn.Count; i++)
                                {
                                    Console.WriteLine(cn.Nhanvienfcn[i].Ten);
                                }

                            }
                            else
                            {
                                Console.WriteLine($"danh sách nhân viên part time chi nhánh {cn.Tencn} ");
                                for (int i = 0; i < cn.Nhanvienpcn.Count; i++)
                                {
                                    Console.WriteLine(cn.Nhanvienpcn[i].Ten);                                }

                            }
                            Console.WriteLine("Thêm nhân viên thành công!");
                            break;
                        case 2:
                            Console.WriteLine("Nhập mã số nhân viên cần xóa: ");
                            string ma = Console.ReadLine();
                            cn.XoaNhanVien(ma, DsNV);
                            Console.WriteLine("Xóa nhân viên thành công!");
                            if (ma.Substring(0, 1) == "F")
                            {
                                Console.WriteLine($"danh sách nhân viên full time của chi nhánh {cn.Tencn} ");
                                for (int i = 0; i < cn.Nhanvienfcn.Count; i++)
                                {
                                    Console.WriteLine(cn.Nhanvienfcn[i].Ten);
                                }

                            }
                            else
                            {
                                Console.WriteLine($"danh sách nhân viên part time chi nhánh {cn.Tencn} ");
                                for (int i = 0; i < cn.Nhanvienpcn.Count; i++)
                                {
                                    Console.WriteLine(cn.Nhanvienpcn[i].Ten);
                                }

                            }
                            break;
                        case 3:
                       // nhap3b:
                            Console.WriteLine("=== QQUẢN LÝ NHÂN VIÊN FULLTIME ===");
                            Console.WriteLine("1. Ca Làm Nhân Viên ");
                            Console.WriteLine("2. Vắng ngày");
                            Console.WriteLine("3. Tiền Lương - Tiền Thưởng - Tiền Phạt");
                            Console.WriteLine("4. Thoát");
                            Console.WriteLine("Nhập mã nhân viên cần quản lý : ");
                            string ms = Console.ReadLine();
                            NvFulltime m = (NvFulltime)DsNV.Tim(ms);
                            nhap3b:
                            Console.WriteLine("Nhập lựa chọn: ");
                            int lchon = int.Parse(Console.ReadLine());
                            if (lchon != 4)
                            {
                                switch (lchon)
                                {
                                    case 1: m.ShowCaLam(); break;
                                    case 2:
                                        List<int[]> NgayVang = m.VangNgay();
                                        Console.WriteLine("Nhân viên đã vắng:");
                                        for (int i = 0; i < NgayVang.Count; i++)
                                        {
                                            Console.WriteLine("Ngày: " + NgayVang[i][1] + " ca " + NgayVang[i][0]);
                                        }
                                        break;
                                    case 3:
                                        Console.WriteLine("Tiền Lương nhân viên: {0}", m.TinhLuong());
                                        Console.WriteLine("Tiền Thưởng nhân viên: {0}", m.TinhThuong());
                                        Console.WriteLine("Tiền Phạt nhân viên: {0}", m.TinhPhat());
                                        break;
                                }
                                goto nhap3b;
                            }
                            break;
                        case 4:
                             //  nhap3c:
                          
                       
                            Console.WriteLine("=== QUẢN LÝ NHÂN VIÊN PARTTIME ===");
                            Console.WriteLine("1. Ca Làm Nhân Viên ");
                            Console.WriteLine("2. Vắng ngày");
                            Console.WriteLine("3. Tiền Lương - Tiền Thưởng - Tiền Phạt");
                            Console.WriteLine("4. Thoát");
                            Console.WriteLine("Nhập mã nhân viên cần quản lý : ");
                            string msss = Console.ReadLine();
                            NvParttime q = (NvParttime)DsNV.Tim(msss);
                        nhap3c:
                            Console.WriteLine("Nhập lựa chọn: ");
                            int chon3b = int.Parse(Console.ReadLine());
                            if (chon3b != 4)
                            {
                                switch (chon3b)
                                {
                                    case 1: q.ShowCaLam(); break;
                                    case 2:
                                        List<int[]> NgayVang = q.VangNgay();
                                        Console.WriteLine("Nhân viên đã vắng:");
                                        for (int i = 0; i < NgayVang.Count; i++)
                                        {
                                            Console.WriteLine("Ngày: " + NgayVang[i][1] + " ca " + NgayVang[i][0]);
                                        }
                                        break;
                                    case 3:
                                        Console.WriteLine("Tiền Lương nhân viên: {0}", q.TinhLuong());
                                        Console.WriteLine("Tiền Thưởng nhân viên: {0}", q.TinhThuong());
                                        Console.WriteLine("Tiền Phạt nhân viên: {0}", q.TinhPhat());
                                        break;
                                }
                                goto nhap3c;
                            }
                            break;
                    }
                }
            }
            if (luachon == 4)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nĐề tài: QUẢN LÝ KINH DOANH CỬA HÀNG TIỆN LỢI\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=== QUẢN LÝ KHÁCH HÀNG ===");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Nhập mã số thẻ khách hàng: ");
                string maso2 = Console.ReadLine();
                KhachHang c = (KhachHang)DsKH.Tim(maso2);
                if (c.GetMaso() != "")
                {
                    Console.WriteLine("1. Lịch sử mua hàng");
                    Console.WriteLine("2. Thông tin khách hàng");
                    Console.WriteLine("3. Trở về");
                nhap4:
                    Console.WriteLine("Nhập lựa chọn: ");
                    int chon5 = int.Parse(Console.ReadLine());
                    if (chon5 != 3)
                    {
                        switch (chon5)
                        {
                            case 1: c.GetLsMuaHang(); break;
                            case 2: Console.WriteLine(c.ToString()); break;
                        }
                    }

                    goto hien;
                }
            }
            if (luachon == 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("CHEERS!");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Cảm ơn Thầy đã dành thời gian cho đồ án của nhóm 6 :)))");
                Console.ReadLine();
                return;
            }
            goto hien;

        }
            static void Main(string[] args)
            {
                // hàng hóa
                Console.InputEncoding = System.Text.Encoding.Unicode;
                Console.OutputEncoding = System.Text.Encoding.Unicode;

                int[] e = { 4, 7 };
                int[] b = { 1, 1 };
                Array caPa1 = Array.CreateInstance(typeof(bool), e, b);
                Array caPa2 = Array.CreateInstance(typeof(bool), e, b);
                Array caPa3 = Array.CreateInstance(typeof(bool), e, b);

                for (int i = caPa1.GetLowerBound(0); i <= caPa1.GetUpperBound(0); i++)
                {
                    for (int j = caPa1.GetLowerBound(1); j <= caPa1.GetUpperBound(1); j++)
                    {
                        caPa1.SetValue(false, i, j);
                        caPa2.SetValue(false, i, j);
                        caPa3.SetValue(false, i, j);
                    }
                }

                caPa1.SetValue(true, 1, 1);
                caPa1.SetValue(true, 3, 2);
                caPa1.SetValue(true, 4, 3);
                caPa1.SetValue(true, 2, 4);
                caPa1.SetValue(true, 4, 6);
                caPa1.SetValue(true, 4, 7);

                caPa2.SetValue(true, 1, 2);
                caPa2.SetValue(true, 2, 1);
                caPa2.SetValue(true, 3, 3);
                caPa2.SetValue(true, 1, 4);
                caPa2.SetValue(true, 4, 5);
                caPa2.SetValue(true, 1, 6);

                caPa3.SetValue(true, 3, 1);
                caPa3.SetValue(true, 1, 3);
                caPa3.SetValue(true, 4, 2);
                caPa3.SetValue(true, 1, 4);
                caPa3.SetValue(true, 2, 5);
                caPa3.SetValue(true, 3, 6);



                int[] c = { 3, 7 };
                int[] d = { 1, 1 };
                Array caFu1 = Array.CreateInstance(typeof(bool), c, d);
                Array caFu2 = Array.CreateInstance(typeof(bool), c, d);
                Array caFu3 = Array.CreateInstance(typeof(bool), c, d);

                for (int i = caFu1.GetLowerBound(0); i <= caFu1.GetUpperBound(0); i++)
                {
                    for (int j = caFu1.GetLowerBound(1); j <= caFu1.GetUpperBound(1); j++)
                    {
                        caFu1.SetValue(false, i, j);
                        caFu2.SetValue(false, i, j);
                        caFu3.SetValue(false, i, j);
                    }
                }

                caFu1.SetValue(true, 1, 1);
                caFu1.SetValue(true, 1, 2);
                caFu1.SetValue(true, 1, 6);
                caFu1.SetValue(true, 3, 5);
                caFu1.SetValue(true, 3, 4);
                caFu1.SetValue(true, 2, 3);

                caFu2.SetValue(true, 2, 1);
                caFu2.SetValue(true, 3, 3);
                caFu2.SetValue(true, 2, 5);
                caFu2.SetValue(true, 2, 6);
                caFu2.SetValue(true, 3, 7);
                caFu2.SetValue(true, 3, 2);

                caFu3.SetValue(true, 3, 1);
                caFu3.SetValue(true, 2, 2);
                caFu3.SetValue(true, 1, 3);
                caFu3.SetValue(true, 1, 4);
                caFu3.SetValue(true, 3, 6);
                caFu3.SetValue(true, 2, 7);

                bool[,] fu1 = new bool[3, 31];
                bool[,] fu2 = new bool[3, 31];
                bool[,] pa1 = new bool[4, 31];
                bool[,] pa2 = new bool[4, 31];
                bool[,] pa3 = new bool[4, 31];

                for (int i = fu1.GetLowerBound(0); i < fu1.GetUpperBound(0); i++)
                {
                    for (int j = fu1.GetLowerBound(1); j < fu1.GetUpperBound(1); j++)
                    {
                        fu1[i, j] = false;
                        if (j % 7 == 2 && i % 3 == 0) fu1[i, j] = true;
                        if (j % 7 == 1 && i % 3 == 1) fu1[i, j] = true;
                        if (j % 7 == 4 && i % 3 == 2) fu1[i, j] = true;
                        if (j % 7 == 3 && i % 3 == 0) fu1[i, j] = true;
                        if (j % 7 == 5 && i % 3 == 2) fu1[i, j] = true;
                        if (j % 7 == 6 && i % 3 == 1) fu1[i, j] = true;
                    }
                }

                for (int i = fu2.GetLowerBound(0); i < fu2.GetUpperBound(0); i++)
                {
                    for (int j = fu2.GetLowerBound(1); j < fu2.GetUpperBound(1); j++)
                    {
                        fu2[i, j] = false;
                        if (j % 7 == 0 && i % 3 == 0) fu2[i, j] = true;
                        if (j % 7 == 2 && i % 3 == 1) fu2[i, j] = true;
                        if (j % 7 == 3 && i % 3 == 2) fu2[i, j] = true;
                        if (j % 7 == 4 && i % 3 == 0) fu2[i, j] = true;
                        if (j % 7 == 6 && i % 3 == 2) fu2[i, j] = true;
                        if (j % 7 == 5 && i % 3 == 1) fu2[i, j] = true;
                    }
                }
                for (int i = pa1.GetLowerBound(0); i < pa1.GetUpperBound(0); i++)
                {
                    for (int j = pa1.GetLowerBound(1); j < pa1.GetUpperBound(1); j++)
                    {
                        pa1[i, j] = false;
                        if (j % 7 == 0 && i % 3 == 0) pa1[i, j] = true;
                        if (j % 7 == 2 && i % 3 == 1) pa1[i, j] = true;
                        if (j % 7 == 4 && i % 3 == 2) pa1[i, j] = true;
                        if (j % 7 == 1 && i % 3 == 3) pa1[i, j] = true;
                        if (j % 7 == 6 && i % 3 == 0) pa1[i, j] = true;
                        if (j % 7 == 5 && i % 3 == 1) pa1[i, j] = true;
                    }
                }
                for (int i = pa2.GetLowerBound(0); i < pa2.GetUpperBound(0); i++)
                {
                    for (int j = pa2.GetLowerBound(1); j < pa2.GetUpperBound(1); j++)
                    {
                        pa2[i, j] = false;
                        if (j % 7 == 0 && i % 3 == 0) pa2[i, j] = true;
                        if (j % 7 == 2 && i % 3 == 1) pa2[i, j] = true;
                        if (j % 7 == 6 && i % 3 == 2) pa2[i, j] = true;
                        if (j % 7 == 4 && i % 3 == 0) pa2[i, j] = true;
                        if (j % 7 == 5 && i % 3 == 2) pa2[i, j] = true;
                        if (j % 7 == 1 && i % 3 == 1) pa2[i, j] = true;
                    }
                }
                for (int i = pa3.GetLowerBound(0); i < pa3.GetUpperBound(0); i++)
                {
                    for (int j = pa3.GetLowerBound(1); j < pa3.GetUpperBound(1); j++)
                    {
                        pa3[i, j] = false;

                        if (j % 7 == 2 && i % 3 == 1) pa3[i, j] = true;
                        if (j % 7 == 6 && i % 3 == 2) pa3[i, j] = true;
                        if (j % 7 == 4 && i % 3 == 0) pa3[i, j] = true;
                        if (j % 7 == 5 && i % 3 == 3) pa3[i, j] = true;
                        if (j % 7 == 1 && i % 3 == 0) pa3[i, j] = true;
                    }
                }
                // hàng hóa
                Console.InputEncoding = System.Text.Encoding.Unicode;
                Console.OutputEncoding = System.Text.Encoding.Unicode;

                CacMH khomathang;
                HangHoa a24 = new HangHoa("Coca", "Nước giải khát", 7000, 12000);
                HangHoa a1 = new HangHoa("Nước cam", "Nước giải khát", 12000, 20000);
                HangHoa a2 = new HangHoa("Bánh quy", "Bánh Kẹo", 12000, 20000);
                HangHoa a3 = new HangHoa("Kẹo", "Bánh Kẹo", 12000, 23000);
                HangHoa a4 = new HangHoa("Kéo", "Dụng cụ học tập", 15000, 30000);
                HangHoa a5 = new HangHoa("Viết chì", "Dụng cụ học tập", 2000, 5000);
                HangHoa a6 = new HangHoa("Thước", "Dụng cụ học tập", 3000, 6000);
                HangHoa a7 = new HangHoa("Khăn ướt", "Dụng cụ vệ sinh", 35000, 50000);
                HangHoa a8 = new HangHoa("Chổi", "Dụng cụ vệ sinh", 20000, 23000);
                HangHoa a9 = new HangHoa("Tập", "Dụng cụ học tập", 5000, 9000);
                HangHoa a10 = new HangHoa("Ly nhựa", "Vật dụng ăn uống", 7000, 15000);
                HangHoa a11 = new HangHoa("Muỗng", "Vật dụng ăn uống", 6000, 11000);
                HangHoa a12 = new HangHoa("Dầu ăn", "Nấu ăn", 35000, 44000);
                HangHoa a13 = new HangHoa("Nước suối", "Nước giải khát", 35000, 44000);
                HangHoa a14 = new HangHoa("Cafe", "Nước giải khát", 7000, 13000);
                HangHoa a15 = new HangHoa("7up", "Nước giải khát", 7000, 12000);
                HangHoa a16 = new HangHoa("Xúc xích", "Thức ăn nhanh", 5000, 23000);
                HangHoa a17 = new HangHoa("Cơm gà", "Thức ăn nhanh", 15000, 40000);
                HangHoa a18 = new HangHoa("Kem đánh răng", "Dụng cụ vệ sinh", 25000, 50000);
                HangHoa a19 = new HangHoa("Tương ớt", "Nấu ăn", 7000, 27000);
                HangHoa a20 = new HangHoa("Sữa rửa mặt", "Dụng cụ vệ sinh", 70000, 100000);
                HangHoa a21 = new HangHoa("Gạo", "Nấu ăn", 50000, 120000);
                HangHoa a22 = new HangHoa("Sữa Tắm", "Dụng cụ vệ sinh", 56000, 200000);
                HangHoa a23 = new HangHoa("Nước giặt", "Dụng cụ vệ sinh", 75000, 300000);
                List<HangHoa> demohh = new List<HangHoa>() { a24, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16, a17, a18, a19, a20, a21, a22, a23 };
                khomathang = new CacMH(demohh);
                // chi nhánh
                ChiNhanh c1 = new ChiNhanh("1", "Chi Nhánh Tân Bình");
                ChiNhanh c2 = new ChiNhanh("2", "Chi Nhánh Quận 10");
                ChiNhanh c3 = new ChiNhanh("3", "Chi Nhánh Quận 1");
                c1.KHOHAN.AddRange(demohh); c2.KHOHAN.AddRange(demohh);
                c3.KHOHAN.AddRange(demohh);


                List<ChiNhanh> DsCn = new List<ChiNhanh>();
                DsCn.Add(c1); DsCn.Add(c2); DsCn.Add(c3);

                //Tao danh sach nhan vien
                DataOfNguoi DsNV = new DataOfNguoi();
                // nhân viên full time
                ANv f1 = new NvFulltime("F01", "Nguyễn Văn A", DateTime.ParseExact("27/06/2002", "dd/MM/yyyy", CultureInfo.InvariantCulture), "Nam", "0374562128", "Anguyenvan@gmail.com", c1, 6);
                ANv f2 = new NvFulltime("F02", "Nguyễn Thị B", DateTime.ParseExact("17/03/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture), "Nữ", "0374562128", "Bnguyen@gmail.com", c1, 7);
                ANv f3 = new NvFulltime("F03", "Trần Văn C", DateTime.ParseExact("19/03/2001", "dd/MM/yyyy", CultureInfo.InvariantCulture), "Nam", "0374562128", "Ctran@gmail.com", c2, 6);
                ANv f4 = new NvFulltime("F04", "Phan Hoàng D", DateTime.ParseExact("25/06/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture), "Nam", "0374562128", "Dphan@gmail.com", c2, 7);
                ANv f5 = new NvFulltime("F05", "Đàm Thị E", DateTime.ParseExact("01/11/2002", "dd/MM/yyyy", CultureInfo.InvariantCulture), "Nữ", "0374562128", "DamE@gmail.com", c3, 6);
                ANv f6 = new NvFulltime("F06", "Võ Thị E", DateTime.ParseExact("29/01/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture), "Nữ", "0374562128", "Evole@gmail.com", c3, 6);
                f1.CaLam(caFu1); f1.CaLamTheoThang_Mau(fu1); f1.ThucLam_Mau(fu1);
                f2.CaLam(caFu2); f2.CaLamTheoThang_Mau(fu2); f2.ThucLam_Mau(fu1);
                f3.CaLam(caFu3); f3.CaLamTheoThang_Mau(fu1); f3.ThucLam_Mau(fu2);
                f4.CaLam(caFu3); f4.CaLamTheoThang_Mau(fu2); f4.ThucLam_Mau(fu2);
                f5.CaLam(caFu1); f5.CaLamTheoThang_Mau(fu2); f5.ThucLam_Mau(fu2);
                f6.CaLam(caFu2); f6.CaLamTheoThang_Mau(fu1); f6.ThucLam_Mau(fu1);

                c1.ThemNhanVien(f1, DsNV); c1.ThemNhanVien(f2, DsNV);
                c2.ThemNhanVien(f3, DsNV); c3.ThemNhanVien(f5, DsNV);
                c2.ThemNhanVien(f4, DsNV); c3.ThemNhanVien(f6, DsNV);
                // nhân viên parttime
                ANv p1 = new NvParttime("P01", "Văn Tuấn Kiệt", DateTime.ParseExact("22/07/2002", "dd/MM/yyyy", CultureInfo.InvariantCulture), "Nam", "0374562128", "Anguyenvan@gmail.com", c1);
                ANv p2 = new NvParttime("P02", "Trần Hoàng E", DateTime.ParseExact("11/08/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture), "Nam", "0374562128", "Bnguyen@gmail.com", c1);
                ANv p3 = new NvParttime("P03", "Hoàng Văn H", DateTime.ParseExact("19/04/2001", "dd/MM/yyyy", CultureInfo.InvariantCulture), "Nam", "0374562128", "Hhoang@gmail.com", c2);
                ANv p4 = new NvParttime("P04", "Phan Đình K", DateTime.ParseExact("25/06/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture), "Nam", "0374562128", "Kphan@gmail.com", c2);
                ANv p5 = new NvParttime("P05", "Đinh THỊ M", DateTime.ParseExact("14/02/2002", "dd/MM/yyyy", CultureInfo.InvariantCulture), "Nữ", "0374562128", "DamM@gmail.com", c3);
                ANv p6 = new NvParttime("P06", "Nguyễn Thị H", DateTime.ParseExact("29/05/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture), "Nữ", "0374562128", "Hnguyenthi@gmail.com", c3);
                p1.CaLam(caPa1); p1.CaLamTheoThang_Mau(pa1); p1.ThucLam_Mau(pa2);
                p2.CaLam(caPa3); p2.CaLamTheoThang_Mau(pa2); p2.ThucLam_Mau(pa2);
                p3.CaLam(caPa2); p3.CaLamTheoThang_Mau(pa3); p3.ThucLam_Mau(pa3);
                p4.CaLam(caPa1); p4.CaLamTheoThang_Mau(pa2); p4.ThucLam_Mau(pa1);
                p5.CaLam(caPa2); p5.CaLamTheoThang_Mau(pa3); p5.ThucLam_Mau(pa3);
                p6.CaLam(caPa3); p5.CaLamTheoThang_Mau(pa1); p6.ThucLam_Mau(pa1);
                c1.ThemNhanVien(p1, DsNV); c1.ThemNhanVien(p2, DsNV);
                c2.ThemNhanVien(p3, DsNV); c2.ThemNhanVien(p4, DsNV);
                c3.ThemNhanVien(p5, DsNV); c3.ThemNhanVien(p6, DsNV);

                // khách hàng thân thiết
                KhachHang k1 = new KhachHang("KH01", "Nguyễn Thị N", "0947652125", "Nnguyen@gmail.com");
                KhachHang k2 = new KhachHang("KH02", "Trần Văn F", "0947652125", "Ftran@gmail.com");
                KhachHang k3 = new KhachHang("KH03", "Phan Hoàng I", "0947652125", "IPhanTr@gmail.com");
                KhachHang k4 = new KhachHang("KH04", "Võ Minh K", "0947652125", "Kvominh@gmail.com");
                KhachHang k5 = new KhachHang("KH05", "Hoàng Văn H", "0947652125", "Hhoang@gmail.com");
                KhachHang k6 = new KhachHang("KH06", "Lê Thị N", "0968972125", "Nnguyen@gmail.com");
                KhachHang k7 = new KhachHang("KH07", "Trần Văn U", "0947650489", "Nnguyen@gmail.com");
                KhachHang k8 = new KhachHang("KH08", "Phạm Ngọc H", "0947612345", "Nnguyen@gmail.com");
                KhachHang k9 = new KhachHang("KH09", "Đinh Như Y", "0947652125", "Ydinh@gmail.com");
                KhachHang k10 = new KhachHang("KH10", "Võ Thị O", "0947652125", "Oooo@gmail.com");
                DataOfNguoi DsKH = new DataOfNguoi();
                DsKH += k1;
                DsKH += k2;
                DsKH += k3;
                DsKH += k4;
                DsKH += k5;
                DsKH += k6;
                DsKH += k7;
                DsKH += k8;
                DsKH += k9;
                DsKH += k10;

                HoaDonBanHang HoaDonBH = new HoaDonBanHang();
                HoaDonDatHang HoaDonDH = new HoaDonDatHang();
                // event 
                //1,2 HDBH, HDDH

                HoaDonBH.sub(c1); HoaDonDH.sub(c1);
                HoaDonBH.sub(c2); HoaDonDH.sub(c2);
                HoaDonBH.sub(c3); HoaDonDH.sub(c3);
                //3 congsl
                khomathang.sub(c3);
                khomathang.sub(c2);
                khomathang.sub(c1);
                //4 thaydoilichsumuahang

                DsKH.sub(c1); DsKH.sub(c2); DsKH.sub(c3);
                //5 
                khomathang.sub(HoaDonDH);
                khomathang.sub(HoaDonBH);

                //DESIGN UI
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("ĐỒ ÁN LẬP TRÌNH HƯỚNG ĐỐI TƯỢNG");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Giảng viên hướng dẫn: Đặng Ngọc Hoàng Thành");
                Console.WriteLine("GROUP 6: Nguyễn Văn Khôi - 31201024412");
                Console.WriteLine("         Văn Tuấn Kiệt - 31201024409");
                Console.WriteLine("         Phan Thị Như Quỳnh - 31201024427");
                Console.WriteLine("         Phạm Lê Phương Trinh - 31201024449");

                HDCN(DsCn, khomathang, DsKH, DsNV);

                System.Environment.Exit(-1);
            }
        
    }
}









