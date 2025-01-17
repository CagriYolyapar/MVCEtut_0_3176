namespace MVCEtut_0.Models.Entities
{
    public class AppUserProfile : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AppUserId { get; set; }


        //Relational Properties
        public virtual AppUser AppUser { get; set; }

    }
}
