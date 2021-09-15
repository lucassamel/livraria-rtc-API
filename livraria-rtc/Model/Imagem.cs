using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace livraria_rtc.Model
{
    public class Imagem
    {

        [Key]
        public int FileDataId { get; set; }
        public string FileName { get; set; }
        public string FileSize { get; set; }
        public string ModifiedOn { get; set; }
    }
}
