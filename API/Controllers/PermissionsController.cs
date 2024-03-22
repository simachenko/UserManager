using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManager.Domain.Models.CreateModels;
using UserManager.Domain.Requests;
using UserManager.DTO.Permissions;

namespace ExampleService.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PermissionsController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public PermissionsController(IMediator mediator, IMapper mapper)
		{
			_mediator = mediator;
			_mapper = mapper;
		}

		[HttpGet("available")]
		public async Task<IActionResult> GetAvailable()
		{
			var result = await _mediator.Send(new GetAvailablePermissionsQuery());
			return Ok(_mapper.Map<List<GetPermissionResultDto>>(result));
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreatePermissionDto perm)
		{
			var result = await _mediator.Send(new CreatePermissionCommand() { Name = perm.Name });
			return Ok(_mapper.Map<GetPermissionResultDto>(result));
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(Guid id)
		{
			await _mediator.Send(new DeletePermissionCommand() { Id = id });
			return Ok();
		}
	}
}
