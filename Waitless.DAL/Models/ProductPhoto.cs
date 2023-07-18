namespace Waitless.DAL.Models;

public class ProductPhoto : BasePhotoEntity
{
    public long ProductId { get; set; }

    public Product Product { get; set; }
}
