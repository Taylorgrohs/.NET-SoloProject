using SoloProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SoloProject.Tests
{
    public class PostTest
    { 
        [Fact]
        public void GetContentTest()
        {
            //Arrange
            var post = new Post();
            post.Content = "Wash the dog";
            //Act
            var result = post.Content;

            //Assert
            Assert.Equal("Wash the dog", result);
        }
        [Fact]
        public void GetComment()
        {
            var post = new Post();
            post.Content = "Today";
            post.PostId = 1;
            var comment = new Comment();
            comment.CommentBody = "Test";
            comment.PostId = 1;


        }
    }
}
