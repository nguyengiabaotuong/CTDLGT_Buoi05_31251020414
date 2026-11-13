using System;
using System.Collections.Generic;
using System.Text;

namespace CTDLGT_Buoi5_31251020414
{
    internal class Bai1
    {
        static void Main1()
        {
            // Đọc dòng 1 lấy số n
            string line1 = Console.ReadLine();
            if (string.IsNullOrEmpty(line1)) return;
            int n = int.Parse(line1.Trim());
            // Đọc dòng 2 lấy mảng a
            string[] tokens = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            long[] a = new long[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = long.Parse(tokens[i]);
            }
            // Biến đếm số lần dịch chuyển
            int Count = 0;
            // THUẬT TOÁN SẮP XẾP CHÈN (Insertion Sort)
            for (int i = 1; i < n; i++)
            {
                // Rút người thứ i ra (gọi là x)
                long x = a[i];
                // Bắt đầu xét từ người đứng ngay trước nó
                int j = i - 1;
                while (j >= 0 && a[j] > x)
                {
                    a[j + 1] = a[j]; 
                    Count++;    
                    j--;             
                }
                // Khi vòng lặp dừng, j là vị trí của phần tử nhỏ hơn hoặc bằng x
                // Suy ra chỗ trống (chỗ cần chèn x) chính là j + 1
                a[j + 1] = x;
            }
            // In dòng 1: Tổng số lần dịch chuyển
            Console.WriteLine(Count);
            // In dòng 2: Mảng sau khi đã sắp xếp (dùng string.Join nối lại bằng dấu cách cho nhanh)
            Console.WriteLine(string.Join(" ", a));
        }
    }
}
