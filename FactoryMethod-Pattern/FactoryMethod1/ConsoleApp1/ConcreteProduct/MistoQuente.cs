namespace ConsoleApp1.ConcreteProduct
{
    public class MistoQuente : Lanche
    {
        private readonly string _nomeLanche;
        public MistoQuente()
        {
            _nomeLanche = "Misto Quente";
            Ingredientes.Add("Pão Francês");
            Ingredientes.Add("Presunto e Mussarela na chapa");
        }
        public override string Nome { get => _nomeLanche; }
    }
}
