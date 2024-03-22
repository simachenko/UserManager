using MediatR;
using UserManager.Domain.Interfaces;
using UserManager.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Domain.Models.GetModels;

namespace UserManager.Domain.Handlers.Queries
{
	internal class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<GetUserResult>>
	{
		private readonly IUserManagerRepository _repository;

		public GetUsersQueryHandler(IUserManagerRepository repository)
		{
			_repository = repository;
		}

		public Task<List<GetUserResult>> Handle(GetUsersQuery notification, CancellationToken cancellationToken)
		{
			return _repository.GetUsers(notification);
		}
	}
}
