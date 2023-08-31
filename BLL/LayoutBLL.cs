using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LayoutBLL
    {
        CategoryDAO categorydao = new CategoryDAO();
        SocialMediaDAO socialdao = new SocialMediaDAO();
        FavDAO favdao = new FavDAO();
        MetaDAO metadao = new MetaDAO();
        AddressDAO addressdao = new AddressDAO();
        PostDAO postdao = new PostDAO();
        public HomeLayoutDTO GetLayoutData()
        {
            HomeLayoutDTO dto = new HomeLayoutDTO();
            dto.Categories = categorydao.GetCategories();
            List<SocialMediaDTO> socialmedialist = new List<SocialMediaDTO>();
            socialmedialist = socialdao.GetSocialMedias();
            dto.Github = socialmedialist.First(x => x.Link.Contains("github"));
            dto.Linkedin = socialmedialist.First(x => x.Link.Contains("linkedin"));
            dto.Facebook = socialmedialist.First(x => x.Link.Contains("facebook"));
            dto.Instagram = socialmedialist.First(x => x.Link.Contains("me"));
            dto.Twitter = socialmedialist.First(x => x.Link.Contains("twitter"));
            dto.FavDTO = favdao.GetFav();
            dto.Metalist = metadao.GetMetaData();
            List<AddressDTO> addresslist = addressdao.GetAddresses();
            dto.Address = addresslist.First();
            dto.HotNews = postdao.GetHotNews();


            return dto;
        }
    }
}
