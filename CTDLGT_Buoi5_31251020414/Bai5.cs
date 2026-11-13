using System;
using System.Collections.Generic;
using System.Text;

namespace CTDLGT_Buoi5_31251020414
{
    internal class Bai5
    {
        static void Main5()
        {
            // Đọc số lượng phần tử n
            string line1 = Console.ReadLine();
            if (string.IsNullOrEmpty(line1)) return;
            int n = int.Parse(line1.Trim());
            // Đọc mảng a 
            string[] tokens = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            // Khởi tạo Dictionary để đếm tần số xuất hiện. 
            // Key (long) là giá trị của phần tử, Value (int) là số lần xuất hiện.
            Dictionary<long, int> counts = new Dictionary<long, int>();
            long maxValue = 0; // Lưu giá trị xuất hiện nhiều nhất
            int maxCount = 0;  // Lưu số lần xuất hiện nhiều nhất
            for (int i = 0; i < n; i++)
            {
                long val = long.Parse(tokens[i]);
                // Nếu giá trị đã có trong Dictionary, tăng số đếm lên 1
                if (counts.ContainsKey(val))
                {
                    counts[val]++;
                }
                // Nếu chưa có, thêm vào với số đếm là 1
                else
                {
                    counts[val] = 1;
                }
                // Cập nhật ngay lập tức nếu tìm thấy giá trị có số lần xuất hiện KỶ LỤC MỚI
                if (counts[val] > maxCount)
                {
                    maxCount = counts[val];
                    maxValue = val;
                }
                // Nếu bằng kỷ lục hiện tại, ưu tiên lấy giá trị NHỎ HƠN
                else if (counts[val] == maxCount)
                {
                    if (val < maxValue)
                    {
                        maxValue = val;
                    }
                }
            }
            // In ra kết quả
            Console.WriteLine($"{maxValue} {maxCount}");
        }
    }
}
