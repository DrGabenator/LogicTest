namespace LogicTest
{
    public class Network
    {
        private int _numberOfElements;
        private List<int>[] _connections;

        public Network(int numberOfElements) 
        { 
            if(numberOfElements <= 0)
            {
                throw new ArgumentException("Invalid number of elements. Can't have have 0 or less elements.");
            }

            numberOfElements++;

            this._numberOfElements = numberOfElements;
            _connections = new List<int>[numberOfElements];

            for(int i = 0; i < numberOfElements; i++)
            {
                _connections[i] = new List<int>();
            }
        }

        public void Connect(int element1, int element2)
        {
            ValidateElement(element1);
            ValidateElement(element2);

            if (element1 == element2)
            {
                throw new ArgumentException("Can't connect element to itself.");
            }

            //Verifica se já existe uma conexão entre o elemento 1 e o elemento 2. Caso o elemento 2 já estiver presente na lista de connections do elemento 1, o elemento 2 é adicionado a lista 1. 
            if (!_connections[element1].Contains(element2))
            {
                _connections[element1].Add(element2);
            }

            //Verifica se já existe uma conexão entre o elemento 2 e o elemento 1. Caso o elemento 1 já estiver presente na lista de connections do elemento 2, o elemento 1 é adicionado a lista 2. 
            if (!_connections[element2].Contains(element1))
            {
                _connections[element2].Add(element1);
            }
        }

        public bool Query(int element1, int element2)
        {
            ValidateElement(element1);
            ValidateElement(element2);

            bool[] elementVisited = new bool[_numberOfElements];
            return IsConnected(element1, element2, elementVisited);
        }

        private bool IsConnected(int currentElement, int targetElement, bool[] elementVisited)
        {
            if (currentElement == targetElement)
            {
                return true;
            }

            elementVisited[currentElement] = true;

            foreach(int element in _connections[currentElement]) 
            { 
                if (!elementVisited[element] && IsConnected(element, targetElement, elementVisited))
                {
                    return true;
                }
            }

            return false;
        }

        private void ValidateElement(int element)
        {
            if (element < 0 || element >= _numberOfElements)
            {
                throw new ArgumentException("Invalid element.");
            }
        }
    }
}
