using System.ComponentModel.DataAnnotations;

namespace JTTT.Interfaces
{
    public interface IDBEntity
    {
        [Key]
        int Id { get; set; }
    }
}
