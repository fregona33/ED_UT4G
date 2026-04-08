using System;

namespace HotelApp
{
    public class h1
    {
        // Atributos públicos (Deuda técnica inicial)
        public int t; // tipo habitacion (1: Individual, 2: Doble, 3: Suite)
        public int d; // dias de estancia
        public bool v; // es cliente VIP
        public int b; // incluye desayuno (1: si, 0: no)

        /// <summary>
        /// Método principal procesar. Refactorizado por Alumno B (Fase 3).
        /// </summary>
        public decimal procesar()
        {
            // Cláusula de guarda para evitar días negativos
            if (d < 0) throw new Exception("Dias no validos");

            // FASE 3: Uso del método extraído para obtener la tarifa base
            decimal tarifaBase = CalcularTarifaBase();
            decimal res = d * tarifaBase;

            // Lógica de extras (desayuno)
            if (b == 1) res += (d * 15);

            // Lógica de descuentos (VIP y Estancia Larga)
            if (d >= 10) res *= 0.95m; // Descuento 5% estancia larga
            if (v) res *= 0.85m;       // Descuento 15% VIP

            return res;
        }

        /// <summary>
        /// FASE 3: Alumno B - Método extraído para calcular la tarifa según el tipo.
        /// Implementa una estructura switch moderna.
        /// </summary>
        private decimal CalcularTarifaBase()
        {
            return t switch
            {
                1 => 50m,  // Tarifa Individual
                2 => 75m,  // Tarifa Doble
                3 => 150m, // Tarifa Suite
                _ => throw new Exception("Tipo invalido")
            };
        }
    }
}