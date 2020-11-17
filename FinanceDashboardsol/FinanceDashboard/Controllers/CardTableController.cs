using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FinanceDashboard.Models;
using FinanceDashboard.Productspurchased;

namespace FinanceDashboard.Controllers
{
    public class CardTableController : ApiController
    {
        private FinanceEntities db = new FinanceEntities();

        // GET: api/CardTable
        public IQueryable<CardTable> GetCardTables()
        {
            return db.CardTables;
        }

        // GET: api/CardTable/Name
        [ResponseType(typeof(CardTable))]
        //[Route("CardTable/Name")]
        public IHttpActionResult GetCardTable(long id)
        {
            CardTable cardTable = db.CardTables.Find(id);
            if (cardTable == null)
            {
                return NotFound();
            }

            return Ok(cardTable);
        }

        [ResponseType(typeof(Productpurchase))]
        [Route("api/CardTable/GetProducts")]
        public IEnumerable<Productpurchase> GetProductspurchased()
        {
            List<Productpurchase> productslist = new List<Productpurchase>();
            var pl = (from p in db.Products
                      join od in db.OrderDetails on
                      p.ProductID equals od.ProductID
                      join o in db.Orders on od.OrderID
                      equals o.OrderID
                      select new { od.OrderID,p.ProductName, od.TotalAmount, o.BillAmountperMonth, Balance = od.TotalAmount - o.BillAmountperMonth }

                    ).ToList();
            foreach (var item in pl)
            {
                Productpurchase objpl = new Productpurchase();
                objpl.OrderID = item.OrderID;
                objpl.ProductName=item.ProductName;
                objpl.TotalAmount = item.TotalAmount;
                objpl.BillAmountperMonth = item.BillAmountperMonth;
                objpl.Balance = item.Balance;

                productslist.Add(objpl);

            }
            return productslist;
        }
        [Route("api/CardTable/GetTransactions")]
        public IEnumerable<RecentTransaction> GetRecenttransactions()
        {
            List<RecentTransaction> transactionlist = new List<RecentTransaction>();
            var tl = (from p in db.Products
                      join od in db.OrderDetails on
                      p.ProductID equals od.ProductID
                      join o in db.Orders on od.OrderID
                      equals o.OrderID
                      select new { od.OrderID, p.ProductName, o.OrderDate,od.TotalAmount}

                    ).ToList();
            foreach (var item in tl)
            {
                RecentTransaction objtl = new RecentTransaction();
                objtl.OrderID = item.OrderID;
                objtl.ProductName = item.ProductName;
                objtl.OrderDate = item.OrderDate;
                objtl.TotalAmount = item.TotalAmount;

                transactionlist.Add(objtl);

            }
            return transactionlist;
        }


    }
}