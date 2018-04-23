using System.Web.Mvc;

namespace GridViewExpandedGroupRowsStateMvc {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult GridViewPartial(string customAction) {
            ViewData["actionToPerform"] = customAction;
            return PartialView();
        }
    }
}