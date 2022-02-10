using DeslocamentoAPI.Domain.Entities;
using DeslocamentoAPI.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeslocamentoAPI.Application.Documentos.Queries
{
    public class GetCarrosQuery : IRequest<List<Carro>>
    {
    }

    public class GetCarrosQueryHandler :
        IRequestHandler<GetCarrosQuery, List<Carro>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCarrosQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Carro>> Handle(
            GetCarrosQuery request,
            CancellationToken cancellationToken)
        {
            var repositoryCarro =
                _unitOfWork.GetRepository<Carro>();

            var carros = await repositoryCarro
                .GetAll()
                .ToListAsync(cancellationToken);

            return carros;
        }
    }
}