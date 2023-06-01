namespace OOP_design_pract.Commands
{
    public class CountTypes : ICommand
    {
        private List<Car> cars;

        public CountTypes(List<Car> cars)
        {
            this.cars = cars;
        }

        public void Execute()
        {
            var count = cars.Select(car => car.brand).Distinct().Count();
            Console.WriteLine($"CountTypes result: {count}");
        }
    }
}
