using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DatieProject.Models;

namespace DatieProject.Controllers
{
    public class DatieController : Controller
    {
        private readonly DatieDBEntities _datieDb = new DatieDBEntities();
        //
        // GET: /Datie/
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult AddShop()
        {
            return PartialView();
        }
        public JsonResult GetData()
        {
            var data = _datieDb.tbl_Shop.ToList();
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
                dt.Add(tmp);
            });

            return Json(new {data = dt.OrderBy(x=>x.ShopId)}, JsonRequestBehavior.AllowGet);
        }
    }
}