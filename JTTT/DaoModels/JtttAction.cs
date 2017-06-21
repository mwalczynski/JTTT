using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JTTT.Interfaces;

namespace JTTT.DaoModels
{
    public class JtttAction : IDBEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
