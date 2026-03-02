using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata.Ecma335;
using static System.Net.Mime.MediaTypeNames;

namespace WagesApp
{
    public class Program
    {
        //Global variables
        public const float PAYRATE = 22.0f;
        public static readonly IReadOnlyCollection<float> TAXRATES = new List<float> { 0.075f, 0.07f }.AsReadOnly();
        public static readonly int BONUS = 5, BONUSCONDITION = 30;
        public static string payslips = "";
        public static float totalWages = 0;
        static readonly List <string> QUESTIONS = new List<string> {"Enter Employee ID", "Enter the first name\n", "Enter the last name\n"};
        static readonly int[] IDMINMAX = new int[] { 0, 5000 };
        static readonly int[] HOURSMINMAX = new int[] { 0, 24 };

        public static int employeeCounter = 0, topHours = 0;
        public static string topEmployee = "";


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
                Console.WriteLine(OneEmployee());
                Console.WriteLine("\n\nDo you want to add another employee? y/n");
                continueInput = Console.ReadLine()[0];
            }
            
            Console.Clear();
            Console.WriteLine("--------Summary--------");
            Console.WriteLine($"Employees processed: {employeeCounter}");
            Console.WriteLine(payslips);



        }


        //Collect employee data and generate payslip
        static string OneEmployee()
        {
            int id;
            string name, lastName;
            List<int> hoursWorked = new List<int>();

            List<string> week = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            week.AsReadOnly();
            
            //Capture Employee data

            //ID
            id = CheckInt(QUESTIONS[0], IDMINMAX[0], IDMINMAX[1]);

            //Name
            name = CheckName(QUESTIONS[1]);
            lastName = CheckName(QUESTIONS[2]);
            
            //Hours worked
            foreach (string day in week)
            {
                
                hoursWorked.Add(CheckInt($"Enter hours worked on {day}:", HOURSMINMAX[0], HOURSMINMAX[1]));
                //if (hoursWorked > topEmployee) {)
                
            }
            //Add wages to total
            totalWages += CalculateWeeklyPay(hoursWorked) + CalculateBonus(hoursWorked) - CalculateTax(hoursWorked);
            if (hoursWorked.Sum() > topHours)
            {
                topHours = hoursWorked.Sum();
                topEmployee = $"{name} {lastName}";
            }
            Console.Clear();
            //Add to employee counter
            employeeCounter++;
            payslips += GeneratePayslip(id, name, lastName, hoursWorked);

            CalculateWeeklyPay(hoursWorked);
            CalculateBonus(hoursWorked);




            return "Employee Added";
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
        //Calculate Tax
        static float CalculateTax(List<int>hoursWorked)
        {
            float tax = 0.0f;
            

            if (CalculateWeeklyPay(hoursWorked) + CalculateBonus(hoursWorked) < 450)
            {
                tax = (CalculateWeeklyPay(hoursWorked) + CalculateBonus(hoursWorked)) * TAXRATES.ElementAt(0);
            }
            else
            {
                tax = (CalculateWeeklyPay(hoursWorked) + CalculateBonus(hoursWorked)) * TAXRATES.ElementAt(1);
            }
            
            return tax;
        }


        //Check if name does not meet expected data (Starts with capital, is longer than two characters, 
        static string CheckName(string question)
        {
            
            Console.Write(question);
            string nameInput = Console.ReadLine();
            nameInput = nameInput[0].ToString().ToUpper() + nameInput.Substring(1);


            return nameInput;
        }

        //Check if user input is between a min and max value
        static int CheckInt(string question, int min, int max)
        {
            while (true)
            {
                Console.WriteLine(question);
                int userInput = Convert.ToInt32(Console.ReadLine());
                if (userInput >= min && userInput <= max)
                {
                    return userInput;
                }

                else
                {
                    Console.WriteLine("Please enter a number between min and max");
                }
            }




            
        }
        //Generate Payslip
        private static string GeneratePayslip(int id, string name, string surname, List<int> hoursWorked) {
            string payslip = "";

            payslip += "--------Payslip--------\n";
            payslip += $"Employee ID: {id} \n";
            payslip += $"Employee name: {name} {surname}\n";
            payslip += $"Hours worked: {hoursWorked.Sum()} \n";
            payslip += $"Gross income: {CalculateWeeklyPay(hoursWorked) + CalculateBonus(hoursWorked):C} \n";
            payslip += $"Tax: {CalculateTax(hoursWorked):C}\n";
            payslip += $"Net income: {CalculateWeeklyPay(hoursWorked) + CalculateBonus(hoursWorked) - CalculateTax(hoursWorked):C}\n";
            payslip += "-----------------------";
            payslips += $"{payslip}\n";
            Console.WriteLine(payslip);
            return "";
        }

        
    }
}
