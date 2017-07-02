using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class OrgTests23
{
    [Test]
    public void FirstInInsertOrder_OnNonExistingRange_ShouldReturnEmptyCollection()
    {
        // Arrange
        IOrganization org = new Organization();

        // Act
        IEnumerable<Person> Result() => org.FirstByInsertOrder(300);

        // Assert
        CollectionAssert.IsEmpty(Result());
    }
}