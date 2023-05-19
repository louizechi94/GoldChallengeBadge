namespace GBC.Repository.Tests;

public class UnitTest1
{
    private ContactDictionaryRepository _contactRepo;

    public UnitTest1()
    {
      _contactRepo = new ContactDictionaryRepository(); 

      var contactA = new Contact
        {
            ID = 1,
            Name = "Alex",
            Address = "California Way",
            Email = "Alex@gmail.com",
            PhoneNumber = "4159665773"
        };

        var contactB = new Contact
        {
            ID = 2,
            Name = "Harper",
            Address = "Berkely Way",
            Email = "Harper@gmail.com",
            PhoneNumber = "4159600073"
        };

        var contactC = new Contact
        {
            ID = 3,
            Name = "Vera",
            Address = "Telegraph street",
            Email = "Vera@gmail.com",
            PhoneNumber = "4159699973"
        };

        var contactD = new Contact
        {
            ID = 4,
            Name = "Sara",
            Address = "San Pablo street",
            Email = "Sara@gmail.com",
            PhoneNumber = "4139973678"
        };

        //we need to add to the database
        _contactRepo.AddContact(contactA);
        _contactRepo.AddContact(contactB);
        _contactRepo.AddContact(contactC);
        _contactRepo.AddContact(contactD);
 
    }

    [Fact]
    public void AddContact_ShouldReturnTrue()
    {
        //Arrange
        Contact contactE = new Contact()
        {
            ID = 5,
            Name = "Nina",
            Address = "Franko street",
            Email = "Nina@gmail.com",
            PhoneNumber = "3145670987"
        };
        
        //Act
        bool isSuccess = _contactRepo.AddContact(contactE);

        //Assert
        Assert.True(isSuccess);

    }
    [Fact]
    public void GetContact_ShouldReturnTrue()
    {
        //Arrange
        //Act
        int expected = 4;
        int actual = _contactRepo.GetContact().Count();

        //Assert
        Assert.Equal(expected,actual);
    }

     [Fact]
    public void GetContact_ShouldReturnCorrectName()
    {
        //Arrange
        //Act
        string expectedName = "Sara";
        string actualName = _contactRepo.GetContact(4).Name;

        //Assert
        Assert.Equal(expectedName,actualName);
    }
    [Fact]  
    public void UpdateContact_shouldReturnTrue()
    {
    //Arrange 
    Contact contactB = new Contact()
    {
        ID = 4,
        Name = "Update",
        Address = "San Diego street",
        Email = "Nael@gmail.com",
        PhoneNumber = "4159992222"
    };

    //Act 
    Contact contactToUpdate = contactB;
    bool isSuccess = _contactRepo.UpdateContact(contactToUpdate.ID,contactB);

    //Assert
    Assert.True(isSuccess);

  
    
}
 [Fact]
public void DeleteContact_ShouldReturnTrue()
{
    //Arrange

    //Act
    int expectedCount = 3;
    bool isSuccess = _contactRepo.DeleteContact(2);
    int actualCount = _contactRepo.GetContact().Count();

    //Assert
    Assert.True(isSuccess);
    Assert.Equal(expectedCount, actualCount);
}

    
}