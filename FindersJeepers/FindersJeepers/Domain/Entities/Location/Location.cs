public class Location : AggregateRoot
{
    public int Id { get; private set; }

    public string Name { get; private set; }
    public string Description { get; private set; }

    public bool IsDeleted { get; private set; } = false;
    public void Delete()
    {
        if (IsDeleted) throw new DomainException("This is entity deleted!");
        IsDeleted = true;
    }

    private Location()
    {
         
    }

    public static Location Create(string name, string description)
    {
        if (string.IsNullOrEmpty(name)) throw new DomainException("Name cannot be empty!");

        return new Location
        {
            Name = name,
            Description = description
        };
    }

    public void UpdateInformation(string name, string description)
    {
        if (string.IsNullOrEmpty(name)) throw new DomainException("Name cannot be empty!");

        Name = name;
        Description = description;
    }
}
