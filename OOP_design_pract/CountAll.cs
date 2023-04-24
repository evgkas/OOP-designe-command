namespace OOP_design_pract
{
    public class CountAll : ICommand
    {
        private List<Car> cars;

        public CountAll(List<Car> cars)
        {
            this.cars = cars;
        }

        public void Execute()
        {            
            var count = cars.Select(car => car.quaintity).Sum();            
            Console.WriteLine($"CountAll result: {count}");
        }
    }
}
