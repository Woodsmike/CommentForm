using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommentForm.Models
{
    public class Procedure
    {
        [Key]
        public int ProcedureID { get; set; }
        public string Title { get; set; }
        public int Priority { get; set; }
        public string Details { get; set; }

    }
}