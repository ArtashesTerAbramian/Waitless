using Riok.Mapperly.Abstractions;
using Waitless.DAL.Models;
using Waitless.DTO.MerchantDtos;

namespace Waitless.BLL.Mappers;

[Mapper]
public static partial class MerchantMapper
{
    public static partial MerchantDto MapToMerchantDto(this Merchant merchant);
    public static partial List<MerchantDto> MapToMerchantsDtos(this List<Merchant> merchants);
}