using Waitless.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waitless.DTO.ProductDtos
{
    public class UpdateProductDto
    {
        public long Id { get; set; }
        public long? ProductTypeId { get; set; }
        public decimal Price { get; set; }
        public List<ProductTranslationDto> Translations { get; set; }
        public FileDto? Photo { get; set; }
    }
}
