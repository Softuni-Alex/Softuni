namespace TheSlum
{
    public abstract class GameObject
    {
        protected GameObject(string id)
        {
            this.Id = id;
        }
		object
        public string Id { get; private set; }
    }
}
