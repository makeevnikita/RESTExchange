using Xunit;
using Moq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using src.Interfaces;
using src.Models;
using src.Controllers;
using src.Exceptions;



namespace Tests.Controllers;

public class NetworkControllerTest
{
    [Fact]
    public void GetAllTest()
    {
        // Arrange
        var mock = new Mock<IRepository<Network>>();
        mock.Setup(repo => repo.GetAll()).Returns(GetAll());
        var controller = new NetworkController(mock.Object);

        // Act
        IActionResult result = controller.GetAll();

        // Assert
        Assert.IsType<JsonResult>(result);
    }

    [Fact]
    public void GetByIdTest()
    {   
        // Arrange
        int id = 1;
        var mock = new Mock<IRepository<Network>>();
        
        mock.Setup(repo => repo.GetById(It.IsAny<int>()))
                               .Returns(GetById(id));  

        var controller = new NetworkController(mock.Object);

        // Act
        var result = controller.GetById(id);

        // Assert
        Assert.IsType<JsonResult>(result);
    }

    [Fact]
    public void GetByIdThrowsObjectNotFoundExceptionTest()
    {   
        // Arrange 
        int id = 100;
        var mock = new Mock<IRepository<Network>>();
        
        mock.Setup(repo => repo.GetById(It.IsAny<int>()))
                               .Returns(GetById(It.IsAny<int>()));  

        var controller = new NetworkController(mock.Object);
        
        // Act & Assert
        Assert.ThrowsAny<ObjectNotFoundException>(() => controller.GetById(id));
    }

    [Fact]
    public void CreateThrowsBadRequestExceptionTest()
    {   
        // Arrange 
        Network network = new Network();
        var mock = new Mock<IRepository<Network>>();
        var controller = new NetworkController(mock.Object);
        controller.ModelState.AddModelError("Name", "Required");
        
        // Act & Assert
        Assert.ThrowsAny<BadRequestException>(() => controller.Create(network));
    }

    [Fact]
    public void UpdateThrowsBadRequestExceptionTest()
    {   
        // Arrange 
        Network network = new Network();
        var mock = new Mock<IRepository<Network>>();
        var controller = new NetworkController(mock.Object);
        controller.ModelState.AddModelError("Name", "Required");

        // Act & Assert
        Assert.ThrowsAny<BadRequestException>(() => controller.Update(network));
    }

    [Fact]
    public void UpdateObjectNotFoundExceptionTest()
    {   
        // Arrange 
        Network network = new Network() { Id = 500, Name = "Name" };
        var mock = new Mock<IRepository<Network>>();
        mock.Setup(repo => repo.GetById(It.IsAny<int>()))
                               .Returns(GetById(network.Id));
        var controller = new NetworkController(mock.Object);

        // Act & Assert
        Assert.ThrowsAny<ObjectNotFoundException>(() => controller.Update(network));
    }

    private readonly IEnumerable<Network> Networks = new List<Network>
    {
        new Network { Id = 1, Name = "Network1" },
        new Network { Id = 2, Name = "Network2" },
        new Network { Id = 3, Name = "Network3" }
    };

    private IEnumerable<Network> GetAll()
    {
        return Networks;
    }

    private Network GetById(int id)
    {
        return Networks.SingleOrDefault(w => w.Id == id);
    }
}