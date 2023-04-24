/*Напишите программу, принимающую из консоли следующую информацию об автомобиле: марка, модель, количество, стоимость 
  одной единицы. После ввода наименований автомобилей, программа должна запросить у пользователя команду. При получении 
  команд программа должна выдать следующую информацию:

count types - количество марок автомобилей;

count all - общее количество автомобилей;

average price - средняя стоимость автомобиля;

average price type - средняя стоимость автомобилей каждой марки (марка задается пользователем), например average price 
volvo

При получении команды exit программа должна завершиться. Использовать паттерны проектирвоания Singleton, Command */

using OOP_design_pract;

public interface ICommand
{
    void Execute();
}

class Program
{
    static void Main(string[] args)
    {        
        var cars = new List<Car> { };

        Console.WriteLine("Enter information about auto. Enter stop to continue to command");

        while (true)    //reading auto parameters 
        {
            Console.WriteLine("Brand:");
            string brand = Console.ReadLine();
            if (brand.ToLower() == "stop") { break; }
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
            Console.WriteLine("Price: !!!разделитель запятая");
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

        bool commandCheck = false;  //exit from cicle
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
                        commandCheck = true;
                        break;
                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }
            }
        }
        while (!commandCheck);
    }
}

public class Invoker
{
    private ICommand _command;

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public void ExecuteCommand()
    {
        _command.Execute();

    }
}
