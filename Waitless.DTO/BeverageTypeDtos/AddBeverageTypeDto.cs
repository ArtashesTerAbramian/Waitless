using Waitless.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waitless.DTO.BeverageTypeDtos
{
    public class AddBeverageTypeDto
    {
        public List<BeverageTypeTranslationDto> Translations { get; set; }
    }
}
