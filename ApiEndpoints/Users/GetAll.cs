using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiEndpoints.Users
{
    public class GetAll : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response>
    {
        private readonly IMediator _mediator;

        public GetAll(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/users")]
        [SwaggerOperation("Gets all Users", "Gets all Users", OperationId = "Users.GetAll", Tags = new[] { "UsersEndpoint" })]
        public override async Task<ActionResult<Response>> HandleAsync(CancellationToken cancellationToken = default) => Ok(await _mediator.Send(new Command(), cancellationToken));
    }

    public class Command : IRequest<Response>
    {
    }

    public class Response
    {
        public List<int> Users { get; set; }
    }

    public class Handler : IRequestHandler<Command, Response>
    {
        public Task<Response> Handle(Command request, CancellationToken cancellationToken) => Task.FromResult(new Response());
    }
}
