using Business.Repository;
using DataAccess.Context;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebUI.Controllers
{
    public class HomeController : Controller
    {
        BaseRepository<Product> _productRepository = new BaseRepository<Product>();
        ProjectDbContext db = new ProjectDbContext();

        public ActionResult Index()
        {
            var model = _productRepository.GetAll();
            return View(model);
        }

        public ActionResult AddToCart(Guid id)
        {
            Product eklenecek = db.Products.Find(id);

            #region First method
            //Cart c = null;

            //if (Session["cart"] == null)
            //{
            //    c = new Cart();
            //}
            //else
            //{
            //    c = Session["cart"] as Cart;
            //} 
            #endregion

            #region Second method, ternary
            //Cart creation
            //Ternary, single line if statement
            // ? means if. This statement is saying, if Session cart is null make new cart, if its not (:) make a cart then put it in Cart c
            Cart c = Session["cart"] == null ? new Cart() : Session["cart"] as Cart;
            #endregion
            //cart item creation
            CartItem cartItem = new CartItem();
            cartItem.ID = eklenecek.MasterId;
            cartItem.UnitPrice = eklenecek.UnitPrice;
            cartItem.Name = eklenecek.ProductName;
            cartItem.UnitsInStock = eklenecek.UnitsInStock;
            //session creation
            c.AddItem(cartItem);
            Session["cart"] = c;

            return RedirectToAction("Index");
        }

        public ActionResult DeleteFromCart(int id)
        {
            Product silinecek = db.Products.Find(id);

            Cart c = Session["cart"] == null ? new Cart() : Session["cart"] as Cart;

            CartItem cartItem = new CartItem();
            cartItem.ID = silinecek.MasterId;

            c.DeleteItem(cartItem);
            Session["cart"] = c;

            return RedirectToAction("Index", "Cart");
        }

    
    }
}