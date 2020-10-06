using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewsPortal_CL
{
    public class MPost
    {
        public int PostId { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public string Content { get; set; }
        public int AccountId { get; set; }

        public virtual MAccount Account { get; set; }
    }
}
