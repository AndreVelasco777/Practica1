using System;
using System.Web.Http;
using admPregunta1.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pregunta1.Models;

namespace admPregunta1.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGet()
        {
            //Arrange
            VelascoesController controller = new VelascoesController();
            //Act
            var listaPersonas = controller.GetVelascoes();
            //Assert
            Assert.IsNotNull(listaPersonas);
        }
        [TestMethod]
        public void TestPost()
        {
            //Arrange
            VelascoesController controller = new VelascoesController();
            Velasco velasco = new Velasco()
            {
                VelascoID = 1,
                FriendofVelasco = "Thaliana Torrez",
                place = Places.Santa_Cruz,
                Email = "thalianatorrez@gmail.com",
                Birthdate = DateTime.Now
            };
            //Act
            IHttpActionResult actionResult = controller.PostVelasco(velasco);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<Velasco>;
            //Assert
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.IsNotNull(createdResult.RouteValues["id"]);
        }
        [TestMethod]
        public void TestPut()
        {
            //Arrange
            VelascoesController controller = new VelascoesController();
            Velasco velasco = new Velasco()
            {
                VelascoID = 2,
                FriendofVelasco = "Enrique Nunes",
                place = Places.Porongo,
                Email = "enriquenunes@gmail.com",
                Birthdate = DateTime.Now
            };
            //Act
            IHttpActionResult actionResultPost = controller.PostVelasco(velasco);
            var result = controller.PutVelasco(velasco.VelascoID, velasco) as StatusCodeResult;
            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }
        [TestMethod]
        public void TestDelete()
        {
            //Arrange
            VelascoesController controller = new VelascoesController();
            Velasco velasco = new Velasco()
            {
                VelascoID = 3,
                FriendofVelasco = "Jimbo Tapia",
                place = Places.Cotoca,
                Email = "jimbotapia@gmail.com",
                Birthdate = DateTime.Now
            };
            //Act
            IHttpActionResult actionResultPost = controller.PostVelasco(velasco);
            IHttpActionResult actionResultDelete = controller.DeleteVelasco(velasco.VelascoID);
            //Assert
            Assert.IsInstanceOfType(actionResultDelete, typeof(OkNegotiatedContentResult<Velasco>));
        }
    }
    }
}
