namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            File file = new("Pesho", 12, 1024);
            Music musicFile = new("Eminem", "Relapse", 24, 4096);
            Movie movie = new(34, 9059);

            StreamProgressInfo spI = new(movie);
            System.Console.WriteLine(spI.CalculateCurrentPercent());
        }
    }
}
