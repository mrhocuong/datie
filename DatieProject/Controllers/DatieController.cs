using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
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

        #region Add

        public PartialViewResult AddShop()
        {
            var model = new DatieModel();
            var district = GetDistrictModels();
            var food = GetFoodModels();
            model.DistrictList = district;
            model.Food = food;
            return PartialView(model);
        }

        [HttpPost]
        public JsonResult Add(DatieModel model)
        {
            var dt = _datieDb.tbl_Shop.ToList().Find(x => x.id_shop.ToString() == model.ShopId);
            if (dt == null)
            {
                var data = new tbl_Shop
                {
                    name = model.ShopName,
                    address = model.ShopAddress,
                    description = model.ShopDescription,
                    averageRate = Convert.ToDouble(model.ShopRate),
                    phone = model.ShopPhone,
                    price_medium = Convert.ToDouble(model.ShopPriceMid),
                    time_medium = Convert.ToDouble(model.ShopTimeMid),
                    id_district = Convert.ToInt32(model.DistrictId),
                    id_food = Convert.ToInt32(model.FoodId),
                    isDelete = false
                };
                _datieDb.tbl_Shop.Add(data);
                var check = _datieDb.SaveChanges();
                if (check > 0)
                {
                    return Json(new {success = true}, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new {success = false}, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Edit

        public PartialViewResult EditShop(int id)
        {
            var data = CreateModel(id);
            return PartialView(data);
        }

        [HttpPost]
        public JsonResult EditShop(DatieModel model)
        {
            var data = _datieDb.tbl_Shop.ToList().Find(x => x.id_shop.ToString() == model.ShopId);
            if (data != null)
            {
                data.name = model.ShopName;
                data.address = model.ShopAddress;
                data.description = model.ShopDescription;
                //data.averageRate = Convert.ToDouble(model.ShopRate);
                data.phone = model.ShopPhone;
                data.price_medium = Convert.ToDouble(model.ShopPriceMid);
                data.time_medium = Convert.ToDouble(model.ShopTimeMid);
                data.id_district = Convert.ToInt32(model.DistrictId);
                data.id_food = Convert.ToInt32(model.FoodId);
                data.isDelete = model.ShopIsDeleted;
                _datieDb.Entry(data).State = EntityState.Modified;
                var check = _datieDb.SaveChanges();
                if (check > 0)
                {
                    return Json(new {success = true}, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new {success = false}, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Get Data

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

            return Json(new {data = dt.OrderBy(x => x.ShopId)}, JsonRequestBehavior.AllowGet);
        }

        public DatieModel CreateModel(int id)
        {
            var tmpData = _datieDb.tbl_Shop.ToList().Find(x => x.id_shop == id);
            var district = GetDistrictModels();
            var food = GetFoodModels();
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
                DistrictList = district,
                Food = food,
                DistrictId = tmpData.id_district.ToString(),
                FoodId = tmpData.id_food.ToString()
            };
            return model;
        }

        public List<DistrictModel> GetDistrictModels()
        {
            var data = _datieDb.tbl_District.ToList();
            var district = new List<DistrictModel>();
            data.ForEach(x =>
            {
                var tmp = new DistrictModel
                {
                    DistrictId = x.id_district,
                    DistrictName = x.district
                };
                district.Add(tmp);
            });
            return district;
        }

        public List<FoodModel> GetFoodModels()
        {
            var data = _datieDb.tbl_Main_Course.ToList();
            var food = new List<FoodModel>();
            data.ForEach(x =>
            {
                var tmp = new FoodModel
                {
                    FoodId = x.id_food,
                    FoodName = x.name_food
                };
                food.Add(tmp);
            });
            return food;
        }

        #endregion

        #region Attach Image
        public ActionResult Image()
        {
            return View();
        }
        #endregion
    }
}