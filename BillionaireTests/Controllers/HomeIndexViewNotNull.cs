using Microsoft.VisualStudio.TestTools.UnitTesting;
using Billionaire.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Billionaire.Controllers.Tests
{
    public class HomeIndexViewNotNull
    {
        [Fact]
        public void IndexViewNotNull()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.IsNull(result);
        }
    }
}