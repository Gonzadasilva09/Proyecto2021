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
        /// Lista que contiene las habilitaciones de la oferta.
        /// </summary>
        /// <returns></returns>
        public List<Ratings> Ratings = new List<Ratings>();

        /// <summary>
        /// Atributo que determina si la oferta es recurrente o no, obtiene y establece el valor.
        /// </summary>
        /// <value></value>
        public bool Recurrent { get; set; } = false;
        public string Location { get; set; }

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
        /// <param name="rating"></param>
        /// <param name="categories"></param>
        /// <param name="type"></param>
        /// <param name="productname"></param>
        /// <param name="productquantity"></param>
        /// <param name="productunit"></param>
        /// <param name="productdirection"></param>
        /// <param name="productprice"></param>
        public Offer (string location, Ratings rating, string type, string productname, int productquantity, Units productunit, string productdirection,int productprice, List<Category> categories)
        {
            this.Type = type;
            Materials product = new Materials(productname,productquantity,productunit,productdirection,productprice,categories);
            this.Product = product;
            Catalogo.Instance.allOffers.Add(this);
            Ratings.Add(rating);
            this.Location=location;
        }

        /// <summary>
        /// Metodo que imprime las habilitaciones de la empresa.
        /// </summary>
        /// <returns></returns>
         public string PrintRatings()
         {  
            string habilitaciones = string.Empty;
            foreach (Ratings rat in this.Ratings)
            {
               habilitaciones = habilitaciones + $"{rat.Name} ,";
            }
            return habilitaciones;
        }
    

        /// <summary>
        /// Metodo que añade habilitaciones a la empresa.
        /// </summary>
        /// <param name="ratings"></param>
        public void AddRatings(Ratings ratings)
        {
            Ratings.Add(ratings);
        }


    }
}