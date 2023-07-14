using Waitless.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waitless.DTO.CoffeeTypeDtos
{
    public class AddCoffeeTypeDto
    {
        public List<CoffeeTypeTranslationDto> Translations { get; set; }
    }
}
