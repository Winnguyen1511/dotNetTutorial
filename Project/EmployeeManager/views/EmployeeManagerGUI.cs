using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManager.models;

namespace EmployeeManager.views
{
    class EmployeeManagerGUI
    {
        private EmployeeList employeeList;

        public EmployeeManagerGUI(EmployeeList employeeList)
        {
            this.employeeList = employeeList;
        }

        private void consoleSeparateLine()
        {
            Console.WriteLine("----------------------------------------------------");
        }
        public void menu()
        {
            Console.WriteLine(" ************************************");
            Console.WriteLine(" *  CHUONG TRINH QUAN LY NHAN VIEN  *");
            Console.WriteLine(" ************************************");
            Console.WriteLine(" * 1. Them nhan vien.               *");
            Console.WriteLine(" * 2. Hien tat ca nhan vien.        *");
            Console.WriteLine(" * 3. Chinh sua thong tin nhan vien.*");
            Console.WriteLine(" * 4. Xoa nhan vien.                *");
            Console.WriteLine(" * 5. Sap xep nhan vien.            *");
            Console.WriteLine(" * 6. Tim kiem nhan vien.           *");
            Console.WriteLine(" * 7. Thoat chuong trinh.           *");
            Console.WriteLine(" ************************************");
        }

        public void addEmployee()
        {
            this.consoleSeparateLine();
            Console.WriteLine("> Insert Employee:");
            
            string id, name, hiredDate;
            bool gender;
            decimal salary;
            for(; ; )
            {
                Console.Write("> Employee ID: ");
                id = Console.ReadLine();
                if (Employee.validID(id) == false)
                {
                    Console.WriteLine(">> Invalid ID. Please try again!");
                    continue;
                }
                break;
            }

            Console.Write("> Employee Name: ");
            name = Console.ReadLine();
            for (; ; )
            {
                Console.Write("> Hired Date: ");
                hiredDate = Console.ReadLine();
                if (Employee.validHiredDate(hiredDate) == false)
                {
                    Console.WriteLine(">> Invalid Hired Date. Please try again!");
                    continue;
                }
                break;
            }

            for(; ; )
            {
                Console.Write("> Employee Gender: ");
                string tmp = Console.ReadLine();
                tmp = tmp.ToLower();
                if (!tmp.Equals("f") && !tmp.Equals("female") &&
                    !tmp.Equals("m") && !tmp.Equals("male"))
                {
                    Console.WriteLine(">> Invalid Gender. Please try again!");
                }

                if(tmp.Equals("f") || tmp.Equals("female"))
                {
                    gender = Employee.GENDER_FEMALE;
                }
                else
                {
                    gender = Employee.GENDER_MALE;
                }
                break;
            }
            Console.Write("> Employee Salary: ");
            for(; ; )
            {
                bool res = Decimal.TryParse(Console.ReadLine(), out salary);
                if(res == false)
                {
                    Console.WriteLine(">> Invalid Salary. Please try again!");
                    continue;
                }
                break;
            }

            Employee newEmployee = new Employee(id, name, hiredDate, gender, salary);
            this.employeeList.addEmployee(newEmployee);
        }

        public void printEmployee(Employee em)
        {
            Console.WriteLine("> Name: {0}", em.getName());
            Console.WriteLine("> Hired Date: {0}", em.getHiredDate());
            Console.WriteLine("> Gender: {0}", em.getGender() == Employee.GENDER_FEMALE ? "female" : "male");
            Console.WriteLine("> Salary: {0}", em.getSalary());
        }

        public void printEmployeeList()
        {
            this.consoleSeparateLine();
            Console.WriteLine("> Print Employee List:");
            Console.WriteLine("*+\t{0,-8}+\t{1,-8}+\t\t{2,-16}+\t{3,-8}+\t\t{4,-16}+*", "ID", "Name", "Hired Date", "Gender", "Salary");
            Console.WriteLine(new string('*', 2 + 14 * 8));
            foreach (Employee em in this.employeeList.getList())
            {
                Console.WriteLine("|+{0,-16}+{1,-16}+{2,-32}+{3,-16}+{4,-32}+|",
                                    em.getID(), em.getName(), em.getHiredDate(), em.getGender(), em.getSalary());
            }
            Console.WriteLine(new string('*', 2 + 14*8));
        }

