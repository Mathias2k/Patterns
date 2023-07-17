namespace ConsoleApp1.ConcreteProduct
{
    public class Vegetariano : Lanche
    {
        private readonly string _nomeLanche;
        public Vegetariano()
        {
            _nomeLanche = "Lanche Vegetariano";
            Ingredientes.Add("Alface e Rúcula ");
            Ingredientes.Add("Ervilha e Tomate");
        }
        public override string Nome { get => _nomeLanche; }

    }
}
