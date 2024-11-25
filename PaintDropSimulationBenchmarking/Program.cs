
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
        Console.ReadKey();

        watch.Restart();
        surface = new Surface(1000, 1000);
        AddDrops(surface, 1000);
        watch.Stop();
        Console.WriteLine($"Time taken for 1000 drops: {watch.ElapsedMilliseconds}");
        Console.ReadKey();

        watch.Restart();
        surface = new Surface(2000, 2000);
        AddDrops(surface, 1500);
        watch.Stop();
        Console.WriteLine($"Time taken for 1500 drops: {watch.ElapsedMilliseconds}");
        Console.ReadKey();

        watch.Restart();
        surface = new Surface(1000, 1000);
        AddDrops(surface, 2000);
        watch.Stop();
        Console.WriteLine($"Time taken for 2000 drops: {watch.ElapsedMilliseconds}");
        Console.ReadKey();



    }
}
