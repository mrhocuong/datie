using System.Collections.Generic;

namespace DatieAPI.Models
{
    public class DatieModel
    {
        public string ShopId { get; set; }
        public string ShopName { get; set; }
        public string ShopAddress { get; set; }
        public string District { get; set; }
        public string Food { get; set; }
        public string ShopPhone { get; set; }
        public string ShopDescription { get; set; }
        public string ShopPriceMid { get; set; }
        public string ShopTimeMid { get; set; }
        public bool ShopIsDeleted { get; set; }
        public string ShopRate { get; set; }
        public IEnumerable<ImageModel> Image { get; set; }
        public string ThumbnailLink { get; set; }
    }

    public class ImageModel
    {
        public int ImgId { get; set; }
        public string ImgLink { get; set; }
    }
}