using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
namespace Task
{
    public class Staff //base class
    {
        private decimal mBaseSalary;
        private DateTime dJoinedDate;
        private string mErrorMessage; 
        public Staff(string name, decimal mBaseSalary, DateTime JoinedDate)
        {
            this.Name = name; // staff name
            this.mBaseSalary = mBaseSalary;
            this.dJoinedDate = JoinedDate;
            mErrorMessage = "";
            if (JoinDate > DateTime.Today)
            {
                mErrorMessage = "Date when " + name + " joined the company must be in the past.";
            }
            if (mBaseSalary < 0)
            {
                mErrorMessage = "Base Salary of " + name + " can't be negative.";
            }
        }
        public decimal BaseSalary // read only property return base staff salary
        {
            get
            {
                return mBaseSalary;
            }
        }
        public int DifferenceTotalYears(DateTime start, DateTime end) // function return difference between end and start date in years
        {
            // Get difference in total months.
            int months = ((end.Year - start.Year) * 12) + (end.Month - start.Month);
            // substract 1 month if end month is not completed
            if (end.Day < start.Day)
            {
                months--;
            }
            int totalyears = (int)(months / 12d);
            return totalyears;
        }
        public decimal Salary // read only property return staff salary
        {
            get
            {
                return mBaseSalary;
            }
        }
        public decimal SubordinetesSalary // read only property return sum of all level subordinetes salary
        {
            get
            {
                decimal dSum = 0;
                foreach (Staff s in Subordinates)
                {
                    dSum += s.Salary + s.SubordinetesSalary; // use recursion to get total sum salaries of all level subordinates
                }
                return dSum; ;
            }
        }
        public DateTime JoinDate // read/write property for date when staff joined the company 
        {
            get
            {
                return dJoinedDate;
            }
            set
            {
                dJoinedDate = value;
            }
        }
        private Staff mSupervisor;
        public Staff Supervisor // read/write property for staff supervisor
        {
            get
            {
                return mSupervisor;
            }
            set
            {
                mSupervisor = value;
                mSupervisor.SubordinatesList.Add(this);
            }
        }
        public string Name { get; set; } // read/write property for staff name
        public string ErrorMessage // read only property returns error message in constructor
        {
            get
            {
                return mErrorMessage;
            }
        }
        private List<Staff> SubordinatesList = new List<Staff>();
        public List<Staff> Subordinates // read only property returns staff subordinates list
        {
            get
            {
                return SubordinatesList;
            }
        }
    }
    public class Employee : Staff
    {
        public Employee(string name, decimal mBaseSalary, DateTime DateJoined) // constructor for Employee class is equal to constructor of base Staff class
        : base(name, mBaseSalary, DateJoined)
        {
        }
        public new decimal Salary // read only property returns Employee salary
        {
            get
            {
                double Premium;
                int YearsWork = DifferenceTotalYears(this.JoinDate, DateTime.Today);
                Premium = (double)(YearsWork * 3) / 100;
                if (Premium > 0.30) { Premium = 0.30; }
                return Decimal.Round((decimal)(1 + Premium) * this.BaseSalary, 2);
            }
        }
    }
    public class Manager : Staff // constructor for Manager class is equal to constructor of base Staff class
    {
        public Manager(string name, decimal mBaseSalary, DateTime DateJoined)
        : base(name, mBaseSalary, DateJoined)
        {
        }
        public new decimal Salary // read only property returns Manager salary
        {
            get
            {
                double Coef;
                double Premium;
                int YearsWork = DifferenceTotalYears(this.JoinDate, DateTime.Today);
                Coef = (double)(YearsWork * 5) / 100;
                if (Coef > 0.40) { Coef = 0.40; }
                Premium = Coef * (double)this.BaseSalary;
                foreach (Staff s in this.Subordinates)
                {
                    Premium += (double)s.Salary * 0.005;
                }
                return Decimal.Round(((decimal)Premium + this.BaseSalary), 2);
            }
        }
    }
    public class Sales : Staff // constructor for Sales class is equal to constructor of base Staff class
    {
        public Sales(string name, decimal mBaseSalary, DateTime DateJoined)
        : base(name, mBaseSalary, DateJoined)
        {
        }
        public new decimal Salary // read only property returns Sales salary
        {
            get
            {
                double Coef;
                decimal Premium;
                int YearsWork = DifferenceTotalYears(this.JoinDate, DateTime.Today);
                Coef = (double)(YearsWork) / 100;
                if (Coef > 0.35) { Coef = 0.35; }
                Premium = ((decimal)Coef) * this.BaseSalary;
                Premium += ((decimal)0.003) * this.SubordinetesSalary;
                return Decimal.Round((decimal)(Premium + this.BaseSalary), 2);
            }
        }
    }
}

