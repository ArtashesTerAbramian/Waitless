using Riok.Mapperly.Abstractions;
using Waitless.DAL.Models;
using Waitless.DTO.VendorDtos;

namespace Waitless.BLL.Mappers;

[Mapper]
public static partial class VendorMapper
{
    public static partial VendorDto MapToVendorDto(this Vendor vendor);
    public static partial List<VendorDto> MapToVendorsDtos(this List<Vendor> vendors);
}
