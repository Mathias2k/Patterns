using System.Collections;

namespace ConsoleApp1
{
    public abstract class Lanche
    {
        public abstract string Nome { get; }
        public ArrayList Ingredientes = new ArrayList();
    }
}
