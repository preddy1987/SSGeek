using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSGeek.Web.DAL;
using SSGeek.Web.Models;
using SessionControllerData;

namespace SSGeek.Web.Controllers
{
    public class StoreController : SessionController
    {
        /* Steps
           1. (StoreController)    Create Index Action for store/index
           2. (Index View)         Create Index View for store/index
           TEST
           3. (Global.asax)        Configure DI container to inject IProductDAL > FakeProductDAL
           4. (StoreController)    Enable constructor injection for IProductDAL
           5. (StoreController)    Update Index Action to pass products
           6. (Index View)         Display Products
           TEST
           7. (Index View)         Add Form Tag w/ AddToCart button > POST to store/index
                                   Pass Product Id in Form
           8. (StoreController)    Create POST Index Action for store/index, accept product id & 
                                   redirect to store/viewcart            
           9. (StoreController)    Create ViewCart action for store/viewcart
           10.(ViewCart View)      Display empty View Cart View
           TEST
           11.(StoreController)    POST store/index: retrieve product and add to active
                                   shopping cart
           12.(ShoppingCart)       Create Shopping Cart class to add Product & Quantity
           13.(StoreController)    Guarantee ShoppingCart is in session, create if not
           14.(StoreController)    POST store/index: Update shopping cart with new product
           15.(StoreController)    GET store/viewcart: Retrieve shoping cart from session
           16.(ViewCart View)      Bind go ShoppingCart and disply each product in it
       */

        IProductDAL dal;
        public StoreController(IProductDAL dal)
        {
            this.dal = dal;
        }

        public ActionResult Index()
        {
            var products = dal.GetAllProducts();

            return View(products);
        }

        public ActionResult Detail(int id = 1)
        {
            return View(dal.GetProduct(id));
        }

        [HttpPost]
        public ActionResult AddToCart(int id, int quantity)
        {
            // Add whichever Product productId represents to the shopping cart

            //1.  Get the Product associated with id
            var product = dal.GetProduct(id);

            //2.  Add Product, qty 1 to our active shopping cart
            ShoppingCart cart = GetActiveShoppingCart();
            cart.AddToCart(product, quantity);

            //3. Save shopping cart
            SaveActiveShoppingCart(cart);

            return RedirectToAction("ViewCart");
        }


        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Get the product associated with the id
            var product = dal.GetProduct(id);

            // Find the active shopping cart
            var cart = GetActiveShoppingCart();

            // Remove Qty 1 of product from shopping cart
            cart.RemoveOne(product);

            // Save shopping cart
            SaveActiveShoppingCart(cart);

            // Redirect to ViewCart
            return RedirectToAction("ViewCart");
        }

        public ActionResult ViewCart()
        {
            ShoppingCart cart = GetActiveShoppingCart();
            return View(cart);
        }

        private ShoppingCart GetActiveShoppingCart()
        {
            ShoppingCart cart = null;

            // See if the user has a shopping cart stored in session            
            if (GetSessionData<ShoppingCart>("ShoppingCart") == null)
            {
                cart = new ShoppingCart();
                SaveActiveShoppingCart(cart);                
            }
            else
            {
                cart = GetSessionData<ShoppingCart>("ShoppingCart"); // <-- gets the shopping cart out of session
            }

            // If not, create one for them

            return cart;
        }

        private void SaveActiveShoppingCart(ShoppingCart cart)
        {
            SetSessionData<ShoppingCart>("ShoppingCart", cart);        // <-- saves the shopping cart into session
        }
    }
}