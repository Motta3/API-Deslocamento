namespace DeslocamentoAPI.Domain.Entities
{
    public class Condutor : BaseEntity
    {

        public Condutor(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }
        private Condutor()
        {
            // Necessário para entity framework
        }
        public string Nome { get; private set; }

        public string Email { get; private set; }

        private readonly List<Deslocamento> _deslocamentos = new();
        public IReadOnlyCollection<Deslocamento> Deslocamentos =>
            _deslocamentos.AsReadOnly();
        public string ToString()
        {
            return $"Nome {Nome} e-mail {Email}";
        }
    }
}
