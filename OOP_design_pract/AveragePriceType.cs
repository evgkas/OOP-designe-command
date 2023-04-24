namespace OOP_design_pract
{
    public class AveragePriceType : ICommand
    {
        private List<Car> cars;
        private string modelToFind;

        public AveragePriceType(List<Car> cars, string modelToFind)
        {
            this.cars = cars;
            this.modelToFind = modelToFind;
        }

        public void Execute()
        {            
            var findedModels = from c in cars
                               where c.brand.ToLower() == modelToFind
                               select c.price;
            try
            {
                double result = findedModels.Average(); //need to add exception
                Console.WriteLine($"Average Price {modelToFind} = {result}");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"There is no {modelToFind} cars in list");
            }
        }
    }
}
