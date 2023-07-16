// using Waitless.DAL.Models;
// using Waitless.DTO.CoffeeTypeDtos;
// using Riok.Mapperly.Abstractions;
//
// namespace Waitless.BLL.Mappers;
//
// [Mapper]
// public static partial class CoffeeTypeMapper
// {
//     public static CoffeeTypeDto MapBeverageTypeDto(this CoffeeType type)
//     {
//         var dto = BeverageTypeToBeverageTypeDto(type);
//
//         dto.Name = type.Translations.First().Name;
//
//         return dto;
//     }
//
//     private static partial CoffeeTypeDto BeverageTypeToBeverageTypeDto(CoffeeType type);
//     public static partial List<CoffeeTypeDto> MapToBeverageTypesDtos(this List<CoffeeType> types);
// }
