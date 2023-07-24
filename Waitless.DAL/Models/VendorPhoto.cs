
namespace Waitless.DAL.Models;

public class VendorPhoto : BasePhotoEntity
{
    public long? VendoerId { get; set; }

    public Vendor Vendor { get; set; }
}
