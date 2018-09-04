using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZZL.MessageBoard.Web.Models
{
    public class MessageViewModel
    {
        [Display(Name ="标题")]
        [Required(ErrorMessage ="留言标题不能为空")]
        public string Title { get; set; }

        [Display(Name ="留言内容")]
        [Required(ErrorMessage ="留言内容不能为空")]
        public string Body { get; set; }
    }
}