using NUnit.Framework;
using Telegram;

namespace Library.Test
{
    public class Tests
    {
        [Test]
        public void Test1()
        {   
            Category Categoria = new Category("Materiales para reciclar","Materiales para reciclar");
            Ratings Habilitacion = new Ratings("Habilitacion para metales", "Metales");
            Units Toneladas = new Units("Toneladas");
            Offer Metal = new Offer(Habilitacion,Categoria,"Tipo", "Metal", 200, Toneladas, "dirección",2000);
            Assert.AreEqual(Categoria,Metal.Categories[0]);
        }
        [Test]
        public void Test2()
        {   
            Category Categoria = new Category("Materiales para reciclar","Materiales para reciclar");
            Ratings Habilitacion = new Ratings("Habilitacion para metales", "Metales");
            Units Toneladas = new Units("Toneladas");
            Offer Metal = new Offer(Habilitacion,Categoria,"Tipo", "Metal", 200, Toneladas, "dirección",2000);
            Assert.AreEqual(Habilitacion,Metal.Ratings[0]);
        }
        [Test]
        public void Test3()
        {   
            Category Categoria = new Category("Materiales para reciclar","Reciclar");
            Category BuenEstado = new Category("Materiales en muy buen estado","Buen estado");
            Ratings Habilitacion = new Ratings("Habilitacion para metales", "Metales");
            Units Toneladas = new Units("Toneladas");
            Offer Metal = new Offer(Habilitacion,Categoria,"Tipo", "Metal", 200, Toneladas, "dirección",2000);
            Metal.addCategories(BuenEstado);
            Assert.AreEqual(BuenEstado,Metal.Categories[1]);
        }
        [Test]
        public void Test4()
        {   
            Category Categoria = new Category("Materiales para reciclar","Reciclar");
            Ratings Habilitacion = new Ratings("Habilitacion para metales", "Metales");
            Ratings Higiene = new Ratings("Cuidado con las medidas necesarias contra el covid", "Higiene");
            Units Toneladas = new Units("Toneladas");
            Offer Metal = new Offer(Habilitacion,Categoria,"Tipo", "Metal", 200, Toneladas, "dirección",2000);
            Metal.addRatings(Higiene);
            Assert.AreEqual(Higiene,Metal.Ratings[1]);
        }
        [Test]
        public void Test5()
        {
            Rubro Metalurgia = new Rubro ("IndustriaPesada", "Metalurgia");
            Emprendedores EstrellaSA = new Emprendedores("EstrellaSA", "Montevideo", Metalurgia);
            Assert.AreEqual(Metalurgia,EstrellaSA.Rubro);
        }

        [Test]
        public void Test6()
        {
            Units Kilos = new Units("Kilos");
            Materials Madera= new Materials("Madera", 20, Kilos, "direction",400);
            Assert.AreEqual("K", Madera.Unit);
        }

    }
}