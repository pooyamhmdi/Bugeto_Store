using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common;

namespace Bugeto_Store.Application.Services.Users.Queries.GetUsers
{
    public partial class GetUsersService : IGetUsersService
    {
        private readonly IDatabaseContext _context;
        public GetUsersService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultGetUsersDto Execute(RequestGetUsersDto request)
        {
            var users = _context.Users.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                users = users.Where(p => p.FullName.Contains(request.SearchKey) && p.Email.Contains(request.SearchKey));
            }
            int RowCount = 0;
            var UsersList =users.ToPaged(request.Page, 20, out RowCount).Select(p => new GetUsersDto
            {
                Id = p.Id,
                FullName = p.FullName,
                Email = p.Email,
                IsActive = p.IsActive,
            }).ToList();
            return new ResultGetUsersDto
            {
                Rows = RowCount,
                Users = UsersList,
            };
        }
    }
}
