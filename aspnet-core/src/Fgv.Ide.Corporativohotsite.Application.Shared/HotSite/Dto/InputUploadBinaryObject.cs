using System;
using System.ComponentModel.DataAnnotations;

namespace Fgv.Ide.Corporativohotsite.HotSite.Dto
{
    public class InputUploadBinaryObject
    {
        [Required]
        public byte[] Bytes { get; set; }
    }
}
