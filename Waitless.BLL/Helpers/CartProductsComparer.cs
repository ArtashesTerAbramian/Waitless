using System.Diagnostics.CodeAnalysis;
using Waitless.DAL.Models;

namespace Waitless.BLL.Helpers;

public class CartProductsComparer : IEqualityComparer<CartProduct>
{
    public bool Equals(CartProduct? x, CartProduct? y)
    {
        return x.ProductId == y.ProductId;
    }

    public int GetHashCode([DisallowNull] CartProduct obj)
    {
        return HashCode.Combine(obj.ProductId, obj.ProductId);
    }
}
