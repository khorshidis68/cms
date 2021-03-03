using CmsProject.Utilities.Payment;
using CmsProject.ViewModel.Payment;
using Microsoft.AspNetCore.Mvc;

namespace CmsProject.WebCore.Controllers
{
    public class ReceivePaymentController : Controller
    {
        public IActionResult Index() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Index")]
        public IActionResult ReceivePaymentNo(ReceivePaymentNoViewModel objectPayNo)
        {
            if (ModelState.IsValid)
            {
                if (objectPayNo.StudentNo != null)
                {
                    string pNo = StudentPayment.GetPayment(objectPayNo.StudentNo);
                    ViewData["pNo"] = pNo;
                    return View("Index", objectPayNo);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(objectPayNo);
        }
    }
}