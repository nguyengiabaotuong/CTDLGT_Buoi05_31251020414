using System;
using System.Collections.Generic;
using System.Text;

namespace CTDLGT_Buoi5_31251020414
{
    internal class Bai2
    {
        static void Main2()
        {
            // Đọc dòng 1 lấy số lượng phần tử n
            string line1 = Console.ReadLine();
            if (string.IsNullOrEmpty(line1)) return;
            int n = int.Parse(line1.Trim());
            // Đọc dòng 2 (chứa toàn bộ n con số) chỉ với 1 nhát cắt Split
            string[] tokens = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            // Nạp dữ liệu vào mảng
            long[] a = new long[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = long.Parse(tokens[i]);
            }
            // Dùng hàm Sort có sẵn O(n log n) của C#
            Array.Sort(a);
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                output.Append(a[i]).Append(" ");
            }
            // Chỉ gọi lệnh in ra màn hình đúng 1 lần duy nhất
            Console.WriteLine(output.ToString().TrimEnd());

        }
    }
}
