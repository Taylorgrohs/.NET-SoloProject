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
        public void GetCommentTest()
        {

            var comment = new Comment();
            comment.CommentBody = "Test";

            var result = comment.CommentBody;

            Assert.Equal("Test", result);

        }
    }
}
