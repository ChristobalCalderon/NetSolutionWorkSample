using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetSolutionWorkSample.Controllers;

namespace NetSolutionWorkSample.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFirstPageTopRatedMovies()
        {
            var homeController = new HomeController();

            var topRatedMovies = homeController.TopRatedMovies(1);
        }
    }
}
