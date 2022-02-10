using DeslocamentoAPI.Domain.Interfaces;
using DeslocamentoAPI.Domain.Entities;
using MediatR;

namespace DeslocamentoAPI.Application.Documentos.Commands.Carros
{
    public class AdicionarCarro : IRequest<Carro>
    {
        public string Placa { get; set; }

        public string Descricao { get; set; }
    }
    public class AdicionarCarroHandler :
        IRequestHandler<AdicionarCarro, Carro>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdicionarCarroHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Carro> Handle(
            AdicionarCarro request,
            CancellationToken cancellationToken)
        {
            var carroInserir = new Carro(
                 request.Placa,
                 request.Descricao);

            var repositoryCarro =
                _unitOfWork.GetRepository<Carro>();

            repositoryCarro.Add(carroInserir);

            await _unitOfWork.CommitAsync();

            return carroInserir;
        }
    }
}