using System;

namespace HotelApp
{
    public class h1 
    {
        // Atributos publicos
        public int t; // tipo habitacion (1: Individual, 2: Doble, 3: Suite)
        public int d; // dias de estancia
        public bool v; // es cliente VIP
        public int b; // incluye desayuno (1: si, 0: no)

        // Metodo para procesar y calcular el precio
        public decimal procesar() 
        {
            // Inicializo la variable res a 0
            decimal res = 0;
            
            // Si los dias son mayores que 0
            if (d > 0)
            {
                // Calculo base de la habitacion
                if (t == 1)
                {
                    res = d * 50;
                }
                else if (t == 2)
                {
                    res = d * 75;
                }
                else if (t == 3)
                {
                    res = d * 150;
                }
                else 
                {
                    // Falla si el tipo no es 1, 2 o 3
                    throw new Exception("Tipo invalido");
                }

                // Añadimos el precio del desayuno si b es igual a 1
                if (b == 1)
                {
                    res = res + (d * 12); // 12 euros por dia de desayuno
                }
                
                // Aplicamos el Descuento VIP si v es true
                if (v == true)
                {
                    res = res * 0.85m; 
                }

                // Descuento extra de larga estancia si son mas de 7 dias
                if (d > 7)
                {
                    res = res - (res * 0.05m); 
                }
            }
            else
            {
                // Falla si dias es menor o igual a 0
                throw new Exception("Dias no validos");
            }

            // Devuelvo el resultado
            return res;
        }
    }
}