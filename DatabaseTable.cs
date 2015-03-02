using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualAssignment
{
    class DatabaseTable
    {   //instance variables
        private string tableName;
        List<StudentData> data;

        //constructor
        public DatabaseTable(string tName)
        {
            tableName = tName;
            data = new List<StudentData>();
            this.ReadFromFile();
        }

        //getter for data (List<StudentData>)
        public List<StudentData> getData() { return data; }

        /**
         * adds the provided student to data(List<StudentData>)
         * */
        public void AddStudent(StudentData d) { data.Add(d); }

        /*
         * returns the instance of StudentData that matches the provided id
         * */
        public StudentData SearchStudent(string id)
        {
            foreach (StudentData x in data)
            {
                int id_to_match = Convert.ToInt32(id);
                int next_id = x.ID;
                if (id_to_match != next_id) continue;
                else return x;
            }
            return null;
        }

        /**
         * deletes a student with the given id from our data (List<StudentData>)
         */
        public void DeleteStudent(string id)
        {
            int id_to_match = Convert.ToInt32(id);
            foreach (StudentData x in data)
            {
                int next_id = x.ID;
                if (id_to_match != next_id) continue;
                else
                {
                    data.Remove(x);
                    break;
                }
            }
        }

        /**
         * reads info from the file (tableName+".txt"), creates structs
         * and adds them to data ( our List<StudentData> )
         * */
        public void ReadFromFile()
        {
            string folderName = "C:\\Users\\Lior\\Documents\\Visual Studio 2013\\Projects\\IndividualAssignment\\IndividualAssignment";
            string fileName = System.IO.Path.Combine(folderName, "myInputFile.txt");

            //var for one line of data
            string line;

            System.IO.StreamReader file = new System.IO.StreamReader(fileName);

            while ((line = file.ReadLine()) != null)
            {
                //Console.WriteLine(line);
                //further processing 
                char[] delimeterChars = { ':', '\t', ' ', ';' };
                string[] words = line.Split(delimeterChars);

                int my_id = Convert.ToInt32(words[0]);
                string my_name = words[1];
                int my_age = Convert.ToInt32(words[2]);
                char my_gender = Convert.ToChar(words[3]);
                StudentData nextRow = new StudentData(my_id, my_name, my_age, my_gender);
                data.Add(nextRow);
            }
            //Console.WriteLine("size of list is "+data.Count);
            file.Close();
        }

        /*
         * prints out the content of the List<StudentData> to stdout.
         * */
        public void Print(List<StudentData> v)
        {
            //int id_num;
            foreach (StudentData x in v)
            {
                Console.WriteLine("-----------------");
                Console.WriteLine("ID: " + x.ID);
                Console.WriteLine("Name: " + x.Name);
                Console.WriteLine("Age: " + x.Age);
                Console.WriteLine("Gender: " + x.Gender);
                Console.WriteLine("-----------------");
            }
        }

        /*
         * writes back the current contents of the List<StudentData> data back to the same file. 
         */
        public void WriteToFile() 
        {
            string output = "";
            string folderName = "C:\\Users\\Lior\\Documents\\Visual Studio 2013\\Projects\\IndividualAssignment\\IndividualAssignment";
            string fileName = System.IO.Path.Combine(folderName, tableName + ".txt");

            foreach(StudentData line in data)
            {
                output += line.ToString() + "\r\n";
            }

            System.IO.StreamWriter file = new System.IO.StreamWriter(fileName);

            file.WriteLine(output);

            file.Close();
        }
        
        /*
         * returns a List<StudentData> that satisfies the provided condition. 
         */
        public List<StudentData> Select(Condition c)
        {
            List<StudentData> temp = new List<StudentData>();

            foreach (StudentData line in data)
            {
                if (c.Apply(line)) temp.Add(line);
                else continue;
            }

            return temp;
        }
    }
}
