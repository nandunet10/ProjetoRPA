using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TestAec.API.Commands
{
    public class ProcessarDadosCommand : IRequest<IActionResult> { }
}
