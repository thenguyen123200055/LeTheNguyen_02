using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau_1
{
    class NhanVien
    {
        private string maso;
        private string hoten;
        private int luongcung;

        public NhanVien()
        {

        }
        public NhanVien(string maso, string hoten, int luongcung)
        {
            this.maso = maso;
            this.hoten = hoten;
            this.luongcung = luongcung;
        }
        public string Maso
        {
            set { this.maso = value; }
            get { return this.maso; }
        }
        public string HoTen
        {
            set { this.hoten = value; }
            get { return this.hoten; }
        }
        public int LuongCung
        {
            set { this.luongcung = value; }
            get { return this.luongcung; }
        }
        public virtual void Nhap()
        {
            Console.Write("Nhap ma so:");
            this.maso = Console.ReadLine();
            Console.Write("Nhap ho ten:");
            this.hoten = Console.ReadLine();
            Console.Write("Nhap luong cung:");
            this.luongcung = int.Parse(Console.ReadLine());
        }
        public virtual int tinhluong()
        {
            return 0;
        }
        class NhanVienBC : NhanVien
        {

            private string mucxeploai;


            public NhanVienBC() : base()
            {
            }
            public NhanVienBC(string maso, string hoten, int luongcung, string mucxeploai) : base(maso, hoten, luongcung)
            {
                this.mucxeploai = mucxeploai; ;
            }

            public string MucXepLoai
            {
                set { mucxeploai = value; }
                get { return mucxeploai; }
            }


            public override void Nhap()
            {
                base.Nhap();
                Console.Write("Nhap Muc Xep Loai:");
                this.mucxeploai = Console.ReadLine();
            }

            public override int tinhluong()
            {
                int thuong = 0;
                switch (mucxeploai)
                {
                    case "A":
                        thuong = (int)(1.5 * luongcung);
                        break;
                    case "B":
                        thuong = (int)(1.0 * luongcung);
                        break;
                    case "C":
                        thuong = (int)(0.5 * luongcung);
                        break;
                }
                return luongcung + thuong;
            }
            class NhanVienHD : NhanVien
            {

                private int doanhthu;


                public NhanVienHD() : base()
                {
                }
                public NhanVienHD(string maso, string hoten, int luongcung, int doanhthu) : base(maso, hoten, luongcung)
                {
                    this.doanhthu = doanhthu;
                }

                public int DoanhThu
                {
                    set { doanhthu = value; }
                    get { return doanhthu; }
                }
                public override void Nhap()
                {
                    base.Nhap();
                    Console.Write("Nhap doanh Thu: ");
                    this.doanhthu = int.Parse(Console.ReadLine());
                }
                public override int tinhluong()
                {
                    return LuongCung + (int)(0.1 * DoanhThu);
                }
                public class QuanLyNV
                {
                    private List<NhanVien> dsnv;
                    public QuanLyNV()
                    {
                        dsnv = new List<NhanVien>();
                    }
                    public void NhapDS()
                    {
                        string tieptuc = "y";
                        int chon;
                        NhanVien nv;
                        do
                        {
                            Console.Write("Chon loai nhan vien [1:nvbc,2:nvhd]:");
                            chon = int.Parse(Console.ReadLine());
                            switch (chon)
                            {
                                case 1:
                                    nv = new NhanVienBC();
                                    nv.Nhap();
                                    dsnv.Add(nv);
                                    break;
                                case 2:
                                    nv = new NhanVienHD();
                                    nv.Nhap();
                                    dsnv.Add(nv);
                                    break;
                                default:
                                    Console.WriteLine("Ban chon sai.vui long chon 1 hoac 2.");
                                    break;
                            }
                            Console.Write("Ban co muon tiep tuc khong?Y/N:");
                            tieptuc = Console.ReadLine();
                        } while (tieptuc.ToLower() == "y");
                    }



                    public void XuatDS()
                    {
                        Console.WriteLine("Danh sach nhan vien:");
                        foreach (NhanVien nv in dsnv)
                        {
                            if (nv is NhanVienBC)
                            {
                                NhanVienBC nvbc = nv as NhanVienBC;
                                Console.WriteLine("Ma so:" + nvbc.Maso);
                                Console.WriteLine("Ho ten:" + nvbc.hoten);
                                Console.WriteLine("Muc xep loai:" + nvbc.mucxeploai);
                                Console.WriteLine("Luong thuc lanh:" + nvbc.tinhluong());
                            }
                            else
                            {
                                NhanVienHD nvhd = nv as NhanVienHD;
                                Console.WriteLine("Ma so:" + nvhd.Maso);
                                Console.WriteLine("Ho ten:" + nvhd.hoten);
                                Console.WriteLine("Muc xep loai:" + nvhd.doanhthu);
                                Console.WriteLine("Luong thuc lanh:" + nvhd.tinhluong());
                            }
                        }
                        {

                        }
                    }
                    public int TinhTongLuong()
                    {
                        int tongluong = 0;
                        foreach (NhanVien nv in dsnv)
                        {
                            tongluong += nv.tinhluong();
                        }
                        return tongluong;
                    }
                    public double TinhLuongTrungBinh()
                    {
                        return (double)TinhTongLuong() / dsnv.Count;
                    }
                    class Program
                    {
                        static void Main(string[] args)
                         
                        {
                            menu();
                        }

                        static void menu()
                        {
                            QuanLyNV ql = new QuanLyNV();
                            int chon = 0;
                            do
                            {
                                Console.WriteLine("******** CHUONG TRINH  QUAN LY NHAN VIEN ******");
                                Console.WriteLine("-----------------------------------------------");
                                Console.WriteLine("1. Nhap danh sach nhan vien.");
                                Console.WriteLine("2. Xuat thong tin nhan vien.");
                                Console.WriteLine("3. Thong ke tong tien luong nhan vien.");
                                Console.WriteLine("0. Ket thuc chuong trinh");
                                Console.WriteLine("--------------------------------");
                                Console.Write("Ban chon chuc nang:");
                                chon = int.Parse(Console.ReadLine());

                                switch (chon)
                                {
                                    case 1:
                                        ql.NhapDS();
                                        break;

                                    case 2:
                                        ql.XuatDS();
                                        break;
                                    case 3:
                                        Console.WriteLine($"Tong tien luong phai tra cho nhan vien: {ql.TinhTongLuong():#,##0 vnd}");
                                        break;
                                    case 0:
                                        Console.WriteLine("Tam bie.");
                                        Console.ReadLine();
                                        break;
                                }

                            } while (chon != 0);
                        }
                    }
                }
            }

        }
    }
}


