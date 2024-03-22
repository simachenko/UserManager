using UserManager.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using UserManager.Infrastructure.DataAccess.Models;
using AutoMapper;
using UserManager.Domain.Models.CreateModels;
using UserManager.Infrastructure.Extentions;
using UserManager.Domain.Models.UpdateModels;
using UserManager.Domain.Models.GetModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace UserManager.Infrastructure.DataAccess.Repos
{
	internal class UserManagerRepository : IUserManagerRepository
	{
		private readonly UserManager<UserDb> _userManager;
		private readonly UserManagerContext _context;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly IMapper _mapper;
		public UserManagerRepository(UserManager<UserDb> userManager, IMapper mapper, UserManagerContext context, RoleManager<IdentityRole> roleManager)
		{
			_userManager = userManager;
			_mapper = mapper;
			_context = context;
			_roleManager = roleManager;
		}

		public async Task<GetUserResult> CreateUser(CreateUserModel request)
		{
			var toCreate = _mapper.Map<UserDb>(request);

			toCreate.Permissions = await _context.Permissions.Where(x => request.Permissions.Contains(x.Id)).ToListAsync();

			(await _userManager.CreateAsync(toCreate)).ThrowIfNotSuccess();
			(await _userManager.AddPasswordAsync(toCreate, request.Password)).ThrowIfNotSuccess();
			await addToRoleOrCreate(request, toCreate);
			return _mapper.Map<GetUserResult>(toCreate);
		}



		public async Task<GetUserResult> DeleteUser(Guid id)
		{
			var user = await _userManager.FindByIdAsync(id.ToString());
			await _userManager.DeleteAsync(user);
			return _mapper.Map<GetUserResult>(user);
		}

		public async Task<List<GetUserResult>> GetUsers(GetUsersModel getUsersModel)
		{
			var query = _context.Users.AsQueryable();
			query = applyFilters(getUsersModel, query);

			query = applyOrder(getUsersModel, query);

			query = applyPagination(getUsersModel, query);
			var users = await query.Include(x=>x.Permissions).AsSingleQuery().AsNoTracking().ToListAsync();
			return _mapper.Map<List<GetUserResult>>(users);
		}

		public async Task<GetUserResult> UpdateUser(UpdateUserModel request)
		{
			await resetPassword(request.Password, request.Id);
			var toUpdate = _mapper.Map<UserDb>(request);
			toUpdate.Permissions = await _context.Permissions.Where(x => request.Permissions.Contains(x.Id)).ToListAsync();
			await _userManager.UpdateAsync(toUpdate);
			
			return _mapper.Map<GetUserResult>(toUpdate);
		}




		#region Internal funcs
		private async Task resetPassword(string newPassword, Guid userId)
		{
			var updatedUser = await _userManager.FindByIdAsync(userId.ToString());
			var token = await _userManager.GeneratePasswordResetTokenAsync(updatedUser);
			(await _userManager.ResetPasswordAsync(updatedUser,
				token,
				newPassword)).ThrowIfNotSuccess();
		}

		private async Task addToRoleOrCreate(CreateUserModel request, UserDb toCreate)
		{
			if(await _roleManager.FindByNameAsync(request.Role) == null)
			{
				await _roleManager.CreateAsync(new IdentityRole { Name = request.Role });
			}

			(await _userManager.AddToRoleAsync(toCreate, request.Role)).ThrowIfNotSuccess();
		}

		private IQueryable<UserDb> applyOrder(GetUsersModel getUsersModel, IQueryable<UserDb> query)
		{
			if (getUsersModel.Ordering != null && getUsersModel.Ordering.Any())
			{
				foreach (var orderRule in getUsersModel.Ordering)
				{
					Expression<Func<UserDb, object>> expression = x => x.UserName;

					if (orderRule.OrderType is FilterType.Email) expression = x => x.Email;

					if(orderRule.Descending) query = query.OrderByDescending(expression);
					else query = query.OrderBy(expression);
				}
			}

			return query;
		}

		private IQueryable<UserDb> applyPagination(GetUsersModel getUsersModel, IQueryable<UserDb> query)
		{
			if (getUsersModel.Pagination?.Skip != null)
			{
				query = query.Skip(getUsersModel.Pagination.Skip.Value);
			}
			if (getUsersModel.Pagination?.Take != null)
			{
				query = query.Take(getUsersModel.Pagination.Take.Value);
			}

			return query;
		}

		private IQueryable<UserDb> applyFilters(GetUsersModel getUsersModel, IQueryable<UserDb> query)
		{
			if (!string.IsNullOrEmpty(getUsersModel.Filter?.Email))
			{
				query = query.Where(x => x.Email == getUsersModel.Filter.Email);
			}
			if (!string.IsNullOrEmpty(getUsersModel.Filter?.Name))
			{
				query = query.Where(x => x.UserName == getUsersModel.Filter.Name);
			}
			if (!string.IsNullOrEmpty(getUsersModel.Filter?.Role))
			{
				query = query.Join(_context.UserRoles, x => x.Id, x => x.UserId, (user, ur) => new { user, ur.RoleId })
					.Join(_context.Roles, x => x.RoleId, x => x.Id, (ur, role) => new { ur.user, role })
					.Where(x => x.role.Name == getUsersModel.Filter.Role).Select(x => x.user);
			}
			if (getUsersModel.Filter?.Permissions != null && getUsersModel.Filter.Permissions.Any())
			{
				query = query.Where(x => x.Permissions.Any(p => getUsersModel.Filter.Permissions.Contains(p.Id)));
			}


			return query;
		}

		#endregion
	}
}
