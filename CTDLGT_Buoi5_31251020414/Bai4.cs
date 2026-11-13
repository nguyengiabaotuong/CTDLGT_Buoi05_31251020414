using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace CTDLGT_Buoi5_31251020414
{
    class Student
    {
        public string Name;
        public int Score;
    }
    internal class Bai4
    {
        static void Main4()
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            string line1 = sr.ReadLine();
            if (string.IsNullOrEmpty(line1)) return;
            int n = int.Parse(line1.Trim());
            Student[] students = new Student[n];
            char[] separators = { ' ', '\t' };
            // Đọc dữ liệu
            for (int i = 0; i < n; i++)
            {
                string line = sr.ReadLine();
                string[] parts = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                students[i] = new Student
                {
                    Name = parts[0],
                    Score = int.Parse(parts[1])
                };
            }
            // DÙNG LINQ ĐỂ SẮP XẾP 
            var sortedStudents = students.OrderByDescending(s => s.Score).ToArray();
            // In kết quả
            StringBuilder output = new StringBuilder();
            foreach (var student in sortedStudents)
            {
                output.Append(student.Name).Append(" ").Append(student.Score).AppendLine();
            }
            Console.Write(output.ToString());
        }
    }
}
