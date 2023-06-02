using OOP_design_pract;
using OOP_design_pract.Commands;

    public class Program
    {
        private static void Main(string[] args)
        {
            var cars = new List<Car> { };

            Console.WriteLine("Enter information about auto. Enter stop to continue to command");

            while (true)    //reading auto parameters 
            {
                Console.WriteLine("Brand:");
                string brand = Console.ReadLine();

                if (brand.ToLower() == "stop")
                {
                    break;
                }

                Console.WriteLine("Model:");
                string model = Console.ReadLine();

                Console.WriteLine("Quaintity:");
                string quaintityToClean = Console.ReadLine();
                int quaintity = 0;

                while ((!int.TryParse(quaintityToClean, out quaintity)) || (Convert.ToInt32(quaintityToClean) <= 0))
                {
                    Console.WriteLine("Quaintity must be positive int value \nQuaintity:");
                    quaintityToClean = Console.ReadLine();
                }

                Console.WriteLine("Price: (use \",\" as separator)");
                string priceToClean = Console.ReadLine();
                double price = 0;

                while ((!double.TryParse(priceToClean, out price)) || (Convert.ToDouble(priceToClean) <= 0))
                {
                    Console.WriteLine("Price must be positive double value \nPrice:");
                    priceToClean = Console.ReadLine();
                }

                cars.Add(new Car(brand, model, quaintity, price));
            }

            Invoker invoker = new Invoker();

            bool exitCheck = false;  //exit from cicle
            do
            {
                Console.WriteLine("Enter command. Enter exit to exit");
                string command = Console.ReadLine().ToLower();

                if ((command.StartsWith("average price")) && (command != "average price"))
                {
                    string modelToFind = command.Replace("average price ", "");

                    ICommand AveragePriceType = new AveragePriceType(cars, modelToFind);
                    invoker.SetCommand(AveragePriceType);
                    invoker.ExecuteCommand();
                }
                else
                {
                    switch (command)
                    {
                        case ("count types"):
                            ICommand CountTypes = new CountTypes(cars);
                            invoker.SetCommand(CountTypes);
                            invoker.ExecuteCommand();
                            break;
                        case ("count all"):
                            ICommand CountAll = new CountAll(cars);
                            invoker.SetCommand(CountAll);
                            invoker.ExecuteCommand();
                            break;
                        case ("average price"):
                            ICommand PriceAverage = new PriceAverage(cars);
                            invoker.SetCommand(PriceAverage);
                            invoker.ExecuteCommand();
                            break;
                        case ("exit"):
                            exitCheck = true;
                            break;
                        default:
                            Console.WriteLine("Invalid command");
                            break;
                    }
                }
            } while (!exitCheck);
        }
    }