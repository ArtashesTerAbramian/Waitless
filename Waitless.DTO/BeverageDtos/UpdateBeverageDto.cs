using Waitless.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waitless.DTO.BeverageDtos
{
    public class UpdateBeverageDto
    {
        public long Id { get; set; }
        public long? CoffeeTypeId { get; set; }
        public decimal Price { get; set; }
        public List<BeverageTranslationDto> Translations { get; set; }
        public FileDto? Photo { get; set; }
    }
}
