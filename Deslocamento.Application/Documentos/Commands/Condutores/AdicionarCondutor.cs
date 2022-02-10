using DeslocamentoAPI.Domain.Interfaces;
using DeslocamentoAPI.Domain.Entities;
using MediatR;

namespace DeslocamentoAPI.Application.Documentos.Commands.AdicionarCondutor
{
    public class AdicionarCondutor : IRequest<Condutor>
    {
        public string Nome { get; set; }

        public string Email { get; set; }

    }
    public class AdicionarCondutorHandler :
        IRequestHandler<AdicionarCondutor, Condutor>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdicionarCondutorHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Condutor> Handle(
            AdicionarCondutor request,
            CancellationToken cancellationToken)
        {
            var condutorInserir = new Condutor(
                 request.Nome,
                 request.Email);

            var repositoryCondutor =
                _unitOfWork.GetRepository<Condutor>();

            repositoryCondutor.Add(condutorInserir);

            await _unitOfWork.CommitAsync();

            return condutorInserir;
        }
    }
}