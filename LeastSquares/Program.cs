using System.Text.Json;

namespace LeastSquares
{
    public class XYValues
    {
        public double[]? х_values { get; set; }
        public double[]? y_values { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var values = JsonSerializer.Deserialize<XYValues>(File.ReadAllText("data.json"));

            double sum_xy = values.х_values.Zip(values.y_values, (x, y) => x * y).Sum();
            double sum_x2 = values.х_values.Sum(x => x * x);
            double sum_x = values.х_values.Sum();
            double sum_y = values.y_values.Sum();
            int n = values.х_values.Length;

            double k = (n * sum_xy - sum_x * sum_y) / (n * sum_x2 - sum_x * sum_x);
            double b = (sum_y - k * sum_x) / n;

            Console.WriteLine($"f(x) = {k:0.000}x + {b:0.000}");
            Console.ReadKey();
        }
    }
}
