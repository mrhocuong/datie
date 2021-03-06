﻿using System;
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
            if (model == null) return false;
            var tmp = DatieDb.tbl_Rate.ToList().Find(x => x.usename == model.UserName && x.id_shop == model.IdShop);
            if (tmp != null)
            {
                tmp.rate = model.Rate;
                DatieDb.Entry(tmp).State = EntityState.Modified;
                var ck = DatieDb.SaveChanges();
                if (ck <= 0) return false;
                UpdateRatePoint(model.IdShop);
                return true;
            }
            var dt = new tbl_Rate
            {
                id_shop = model.IdShop,
                usename = model.UserName,
                rate = model.Rate
            };
            DatieDb.tbl_Rate.Add(dt);
            var check = DatieDb.SaveChanges();
            if (check <= 0) return false;
            UpdateRatePoint(model.IdShop);
            return true;
        }

        public bool UpdateRatePoint(int id)
        {
            var data = DatieDb.tbl_Rate.Where(x => x.id_shop == id).ToList();
            var point = data.Sum(p => p.rate);
            point = point/data.Count;
            var shop = DatieDb.tbl_Shop.ToList().Find(x => x.id_shop == id);
            if (shop == null) return false;
            shop.averageRate = Math.Round(point, 1);
            DatieDb.Entry(shop).State = EntityState.Modified;
            var check = DatieDb.SaveChanges();
            return check > 0;
        }
    }
}