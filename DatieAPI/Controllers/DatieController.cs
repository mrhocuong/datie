using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Http;
using DatieAPI.Models;

namespace DatieAPI.Controllers
{
    public class DatieController : ApiController
    {
        private readonly DatieDBEntities DatieDb = new DatieDBEntities();

        public IEnumerable<DatieModel> GetData()
        {
            var data = DatieDb.tbl_Shop.Where(x=>x.isDelete==false).OrderBy(x => x.id_shop).ToList();
            var dt = new List<DatieModel>();
            data.ForEach(x =>
            {
                var tmp = new DatieModel
                {
                    ShopId = x.id_shop.ToString(),
                    ShopAddress = x.address,
                    ShopDescription = x.description,
                    ShopIsDeleted = x.isDelete,
                    ShopName = x.name,
                    ShopPhone = x.phone,
                    ShopPriceMid = x.price_medium.ToString(),
                    ShopRate = x.averageRate.ToString(),
                    ShopTimeMid = x.time_medium.ToString()
                };
                var tmpImg = ImageLink(x.id_shop).FirstOrDefault();
                if (tmpImg != null)
                {
                    tmp.ThumbnailLink = tmpImg.ImgLink;
                }
                else tmp.ThumbnailLink = "http://i.imgur.com/ftNpsJS.jpg";
                dt.Add(tmp);
            });
            return dt;
        }

        public DatieModel Get(int id)
        {
            var tmpData = DatieDb.tbl_Shop.FirstOrDefault(x => x.id_shop == id);
            var imgList = ImageLink(id);
            if (imgList.Count == 0)
            {
                var tmp = new ImageModel
                {
                    ImgId = 1,
                    ImgLink = "http://i.imgur.com/ftNpsJS.jpg"
                };
                imgList.Add(tmp);
            }
            if (tmpData != null)
            {
                var model = new DatieModel
                {
                    ShopId = tmpData.id_shop.ToString(),
                    ShopAddress = tmpData.address,
                    ShopDescription = tmpData.description,
                    ShopIsDeleted = tmpData.isDelete,
                    ShopName = tmpData.name,
                    ShopPhone = tmpData.phone,
                    ShopPriceMid = tmpData.price_medium.ToString(),
                    ShopRate = tmpData.averageRate.ToString(CultureInfo.CurrentCulture),
                    ShopTimeMid = tmpData.time_medium.ToString(),
                    Image = imgList,
                    District = DistrictName(tmpData.id_district),
                    Food = FoodName(tmpData.id_food)
                };
                return model;
            }
            return null;
        }

        public string DistrictName(int id)
        {
            var data = DatieDb.tbl_District.ToList().Find(x => x.id_district == id);
            return data.district;
        }

        public string FoodName(int id)
        {
            var data = DatieDb.tbl_Main_Course.ToList().Find(x => x.id_food == id);
            return data.name_food;
        }

        public List<ImageModel> ImageLink(int id)
        {
            var data = DatieDb.tbl_Image.Where(x => x.id_shop == id).ToList();
            var imgList = new List<ImageModel>();
            data.ForEach(x =>
            {
                if (!x.isDelete)
                {
                    var tmp = new ImageModel
                    {
                        ImgId = x.id_img,
                        ImgLink = x.url_image
                    };
                    imgList.Add(tmp);
                }
            });
            return imgList;
        }
    }
}