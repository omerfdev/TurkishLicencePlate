namespace TurkishLicencePlate
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            MainPage();
        }
        private static void MainPage()
        {
            Console.WriteLine("...Welcome Turkish Plate Center...");
            string[] chooseProcess = { "=> How Many Get List Turkish Plate For Press 1", "=> \tHOW MANY ATTEMPTS WILL THE PC FIND YOUR LICENSE PLATE FOR 2", "CHOOSE YOUR PROCESS" };
            foreach (string process in chooseProcess) { Console.WriteLine(process); }
            int choose = new int();
            try
            {
                choose = int.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message + "\n");

            }
            finally
            {
                switch (choose)
                {
                    case 1: Console.Clear(); HowManyShowPlate(); Console.WriteLine("\n"); break;
                    case 2: Console.Clear(); FindLicencePlate(yourPlate()); Console.WriteLine("\n"); break;
                    default:
                        Console.WriteLine("Wrong Process");
                        break;
                }
                MainPage();
            }



        }
        private static string yourPlate()
        {

            Console.WriteLine("Please Enter Your Turkish Licence Plate");
            string yourPlate = Console.ReadLine().ToUpper();
            return yourPlate;
        }
        private static string pcPlate()
        {
            string[] pcPlate = LastNumber(MiddleCharacter(CityNumber()));
            string pcplate = "";
            for (int i = 0; i < pcPlate.Length; i++)
            {
                pcplate += pcPlate[i];
            }
            return pcplate;
        }
        private static void FindLicencePlate(string yourPlate)
        {
            for (; ; )
            {
                int count = 0;
                pcPlate();
                while (pcPlate() == yourPlate)
                {
                    Console.WriteLine(count);
                }
                count++;
            }

        }
        private static void HowManyShowPlate()
        {
            Console.WriteLine("How many get turkish plate");
            int loopCount = int.Parse(Console.ReadLine());
            PlateShow(loopCount);
        }
        private static void PlateShow(int loopCount)
        {
            for (int i = 0; i < loopCount; i++)
            {
                if (i >= 0)
                {
                    foreach (var plate in LastNumber(MiddleCharacter(CityNumber())))
                    {
                        Console.Write(plate + " ");
                    }
                    Console.WriteLine("");
                }
            }

        }
        
        /// <summary>
        /// 1 to 81 random create number.
        /// </summary>
        /// <returns></returns>              
        private static string[] CityNumber()
        {
            string[] plateTurkish = new string[3];
            Random rnd = new Random();
            int cityNumber = rnd.Next(1, 82);
            if (cityNumber < 10) { string city = "0"; city += cityNumber.ToString(); plateTurkish[0] = city; }
            else plateTurkish[0] = cityNumber.ToString();
            return plateTurkish;
        }
        private static string[] MiddleCharacter(string[] plateTurkish)
        {
            Random rnd = new Random();
            string middleCharacter = "";
            int characterNumber = rnd.Next(1, 4);
            for (int i = 0; i < characterNumber; i++)
            {
                middleCharacter += (char)rnd.Next(65, 91);
            }
            plateTurkish[1] = middleCharacter;
            return plateTurkish;
        }
        private static string[] LastNumber(string[] plateTurkish)
        {
            Random rnd = new Random();
            string lastNumber = "";
            int loopLastNumber = plateTurkish[1].Length;
            for (int i = 0; i < 6 - loopLastNumber; i++)
            {
                lastNumber += (char)rnd.Next(48, 58);
            }
            plateTurkish[2] = lastNumber;
            return plateTurkish;
        }
    }
}
