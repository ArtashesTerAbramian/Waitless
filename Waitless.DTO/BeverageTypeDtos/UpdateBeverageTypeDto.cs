using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waitless.DTO.BeverageTypeDtos
{
    public class UpdateBeverageTypeDto
    {
        public long Id { get; set; }
        public List<BeverageTypeTranslationDto> Translations { get; set; }
    }
}
