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
            Console.WriteLine("Enter to continue");
            Console.ReadLine();



            //Console.WriteLine("You have entered {} Employees.");
        }


        //One Employee method
        static string OneEmployee()
        {





            return "";
        }






    }
}
