using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroPersonas.BLL;
using RegistroPersonas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroPersonas.BLL.Tests
{
    [TestClass()]
    public class PersonasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Personas persona = new Personas();
            bool paso = false;

            persona.PersonasId = 0;
            persona.Nombre = "Jose Armando";
            persona.Telefono = "8296902801";
            persona.Cedula = "40212965186";
            persona.Direccion = "Bomba de Cenovi";
            persona.FechaNacimiento = DateTime.Now;

            paso = PersonasBLL.Guardar(persona);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Personas persona = new Personas();
            bool paso = false;

            persona.PersonasId = 1;
            persona.Nombre = "Jose Armando";
            persona.Telefono = "8296902801";
            persona.Cedula = "40212965186";
            persona.Direccion = "Bomba de Cenovi, SFM";
            persona.FechaNacimiento = DateTime.Now;

            paso = PersonasBLL.Modificar(persona);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;
            paso = PersonasBLL.Eliminar(1);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            bool paso = false;
            Personas persona = PersonasBLL.Buscar(1);

            if (persona != null)
                paso = true;
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool paso = false;
            paso = PersonasBLL.Existe(1);
            Assert.AreEqual(paso, true);
        }
    }
}