﻿using System.ComponentModel.DataAnnotations;

namespace Fgv.Ide.Corporativohotsite.Localization.Dto
{
    public class CreateOrUpdateLanguageInput
    {
        [Required]
        public ApplicationLanguageEditDto Language { get; set; }
    }
}