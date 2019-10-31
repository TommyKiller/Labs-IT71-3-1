using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public class EmployeeID
    {
        public EmployeeID(int id)
        {
            ID = id;
        }
        
        public static bool operator ==(EmployeeID left, EmployeeID right)
        {
            return left.ID == right.ID;
        }

        public static bool operator !=(EmployeeID left, EmployeeID right)
        {
            return left.ID != right.ID;
        }

        public int ID;

        public override string ToString()
        {
            return ID.ToString();
        }
    }
}
