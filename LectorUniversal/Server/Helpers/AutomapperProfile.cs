using AutoMapper;
using LectorUniversal.Shared;

namespace LectorUniversal.Server.Helpers
{
    public class AutomapperProfile: Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Book, Book>()
                .ForMember(x => x.Cover, option => option.Ignore());

            CreateMap<Shared.Pages, Shared.Pages>()
                .ForMember(x => x.ImageUrl, option => option.Ignore());
        }
    }
}
