using LogicTest;
using Xunit;

namespace LogicTests
{
    public class NetworkTests
    {
        [Fact]
        public void ConnectShouldEstablishConnection()
        {
            Network network = new Network(8);

            network.Connect(1, 2);

            Assert.True(network.Query(1, 2));
            Assert.True(network.Query(2, 1));
        }

        [Fact]
        public void QueryShouldReturnTrueForConnectedElements()
        {
            Network network = new Network(8);
            network.Connect(1, 2);
            network.Connect(6, 2);
            network.Connect(2, 4);
            network.Connect(5, 8);

            Assert.True(network.Query(1, 6));
            Assert.True(network.Query(6, 4));

        }

        [Fact]
        public void QueryShouldReturnFalseForDisconnectedElements()
        {
            Network network = new Network(8);
            network.Connect(1, 2);
            network.Connect(6, 2);
            network.Connect(2, 4);
            network.Connect(5, 8);

            Assert.False(network.Query(7, 4));
            Assert.False(network.Query(5, 6));

        }

        [Fact]
        public void ConnectWithInvalidElementShouldThrowException()
        {
            Network network = new Network(8);

            Assert.Throws<ArgumentException>(() => network.Connect(1, 10));
            Assert.Throws<ArgumentException>(() => network.Connect(-1, 3));
        }

        [Fact]
        public void QueryWithInvalidElementShouldThrowException()
        {
            Network network = new Network(8);

            Assert.Throws<ArgumentException>(() => network.Query(1, 10));
            Assert.Throws<ArgumentException>(() => network.Query(-1, 3));
        }
    }
}
