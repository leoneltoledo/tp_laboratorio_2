using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using MainCorreo;
using System.Collections.Generic;

namespace TestUnitario
{
    [TestClass]
    public class UnitTestTP04
    {
        [TestMethod]
        public void ListaPaquetes()
        {
            //Arrange
            Correo correo;

            //Act
            correo = new Correo();

            //Assert
            Assert.IsNotNull(correo.Paquetes);
        }

        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void MismoTrackingId()
        {
            // Arrange
            Correo correo = new Correo();
            Paquete p1 = new Paquete("direccion1", "123-456-7899");
            Paquete p2 = new Paquete("direccion2", "123-456-7899");

            // Act

            correo += p1;
            correo += p2;

            // Assert es manejado en el ExpectedException
        }
    }
}
