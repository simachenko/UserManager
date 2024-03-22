using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Domain.Interfaces;
using UserManager.Domain.Models.Permissions;
using UserManager.Domain.Requests;
using UserManager.Infrastructure.DataAccess.Models;

namespace UserManager.Infrastructure.DataAccess.Repos
{
	internal class PermissionsRepository : IPermissionsRepository
	{
		private readonly UserManagerContext _context;
		private readonly IMapper _mapper;

		public PermissionsRepository(IMapper mapper, UserManagerContext context)
		{
			_mapper = mapper;
			_context = context;
		}

		public async Task<Permission> CreatePermission(Permission request)
		{
			var toCreate = _mapper.Map<PermissionDb>(request);
			_context.Permissions.Add(toCreate);
			await _context.SaveChangesAsync();
			return _mapper.Map<Permission>(toCreate);
		}

		public Task DeletePermission(Guid? id)
		{
			return _context.Permissions.Where(x => x.Id == id).ExecuteDeleteAsync();
		}

		public async Task<List<Permission>> GetAvailablePermissions()
		{
			return _mapper.Map<List<Permission>>(await _context.Permissions.AsNoTracking().ToListAsync());
		}
	}
}
