using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualAssignment
{
    public class StudentData
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _age;
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        private char _gender;
        public char Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public StudentData(int i, string n, int ag, char g)
        {
            this.ID = i;
            this.Name = n;
            this.Age = ag;
            this.Gender = g;
        }

        public override string ToString() { return this.ID +" "+ this.Name +" "+ this.Age+" "+this.Gender;}
    }
}
