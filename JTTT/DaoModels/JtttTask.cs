using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JTTT.Interfaces;

namespace JTTT.DaoModels
{
    public class JtttTask : IDBEntity
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        public int ActionId { get; set; }
        [ForeignKey("ActionId")]
        public virtual JtttAction Action { get; set; }

        public int ConditionId { get; set; }
        [ForeignKey("ConditionId")]
        public virtual JtttCondition Condition { get; set; }
    }
}