using MVCEtut_0.Models.Enums;

namespace MVCEtut_0.Models.Entities
{
    public abstract class BaseEntity 
    {
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            Status = DataStatus.Inserted;
        }
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DataStatus Status { get; set; }
    }
}
