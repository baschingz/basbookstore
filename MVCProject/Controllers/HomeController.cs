using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.Models;
using MVCProject.Helper;

namespace MVCProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        protected  HomeHelper homehlep = new HomeHelper();

        public ActionResult AddBookOrder(BookOrderModel bookOrder , List<BookOrderDetailModel> bookOrderDetailList)
        {
            try
            {
                var orderId = homehlep.AddBookOrder(bookOrder);
                if (orderId > 0)
                {
                    //var List = homehlep.GetBookOrder(bookOrder, bookOrderDetailList);
                    var list = AddBookOrderDetail(bookOrderDetailList, orderId);
                    return Json(list, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public bool AddBookOrderDetail(List<BookOrderDetailModel> bookOrderDetailList,int orderId)
        {
            try
            {
                var check = homehlep.AddBookOrderDetailL(bookOrderDetailList,orderId);
                if (check)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }

}