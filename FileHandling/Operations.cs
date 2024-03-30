using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text.Json;


namespace FileHandling
{
    public class Operations
    {
        //Create
        public void Create()
        {
            string fPath = @"D:\test.txt";
            File.Create(fPath).Close();
            if (File.Exists(fPath))
            {
                Console.WriteLine("File is already  created successfully");
            }
            else
            {
                Console.WriteLine("new file is created");
            }
            Console.ReadKey();
        }
        //Write
        public void Write()
        {
            string fpath = @"D:\test.txt";

            if (File.Exists(fpath))
            {
                //Single_line
                string line = "Hello World";
                File.WriteAllText(fpath, line);

                //Multiple_lines
                string[] lines =
                {
                    "Hii Kavitha",
                    "How are you",
                    DateTime.Now.ToString()
                };
                File.WriteAllLines(fpath, lines);
            }
            else
            {
                Console.WriteLine("File not Exists");
            }
            Console.ReadKey();
        }
        //Read
        public void Read()
        {
            string fpath = @"D:\test.txt";
            if (File.Exists(fpath))
            {
                string line = File.ReadAllText(fpath);
                Console.WriteLine(line);

                string[] lines = File.ReadAllLines(fpath);
                Console.WriteLine(lines[0]);

                //foreach (string l in lines)
                //{
                //    Console.WriteLine(l);
                //}
            }
        }
        //Copy
        public void Copy()
        {
            string fpath = @"D:\test.txt";
            string cpath = @"D:\text1.txt";
            File.Copy(fpath, cpath);

            if (File.Exists(cpath))
            {
                Console.WriteLine("successfully copied");
            }
            else
            {
                Console.WriteLine("file not copied");
            }
            Console.ReadKey();
        }
        //Move
        public void Move()
        {
            string fpath = @"D:\text1.txt";
            string mpath = @"D:\text2.txt";
            File.Move(fpath, mpath);

            if (File.Exists(mpath))
            {
                Console.WriteLine("successfully moved");
            }
            else
            {
                Console.WriteLine("file not moved");
            }
            Console.ReadKey();
        }
        //Delete
        public void Delete()
        {
            string path = @"D:\text2.txt";
            File.Delete(path);
            if (File.Exists(path))
            {
                Console.WriteLine("File not deleted");
            }
            else
            {
                Console.WriteLine("successfully deleted");
            }
        }
        //FileInfo
        public void FileInfo()
        {
            string fpath = @"D:/.Net/text.txt";
            FileInfo file = new FileInfo(fpath);
            Console.WriteLine(file.FullName);
            Console.WriteLine(file.Name);
            Console.WriteLine(file.Extension);
            Console.WriteLine(file.Length + " bytes");
        }
        //Directory
        public void DCreate()
        {
            string dpath = @"D:/.Net/C#/Demo";
            Directory.CreateDirectory(dpath);
            if (Directory.Exists(dpath))
            {
                Console.WriteLine("suceessfully created");
                string fpath = @"D:/.Net/";
                string[] files = Directory.GetFiles(fpath);
                foreach (var file in files)
                {
                    Console.WriteLine(file);
                }
            }
            else
            {
                Console.WriteLine("Directory not exists");
            }
            Console.ReadKey();
        }
        //Stream Writer
        public void SWriter()
        {
            string fpath = @"D:/.Net/text.txt";
            StreamWriter writer = new StreamWriter(fpath);
            writer.WriteLine("This is Stream Writer");
            writer.Write("and properties and methods");
            writer.Flush();
            writer.Close();
        }
        //Stream Reader
        public void SReader()
        {
            string fpath = @"D:/.Net/text.txt";
            StreamReader reader = new StreamReader(fpath);

            // Read from the stream and display the content
            string content = reader.ReadToEnd();
            Console.WriteLine(content);

            // Read characters one by one and display them
            int character;
            while ((character = reader.Read()) != -1)
            {
                Console.WriteLine((char)character);
            }

            // Read characters into a buffer and display them
            char[] buffer = new char[10]; // Read 10 characters at a time
            int bytes;
            while ((bytes = reader.Read(buffer, 0, buffer.Length)) != 0)
            {
                Console.WriteLine(buffer, 0, bytes);
            }

            reader.Close();
        }
        //file Handling
        public void FileHandling()
        {
            try
            {
                string fpath = @"D:/.Net/text.txt";
                StreamReader reader = new StreamReader(fpath);
                string content = reader.ReadToEnd();
                Console.WriteLine(content);
            }
            catch (IOException e)
            {

                Console.WriteLine(e.Message);
            }
        }
        //Binary Writer
        public void BWriter()
        {
            string fPath = @"D:/.Net/text.txt";
            FileStream fs = new FileStream(fPath, FileMode.Create);
            BinaryWriter writer = new BinaryWriter(fs);
            writer.Write("Hello World");
            writer.Write(true);
            writer.Write((byte)255);
            writer.Write(2.34);
            writer.Write(25);
            writer.Close();
        }
        //Binary Reader
        public void BReader()
        {
            string fpath = @"D:/.Net/text.txt";
            FileStream fs = new FileStream(fpath, FileMode.Open);
            BinaryReader reader = new BinaryReader(fs);

            string s = reader.ReadString();
            int i = reader.ReadInt32();
            double d = reader.ReadDouble();
            bool b = reader.ReadBoolean();
            byte bt = reader.ReadByte();

            Console.WriteLine($"string: {s}");
            Console.WriteLine($"int: {i}");
            Console.WriteLine($"double: {d}");
            Console.WriteLine($"bool: {b}");
            Console.WriteLine($"byte: {bt}");

            reader.Close();
        }
        //CSV
        public void CWriter()
        {
            // Data to write to the CSV file
            string[] rowData1 = { "Name", "Age", "City" };
            string[] rowData2 = { "John Doe", "30", "New York" };
            string[] rowData3 = { "Jane Smith", "25", "Los Angeles" };

            // Path to the CSV file
            string filePath = "data.csv";

            // Write data to the CSV file
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Write header row
                writer.WriteLine(string.Join(",", rowData1));

                // Write data rows
                writer.WriteLine(string.Join(",", rowData2));
                writer.WriteLine(string.Join(",", rowData3));
            }

