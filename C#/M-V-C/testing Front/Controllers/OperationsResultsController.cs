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
            
            return View();
        }
    }
}
