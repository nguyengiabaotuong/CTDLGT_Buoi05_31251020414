using System;
using System.Collections.Generic;
using System.Text;

namespace CTDLGT_Buoi5_31251020414
{
    internal class Bai6
    {
        static void Main()
        {
            // Đọc dòng 1 lấy n và S
            string line1 = Console.ReadLine();
            if (string.IsNullOrEmpty(line1)) return;
            string[] parts = line1.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(parts[0]);
            // S có thể lên đến 2*10^9, 
            // phép tính (S - a[i]) có thể vọt qua 3 tỷ, tràn kiểu int => dùng long
            long S = long.Parse(parts[1]);
            // Đọc dòng 2 lấy mảng a
            string[] tokens = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<long, int> counts = new Dictionary<long, int>();
            // Tổng số cặp (có thể lên 2*10^10 => dùng long)
            long totalPairs = 0;
            for (int i = 0; i < n; i++)
            {
                long val = long.Parse(tokens[i]);
                // Mảnh ghép còn thiếu để tổng bằng S
                long neededval = S - val;
                // Nếu mảnh ghép này đã từng được cất vào túi từ trước đó
                if (counts.ContainsKey(neededval))
                {
                    // Có bao nhiêu mảnh ghép hợp lệ trong túi thì tạo ra bấy nhiêu cặp
                    totalPairs += counts[neededval];
                }
                // Xử lý xong hiện tại thì cất val vào túi để làm "mảnh ghép cho các số đi sau
                if (counts.ContainsKey(val))
                {
                    counts[val]++;
                }
                else
                {
                    counts[val] = 1;
                }
            }
            // 3. In ra kết quả
            Console.WriteLine(totalPairs);
        }
    }
}
