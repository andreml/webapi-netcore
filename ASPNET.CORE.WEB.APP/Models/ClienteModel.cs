using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNET.CORE.WEB.APP.Models
{
    [Table("TEMP_CLIENTE")]
    public class ClienteModel
    {
        [Key]
        [Column("ID")]
        public int id { get; set; }

        [Column("DOCUMENTO")]
        public string documento { get; set; }

        [Column("NOME")]
        public string nome { get; set; }
    }
}
