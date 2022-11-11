using Metalapp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metalapp     //DO NOT change the namespace name
{
    public class Program          //DO NOT change the class name
    {
        static void Main(string[] args)         //DO NOT change the 'Main' method signature
        {
            SalesDetails salesDetails = new SalesDetails();
            metalapps metalapps = new metalapps();

            //Adding values to database
            
            SalesDetails salesDetails1= new SalesDetails();
            salesDetails1.SalesId = 2119;
            salesDetails1.CustomerName = "kranthi";
            salesDetails1.NoOfUnits = 75;
            salesDetails1.NetAmount = 1000;
            metalapps.AddSalesDetails(salesDetails1);

            SalesDetails salesDetails2 = new SalesDetails();
            salesDetails2.SalesId = 1124;
            salesDetails2.CustomerName = "krishna";
            salesDetails2.NoOfUnits = 52;
            salesDetails2.NetAmount = 12;
            metalapps.AddSalesDetails(salesDetails2);

            Console.WriteLine("Enter sales id : ");
            salesDetails.SalesId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter customer name : ");
            salesDetails.CustomerName = Console.ReadLine();

            Console.WriteLine("Enter the number of units sold : ");
            salesDetails.NoOfUnits = int.Parse(Console.ReadLine());

            metalapps.CalculateNetAmount(salesDetails);

            Console.WriteLine("\n\nSales Bill");
             Console.WriteLine("*************");
             Console.WriteLine($"Sales Id : {salesDetails.SalesId}");
             Console.WriteLine($"Customer Name : {salesDetails.CustomerName}");
             Console.WriteLine($"Number of Units Sold : {salesDetails.NoOfUnits}");
             Console.WriteLine($"Net Amount : Rs.{salesDetails.NetAmount}");
             metalapps.DisplayDetails();


        }
    }

}







***********************************************




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metalapp   //DO NOT change the namespace name
{
    public class SalesDetails   //DO NOT change the class name
    {
        
            
        private int salesId;
        private string customerName;
        private int noOfUnits;
        private double netAmount;


        public int SalesId 
        {
            get
            {
                return salesId;
            }
            set
            {
                salesId = value;
            }
        }
        public string CustomerName 
        {
            get
            {
                return customerName;
            } 
            set
            {
                customerName = value;
            }
        }
        public int NoOfUnits
        {
            get
            {
                return noOfUnits;
            }
            set
            {
                noOfUnits = value;
                if (noOfUnits <= 5)
                {
                    throw new ArgumentOutOfRangeException("\n\nNo Sales for units below 5!\n\n\n");
                }
            }
        }

        public double NetAmount 
        {
            get
            {
                return netAmount;
            }
            set
            {
                netAmount = value;
            }
        }
    }
}






***********************************************







using Metalapp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metalapp //DO NOT change the namespace name
{
    public class metalapps            //DO NOT change the class name
    {
        //LinkedList<SalesDetails> SalesDetailsDatabase = new LinkedList<>(SalesDetails);
        List<SalesDetails> SalesDetailsDatabase = new List<SalesDetails>();

        public void AddSalesDetails(SalesDetails salesDetails)
        {
            SalesDetailsDatabase.Add(salesDetails);
           
        }


        public void DisplayDetails()
        {
            Console.WriteLine("\n\n*************");
            Console.WriteLine("Sales Details Database");
            Console.WriteLine("*************");


            for (int i = 0; i < SalesDetailsDatabase.Count; i++)
                Console.WriteLine(
                    $"\nSales id : {SalesDetailsDatabase[i].SalesId}" +
                    $"\nCustomer Name : {SalesDetailsDatabase[i].CustomerName}" +
                    $"\nNo of Units : {SalesDetailsDatabase[i].NoOfUnits}" +
                    $"\nNet Amount : Rs.{SalesDetailsDatabase[i].NetAmount}");
        }



        public void CalculateNetAmount(SalesDetails salesDetails)
        {
            int units = salesDetails.NoOfUnits;

            if (units <= 5)
                salesDetails.NetAmount = 75350 * units;
            else if (units > 5 && units <= 10)
                salesDetails.NetAmount = 75350 * units * 0.98;
            else if (units > 10 && units <= 15)
                salesDetails.NetAmount = 75350 * units * 0.95;
            else if (units > 15 && units <= 20)
                salesDetails.NetAmount = 75350 * units * 0.92;
            else if (units > 20)
                salesDetails.NetAmount = 75350 * units * 0.90;

            AddSalesDetails(salesDetails);

        }
    }
}
