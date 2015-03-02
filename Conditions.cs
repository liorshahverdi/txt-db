using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualAssignment
{
    public interface Condition
    {
       bool Apply(StudentData d);
    }

    public class Over22 : Condition
    {
        public bool Apply(StudentData d)
        {
            String ageString = Convert.ToString(d.Age);
            int age = Convert.ToInt32(ageString);
            if (age >= 23) return true;
            return false;
        }
    }

    public class FemaleStudent : Condition
    {
        public bool Apply(StudentData d)
        {
            char dchar = d.Gender;
            if (dchar == 'F') return true;
            else return false;
        }
    }

    public class MaleStudentUnder21 : Condition
    {
        public bool Apply(StudentData d)
        {
            char gender = d.Gender;
            int age = d.Age;
            return (gender == 'M') && (age < 21);
        }
    }
}