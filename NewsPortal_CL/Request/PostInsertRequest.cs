using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal_CL.Request
{
    public class PostInsertRequest
    {
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public string Content { get; set; }
        public int AccountId { get; set; }
    }
}
