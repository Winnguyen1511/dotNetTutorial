using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmployeeManager.models
{

    public class EmployeeComparer: IComparer<Employee>
    {
        public enum EmployeeComparer_enum
        {
            BY_ID,
            BY_NAME,
            BY_HIRED_DATE,
            BY_GENDER,
            BY_SALARY
        }

        private EmployeeComparer_enum comparer;
        public EmployeeComparer(EmployeeComparer_enum choice)
        {
            this.comparer = choice;           
        }

        public int Compare(Employee x, Employee y)
        {
            if(this.comparer == EmployeeComparer_enum.BY_ID)
            {
                if(x.getID() == null)
                {
                    if(y.getID() == null)
                    {
                        return 0;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    if (y.getID() == null)
                        return 1;
                    else
                    {
                        int retval = x.getID().Length.CompareTo(y.getID().Length);
                        if(retval != 0)
                        {
                            return retval;
                        }
                        else
                        {
                            return x.getID().CompareTo(y.getID());
                        }
                    }
                }
            }
            else if(this.comparer == EmployeeComparer_enum.BY_NAME)
            {
                if (x.getName() == null)
                {
                    if (y.getName() == null)
                    {
                        return 0;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    if (y.getName() == null)
                        return 1;
                    else
                    {
                        int retval = x.getName().Length.CompareTo(y.getName().Length);
                        if (retval != 0)
                        {
                            return retval;
                        }
                        else
                        {
                            return x.getName().CompareTo(y.getName());
                        }
                    }
                }
            }
            else if(this.comparer == EmployeeComparer_enum.BY_HIRED_DATE)
            {
                return x.getHiredDate().CompareTo(y.getHiredDate());
            }
            else if(this.comparer == EmployeeComparer_enum.BY_GENDER)
            {
                if(x.getGender() == y.getGender())
                {
                    return 0;
                }
                else
                {
                    if (x.getGender() == Employee.GENDER_FEMALE)
                        return -1;
                    else return 1;
                }
            }
            else if(this.comparer == EmployeeComparer_enum.BY_SALARY)
            {
                if (x.getSalary() < y.getSalary())
                    return -1;
                else
                    return x.getSalary() == y.getSalary() ? 0 : -1;
            }
            else
            {
                //do nothing
                throw new NotImplementedException();
            }
        }
    }

    public class Employee//: IEquatable<Employee>, IComparable<Employee>
    {
        static int ID_LENGTH = 6;

        public static bool GENDER_MALE = true;
        public static bool GENDER_FEMALE = false;

        private string id;
        private string name;
        private DateTime hiredDate;
        private bool gender; // True = male
        private decimal salary;

        //static string DATETIME_REGEX = @"^(0?[1-9]|[12][0-9]|3[01])[/-](0?[1-9]|1[12])[/-](19[0-9]{2}|[2][0-9][0-9]{2})$";
        static string DATETIME_REGEX = @"^(0?[1-9]|1[12]|10)[/-](0?[1-9]|[12][0-9]|3[01])[/-](19[0-9]{2}|[2][0-9][0-9]{2})$";

        public Employee()
        {
            this.id = "EM0000";
            this.name = "Unknown";
            this.hiredDate = DateTime.Now;
            this.gender = Employee.GENDER_MALE;
            this.salary = 1000;
        }

        public static bool validID(string id)
        {
            if(id.Length != Employee.ID_LENGTH)
            {
                Console.WriteLine("> Error: Employee ID must has {0} characters", Employee.ID_LENGTH);
                return false;
            }
            return true;
        }

        public static bool validHiredDate(string hiredDate)
        {
            //bool res = true;
            Regex datetime_regex = new Regex(Employee.DATETIME_REGEX);
            bool res = datetime_regex.IsMatch(hiredDate);
            if (res == false)
            {
                Console.WriteLine("> Error: Date time must has mm/dd/yyyy or mm-dd-yyyy format.");
            }
            return res;
        }

        public Employee(Employee that)
        {
            this.id = that.id;
            this.name = new string(that.getName().ToCharArray());
            this.hiredDate = new DateTime(that.getHiredDate().ToBinary());
            this.gender = that.getGender();
            this.salary = that.getSalary();
        }
        public Employee(string id, string name, string hiredDate, bool gender, decimal salary)
        {
            if (Employee.validID(id) == true)
                this.id = id;
            else
            {
                Console.WriteLine("> Error: Invalid input");
                this.id = "EM0000";
            }

            this.name = name;

            if(Employee.validHiredDate(hiredDate) == true)
            {
                this.setHiredDate(hiredDate);
            }
            else
            {
                Console.WriteLine("> Error: Invalid input");
                this.hiredDate = DateTime.Now;
            }

            this.gender = gender;
            this.salary = salary;
        }

        public Employee(string id, string name, DateTime hiredDate, bool gender, decimal salary)
        {
            if (Employee.validID(id) == true)
                this.id = id;
            else
            {
                Console.WriteLine("> Error: Invalid input id");
                this.id = "EM0000";
            }
            this.name = name;
            this.hiredDate = hiredDate;
            this.gender = gender;
            this.salary = salary;
        }

        public void setId(string id)
        {
            if (Employee.validID(id) == true)
                this.id = id;
        }

        public string getID()
        {
            return this.id;
        }
        
        public void setName(string name)
        {
            this.name = name;
        }

        public string getName()
        {
            return this.name;
        }

        public void setHiredDate(string hiredDate)
        {
            if (Employee.validHiredDate(hiredDate) == true)
            {
                this.hiredDate = DateTime.Parse(hiredDate, System.Globalization.CultureInfo.CurrentCulture);
            }
        }
        public void setHiredDate(DateTime hiredDate)
        {
            this.hiredDate = hiredDate;
        }

        public DateTime getHiredDate()
        {
            return this.hiredDate;
        }

        public void setGender(bool gender)
        {
            this.gender = gender;
        }

        public bool getGender()
        {
            return this.gender;
        }

        public void setSalary(decimal salary)
        {
            this.salary = salary;
        }

        public decimal getSalary()
        {
            return this.salary;
        }

        //public bool Equals(Employee other)
        //{
        //    throw new NotImplementedException();
        //}

        //public int CompareTo(Employee other)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
