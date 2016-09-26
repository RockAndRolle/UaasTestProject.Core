using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Umbraco.Web.WebApi;
using UaasTestProject.Core.Models;

/*
 * Added System.Web.Http (5.2.3.0)
 * Install-Package Microsoft.AspNet.WebApi.Core -version 5.2.3
 * */
namespace UaasTestProject.Core.Controllers
{
    public class CommentsApiController : UmbracoApiController
    {
        // http://localhost:3478/umbraco/api/CommentsApi/GetComments
        public IEnumerable<Comment> GetComments()
        {
            var allComments = Services.ContentService.GetContentOfContentType(1073);
            var comments = new List<Comment>();

            foreach(var comment in allComments)
            {
                Comment tempComment = new Comment();
                tempComment.Name = comment.Name;
                tempComment.Email = comment.GetValue<string>("email");
                tempComment.Message = comment.GetValue<string>("message");
                comments.Add(tempComment);
            }
            
            return comments.AsEnumerable();
        }
    }
}
