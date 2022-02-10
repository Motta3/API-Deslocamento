namespace DeslocamentoAPI.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public Cliente(string cpf, string nome)
        {
            Cpf = cpf;
            Nome = nome;
        }
        private Cliente()
        {
            // Necessário para o EF
        }
        public string Cpf { get; private set; }

        public string Nome { get; private set; }

        private readonly List<Deslocamento> _deslocamentos = new();
        public IReadOnlyCollection<Deslocamento> Deslocamentos =>
            _deslocamentos.AsReadOnly();
        public string ToString()
        {
            return $"Nome {Nome} CPF {Cpf}";
        }
    }
}
