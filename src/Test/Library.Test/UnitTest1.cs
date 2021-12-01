using NUnit.Framework;
using Telegram;
using System.Collections.Generic;

namespace Library.Test
{
    /// <summary>
    /// Hicimos la mayoria de los tests de forma manual, ya que se nos dificultaba hacerlo a travez de los handlers.
    /// Nuestra intención ademas de poner a prueba nuestro codigo, asegurarnos de que se cumplieran todos los user storys que nos plantearon con el proyecto.
    /// Aunque algunas cosas como por ejemplo el uso de tokens y la lista tokens para crear empresas no pudimos agregarlas aqui ya que su encargado es el handler.
    /// </summary>
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Teardown()
        {
            Catalogo.Instance.AllOffers = new List<Offer>();
            Listas.Instance.Listrubro= new List<Rubro>();
            Listas.Instance.Listbussiness= new List<Business>();

        }
        [Test]
        public void Test1()
        {   
            Rubro rubro= new Rubro("Encargados de capacitar a las nuevas generaciones","EDUCACION");
            Assert.AreEqual(Listas.Instance.Listrubro[0],rubro);
        }
        [Test]
        public void Test2()
        {   
            Rubro rubro= new Rubro("Encargados de capacitar a las nuevas generaciones","EDUCACION");
            Business empresa = new Business("Panaderia Suiza","Av. Costanera 194",rubro,"12312321");
            Assert.AreEqual(Listas.Instance.Listbussiness[0],empresa);
            Assert.AreEqual(Listas.Instance.Listrubro[0],rubro);
        }
        [Test]
        public void Test3()
        {   
            Rubro rubro= new Rubro("Admin","Admin");
            Admin admin = new Admin("Fede", "Oficina del admin", rubro, "196490");
            Assert.AreEqual(Listas.Instance.Listadmin[0],admin);
        }
        [Test]
        public void Test4()
        {   
            Ratings ratings = new Ratings("Materiales para reciclaje","Reciclar");
            Assert.AreEqual(Listas.Instance.Listratings[0],ratings);
        }
        [Test]
        public void Test5()
        {   
            Category Categoria = new Category("Materiales para manejar con cuidado","Radioactividad");
            Units Toneladas = new Units("Toneladas");
            Offer Metal = new Offer("location","Reciclado","Asfalto",Toneladas,12,"1200$",Categoria);
            Assert.AreEqual(Toneladas,Metal.Product.Unit);
        }
        [Test]
        public void Test6()
        {   
            Category Categoria = new Category("Materiales para reciclar","Reciclar");
            Units Toneladas = new Units("Toneladas");
            Offer Metal = new Offer("location","Reciclado","Asfalto",Toneladas,12,"1200$",Categoria);
            Assert.AreEqual(Metal,Search.Instance.SearchxCategory(Categoria)[0]);
        }
        [Test]
        public void Test7()
        {
            Category Categoria = new Category("Materiales para reciclar","Reciclar");
            Units Toneladas = new Units("Toneladas");
            Offer Metal = new Offer("location","Reciclado","Asfalto",Toneladas,12,"1200$",Categoria);
            Offer Metaly = new Offer("locations","Reciclados","Asfaltos",Toneladas,12,"1200$",Categoria);
            Assert.AreEqual(Metal,Search.Instance.SearchxCategory(Categoria)[0]);
            Assert.AreEqual(Metaly,Search.Instance.SearchxCategory(Categoria)[1]);
        }
        [Test]
        public void Test8()
        {
            Category Categoria = new Category("Materiales para reciclar","Reciclar");
            Category Categoriano = new Category("Materiales que no se reciclan","No reciclar");
            Units Toneladas = new Units("Toneladas");
            Offer Metal = new Offer("location","Reciclado","Asfalto",Toneladas,12,"1200$",Categoria);
            Offer Metalno = new Offer("location","Reciclado","Asfaltin",Toneladas,12,"1200$",Categoriano);
            Offer Metaly = new Offer("locations","Reciclados","Asfaltos",Toneladas,12,"1200$",Categoria);
            Assert.AreEqual(Metal,Search.Instance.SearchxCategory(Categoria)[0]);
            Assert.AreEqual(Metaly,Search.Instance.SearchxCategory(Categoria)[1]);
        }
        [Test]
        public void Test9()
        {
            Category Categoria = new Category("Materiales para reciclar","Reciclar");
            Units Toneladas = new Units("Toneladas");
            Offer Metal = new Offer("location","Reciclado","Asfalto",Toneladas,12,"1200$",Categoria);
            Offer Metaly = new Offer("locations","Reciclados","Asfalto",Toneladas,12,"1200$",Categoria);
            Assert.AreEqual(Metal,Search.Instance.SearchxMaterial("Asfalto")[0]);
            Assert.AreEqual(Metaly,Search.Instance.SearchxMaterial("Asfalto")[1]);
        }
        [Test]
        public void Test10()
        {
            Category Categoria = new Category("Materiales para reciclar","Reciclar");
            Units Toneladas = new Units("Toneladas");
            Offer Metal = new Offer("location","Reciclado","Asfalto",Toneladas,12,"1200$",Categoria);
            Offer Metalno = new Offer("location","Reciclado","Asfaltin",Toneladas,12,"1200$",Categoria);
            Offer Metaly = new Offer("locations","Reciclados","Asfalto",Toneladas,12,"1200$",Categoria);
            Assert.AreEqual(Metal,Search.Instance.SearchxMaterial("Asfalto")[0]);
            Assert.AreEqual(Metaly,Search.Instance.SearchxMaterial("Asfalto")[1]);
        }
        [Test]
        public void Test11()
        {
            Category Categoria = new Category("Materiales para reciclar","Reciclar");
            Units Toneladas = new Units("Toneladas");
            Offer Metal = new Offer("location","Reciclado","Asfalto",Toneladas,12,"1200$",Categoria);
            Offer Metalno = new Offer("location","Reciclado","Asfaltin",Toneladas,12,"1200$",Categoria);
            Offer Metaly = new Offer("locations","Reciclados","Asfalto",Toneladas,12,"1200$",Categoria);
            Rubro rubro= new Rubro("Encargados de capacitar a las nuevas generaciones","EDUCACION");
            Emprendedores testemprendedor= new Emprendedores("Panaderia Suiza","Av. Costanera 194",rubro,"12312321");
            BuyOffer.Instance.Buy(Metal,testemprendedor);
            Assert.AreEqual(Metal,testemprendedor.Purchased[0]);
        }
    }
}