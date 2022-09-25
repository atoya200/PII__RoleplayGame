using System;
using Library;
using NUnit.Framework;

namespace Test.Library
{
    [TestFixture]
    public class TestMago
    {
        [Test]

        public void CrearMagoNameCorrecto()
        {
            string nombreEsperado = "Jason";
            Mago jason = new Mago("Jason");
            Assert.AreEqual(nombreEsperado,jason.Name);
        }
        [Test]
        public void CrearElfoNameVacio()
        {
            string nombreEsperado = null;
            Mago jason = new Mago("");
            Assert.AreEqual(nombreEsperado,jason.Name);
        }
         [Test]
        public void CrearElfoNameEspaciosEnBlanco()
        {
            string nombreEsperado = null;
            Mago jason = new Mago("     ");
            Assert.AreEqual(nombreEsperado,jason.Name);
        }

         [Test]
        public void CrearElfoNameNulo()
        {
            string nombreEsperado = null;
            Mago jason = new Mago(null);
            Assert.AreEqual(nombreEsperado,jason.Name);
        }

        [Test]
        public void CrearElfoNombrSoloSignos()
        {
            string nombreEsperado = null;
            Mago jason = new Mago("&/$#&");
            Assert.AreEqual(nombreEsperado,jason.Name);

        }
        [Test]
        public void RopaEquipada()
        {
            // Configuración.
            Ropa armadura = new Ropa("Capa de destrucción", "Esta capa potencia los hechizos de ataque", 0, 30);
            Ropa armadura1 = new Ropa("Capa de destrucción", "Esta capa potencia los hechizos de ataque", 0, 30);
            Mago jason = new Mago("Jason");
            jason.Inventario.AgregarElemento(armadura);
            // Comportamiento.
            jason.EquiparRopa(armadura);
            // Comprobación.
            Assert.IsTrue(jason.RopaEquipada.Contains(armadura));

        }
        [Test]
        public void QuitarRopa()
        {
            // Configuración.
            Ropa armadura = new Ropa("Capa de destrucción", "Esta capa potencia los hechizos de ataque", 0, 30);
            Ropa armadura1 = new Ropa("Capa de destrucción", "Esta capa potencia los hechizos de ataque", 0, 30);
            Mago jason = new Mago("Jason");
            jason.Inventario.AgregarElemento(armadura);
            jason.EquiparRopa(armadura);
            // Comportamiento.
            jason.QuitarRopa(armadura);
            // Comprobación.
            Assert.IsFalse(jason.RopaEquipada.Contains(armadura));

        }
    }
}