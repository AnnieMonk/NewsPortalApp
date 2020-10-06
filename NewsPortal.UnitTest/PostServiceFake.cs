using NewsPortal.Services;
using NewsPortal_CL;
using NewsPortal_CL.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsPortal.UnitTest
{
    public class PostServiceFake<TModel, TSearch, TUpdate, TInsert> : ICRUDService<MPost, PostSearchRequest, PostUpdateRequest, PostInsertRequest>
    {
        private readonly List<MPost> _posts;
       
        public PostServiceFake()
        {
           
            _posts = new List<MPost>()
            {
                new MPost(){ PostId = 1, AccountId =1, Content="Oranges", Title ="Post 1", PublishDate = DateTime.Now, Account = new MAccount{ AccountId=1, DateCreated=DateTime.Now, Username= "Test1", PassHash="cVMuQIPeei+fe/aH5HBASqnh+tA=", PassHsalt= "W3Sc2mwTuWNPaGcc/0zQcw==", UserId =1, User = new MUser{ Email ="string", Fname="Name", Lname="Name", Phone="12131421", UserId =1
                 } } },
                new MPost(){ PostId = 2, AccountId =2, Content="Apples", Title ="Post 2", PublishDate = DateTime.Now, Account = new MAccount{ AccountId=2, DateCreated=DateTime.Now, Username= "Test1", PassHash="cVMuQIPeei+fe/aH5HBASqnh+tA=", PassHsalt= "W3Sc2mwTuWNPaGcc/0zQcw==", UserId =2, User = new MUser{ Email ="string", Fname="Name", Lname="Name", Phone="12131421", UserId =1 } } } ,
                new MPost(){ PostId = 3, AccountId =1, Content="Grapes", Title ="Post 3", PublishDate = DateTime.Now, Account = new MAccount{ AccountId=1, DateCreated=DateTime.Now, Username= "Test1", PassHash="cVMuQIPeei+fe/aH5HBASqnh+tA=", PassHsalt= "W3Sc2mwTuWNPaGcc/0zQcw==", UserId =1, User = new MUser { Email = "string", Fname = "Name", Lname = "Name", Phone = "12131421", UserId = 1 }  } },
            };

            
        }

        public MPost Delete(int id)
        {
            MPost entity = _posts.Where(i=>i.PostId == id).FirstOrDefault();

            _posts.Remove(entity);

            return entity;
        }

        public List<MPost> GetAll(PostSearchRequest search)
        {
            List<MPost> returning = new List<MPost>();
            if (search != null)
                returning = _posts
                    .Where(i => i.Account.Username == search.Username)
                    .ToList();

            returning = _posts.ToList();
            return returning;
        }

        public MPost GetById(int id)
        {
            return _posts.Where(a => a.PostId == id).FirstOrDefault();
        }

        public MPost Insert(PostInsertRequest request)
        {
            
            MPost newPost = new MPost
            {
                AccountId = request.AccountId,
                Content = request.Content,
                PublishDate = request.PublishDate,
                Title = request.Title
            };

            _posts.Add(newPost);

            return newPost;
        }

        public MPost Update(int id, PostUpdateRequest request)
        {
            var found = _posts.Where(i => i.PostId == id).FirstOrDefault();

            MPost updatePost = new MPost
            {
                PostId = found.PostId,
                AccountId = found.AccountId,
                Content = found.Content,
                PublishDate = found.PublishDate,
                Title = found.Title
            };

            return found;

        }
    }
}
