using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
using DatieAPI.Models;

namespace DatieAPI.Controllers
{
    public class RateController : ApiController
    {
        private readonly DatieDBEntities DatieDb = new DatieDBEntities();

        public IEnumerable<RateModel> Get(int id)
        {
            var data = DatieDb.tbl_Rate.Where(x => x.id_shop == id).ToList();
            var dt = new List<RateModel>();
            data.ForEach(x =>
            {
                var tmp = new RateModel
                {
                    IdRate = x.id_rate,
                    IdShop = x.id_shop,
                    UserName = x.usename,
                    Rate = x.rate
                };
                dt.Add(tmp);
            });
            return dt;
        }

        public bool PostRate(RateModel model)
        {
            if (model != null)
            {
                var dt = new tbl_Rate
                {
                    id_shop = model.IdShop,
                    usename = model.UserName,
                    rate = model.Rate
                };
                DatieDb.tbl_Rate.Add(dt);
                var check = DatieDb.SaveChanges();
                if (check > 0)
                {
                    UpdateRatePoint(model.IdShop);
                    return true;
                }
            }

            return false;
        }

        public bool UpdateRatePoint(int id)
        {
            var data = DatieDb.tbl_Rate.Where(x => x.id_shop == id).ToList();
            double point = 0;
            foreach (var p in data)
            {
                point += p.rate;
            }
            point = point/data.Count;

            var shop = DatieDb.tbl_Shop.ToList().Find(x => x.id_shop == id);
            if (shop != null)
            {
                shop.averageRate = point;
                DatieDb.Entry(shop).State = EntityState.Modified;
                var check = DatieDb.SaveChanges();
                if (check > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}