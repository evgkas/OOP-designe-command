namespace OOP_design_pract
{
    public class CountTypes : ICommand
    {
        private List<Car> _cars;

        public CountTypes(List<Car> cars)
        {
            _cars = cars;
        }

        public void Execute()
        {
            var count = _cars.Select(car => car.brand).Distinct().Count();
            Console.WriteLine($"CountTypes result: {count}");
        }
    }
}
