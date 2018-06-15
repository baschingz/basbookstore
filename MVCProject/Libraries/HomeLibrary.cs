using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCProject.Entities;
using MVCProject.Models;

namespace MVCProject.Libraries
{
    
    public class HomeLibrary
    {
        mvc_projectEntities db = new mvc_projectEntities();

        public book_order Mapping(BookOrderModel bs)
        {
            try
            {
                book_order bsm = new book_order();
                if (bs != null)
                {
                    bsm.book_order_id = bs.book_order_id;
                    bsm.cus_id = bs.cus_id;
                    bsm.book_status_code = bs.book_status_code;
                    bsm.book_order_total = bs.book_order_total;
                    bsm.book_order_date = bs.book_order_date;
                    return bsm;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<book_order_detail> Mapping(List<BookOrderDetailModel> bslist)
        {
            try
            {
                if (bslist != null && bslist.Count > 0)
                {
                    List<book_order_detail> bsmlist = new List<book_order_detail>();
                    foreach (BookOrderDetailModel bs in bslist)
                    {
                        book_order_detail bsm = new book_order_detail();
                        bsm.book_order_detail_id = bs.book_order_detail_id;
                        bsm.book_order_id = bs.book_order_id;
                        bsm.book_product_id = bs.book_product_id;
                        bsm.book_order_detail_price = bs.book_order_detail_price;
                        bsm.book_order_detail_qty = bs.book_order_detail_qty;
                        bsmlist.Add(bsm);
                    }
                    return bsmlist;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        IQueryable<book_order> GetOrder()
        {
            return db.book_order;
        }
        public int AddBookOrder(BookOrderModel bs)
        {
            try
            {
                if (bs != null)
                {
                    if (GetOrder().Where(obj => obj.book_order_id == bs.book_order_id).ToList().Count == 0)
                    {
                        book_order brDb = new book_order();
                        brDb.cus_id = bs.cus_id;
                        brDb.book_status_code = bs.book_status_code;
                        brDb.book_order_total = bs.book_order_total;
                        brDb.book_order_date = DateTime.Today;
                        db.book_order.Add(brDb);
                        db.SaveChanges();
                        
                            return brDb.book_order_id;
                        }                                           
                    
                    return 0;
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public bool AddBookOrderDetail(List<BookOrderDetailModel> bookOrderDetailModels, int orderId)
        {
            try
            {
                if (bookOrderDetailModels.Count > 0 && orderId != 0)
                {
                    foreach (BookOrderDetailModel brd in bookOrderDetailModels)
                    {
                        book_order_detail bod = new book_order_detail();
                        bod.book_order_id = orderId;
                        bod.book_product_id = brd.book_product_id;
                        bod.book_order_detail_price = brd.book_order_detail_price;
                        bod.book_order_detail_qty = brd.book_order_detail_qty;
                        db.book_order_detail.Add(bod);
                        db.SaveChanges();
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}