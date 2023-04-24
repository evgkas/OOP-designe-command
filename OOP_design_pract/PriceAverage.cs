namespace OOP_design_pract
{
    public class PriceAverage : ICommand
    {
        private List<Car> cars;

        public PriceAverage(List<Car> cars)
        {
            this.cars = cars;
        }

        public void Execute()
        {
            try
            {
                var result = cars.Select(car => car.price).Average();
                Console.WriteLine($"Average price: {result}");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Error. Car list is empty");
            }
        }
    }
}
