namespace Nullability
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int? a = null;
            var c = a.ToString();
            Console.WriteLine(c);
        }
    }
}
