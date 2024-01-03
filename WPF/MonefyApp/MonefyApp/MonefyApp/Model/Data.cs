using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonefyApp.Model
{
    public class Data
    {
        private float percentAge;
        public string Categorie { get; set; }
        public string Note { get; set; }
        public string Color { get; set; }
        public DateTime TimeCreate { get; set; }
        public bool Income { get; set; }
        public bool Expensed { get; set; }
        public string IncomeColor
        {
            get
            {
                if (Income)
                {
                    return "Green";
                }
                return "Red";
            }
        }
        public double Money { get; set; }
        public float Percentage { get => percentAge; set=>percentAge = value; }
        public string Name { get; internal set; }
        public double Expense { get; set; }
    }
}