        public void editEmployee()
        {
            this.consoleSeparateLine();
            Console.WriteLine("> Edit Employee:");
            
            string empID;// = Console.ReadLine();
            for (; ; )
            {
                Console.Write(">> Please enter Employee ID:");
                empID = Console.ReadLine();
                if(empID.Equals("0"))
                {
                    Console.WriteLine(">> Aborted!");
                    return;
                }
                if (Employee.validID(empID) == false)
                {
                    Console.WriteLine(">> Invalid ID. Please try again!");
                    continue;
                }
                break;
            }
            Employee editedEmp = this.employeeList.getEmployee(empID);
            Console.WriteLine(">> Old Employee:");
            this.printEmployee(editedEmp);

            Console.WriteLine(">> Please enter new Info:");
            string name, hiredDate;
            bool gender;
            decimal salary;
            

            Console.Write("> Employee Name: ");
            name = Console.ReadLine();
            if(!name.Equals(""))
                editedEmp.setName(name);


            for (; ; )
            {
                Console.Write("> Hired Date: ");
                hiredDate = Console.ReadLine();
                if (hiredDate.Equals(""))
                    break;
                if (Employee.validHiredDate(hiredDate) == false)
                {
                    Console.WriteLine(">> Invalid Hired Date. Please try again!");
                    continue;
                }
                editedEmp.setHiredDate(hiredDate);
                break;
            }

            for (; ; )
            {
                Console.Write("> Employee Gender: ");
                string tmp = Console.ReadLine();
                if (tmp.Equals(""))
                    break;
                tmp = tmp.ToLower();
                if (!tmp.Equals("f") && !tmp.Equals("female") &&
                    !tmp.Equals("m") && !tmp.Equals("male"))
                {
                    Console.WriteLine(">> Invalid Gender. Please try again!");
                }

                if (tmp.Equals("f") || tmp.Equals("female"))
                {
                    gender = Employee.GENDER_FEMALE;
                }
                else
                {
                    gender = Employee.GENDER_MALE;
                }

                editedEmp.setGender(gender);
                break;
            }
            Console.Write("> Employee Salary: ");
            for (; ; )
            {
                string tmp = Console.ReadLine();
                if(tmp.Equals(""))
                {
                    break;
                }
                bool res = Decimal.TryParse(tmp, out salary);
                if (res == false)
                {
                    Console.WriteLine(">> Invalid Salary. Please try again!");
                    continue;
                }

                editedEmp.setSalary(salary);
                break;
            }

            this.employeeList.editEmployee(empID, editedEmp);

        }

        public void deleteEmployee()
        {
            this.consoleSeparateLine();
            Console.WriteLine("> Delete Employee:");

            string empID;// = Console.ReadLine();
            for (; ; )
            {
                Console.Write(">> Please enter Employee ID:");
                empID = Console.ReadLine();
                if (empID.Equals("0"))
                {
                    Console.WriteLine(">> Aborted!");
                    return;
                }
                if (Employee.validID(empID) == false)
                {
                    Console.WriteLine(">> Invalid ID. Please try again!");
                    continue;
                }
                break;
            }

            Employee tmpEmp = this.employeeList.getEmployee(empID);

            Console.WriteLine(">> Incoming delete:");
            this.printEmployee(tmpEmp);
            for(; ; )
            {
                Console.Write("> Press [ENTER] to delete, 0 to cancel!");
                string tmp = Console.ReadLine();
                if (tmp.Equals("0"))
                {
                    Console.WriteLine(">> Aborted!");
                    return;
                }
                else if (tmp.Equals(""))
                {
                    break;
                }
                else continue;
            }
            this.employeeList.deleteEmployee(empID);
        }

        public void sortEmployee()
        {
            this.consoleSeparateLine();
            Console.WriteLine("> Sort Employee:");
            Console.WriteLine(">> 1. Sort by ID.");
            Console.WriteLine(">> 2. Sort by Name.");
            Console.WriteLine(">> 3. Sort by Hired Date.");
            Console.WriteLine(">> 4. Sort by Gender.");
            Console.WriteLine(">> 5. Sort by Salary.");
            Console.Write(">> Choice: ");
            int choice;
            for(; ; )
            {
                bool res = Int32.TryParse(Console.ReadLine(), out choice);
                if(res == false)
                {
                    continue;
                }
                if (choice > 5 || choice < 1)
                    continue;
                if (choice == 0)
                {
                    Console.WriteLine("> Aborted!");
                    return;
                }
                break;
            }

            EmployeeComparer ec;
            EmployeeComparer.EmployeeComparer_enum sorted_by;
            switch(choice)
            {
                case 1: sorted_by = EmployeeComparer.EmployeeComparer_enum.BY_ID; break;
                case 2: sorted_by = EmployeeComparer.EmployeeComparer_enum.BY_NAME; break;
                case 3: sorted_by = EmployeeComparer.EmployeeComparer_enum.BY_HIRED_DATE; break;
                case 4: sorted_by = EmployeeComparer.EmployeeComparer_enum.BY_GENDER; break;
                case 5: sorted_by = EmployeeComparer.EmployeeComparer_enum.BY_SALARY; break;
                default: sorted_by = EmployeeComparer.EmployeeComparer_enum.BY_NAME; break;
            }

            ec = new EmployeeComparer(sorted_by);
            List<Employee> tmpLst = this.employeeList.getList();
            tmpLst.Sort(ec);
            this.printEmployeeList();

        }

        public void searchEmployee()
        {

        }
    }
}
