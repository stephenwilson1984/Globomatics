using Globomantics.Domain.Models;
using Globomatics.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Globomatics.Infrastructure.Repositories;

public class CartRepository(GlobomanticsContext context) : GenericRepository<Cart>(context), ICartRepository
{
    public Cart CreateOrUpdate(Guid? cartId, Guid productId, int quantity = 1)
    {
        (var cart, var isNewCart) = GetCart(cartId);

        AddProductToCart(cart, productId, quantity);

        if (isNewCart)
        {
            Context.Add(cart);
        }
        else
        {
            Context.Update(cart);
        }

        return cart;
    }

    private (Cart cart, bool isNewCart) GetCart(Guid? cartId)
    {
        Cart? cart = null;
        bool isNewCart = false;

        if (cartId is not null || cartId == Guid.Empty)
        {
            cart = Context.Carts
                .Include(x => x.LineItems)
                .FirstOrDefault(x => x.CartId == cartId);
        }

        if (cart is null)
        {
            isNewCart = true;
            cart = new();
        }

        return (cart, isNewCart);
    }

    private void AddProductToCart(Cart cart, Guid productId, int quantity)
    {
        var lineItem = cart.LineItems.FirstOrDefault(x => x.ProductId == productId);

        if (lineItem is not null && quantity == 0)
        {
            cart.LineItems.Remove(lineItem);
        }
        else if (lineItem is not null)
        {
            lineItem.Quantity = quantity;
        }
        else
        {
            lineItem = new() { ProductId = productId, Quantity = quantity };

            Context.LineItems.Add(lineItem);

            cart.LineItems.Add(lineItem);
        }
    }
}