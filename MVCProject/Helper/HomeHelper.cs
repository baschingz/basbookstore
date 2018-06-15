using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCProject.Models;
using MVCProject.Libraries;

namespace MVCProject.Helper
{
    public class HomeHelper
    {
        public int AddBookOrder(BookOrderModel bookOrder)
        {
            return new HomeLibrary().AddBookOrder(bookOrder);
        }

        public bool AddBookOrderDetailL(List<BookOrderDetailModel> bookOrderDetailModels,int orderId)
        {
            return new HomeLibrary().AddBookOrderDetail(bookOrderDetailModels,orderId);
        }

       

    }
}