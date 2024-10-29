using mojofawad.Shared.Domain.Entities;

namespace mojofawad.Shared.UnitTests;

public class EntityTests
{
    [Fact]
    public void Create_WhenInstantiated_ShouldSetDefaultProperties()
    {
        // Arrange & Act
        var testEntity = new TestEntity();
        
        // Assert
        Assert.Equal(0, testEntity.Id);
        Assert.NotEqual(Guid.Empty, testEntity.TrackingId);
        Assert.InRange(testEntity.CreatedAt, DateTime.UtcNow.AddSeconds(-1), DateTime.UtcNow);
        Assert.Null(testEntity.UpdatedAt);
    }

    [Fact]
    public void Equals_WhenSameId_ShouldBeEqual()
    {
        // Arrange
        var testEntity1 = new TestEntity();
        var testEntity2 = new TestEntity();
        
        // Act
        typeof(Entity).GetProperty("Id")!.SetValue(testEntity1, 1);
        typeof(Entity).GetProperty("Id")!.SetValue(testEntity2, 1);
        
        // Assert
        Assert.Equal(testEntity1, testEntity2);
        Assert.True(testEntity1.Equals(testEntity2));
    }
    
    [Fact]
    public void Equals_WhenDifferentId_ShouldNotBeEqual()
    {
        // Arrange
        var testEntity1 = new TestEntity();
        var testEntity2 = new TestEntity();
        
        // Act
        typeof(Entity).GetProperty("Id")!.SetValue(testEntity1, 1);
        typeof(Entity).GetProperty("Id")!.SetValue(testEntity2, 2);
        
        // Assert
        Assert.NotEqual(testEntity1, testEntity2);
        Assert.False(testEntity1.Equals(testEntity2));
    }
    
}