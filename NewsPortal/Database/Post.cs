using System;
using System.Collections.Generic;

namespace NewsPortal.Database
{
    public partial class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public string Content { get; set; }
        public int AccountId { get; set; }

        public virtual Account Account { get; set; }
    }
}
