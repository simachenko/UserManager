using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Domain.Models.CreateModels;
using UserManager.Domain.Models.GetModels;
using UserManager.Domain.Models.Permissions;
using UserManager.Domain.Models.UpdateModels;
using UserManager.Domain.Requests;
using UserManager.DTO.GetUsers;
using UserManager.DTO.MutateUser;
using UserManager.DTO.Permissions;
using UserManager.Infrastructure.DataAccess.Models;

namespace UserManager.Domain.Converter
{
	internal class ConvertingProfile : Profile
	{
		public ConvertingProfile()
		{
			#region permissions

			CreateMap<Permission, GetPermissionResultDto>().ReverseMap();
			CreateMap<Permission, PermissionDb>().ReverseMap();
			CreateMap<Permission, GetPermissionResultDto>();
			CreateMap<Permission, GetPermissionResultDto>();
			CreateMap<PermissionDb, GetPermissionResultModel>();
			CreateMap<GetPermissionResultModel, GetPermissionResultDto>();
			#endregion

			#region users

			CreateMap<GetUsersDto, GetUsersQuery>();
			CreateMap<UserFilterDto, UserFilter>();
			CreateMap<PaginationDto, Pagination>();
			CreateMap<OrderingDto, Ordering>();
			CreateMap<FilterTypeDto, FilterType>();

			CreateMap<UserDb, GetUserResult>()
				.ForMember(x => x.Name, x => x.MapFrom(x => x.UserName));
			CreateMap<GetUserResult, GetUserResultDto>();

			CreateMap<MutateUserDto, CreateUserCommand>();
			CreateMap<MutateUserDto, UpdateUserCommand>();
			
			CreateMap<CreateUserModel, UserDb>()
				.ForMember(x => x.UserName, x => x.MapFrom(x => x.Name))
				.ForMember(x => x.Permissions, x => x.MapFrom(x => x.Permissions.Select(p => new PermissionDb() { Id = p })));
			CreateMap<UpdateUserModel, UserDb>()
				.ForMember(x => x.UserName, x => x.MapFrom(x => x.Name))
				.ForMember(x => x.Permissions, x => x.MapFrom(x => x.Permissions.Select(p => new PermissionDb() { Id = p })));

			#endregion
		}
	}
}
