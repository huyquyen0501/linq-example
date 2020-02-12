using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tesst
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> listStudent = new List<Student>();
            listStudent.Add(new Student(11, "st1", 1));
            listStudent.Add(new Student(12, "st2", 1));
            listStudent.Add(new Student(13, "st3", 2));
            List<Class> listClass = new List<Class>();
            listClass.Add(new Class(1, "c1"));
            listClass.Add(new Class(2, "c2"));
            listClass.Add(new Class(3, "c3"));
            Console.WriteLine("1, 1");
            b1(listStudent, listClass);
            Console.WriteLine("1, 2");
            b12(listStudent, listClass);
            Console.WriteLine("4, 1");
            b41(listStudent, listClass);
            Console.WriteLine("4, 2");
            b42(listStudent, listClass);
            Console.WriteLine("3,1");
            b31(listStudent, listClass);
            Console.WriteLine("3,2");
            b32(listStudent, listClass);
            Console.WriteLine("4");
            b4(listStudent, listClass);
            Console.WriteLine("b2");
            b2(listStudent, listClass);




        }
        static void b1(List<Student> liststudent, List<Class> listClass)
        {
            var query = from s in liststudent
                        from c in listClass
                        select new
                        {
                            s.IDStudent,
                            c.ID

                        };
           
            foreach (var b in query)
            {
                Console.WriteLine(b.IDStudent + "," + b.ID);
            }
            Console.ReadLine();



        }
        static void b12(List<Student> listStudent, List<Class> listClass)
        {
            var query = from s in listStudent
                        select new
                        {
                            s.IDStudent
                        };
            var query2 = from c in listClass
                         select new
                         {
                             c.ID
                         };
            foreach (var i in query)
            {
                foreach (var j in query2)
                {
                    Console.WriteLine(i.IDStudent + "," + j.ID);
                }
            }

            Console.ReadLine();

        }
        static void b41(List<Student> student, List<Class> classes)
        {

            var query = from students in student
                        join classname in classes
                        on students.ClassID equals classname.ID
                        group classname by classname.Name into classgrouped
                        select new
                        {
                            classname = classgrouped.Key,
                            count = classgrouped.Count(),

                        };
            foreach (var c in query)
            {
                Console.WriteLine(c.classname + "," + c.count);
            }
            Console.ReadLine();

        }
        static void b42(List<Student> student, List<Class> classes)
        {

            var query = from classname in classes
                        join students in student
                        on classname.ID equals students.ClassID
                        group classname by classname.Name into classgrouped
                        
                        select new
                        {
                            classname = classgrouped.Key,
                            count = classgrouped.Count(),

                        };
            foreach (var i in query)
            {
                Console.WriteLine(i.classname + "," + i.count);
            }
            Console.ReadLine();

        }

        static void b31(List<Student> student, List<Class> classes)
        {
            var query = from students in student
                        group students by students.ClassID into classgrouped
                        select new
                        {
                           classid= classgrouped.Key,
                           count= classgrouped.Count()
                        };
            foreach(var i in query)
            {
                Console.WriteLine(i.classid + "," + i.count);
            }
            Console.ReadLine();
        }
        static void b32 (List<Student> student, List<Class> classes)
        {
            var query = from students in student
                        join class1 in classes
                        on students.ClassID equals class1.ID
                        group class1 by class1.ID into classgrouped
                        select new
                        {
                            classID = classgrouped.Key,
                            count = classgrouped.Count()
                        };
            foreach(var i in query)
            {
                Console.WriteLine(i.classID + "," + i.count);
            }
            Console.ReadLine();
        }
        static void b4(List<Student> student, List<Class> classes)
        {   //join 2 bang voi nhau
            var subquery = from class1 in classes
                           join students in student
                           on class1.ID equals students.ClassID
                           into subquery1
                           from subquery2 in subquery1.DefaultIfEmpty()


                           select new
                           {
                               Studentname=subquery2==null?"null":subquery2.StudentName,
                               
                               classname = class1.Name

                           };
            // sefl join tim min
            var query = from s in subquery
                        group s by s.classname into grouped
                      //  from grouped1 in grouped.FirstOrDefault()
                        select new
                        {
                            classname=grouped.Key,
                            
                        
                           
     /* code dung la dong nay */  nameFirstStudent= grouped.First().Studentname
                                // dung min la loi grouped.Min().Studentname
                        };
            foreach(var i in query)
            {
                Console.WriteLine(i.classname + "," + i.nameFirstStudent);
            }
            Console.ReadLine();
        }
        static void b2(List<Student> student, List<Class> classes)
        {
            var subquery = from classes1 in classes
                           join students in student
                           on classes1.ID equals students.ClassID into temped
                           //from temped1 in temped.DefaultIfEmpty()
                           // join into = group join
                           select new
                           {
                                classname=classes1.Name,
                               count = temped.Count()
                           };

              
            foreach(var i in subquery)
            {
                Console.WriteLine(i.classname + "," + i.count);
            }
            Console.ReadLine();
        }
        
    
}}
        