            Console.WriteLine("Data has been written to the CSV file.");
        }
        public void CReader()
        {
            // Path to the CSV file
            string filePath = "data.csv";

            // Read data from the CSV file
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Split the line into fields
                    string[] fields = line.Split(',');

                    // Process the fields
                    foreach (string field in fields)
                    {
                        Console.Write(field + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }
        //JSON
        public void Json()
        {
            // Define a sample object
            var person = new
            {
                Name = "John Doe",
                Age = 30,
                City = "New York"
            };

            // Serialize the object to JSON
            string json = JsonSerializer.Serialize(person);

            Console.WriteLine(json);//{"Name":"John Doe","Age":30,"City":"New York"}
        }
        //public void Object()
        //{
        //    // JSON string to deserialize
        //    string jsonString = @"{""Name"": ""John Doe"",""Age"": 30,""City"": ""New York""}";

        //    // Deserialize JSON string to object
        //    var person = JsonSerializer.Deserialize<Person>(jsonString);

        //    // Access object properties
        //    Console.WriteLine($"Name: {person.Name}");
        //    Console.WriteLine($"Age: {person.Age}");
        //    Console.WriteLine($"City: {person.City}");
        //}

        // Define a class for JSON object structure
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string City { get; set; }

            public void Object()
            {
                // JSON string to deserialize
                string jsonString = @"{""Name"": ""John Doe"",""Age"": 30,""City"": ""New York""}";

                // Deserialize JSON string to object
                var person = JsonSerializer.Deserialize<Person>(jsonString);

                // Access object properties
                Console.WriteLine($"Name: {person.Name}");
                Console.WriteLine($"Age: {person.Age}");
                Console.WriteLine($"City: {person.City}");
            }
        }
        public void Demo()
        {
            try
            {
                string dpath = @"D:/dem.txt";
                File.Create(dpath).Close();
                if (File.Exists(dpath))
                {
                    string[] lines =
                    {
                    "Hello",
                    "Hai",
                    "Bye"
                };
                    File.WriteAllLines(dpath, lines);
                    lines = File.ReadAllLines(dpath);
                    foreach (string line in lines)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Demo1()
        {
            try
            {
                string dpath1 = @"D:/demo1.txt";
                //File.Create(dpath1).Close();
                if (File.Exists(dpath1))
                {
                    //Console.WriteLine("s");
                    StreamWriter writer = new StreamWriter(dpath1);
                    writer.WriteLine("Bye");
                    writer.WriteLine("Hai");
                    writer.WriteLine("Hello");
                    writer.Flush();
                    writer.Close();
                    StreamReader reader = new StreamReader(dpath1);
                    string content = reader.ReadToEnd();
                    reader.Close();
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

