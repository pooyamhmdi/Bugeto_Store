namespace Bugeto_Store.Application.Services.Users.Queries.GetUsers
{
    public partial class GetUsersService
    {
        public class ResaultGetUsersDto
        {
            public List<GetUsersDto> Users { get; set; }
            public int Rows { get; set; }
        }
    }
}
