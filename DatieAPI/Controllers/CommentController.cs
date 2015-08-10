using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DatieAPI.Models;

namespace DatieAPI.Controllers
{
    public class CommentController : ApiController
    {
        private readonly DatieDBEntities DatieDb = new DatieDBEntities();

        public IEnumerable<CommentModel> Get(int id)
        {
            var data = DatieDb.tbl_Comment.Where(x => x.id_shop == id).ToList();
            var dt = new List<CommentModel>();
            data.ForEach(x =>
            {
                var tmp = new CommentModel
                {
                    IdComment = x.id_cmt,
                    IdShop = x.id_shop,
                    UserName = x.username,
                    Comment = x.comment,
                    DateComment = x.date_cmt
                };
                dt.Add(tmp);
            });
            return dt;
        }

        public bool PostComment(CommentModel model)
        {
            if (model != null)
            {
                var dt = new tbl_Comment
                {
                    id_shop = model.IdShop,
                    username = model.UserName,
                    comment = model.Comment,
                    date_cmt = DateTime.Now
                };
                DatieDb.tbl_Comment.Add(dt);
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