using System;
using System.Collections.Generic; 

namespace Telegram 
{
    /// <summary>
    /// Clase que se encarga de controlar las ofertas.
    /// </summary>
    public class Offer 
    {
        /// <summary>
        /// Lista que contiene las categorias de la oferta.
        /// </summary>
        /// <typeparam name="Category"></typeparam>
        /// <returns></returns>
        public List<Category> categories = new List<Category>();
        /// <summary>
        /// Lista que contiene las habilitaciones de la oferta.
        /// </summary>
        /// <typeparam name="Ratings"></typeparam>
        /// <returns></returns>
        public List<Ratings> Ratings = new List<Ratings>();
        /// <summary>
        /// Atributo que determina si la oferta es recurrente o no, obtiene y establece el valor.
        /// </summary>
        /// <value></value>

        public bool Recurrent { get; set; } = false;
        /// <summary>
        /// Establece o obtiene el tipo de la oferta, que puede ser residuo o material.
        /// </summary>
        /// <value></value>
        public string Type { get; set; }
        /// <summary>
        /// Obtiene y establece el material ofrecido en la oferta.
        /// </summary>
        /// <value></value>

        public Materials Product { get; set; }
        /// <summary>
        /// Obtiene o establece el atributo que determina si la oferta esta disponible o no.
        /// </summary>
        /// <value></value>
        public bool status { get; set; }
        /// <summary>
        /// Obtiene o establece el dueño de la ofterta.
        /// </summary>
        /// <value></value>

        public Emprendedores Owner { get; set; }
        /// <summary>
        /// Constructor de objetos de tipo oferta.
        /// </summary>
        /// <param name="ratings"></param>
        /// <param name="categories"></param>
        /// <param name="type"></param>
        /// <param name="productname"></param>
        /// <param name="productquantity"></param>
        /// <param name="productunit"></param>
        /// <param name="productdirection"></param>
        /// <param name="productprice"></param>
        public Offer (Ratings ratings, Category categories, string type, string productname, int productquantity, Units productunit, string productdirection,int productprice )
        {
            this.Type = type;
            Materials product = new Materials(productname,productquantity,productunit,productdirection,productprice);
            this.Product = product;
            Catalogo.Instance.AllOffers.Add(this);
        }
        
        /// <summary>
        /// Metodo que imprime una oferta en la consola.
        /// </summary>
        /// <returns></returns>
        public string printOffer(){
            string offer = $"Oferta de tipo {this.Type}, \n"+
                            $"Pertenece a la/s categoria/s {this.PrintCategories()} \n"+
                            $"Esta oferta contiene {this.Product.Quantity} {this.Product.Unit} de {this.Product.Name}\n"+
                            $"Tiene un valor de {this.Product.Price}\n"+
                            $"Requiere de las siguientes habilitaciones : {this.PrintRatings()}\n"+
                            $"Y esta ubicado en {this.Product.Direction}";
                           
            
            return offer;
        }
        /// <summary>
        /// Metodo que imprime las categorias de la oferta.
        /// </summary>
        /// <returns></returns>

        public string PrintCategories(){
           
            string categorias="";
            foreach (Category Cate in this.categories)
            {
               categorias=categorias+$"{Cate.Name} ,";
            }
            return categorias;

        }
        /// <summary>
        /// Metodo que imprime las habilitaciones de la empresa.
        /// </summary>
        /// <returns></returns>
         public string PrintRatings(){
           
            string habilitaciones="";
            foreach (Ratings Rat in this.Ratings)
            {
               habilitaciones=habilitaciones+$"{Rat.Name} ,";
            }
            return habilitaciones;

        }
        /// <summary>
        /// Metodo que añade categorias a la oferta.
        /// </summary>
        /// <param name="category"></param>

        public void addCategories(Category category){
            categories.Add(category);
        }

        /// <summary>
        /// Metodo que añade habilitaciones a la empresa
        /// </summary>
        /// <param name="ratings"></param>
        
        public void addRatings(Ratings ratings){
            Ratings.Add(ratings);
        }


    }
}