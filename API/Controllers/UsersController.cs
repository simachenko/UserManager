using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManager.Domain.Requests;
using UserManager.DTO.GetUsers;
using UserManager.DTO.MutateUser;

namespace ExampleService.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UsersController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public UsersController(IMediator mediator, IMapper mapper)
		{
			_mediator = mediator;
			_mapper = mapper;
		}

		[HttpPost("find")]
		public async Task<IActionResult> GetUsers(GetUsersDto searchDto)
		{
			var result = await _mediator.Send(_mapper.Map<GetUsersQuery>(searchDto));
			return Ok(_mapper.Map<List<GetUserResultDto>>(result));
		}

		[HttpPost]
		public async Task<IActionResult> Create(MutateUserDto user)
		{
			var result = await _mediator.Send(_mapper.Map<CreateUserCommand>(user));
			return Ok(_mapper.Map<GetUserResultDto>(result));
		}

		[HttpPut]
		public async Task<IActionResult> Update(MutateUserDto user)
		{
			var result = await _mediator.Send(_mapper.Map<UpdateUserCommand>(user));
			return Ok(_mapper.Map<GetUserResultDto>(result));
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(Guid id)
		{
			var result = await _mediator.Send(new DeleteUserCommand() { Id = id });
			return Ok(_mapper.Map<GetUserResultDto>(result));
		}
	}
}
