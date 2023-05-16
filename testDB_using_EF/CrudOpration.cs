using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;
using ConsoleTables;

namespace testDB_using_EF
{
    internal class CrudOpration : ICrudOpration
    {
        public void Add()
        {

            var newEmployee = new Employee()
            {
                FirstName = "Pranaya",
                MiddleName = "J",
                LastName = "Rout",
                EmpCode = 12,
                Gender = 1,
                DOB = DateTime.Now,
                salary = 54166,
                JoiningDate = DateTime.Now,
                ResignDate = DateTime.Now,

            };
            using (EmployeeEntities context = new EmployeeEntities())
            {

                context.Employees.Add(newEmployee);
                context.SaveChanges();


            }
        }
        public void Delete(int Id)
        {
            using (EmployeeEntities context = new EmployeeEntities())
            {
                    var removeEmployee = context.Employees.Find(Id);

                if (removeEmployee != null)
                {
                    context.Employees.Remove(removeEmployee);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("\n Employee Does Not Exist");

                }
            }

        }
        public void Update(int Id)
        {
            using (EmployeeEntities context = new EmployeeEntities())
            {
                var Emp = context.Employees.Find(Id);

                if (Emp != null)
                {
                    Emp.FirstName = "Sanju";
                    Emp.LastName = "Samson";


                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("\n Employee Does Not Exist");
                }

            }
        }
        public void Read()
        {

            using (EmployeeEntities context = new EmployeeEntities())
            {


                var AllEmployees = context.Employees.ToList();
                var table = new ConsoleTable("Id", "First Name", "Middle Name", "Last Name", "Employee Code", "DOB", "Salary","Gender", "Joining Date", "Resign Date");


                foreach (var Emp in AllEmployees)
                {
                    table.AddRow(Emp.Employee_PK,Emp.FirstName,Emp.MiddleName,Emp.LastName,Emp.EmpCode,Emp.DOB,Emp.salary,Emp.Gender,Emp.JoiningDate,Emp.ResignDate);
                }
                table.Options.EnableCount = false;
                table.Write();
            }

        }
        public void Read(int Id)
        {
           
            using (EmployeeEntities context = new EmployeeEntities())
            {
                var Emp = context.Employees.Find(Id);

                if (Emp != null)
                {
                    var table = new ConsoleTable("Id", "First Name", "Middle Name", "Last Name", "Employee Code", "DOB", "Salary", "Gender", "Joining Date", "Resign Date");

                    table.AddRow(Emp.Employee_PK, Emp.FirstName, Emp.MiddleName, Emp.LastName, Emp.EmpCode, Emp.DOB, Emp.salary, Emp.Gender, Emp.JoiningDate, Emp.ResignDate);
                    table.Options.EnableCount = false;
                    table.Write();
                }
                else {
                    Console.WriteLine("\n Employee Does Not Exist");

                }





            }
        }

    }
}
