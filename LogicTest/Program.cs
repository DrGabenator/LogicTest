namespace LogicTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Network network = new Network(8);

                network.Connect(1, 2);
                network.Connect(6, 2);
                network.Connect(2, 4);
                network.Connect(5, 8);

                bool is1ConnectedTo6 = network.Query(1, 6);
                bool is6ConnectedTo4 = network.Query(6, 4);
                bool is7ConnectedTo4 = network.Query(7, 4);
                bool is5ConnectedTo6 = network.Query(5, 6);

                Console.WriteLine("Is element 1 connected to element 6? " + is1ConnectedTo6);
                Console.WriteLine("Is element 6 connected to element 4? " + is6ConnectedTo4);
                Console.WriteLine("Is element 7 connected to element 4? " + is7ConnectedTo4);
                Console.WriteLine("Is element 5 connected to element 6? " + is5ConnectedTo6);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occurred: " + ex.Message);
            }
        }
    }
}
