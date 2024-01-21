using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StockTest();
        }
        private static void StockTest()
        {
            StockTypeManager stockManager = new StockTypeManager(new EfStockTypeDal());

            var result = stockManager.GetAll();
            if (result.Success)
            {
                foreach (var stock in result.Data)
                {
                    Console.WriteLine(stock.Name);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}