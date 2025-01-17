namespace MVCEtut_0.Models.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }

        //Relational Properties
        public virtual ICollection<Product> Products { get; set; }

    }
}
