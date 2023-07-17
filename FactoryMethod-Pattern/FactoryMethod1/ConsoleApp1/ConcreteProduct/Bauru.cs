namespace ConsoleApp1.ConcreteProduct
{
    public class Bauru : Lanche
    {
        private readonly string _nomeLanche;
        public Bauru()
        {
            _nomeLanche = "Bauru";
            Ingredientes.Add("Pão Francês");
            Ingredientes.Add("Presunto");
            Ingredientes.Add("Mussarela");
            Ingredientes.Add("Tomate e maionese");
        }
        public override string Nome { get => _nomeLanche; }
    }
}
