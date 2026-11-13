using System;
using System.Collections.Generic;
using System.Text;

namespace CTDLGT_Buoi5_31251020414
{
    internal class Bai3
    {
        static long MergeSortAndCount(long[] a, long[] temp, int left, int right)
        {
            long Count = 0;
            if (left < right)
            {
                int mid = left + (right - left) / 2;
                // Đếm nghịch thế nội bộ nửa bên trái
                Count += MergeSortAndCount(a, temp, left, mid);
                // Đếm nghịch thế nội bộ nửa bên phải
                Count += MergeSortAndCount(a, temp, mid + 1, right);
                // Đếm nghịch thế chéo (phần tử nửa phải nhỏ hơn nửa trái) khi trộn
                Count += MergeAndCount(a, temp, left, mid, right);
            }
            return Count;
        }
        // Hàm trộn (Merge) kết hợp đếm nghịch thế
        static long MergeAndCount(long[] a, long[] temp, int left, int mid, int right)
        {
            int i = left;      // Con trỏ duyệt nửa bên trái
            int j = mid + 1;   // Con trỏ duyệt nửa bên phải
            int k = left;      // Con trỏ duyệt mảng tạm
            long Count = 0;
            while (i <= mid && j <= right)
            {
                if (a[i] <= a[j])
                {
                    // Trật tự đúng, không có nghịch thế, bỏ nửa trái vào mảng tạm
                    temp[k++] = a[i++];
                }
                else
                {
                    // PHÁT HIỆN NGHỊCH THẾ
                    // a[i] > a[j] mà mảng trái đã sắp xếp tăng dần
                    // => a[j] chắc chắn nhỏ hơn TẤT CẢ các phần tử còn lại của mảng trái
                    // Số lượng phần tử còn lại của mảng trái chính là (mid - i + 1)
                    temp[k++] = a[j++];
                    Count += (mid - i + 1);
                }
            }
            // Quét các phần tử của mảng trái
            while (i <= mid)
            {
                temp[k++] = a[i++];
            }
            // Quét các phần tử của mảng phải
            while (j <= right)
            {
                temp[k++] = a[j++];
            }
            // Chép ngược mảng tạm t đã sắp xếp đè lên mảng gốc a
            for (i = left; i <= right; i++)
            {
                a[i] = temp[i];
            }
            return Count;
        }
        static void Main3()
        {
            // Nhập n
            string line1 = Console.ReadLine();
            if (string.IsNullOrEmpty(line1)) return;
            int n = int.Parse(line1.Trim());
            // Nhập mảng a 
            string[] tokens = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            long[] a = new long[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = long.Parse(tokens[i]);
            }
            // Cần một mảng tạm (temp) cùng kích thước để phục vụ cho Merge Sort
            long[] temp = new long[n];
            // Gọi hàm đếm
            long total = MergeSortAndCount(a, temp, 0, n - 1);
            // In kết quả
            Console.WriteLine(total);
        }
    }
}
