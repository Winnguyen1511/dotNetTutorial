using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManager.models;
using EmployeeManager.views;
namespace EmployeeManager
{
    class Program
    {
        static void Main(string[] args)
        {
            // system init:
            EmployeeList employeeList = new EmployeeList();

            Employee khoa = new Employee("EM0001", "khoa", "06/15/2020", Employee.GENDER_MALE, 1000);
            Employee hien = new Employee("EM0003", "hien nguyen", "07/10/2020", Employee.GENDER_FEMALE, 1000);
            Employee hoa = new Employee("EM0002", "vo van hoa", "06/15/2015", Employee.GENDER_MALE, 10000);
            Employee lam = new Employee("EM0004", "lam nguyen", "10/20/2017", Employee.GENDER_MALE, 10000);
            Employee kiet = new Employee("EM0008", "kiet nguyen", "11/10/2015", Employee.GENDER_MALE, 5000);
            employeeList.addEmployee(khoa);
            employeeList.addEmployee(hien);
            employeeList.addEmployee(hoa);
            employeeList.addEmployee(lam);
            employeeList.addEmployee(kiet);
            EmployeeManagerGUI employeeManagerGUI = new EmployeeManagerGUI(employeeList);
            while(true)
            {
                employeeManagerGUI.menu();

                int n;
                Console.Write(">> Choice: ");
                bool res = Int32.TryParse(Console.ReadLine(), out n);
                switch (n)
                {
                    case 1: employeeManagerGUI.addEmployee(); break;
                    case 2: employeeManagerGUI.printEmployeeList(); break;
                    case 3: employeeManagerGUI.editEmployee(); break;
                    case 4: employeeManagerGUI.deleteEmployee(); break;
                    case 5: employeeManagerGUI.sortEmployee(); break;
                    case 6: employeeManagerGUI.searchEmployee();break;
                    case 7:
                        Console.WriteLine(">> Exit...");
                        break;
                }
                if (n == 7)
                    break;
            }
        }
    }
}
