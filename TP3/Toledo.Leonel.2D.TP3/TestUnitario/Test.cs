using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Abstractas;
using Clases_Instanciables;
using Excepciones;

namespace TestUnitario
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void NacionalidadInvalidaExceptionTest()
        {
            //Arrange
            Alumno alumno;

            //Act
            try
            {
                alumno = new Alumno(1, "Leonel", "Toledo", "90000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion);
            }

            //Assert
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }

        [TestMethod]
        public void AlumnoRepetidoExceptionTest()
        {
            //Arrange
            Alumno alumno1 = new Alumno(1, "Leonel", "Toledo", "34000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion);
            Alumno alumno2 = new Alumno(1, "Juan", "Perez", "34000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion);
            Universidad universidad = new Universidad();

            //Act
            try
            {
                universidad += alumno1;
                universidad += alumno2;
            }

            //Assert
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }

        [TestMethod]
        public void DniTest()
        {
            //Arrange
            int dni = 38889128;
            Alumno aux = new Alumno(1, "Leonel", "Toledo", dni.ToString(), Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion);

            //Act
            int resultado = aux.DNI;

            //Assert
            Assert.AreEqual(dni, resultado);
        }

        [TestMethod]
        public void NewProfesorTest()
        {
            //Arrange
            Profesor profe = new Profesor(1, "Juan", "Perez", "30000000", Persona.ENacionalidad.Argentino);

            //Assert
            Assert.IsNotNull(profe.DNI);
            Assert.IsNotNull(profe.Nombre);
            Assert.IsNotNull(profe.Apellido);
            Assert.IsNotNull(profe.Nacionalidad);
        }
    }
}
