using Bugeto_Store.Domain.Entities.HomePages;

namespace Bugeto_Store.Application.Services.HomePages.Queries.GetHomePageImagesForAdmin
{
    public class GetHomePageImagesDto
    {
        public long Id { get; set; }
        public string Src { get; set; }
        public string Link { get; set; }
        public ImageLocation ImageLocationInSite { get; set; }
    }

}
