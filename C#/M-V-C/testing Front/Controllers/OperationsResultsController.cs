using Microsoft.AspNetCore.Mvc;

namespace testing_Front.Controllers
{
    public class OperationsResultsController : Controller
    {
        public IActionResult Index()
        {
            //Success for loading money, error is handled in the same view...

            string? operationLoadMoney = HttpContext.Session.GetString("LoadMoneyOperation");
            string? operationBuy = HttpContext.Session.GetString("BuyOperation");
            if (operationLoadMoney != "" && operationLoadMoney != null )
            {
                ViewBag.operationLoadMoney = $"La carga de {operationLoadMoney}$ ha sido procesada correctamente";
                HttpContext.Session.SetString("LoadMoneyOperation", "");
            } else if (operationBuy != "" && operationBuy != "No se pudo procesar la operación por falta de saldo" && operationBuy != null)
            {
                ViewBag.buyOperation = $"La compra de {operationBuy}$ ha sido procesada correctamente";
                HttpContext.Session.SetString("BuyOperation", "");
            } else if (operationBuy == "No se pudo procesar la operación por falta de saldo")
            {
                ViewBag.buyOperationError = operationBuy;
                HttpContext.Session.SetString("BuyOperation", "");
            }

            // Success for buying


            //Case of the method "RealizeOffer"...


            string? offerValue = HttpContext.Session.GetString("OfferValue");
            string? offerSuccess = HttpContext.Session.GetString("OfferSuccess");
            string? offerError = HttpContext.Session.GetString("OfferError");

            if (!string.IsNullOrEmpty(offerValue) && !string.IsNullOrEmpty(offerSuccess))
            {
                ViewBag.offerValue = offerValue;
                ViewBag.offerSuccess = offerSuccess;

                HttpContext.Session.SetString("OfferValue", "");
                HttpContext.Session.SetString("OfferSuccess", ""); 
            }

            if (!string.IsNullOrEmpty(offerError)) 
            {
                ViewBag.offerError = offerError;
                HttpContext.Session.SetString("OfferError", ""); 
            }


            return View();
        }
    }
}
