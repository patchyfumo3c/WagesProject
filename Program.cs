using System.Reflection.Metadata.Ecma335;

namespace WagesApp
{
    public class Program
    {
        //Global variables

        // Constant variables
        public const float PAYRATE = 22.0f;
        public static readonly IReadOnlyCollection<float> TAXRATES = new List<float> { 0.075f, 0.07f }.AsReadOnly();
        public static readonly int BONUS = 5, BONUSCONDITION = 30;
        //Main method
        static void Main(string[] args)
        {
            //Display app title screen
            Console.WriteLine("                                                                                          \r\n                                                                                          \r\n██     ██  ▄▄▄   ▄▄▄▄ ▄▄▄▄▄   ▄█████  ▄▄▄  ▄▄     ▄▄▄▄ ▄▄ ▄▄ ▄▄     ▄▄▄ ▄▄▄▄▄▄ ▄▄▄  ▄▄▄▄  \r\n██ ▄█▄ ██ ██▀██ ██ ▄▄ ██▄▄    ██     ██▀██ ██    ██▀▀▀ ██ ██ ██    ██▀██  ██  ██▀██ ██▄█▄ \r\n ▀██▀██▀  ██▀██ ▀███▀ ██▄▄▄   ▀█████ ██▀██ ██▄▄▄ ▀████ ▀███▀ ██▄▄▄ ██▀██  ██  ▀███▀ ██ ██ \r\n                                                                                          ");
            //make description of app later


            Console.WriteLine("Enter to continue");
            Console.ReadLine();

            //Repeat OneEmployee() until all employee pay slips have been generated
            char continueInput = 'y';
            while (continueInput.Equals('y'))
            {
                OneEmployee();
                Console.WriteLine("\n\nDo you want to add another employee? y/n");
                continueInput = Console.ReadLine()[0];
            }


            //Console.WriteLine("You have entered {} Employees.");

            // Repeat OneEmployee
        }


        //Collect employee data and generate payslip
        static void OneEmployee()
        {
            int id;
            string name, lastName;
            List<int> hoursWorked = new List<int>();

            List<string> WEEK = new List<string> { "Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday" };
            WEEK.AsReadOnly();

            //Capture Employee data

            //ID
            Console.WriteLine("Enter Employee ID:");
            id = Convert.ToInt32(Console.ReadLine());

            //Name
            Console.WriteLine("Enter the first name");

            Console.WriteLine("Enter the Last name");

            //Hours worked
            foreach (string day in WEEK)
            {
                Console.WriteLine($"Enter hours worked on {day}:");
                hoursWorked.Add(Convert.ToInt32(Console.ReadLine()));
            }



            CalculateWeeklyPay(hoursWorked);
            CalculateBonus(hoursWorked);

            //calculate tax

            //calculate gross income

            //calculate net income

            //generate payslip


        }




        static float CalculateWeeklyPay(List<int> hoursWorked)
        {
            float weeklyPay = 0.0f;
            int totalHours = hoursWorked.Sum();
            weeklyPay = totalHours * PAYRATE;

            return weeklyPay;
        }
        //Calculate Bonus
        static float CalculateBonus(List<int> hoursWorked)
        {

            if (hoursWorked.Sum() >= BONUSCONDITION)
            {
                return BONUS * PAYRATE;
            }
            return 0;


        }
        //Calculate tax
        static float CalculateTax(List<int>hoursWorked)
        {
            float tax = 0.0f;  



            return tax;
        }


        
    }
}
