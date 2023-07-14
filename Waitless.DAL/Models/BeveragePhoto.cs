namespace Waitless.DAL.Models;

public class BeveragePhoto : BasePhotoEntity
{
    public long BeverageId { get; set; }

    public Beverage Beverage { get; set; }
}
