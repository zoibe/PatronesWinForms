using System;

namespace PatronesWinForms
{
    public class Suma : IOperacion
    {
        private string tipo;

        public Suma(string tipo)
        {
            this.tipo = tipo;
        }

        public double Calcular(double a, double b)
        {
            if (tipo == "suma") return a + b;
            if (tipo == "multiplicacion") return a * b;
            throw new InvalidOperationException("Operación no soportada en Suma");
        }
    }
}
