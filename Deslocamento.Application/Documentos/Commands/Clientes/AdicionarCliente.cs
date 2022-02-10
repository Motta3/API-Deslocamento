using DeslocamentoAPI.Domain.Interfaces;
using DeslocamentoAPI.Domain.Entities;
using MediatR;

namespace DeslocamentoAPI.Application.Documentos.Commands.AdicionarCliente
{
    public class AdicionarCliente : IRequest<Cliente>
    {
        public string Cpf { get; set; }

        public string Nome { get; set; }

    }
    public class AdicionarClienteHandler :
        IRequestHandler<AdicionarCliente, Cliente>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdicionarClienteHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Cliente> Handle(
            AdicionarCliente request,
            CancellationToken cancellationToken)
        {
            var clienteInserir = new Cliente(
                 request.Cpf,
                 request.Nome);

            var repositoryCliente =
                _unitOfWork.GetRepository<Cliente>();

            repositoryCliente.Add(clienteInserir);

            await _unitOfWork.CommitAsync();

            return clienteInserir;
        }
    }
}