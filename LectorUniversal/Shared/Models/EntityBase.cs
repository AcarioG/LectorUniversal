namespace LectorUniversal.Shared
{ 
    public class EntityBase
    {
        public EntityBase()
        {
            CreatedOn = DateTime.Now;
            ModifiedOn = DateTime.Now;
        }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
