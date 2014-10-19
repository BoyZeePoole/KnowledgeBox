using KnowledgeBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeBox.Custom
{
    public class HelperClass
    {
        private static KnowledgeBoxEntities db = new KnowledgeBoxEntities();
        public static void RemoveCart(Guid guid)
        {
            var cartItems = db.Carts.Where(c => c.Cart_Id == guid);
            foreach (var cartItem in cartItems)
            {
                db.Carts.Remove(cartItem);
            }
            db.SaveChanges();
        }
        public static List<KnowledgeBox.Models.Item> GetItemsFromCart(Guid guid)
        {            
            return (from i in db.Items
                        from c in db.Carts
                        where c.Cart_Id == guid
                        && i.Item_Id == c.Item_Id 
                        select i).ToList();

        }
    }
}