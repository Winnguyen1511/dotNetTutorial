using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.models
{
    class EmployeeList
    {
        private List<Employee> listEmployees;
        public EmployeeList()
        {
            this.listEmployees = new List<Employee>();
        }

        public List<Employee> getList()
        {
            return this.listEmployees;
        }
        public bool addEmployee(Employee em)
        {
            this.listEmployees.Add(em);
            return true;
        }
        
        public Employee getEmployee(string id)
        {
            Employee tmpEm = null;
            foreach(Employee em in this.listEmployees)
            {
                if(em.getID().Equals(id))
                {
                    Console.WriteLine("Found!");
                    tmpEm = new Employee(em);
                }
            }
            return tmpEm;
        }

        public bool editEmployee(string id, Employee editedEmp)
        {
            int index = this.listEmployees.FindLastIndex(em => em.getID().Equals(id));
            if(index < 0)
            {
                return false;
            }
            this.listEmployees[index] = editedEmp;
            return true;
        }

        public bool deleteEmployee(string id)
        {
            int index = this.listEmployees.FindLastIndex(em => em.getID().Equals(id));
            if (index < 0)
            {
                return false;
            }
            this.listEmployees.RemoveAt(index);
            return true;
        }
    }
}
