﻿namespace DatieAPI.Models
{
    public class CommentModel
    {
        public int IdComment { get; set; }
        public int IdShop { get; set; }
        public string UserName { get; set; }
        public string DateComment { get; set; }
        public string Comment { get; set; }
    }
}