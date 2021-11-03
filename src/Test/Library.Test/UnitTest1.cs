using NUnit.Framework;
using Telegram;

namespace Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Rubro rubro1 = new Rubro("Testing de programas", "Testing");
            Emprendedores emprendedor1 = new Emprendedores("Emprendedor","Emprendedorland",rubro1);
            Category categoria1 = new Category("S", "Testing");
            
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}