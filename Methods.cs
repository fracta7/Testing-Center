using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.CodeDom.Compiler;

namespace Learning_Center
{

    //class for all methods used across the app
    class Methods
    {

        //reads and stores back all data to array
        //first parameter for setting array length
        //second parameter for setting file path to read from
        public string[] ReadArrayDB(int a, string b)
        {
            string[] c = new string[a];
            int temp = 0;
            while (temp < a)
            {
                c[temp] = File.ReadAllText(b);
                temp++;
            }
            return c;
        }

        //the same method but with integer array
        public int[] ReadArrayInt(int a, string b)
        {
            int[] c = new int[a];
            int temp = 0;
            while (temp < a)
            {
                c[temp] = Convert.ToInt32(File.ReadAllText(b));
                temp++;
            }
            return c;
        }

        //writing data from array to a file
        //first parameter gets the array to be written to a file
        //second parameter sets a file path to write the given array
        public void WriteArrayDB(string[] a, string b)
        {
            int temp = 0;
            int c = a.Length;
            while (temp < c)
            {
                FileStream fileStream = new FileStream(b + @"_" + temp, FileMode.Create, FileAccess.Write);
                StreamWriter streamWriter = new StreamWriter(fileStream);
                streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                streamWriter.Write(a[temp]);
                streamWriter.Flush();
                streamWriter.Close();
                temp++;
            }
        }

        //the same method but with integer array
        public void WriteArrayInt(int[] a, string b)
        {
            int temp = 0;
            int c = a.Length;
            while (temp < c)
            {
                FileStream fileStream = new FileStream(b + @"_" + temp, FileMode.Create, FileAccess.Write);
                StreamWriter streamWriter = new StreamWriter(fileStream);
                streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                streamWriter.Write(a[temp]);
                streamWriter.Flush();
                streamWriter.Close();
            }
        }

        //write email and username to db

        //sha256 hash calculator
        public static string EncryptPass(string plainText)
        {
            // Create a SHA256 hash from string   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Computing Hash - returns here byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(plainText));

                // now convert byte array to a string   
                StringBuilder stringbuilder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    stringbuilder.Append(bytes[i].ToString("x2"));
                }
                return stringbuilder.ToString();
            }
        }

        //read student accounts
        //parameter is for giving last student id to load all of them to array
        public string[] LoadStudents(int a)
        {
            string[] b = new string[a];
            int temp = 0;

            while (temp < a)
            {
                b[temp] = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"db\students\" + temp+@"\username");
                temp++;
            }
            return b;
        }

        //the same but with teacher
        public string[] LoadTeachers(int a)
        {
            string[] b = new string[a];
            int temp = 0;

            while (temp<a)
            {
                b[temp] = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"db\teachers\" + temp + @"\username");
                temp++;
            }

            return b;
        }

        //loading passwords of students
        public string[] LoadPasswordStudents(int a)
        {
            string[] b = new string[a];
            int temp = 0;

            while (temp<a)
            {
                b[temp] = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"db\students\" + temp + @"\password");
                temp++;
            }
            return b;
        }

        //loading password of teachers
        public string[] LoadPasswordTeachers(int a)
        {
            string[] b = new string[a];
            int temp = 0;

            while (temp<a)
            {
                b[temp] = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"db\teachers\" + temp + @"\password");
                temp++;
            }
            return b;
        }


        //loading email of students
        public string[] LoadEmailStudents(int a)
        {
            string[] b = new string[a];
            int temp = 0;

            while (temp < a)
            {
                b[temp] = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"db\students\" + temp + @"\email");
                temp++;
            }
            return b;
        }

        //loading email of teachers
        public string[] LoadEmailTeachers(int a)
        {
            string[] b = new string[a];
            int temp = 0;

            while (temp < a)
            {
                b[temp] = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"db\teachers\" + temp + @"\email");
                temp++;
            }

            return b;
        }

        //load subject of a teacher
        public string LoadSubject(int a)
        {
            string b;
            b = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"db\teachers\" + a + @"\subject");
            return b;
        }

        //file writer/creator
        //first parameter for path to a file
        //second parameter for content to be written
        public void FileWrite(string a, string b)
        {
            FileStream fileStream = new FileStream(a, FileMode.Create, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.BaseStream.Seek(0, SeekOrigin.End);
            streamWriter.Write(b);
            streamWriter.Flush();
            streamWriter.Close();
        }

    }
}
