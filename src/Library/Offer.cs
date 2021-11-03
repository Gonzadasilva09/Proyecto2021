using System;
namespace Telegram 
{
    public class Offer 
    {
        public Offer (Ratings ratings, Category category, string type, string prodname, int prodquantity, Units produnit, string proddirection, int prodprice )
        {
            this.Ratings = ratings;
            this.Category = category;
            this.Type = type;
            this.Status = true;
            Materials product = new Materials(prodname,prodquantity,produnit,proddirection,prodprice);
            this.Product = product;

        }
        public Ratings Ratings { get; set; }
        public bool Recurrent { get; set; } = false;

        public Category Category { get; set; }

        public string Type { get; set; }

        public bool Status { get; set; }

        public Emprendedores Owner{ get; set; }

        public Materials Product { get; set; }
        public string printOffer()
            {
                return $"El {this.Product.Name} y $ {this.Type}";
            }

        public string printOfferCompleta()
            {
                return $"El producto {this.Product.Name} del que se dispone la cantidad {this.Product.Quantity} en {this.Product.Unit} unidades y precio {this.Product.Price}, con el proveedor de dirección {this.Product.Direction}. Tiene el dato {this.Ratings} y es una oferta {this.Recurrent}. Pertenece a la categoría {this.Category.Name}, {this.Category.Description} y {this.Type}. Con {this.Status} statis. del proveedor {this.Emprendedores.Name} y {this.Emprendedores.Location} dirección, que se desempeña en el rubro {this.Emprendedores.Rubro}";
            }   
        }
    }
}