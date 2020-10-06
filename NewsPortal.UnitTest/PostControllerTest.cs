using Microsoft.AspNetCore.Mvc;
using NewsPortal.Controllers;
using NewsPortal.Services;
using NewsPortal_CL;
using NewsPortal_CL.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace NewsPortal.UnitTest
{
    public class PostControllerTest
    {
        private PostController _controller;
        private ICRUDService<MPost, PostSearchRequest, PostUpdateRequest, PostInsertRequest> _service;

        public PostControllerTest()
        {   
           

            _service = new PostServiceFake<MPost,PostSearchRequest, PostUpdateRequest, PostInsertRequest>();
            _controller = new PostController(_service);


        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetAll();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.GetAll().Result as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<MPost>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }
        [Fact]
        public void GetById_NonExistingIdPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.GetById(8);
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }
       
        [Fact]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
           
            // Act
            var okResult = _controller.GetById(1).Result as OkObjectResult;
            // Assert
            Assert.IsType<MPost>(okResult.Value);
            Assert.Equal(1, (okResult.Value as MPost).PostId);
        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnsOk()
        {
            // Arrange
            var testItem = new PostInsertRequest()
            {
                Content = "Bananas",
                Title = "Newss",
                PublishDate = DateTime.Now,
                AccountId = 1
            };
            // Act
            var createdResponse = _controller.Insert(testItem);
            // Assert
            Assert.IsType<OkObjectResult>(createdResponse.Result);
        }

        [Fact]
        public void Update_ValidIdPassed_ReturnsOk()
        {
            // Arrange


            var testItem = new PostUpdateRequest()
            {
                Content = "Bananas",
                Title = "Newss",
                PublishDate = DateTime.Now,
                AccountId = 1
            };
            // Act
            var createdResponse = _controller.Update(1, testItem);
            // Assert
            Assert.IsType<OkObjectResult>(createdResponse.Result);
        }
        [Fact]
        public void Update_InValidIdPassed_ReturnsOk()
        {
            // Arrange


            var testItem = new PostUpdateRequest()
            {
                Content = "Bananas",
                Title = "Newss",
                PublishDate = DateTime.Now,
                AccountId = 1
            };
            // Act
            var createdResponse = _controller.Update(89, testItem);
            // Assert
            Assert.IsType<NotFoundResult>(createdResponse.Result);
           
        }


        [Fact]
        public void Remove_ExistingGuidPassed_RemovesOneItem()
        {
            // Act
            var okResponse = _controller.Delete(1);
            // Assert
            Assert.Equal(2, _service.GetAll(null).Count());
        }
    }
}
