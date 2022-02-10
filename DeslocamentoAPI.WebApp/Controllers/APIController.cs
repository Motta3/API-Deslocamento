using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeslocamentoAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class APIController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??
            HttpContext.RequestServices.GetService<IMediator>();
    }
}