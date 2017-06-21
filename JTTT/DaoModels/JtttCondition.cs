using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JTTT.Interfaces;

namespace JTTT.DaoModels
{
    public class JtttCondition : IDBEntity
    {
        [Key]
        public int Id { get; set; }
    }
}