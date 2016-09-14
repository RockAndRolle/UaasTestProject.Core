using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.Mvc;
using UaasTestProject.Core.Models;
using Umbraco.Web.Mvc;

namespace UaasTestProject.Core.Controllers
{
    public class CommentController : SurfaceController
    {
        public ActionResult Submit(CommentModel model)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            //create comment
            var contentService = Services.ContentService;
            var newComment = contentService.CreateContent(model.Name, CurrentPage.Id, "Comment");
            newComment.SetValue("firstName", model.Name);
            newComment.SetValue("email", model.Email);
            newComment.SetValue("message", model.Comment);

            Services.ContentService.SaveAndPublishWithStatus(newComment);

            TempData["success"] = true;

            return RedirectToCurrentUmbracoPage();
        }
    }
}
