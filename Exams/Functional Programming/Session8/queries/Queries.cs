using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Laboratory.Functional.Lab08
{

    class Query
    {
        private Model model = new Model();

        static void Main(string[] args)
        {
            Query query = new Query();

            query.Query1();
            query.Query2();
            query.Query3();
            query.Query4();
            query.Query5();
            query.Query6();
            
            query.Homework1();
            query.Homework2();
            query.Homework3();
            query.Homework4();
            query.Homework5();

            Console.ReadLine();
        }

        // Check out:
        //  http://msdn.microsoft.com/en-us/library/9eekhta0.aspx
        //  https://msdn.microsoft.com/es-es/library/bb397933.aspx


        private void Query1()
        {
            // Show the phone calls that lasted more than 15 seconds
            Console.WriteLine();
            Console.WriteLine("*** *** *** QUERY 1 *** *** ***");
            Console.WriteLine();

            // Query syntax
            var q1 =
                from pc in model.PhoneCalls
                where pc.Seconds > 15
                select pc;

            foreach (var item in q1)
                Console.WriteLine(item);


            // Method syntax
            Console.WriteLine();

            var q1_m = model.PhoneCalls.Where(pc => pc.Seconds > 15);

            foreach (var item in q1_m)
                Console.WriteLine(item);
        }
		
		private void Query2()
        {
            // Show the name and surname of the employees older than 50 that work in Cantabria
            Console.WriteLine();
            Console.WriteLine("*** *** *** QUERY 2 *** *** ***");
            Console.WriteLine();

            var q2 = model.Employees.Where(p => p.Age > 50 && p.Province == "Cantabria").Select(p => p.Name + "  "+ p.Surname);

            foreach (var item in q2)
                Console.WriteLine(item);
        }
		
		private void Query3()
        {
            // Show the names of the departments with more than one employee
            Console.WriteLine();
            Console.WriteLine("*** *** *** QUERY 3 *** *** ***");
            Console.WriteLine();

            var q3 = model.Departments.Where(d => d.Employees.Count() >= 1).Select(d=> d.Name);

            foreach (var item in q3)
                Console.WriteLine(item);
        }
        
        private void Query4()
        {
            // Show the phone calls of each employee ordered by employee name. 
            // Each line should show the name of the employee and the phone call duration in seconds.
            Console.WriteLine();
            Console.WriteLine("*** *** *** QUERY 4 *** *** ***");
            Console.WriteLine();

            var q4 = model.Employees.OrderBy(e => e.Name).Join(
                model.PhoneCalls, e => e.TelephoneNumber, pc => pc.SourceNumber,
                (e, pc) => ("Name: "+ e.Name + "\tDuration (seconds):"+pc.Seconds));

            foreach (var item in q4)
                Console.WriteLine(item);

        }
		
		private void Query5()
        {
            // Show, grouped by province, the name of the employees 
			
			Console.WriteLine();
            Console.WriteLine("*** *** *** QUERY 5 *** *** ***");
            Console.WriteLine();
            var q5 = model.Employees.GroupBy(p => p.Province );

            foreach (var item in q5)
            {
                Console.WriteLine(item.Key);
                foreach (var g in item)
                {
                    Console.WriteLine(" "+g.Name);
                }
            }
        }

        private void Query6()
        {
            // Show the phone calls done by employees in each department (grouped by departement)
            Console.WriteLine();
            Console.WriteLine("*** *** *** QUERY 6 *** *** ***");
            Console.WriteLine();

            var q6 = model.Employees.Join(model.PhoneCalls, e => e.TelephoneNumber, pc => pc.SourceNumber,
                (e, pc) => new { EmpDep = e.Department, PCs = pc }).GroupBy(epc => epc.EmpDep, pc => pc);

            foreach (var item in q6)
            {
                Console.WriteLine(item.Key);
                foreach (var g in item)
                {
                    Console.WriteLine(" " + g.PCs);
                }
            }
        }

        /************ Homework **********************************/

        private void Homework1()
        {
            // Show, ordered by age, the names of the employees in the Computer Science department, 
            // who have an office in the Faculty of Science, 
            // and who have done phone calls longer than one minute
            Console.WriteLine("HOMEWORK 1");
            var q = model.Employees
                .Where(e => e.Department.Name == "Computer Science")
                .Where(e => e.Office.Building == "Faculty of Science")
                .Join(model.PhoneCalls.Where(pc => pc.Seconds > 60),
                    e => e.TelephoneNumber,
                    pc => pc.SourceNumber,
                    (e,pc) => new { Name = e.Name, Seconds = pc.Seconds })
                .OrderBy( e => e.Name)
                .Select( a => a.Name);
            foreach (var item in q) {
                Console.WriteLine(q);
            }

        }

        private void Homework2()
        {
            // Show the summation, in seconds, of the phone calls done
            // by the employees of the Computer Science department
            Console.WriteLine("HOMEWORK 2");

            var q = model.Employees
                .Where(e => e.Department.Name == "Computer Science")
                .Join(model.PhoneCalls,
                e => e.TelephoneNumber,
                pc => pc.SourceNumber,
                (e, pc) => new { Tel = e.TelephoneNumber, Seconds = pc.Seconds }).Sum(pc => pc.Seconds);
            Console.WriteLine(q);
            
        }

        private void Homework3()
        {
            Console.WriteLine("HOMEWORK 3");
            // Show the phone calls done by each department, ordered by department names. 
            // Each line must show “Department = <Name>, Duration = <Seconds>”
            var q = model.Employees.Join(model.PhoneCalls, e => e.TelephoneNumber, pc => pc.SourceNumber,
                (e, pc) => new
                {
                    DepName = e.Department.Name,
                    Duration = pc.Seconds
                }
            ).GroupBy(x => x.DepName);

            foreach (var item in q) {
                Console.WriteLine(item.Key);
                foreach (var it in item) {
                    Console.WriteLine("\t" + it);
                }
            }
        }

        private void Homework4()
        {
            Console.WriteLine("HOMEWORK 4");
            // Show the departments with the youngest employee, 
            // together with the name of the youngest employee and his/her age 
            // (more than one youngest employee may exist)

            var youngest = model.Employees.Min(e => e.Age);

            var q = model.Employees.Where(e => e.Age <= youngest).Select( (e) => new { Name = e.Name, Dep = e.Department });

            foreach (var item in q) {
                Console.WriteLine(item);
            }
        }

        private void Homework5()
        {
            Console.WriteLine("HOMEWORK 5");
            // Show the greatest summation of phone call durations, in seconds, 
            // of the employees in the same department, together with the name of the department 
            // (it can be assumed that there is only one department fulfilling that condition)

            var q = 9;
        }
    }

}
