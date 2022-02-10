using DeslocamentoAPI.Domain.Entities;
using DeslocamentoAPI.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeslocamentoAPI.Application.Documentos.Queries
{
    public class GetCondutoresQuery : IRequest<List<Condutor>>
    {
    }

    public class GetCondutoresQueryHandler :
        IRequestHandler<GetCondutoresQuery, List<Condutor>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCondutoresQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Condutor>> Handle(
            GetCondutoresQuery request,
            CancellationToken cancellationToken)
        {
            var repositoryCondutor =
                _unitOfWork.GetRepository<Condutor>();

            var condutores = await repositoryCondutor
                .GetAll()
                .ToListAsync(cancellationToken);

            return condutores;
        }
    }
}