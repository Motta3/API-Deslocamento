using DeslocamentoAPI.Domain.Entities;
using DeslocamentoAPI.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeslocamentoAPI.Application.Documentos.Queries
{
    public class GetClientesQuery : IRequest<List<Cliente>>
    {
    }

    public class GetClientesQueryHandler :
        IRequestHandler<GetClientesQuery, List<Cliente>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetClientesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Cliente>> Handle(
            GetClientesQuery request,
            CancellationToken cancellationToken)
        {
            var repositoryCliente =
                _unitOfWork.GetRepository<Cliente>();

            var clientes = await repositoryCliente
                .GetAll()
                .ToListAsync(cancellationToken);

            return clientes;
        }
    }
}