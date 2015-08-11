using System.Collections.Generic;
using System.Net.Http.Formatting;
using System.Web;

namespace DatieProject.Models
{
    public class DatieModel
    {
        public string ShopId { get; set; }
        public string ShopName { get; set; }
        public string ShopAddress { get; set; }
        public string DistrictId { get; set; }
        public string FoodId { get; set; }
        public string ShopPhone { get; set; }
        public string ShopDescription { get; set; }
        public string ShopPriceMid { get; set; }
        public string ShopTimeMid { get; set; }
        public bool ShopIsDeleted { get; set; }
        public string ShopRate { get; set; }
        public IEnumerable<DistrictModel> DistrictList { get; set; }
        public IEnumerable<FoodModel> Food { get; set; }
        public HttpPostedFileBase ImgCollection { get; set; }
    }
}