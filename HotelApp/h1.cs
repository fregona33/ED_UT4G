using System;

namespace HotelApp
{
    public class h1
    { 
        private const decimal DESCUENTO_VIP = 0.85m; 
        private const decimal DESCUENTO_ESTANCIA_LARGA = 0.05m;
        private const int DIAS_ESTANCIA_LARGA = 7;
        
        public int t; // tipo
        public int d; // dias
        public bool v; // vip
        public int b; // desayuno

        public decimal procesar()
        {
            if (d < 1)
            {
                throw new ArgumentException("La cantidad de días debe ser mayor a 0.");
            }
            
            decimal precioBase = 0;
            
            if (t == 1) precioBase = 50;
            else if (t == 2) precioBase = 75;
            else if (t == 3) precioBase = 150;

            decimal total = precioBase * d;
            
            if (b == 1) total += (12 * d);
            
            if (d > DIAS_ESTANCIA_LARGA)
            {
                total -= total * DESCUENTO_ESTANCIA_LARGA;
            }

            if (v)
            {
                total *= DESCUENTO_VIP;
            }

            return total;
        }
    }
}