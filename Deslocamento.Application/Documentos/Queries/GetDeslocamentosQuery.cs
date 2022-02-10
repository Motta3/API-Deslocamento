using DeslocamentoAPI.Domain.Interfaces;
using DeslocamentoAPI.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeslocamentoAPI.Application.Documentos.Queries
{
    public class GetDeslocamentosQuery : IRequest<List<Deslocamento>>
    {
    }

    public class GetDeslocamentosQueryHandler :
        IRequestHandler<GetDeslocamentosQuery, List<Deslocamento>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDeslocamentosQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Deslocamento>> Handle(
            GetDeslocamentosQuery request,
            CancellationToken cancellationToken)
        {
            var repositoryDeslocamento =
                _unitOfWork.GetRepository<Deslocamento>();

            var deslocamentos = await repositoryDeslocamento
                .GetAll()
                .ToListAsync(cancellationToken);

            return deslocamentos;
        }
    }
}
