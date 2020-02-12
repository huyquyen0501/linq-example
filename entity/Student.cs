using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tesst
{
    public class Student //: IComparable<Student>
    {
        public int IDStudent { set; get; }
        public string StudentName { set; get; }
        public int ClassID { set; get; }

        public Student(int iDStudent, string name, int classID)
        {
            IDStudent = iDStudent;
            StudentName = name;
            ClassID = classID;
        }


       /* public int CompareTo(Student other)
        {
            return this.StudentName.CompareTo(other.StudentName);
        }*/
    }
}
