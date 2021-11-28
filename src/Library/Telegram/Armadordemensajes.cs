namespace Telegram{
    /// <summary>
    /// Clase encargada de interactuar con la ApiLocation
    /// </summary>
    public class Armadordemensajes{
        private static Armadordemensajes Impresor;
        /// <summary>
        /// Singleton para que solo exista una instancia del catalogo.
        /// </summary>
        /// <returns></returns>
        private Armadordemensajes(){}
        public static Armadordemensajes Instance
        {
            get
            {
                if (Impresor == null)
                {
                    Impresor= new Armadordemensajes();
                }

                return Impresor;
            }
        }
        public string Veruser(User user)
        {
            string Frasesarmadas=string.Empty;
            Frasesarmadas+=$"Nombre de usuario: {user.Name}\n";
            Frasesarmadas+=$"Direccion: {user.Location}\n";
            Frasesarmadas+=$"Rubro: {user.Rubro.Name}\n";
            Frasesarmadas+=$"ID de usuario: {user.ID}\n";
            return Frasesarmadas;
        }
        
        public string Veroferta(Offer offer)
        {
            string Frasesarmadas=string.Empty;
            Frasesarmadas+=$"La oferta de {offer.Product.Name} tiene {offer.Product.Quantity} {offer.Product.Unit.Name}\n";
            Frasesarmadas+=$"Su precio es de {offer.Product.Price}\n";
            Frasesarmadas+=$"Sus habilitaciones son:\n";
            foreach (Ratings rat in offer.Ratings)
            {
                Frasesarmadas+=$"{rat.Name}\n";
            }
            Frasesarmadas+=$"\nY Pertence a la cateogoria {offer.Product.Categories}\n";
            return Frasesarmadas;
        }
        public string Vercategory(Category category)
        {
            string Frasesarmadas=string.Empty;
            Frasesarmadas+=$"El nombre de la categoria es {category.Name}\n";
            Frasesarmadas+=$"{category.Description}\n";
            return Frasesarmadas;
        }
        public string Verrating(Ratings rating)
        {
            string Frasesarmadas=string.Empty;
            Frasesarmadas+=$"El nombre de la habilitacion es {rating.Name}\n";
            Frasesarmadas+=$"{rating.Description}\n";
            return Frasesarmadas;
        }
        public string Verrubro(Rubro rubro)
        {
            string Frasesarmadas=string.Empty;
            Frasesarmadas+=$"El nombre del rubro es {rubro.Name}\n";
            Frasesarmadas+=$"{rubro.Description}\n";
            return Frasesarmadas;
        }
        public string Verunit(Units units)
        {
            string Frasesarmadas=string.Empty;
            Frasesarmadas+=$"El nombre de la unidad es {units.Name}\n";
            Frasesarmadas+=$"Su sigla es {units.shortcut}\n";
            return Frasesarmadas;
        }
        public string Vercatalogo()
        {
            Catalogo catalogo = Catalogo.Instance;
            string Frasesarmadas=string.Empty;
            foreach (Offer oferta in catalogo.AllOffers)
            {
                Frasesarmadas+=$"{Veroferta(oferta)}\n";
            }
            return Frasesarmadas;
        } 
        public string Verlistasbussiness()
        {
            Listas listas= Listas.Instance;
            string Frasesarmadas=string.Empty;
            foreach (Business empresa in listas.Listbussiness)
            {
                Frasesarmadas+=$"{Veruser(empresa)}\n";
            }
            return Frasesarmadas;
        }
        public string Verlistaemprendedores()
        {
            Listas listas= Listas.Instance;
            string Frasesarmadas=string.Empty;
            Frasesarmadas+=$"Los siguientes usuarios estan registrados como Emprendedores\n";
            foreach (Emprendedores emprendedor in listas.Listemprendedores)
            {
                Frasesarmadas+=$"{Veruser(emprendedor)}\n";
            }
            return Frasesarmadas;
        }
        public string Verlistasusuarios()
        {
            string Frasesarmadas=string.Empty;
            Frasesarmadas+=$"Los siguientes usuarios estan registrados como Empresas\n";
            Frasesarmadas+=Verlistasbussiness();
            Frasesarmadas+=$"Los siguientes usuarios estan registrados como Emprendedores\n";
            Frasesarmadas+=Verlistaemprendedores();
            return Frasesarmadas;
        }
        
        public string Verlistacategory()
        {
            Listas listas= Listas.Instance;
            string Frasesarmadas=string.Empty;
            foreach (Category category in listas.Listcategory)
            {
                Frasesarmadas+=$"{Vercategory(category)}\n";
            }
            return Frasesarmadas;
        }
       
        public string Verlistaratings()
        {
            Listas listas= Listas.Instance;
            string Frasesarmadas=string.Empty;
            foreach (Ratings habilitaciones in listas.Listratings)
            {
                Frasesarmadas+=$"{Verrating(habilitaciones)}\n";
            }
            return Frasesarmadas;
        }
        public string Verlistarubros()
        {
            Listas listas= Listas.Instance;
            string Frasesarmadas=string.Empty;
            foreach (Rubro rubro in listas.Listrubro)
            {
                Frasesarmadas+=$"{Verrubro(rubro)}\n";
            }
            return Frasesarmadas;
        }
        public string Verlistaunit()
        {
            Listas listas= Listas.Instance;
            string Frasesarmadas=string.Empty;
            foreach (Units unidad in listas.Listunit)
            {
                Frasesarmadas+=$"{Verunit(unidad)}\n";
            }
            return Frasesarmadas;
        }
    }
}