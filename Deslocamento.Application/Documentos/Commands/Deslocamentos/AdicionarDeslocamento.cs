using DeslocamentoAPI.Domain.Interfaces;
using DeslocamentoAPI.Domain.Entities;
using MediatR;

namespace DeslocamentoAPI.Application.Documentos.Commands.AdicionarDeslocamento
{
    public class AdicionarDeslocamento : IRequest<Deslocamento>
    {
        public long CarroId { get; set; }
        public long ClienteId { get; set; }
        public long CondutorId { get; set; }
        public decimal QuilometragemInicial { get; set; }
    }

    public class AdicionarDeslocamentoHandler :
        IRequestHandler<AdicionarDeslocamento, Deslocamento>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdicionarDeslocamentoHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Deslocamento> Handle(
            AdicionarDeslocamento request,
            CancellationToken cancellationToken)
        {
            var deslocamentoInserir = new Deslocamento(
                 request.CarroId,
                 request.ClienteId,
                 request.CondutorId,
                 request.QuilometragemInicial);

            var repositoryDeslocamento =
                _unitOfWork.GetRepository<Deslocamento>();

            repositoryDeslocamento.Add(deslocamentoInserir);

            await _unitOfWork.CommitAsync();

            return deslocamentoInserir;
        }
    }
}