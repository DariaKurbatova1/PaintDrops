
using System.Diagnostics;
using ShapeLibrary;
using PaintDropSimulation;
internal class Program
{
    public static void AddDrops(ISurface surface, int numDrops)
    {
        for (int i = 0; i < numDrops; i++)
        {
            ICircle c = ShapeFactory.CreateCircle(5, 5, 5, new Colour(3, 3, 3));
            IPaintDrop drop = new PaintDrop(c);
            surface.AddPaintDrop(drop);
        }
    }
    private static void Main(string[] args)
    {
        Console.WriteLine("PaintDropsApp - Performance analysis");

        var watch = new Stopwatch();
        watch.Start();
        ISurface surface = new Surface(489, 480);
        AddDrops(surface, 500);
        watch.Stop();
        Console.WriteLine($"Time taken for 500 drops: {watch.ElapsedMilliseconds}");
        //for (int i = 10000; i < 500000; i += 1000)
        //{
        //    watch.Restart();
        //    watch.Start();
        //    CountOfEvens(Create2DArray(i)); //To benchmark this method
        //    watch.Stop();
        //    Console.WriteLine($"Time taken for array of size {i}: {watch.ElapsedMilliseconds}");
        //    Console.WriteLine("Enter key to continue");
        //    Console.ReadKey();
        //}

        /*Parallel.For(0, 100, i =>
        {
            watch.Restart();
            watch.Start();
            ALongMethod();
            watch.Stop();
            Console.WriteLine($"Time taken for {i} : {watch.ElapsedMilliseconds}");
        });
*/

    }
    //Demo 1 - To benchmark a simple for
    /*private static double[] Create1DArray(int n)
    {
        double[] array = new double[n];
        Random r = new Random();
        for (int i = 0; i < n; i++)
        {
            array[i] = r.Next(200);
        }
        return array;
    }
    //Demo 2 - To benchmark a nested for
    private static double[,] Create2DArray(int n)
    {
        double[,] array = new double[n, n];
        Random r = new Random();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                array[i, j] = r.Next(200);
            }
        }
        return array;
    }
    private static void CountOfEvens(double[,] array)
    {
        double count = 0;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (array[i, j] % 2 == 0) count++;
            }
        }
        Console.WriteLine($"Count of evens: {count}");
    }
    //Demo 3 - For parallel for
    private static long ALongMethod()
    {
        long total = 0;
        for (int i = 0; i < 100000000; i++)
        {
            total += i;
        }
        return total;
    }*/
}
