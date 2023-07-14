using Waitless.DAL.Enums;
using Waitless.Dto;

namespace Waitless.DTO.BeverageDtos;

public class AddBeverageDto
{
    public long? BeverageTypeId { get; set; }
    public long? BeverageSizeId { get; set; }
    public decimal Price { get; set; }
    public List<BeverageTranslationDto> Translations;
    public FileDto? File { get; set; }
}
