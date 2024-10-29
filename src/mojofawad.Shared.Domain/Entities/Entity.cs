namespace mojofawad.Shared.Domain.Entities;

public abstract class Entity : IEquatable<Entity>
{
    public int Id { get; private set; }
    public Guid TrackingId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    
    protected Entity()
    {
        TrackingId = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
    }

    public bool Equals(Entity? other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }
        
        return Id != 0 && Id == other.Id;
    }
    
    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }
        
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj.GetType() != GetType())
        {
            return false;
        }
        
        return Equals(obj as Entity);
    }
    
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
    
    public static bool operator ==(Entity? left, Entity? right)
    {
        return Equals(left, right);
    }
    
    public static bool operator !=(Entity? left, Entity? right)
    {
        return !Equals(left, right);
    }
}