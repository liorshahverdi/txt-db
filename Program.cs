using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseTable  t = new DatabaseTable("table");//ReadFromFile() is called in the constructor
            
            //.getData() test
            List<StudentData> myList = t.getData();
            Console.WriteLine(".getData() test");
            foreach (StudentData sd in myList)
            {
                Console.WriteLine(sd.ToString());
            }
            Console.WriteLine();

            //.AddStudent() test
            Console.WriteLine(".AddStudent() test");
            StudentData m1 = new StudentData(4, "Jacob", 39, 'M');
            Console.WriteLine("Size Before = " + myList.Count());
            t.AddStudent(m1);
            Console.WriteLine("Size After = "+ myList.Count());
            Console.WriteLine();

            //.SearchStudent with id 3
            Console.WriteLine(".SearchStudent(3) test");
            StudentData res = t.SearchStudent("3");
            Console.WriteLine("Result is " + res.ToString());
            Console.WriteLine();

            //.DeleteStudent() test
            Console.WriteLine(".DeleteStudent() test");
            Console.WriteLine("Size Before = " + myList.Count());
            t.DeleteStudent("4");
            Console.WriteLine("Size After = " + myList.Count());
            Console.WriteLine();

            //.Print() test
            Console.WriteLine(".Print() test");
            t.Print(myList);
            Console.WriteLine();

            //.WriteToFile() test
            Console.WriteLine(".WriteToFile test");
            StudentData m2 = new StudentData(5, "Kelly", 22, 'F');
            t.AddStudent(m2);
            StudentData m3 = new StudentData(6, "Jeremy", 25, 'M');
            t.AddStudent(m3);
            t.WriteToFile();
            Console.WriteLine();

            //.Select() tests
            List<StudentData> satisfied_Condition_list = t.Select(new Over22());
            Console.WriteLine("Size of satisfied condition list = " + satisfied_Condition_list.Count());
            Console.WriteLine("Expected Size = 2");
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
