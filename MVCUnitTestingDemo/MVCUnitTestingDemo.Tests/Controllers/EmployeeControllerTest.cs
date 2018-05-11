using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCUnitTestingDemo.Controllers;
using System.Web.Mvc;

[TestClass]
public class EmployeeControllerTest
{
    [TestMethod]
    public void Employees()
    {
        // Arrange
        EmployeeController controller = new EmployeeController();

        // Act
        ViewResult result = controller.Index() as ViewResult;

        // Assert
        Assert.IsNotNull(result);
    }
}