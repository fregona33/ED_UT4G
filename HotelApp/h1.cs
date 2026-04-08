using System;

namespace HotelApp
{
    /// <summary>
    /// Clase h1: Gestiona el cálculo de precios para las reservas del hotel.
    /// Esta versión combina las optimizaciones del Alumno A (Constantes) 
    /// y la refactorización del Alumno B (Switch y Método Extraído).
    /// </summary>
    public class h1
    {
        // FASE 3 (Alumno A): Constantes para eliminar números mágicos
        private const decimal DESCUENTO_VIP = 0.85m;
        private const decimal DESCUENTO_ESTANCIA_LARGA = 0.05m;
        private const int DIAS_ESTANCIA_LARGA = 7;
        private const decimal TARIFA_DESAYUNO = 12m;

        // Atributos de la reserva
        public int t; // Tipo de habitación (1: Individual, 2: Doble, 3: Suite)
        public int d; // Días de estancia
        public bool v; // Indica si es cliente VIP
        public int b; // Indica si incluye desayuno (1: Sí, 0: No)

        /// <summary>
        /// Calcula el precio total de la reserva procesando tarifas, extras y descuentos.
        /// </summary>
        /// <returns>Precio total final en formato decimal.</returns>
        /// <exception cref="ArgumentException">Se lanza si la cantidad de días es menor a 1.</exception>
        public decimal procesar()
        {
            // FASE 3 (Alumno A): Cláusula de guarda para validar la entrada
            if (d < 1)
            {
                throw new ArgumentException("La cantidad de días debe ser mayor a 0.");
            }

            // FASE 3 (Alumno B): Cálculo de tarifa base mediante método extraído
            decimal tarifaBase = CalcularTarifaBase();
            decimal total = tarifaBase * d;

            // Cálculo del suplemento por desayuno
            if (b == 1)
            {
                total += (TARIFA_DESAYUNO * d);
            }

            // Aplicación de descuento por estancia larga
            if (d > DIAS_ESTANCIA_LARGA)
            {
                total -= total * DESCUENTO_ESTANCIA_LARGA;
            }

            // Aplicación de descuento por cliente VIP
            if (v)
            {
                total *= DESCUENTO_VIP;
            }

            return total;
        }

        /// <summary>
        /// FASE 3 (Alumno B): Método privado que determina la tarifa base por noche.
        /// Utiliza una expresión switch para mejorar la legibilidad.
        /// </summary>
        /// <returns>Precio por noche según el tipo de habitación.</returns>
        private decimal CalcularTarifaBase()
        {
            return t switch
            {
                1 => 50m,  // Individual
                2 => 75m,  // Doble
                3 => 150m, // Suite
                _ => throw new Exception("Tipo de habitación no válido")
            };
        }
    }
}