namespace SwimmingModel
{
    public abstract class Entity<ID>
    {
        public ID Id { get; set; }

        public Entity(ID id)
        {
            Id = id;
        }

        public Entity()
        {
            
        }
    }
}