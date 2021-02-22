using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Cart
    {
        Dictionary<int, CartItem> _myCart = new Dictionary<int, CartItem>();

        public List<CartItem> myCart
        {
            get
            {
                return _myCart.Values.ToList();
            }
        }

        public void AddItem(CartItem cartItem)
        {
            if (_myCart.ContainsKey(cartItem.ID))
            {
                _myCart[cartItem.ID].Quantity += cartItem.Quantity;
                return;
            }
            _myCart.Add(cartItem.ID, cartItem);
        }

        public void DeleteItem(CartItem cartItem)
        {
            if (_myCart.ContainsKey(cartItem.ID))
            {
                _myCart.Remove(cartItem.ID);
            }
        }
    }
}
