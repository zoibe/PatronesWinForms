using System;

namespace PatronesWinForms
{
    public class Resta : IOperacion
    {
        private string tipo;

        public Resta(string tipo)
        {
            this.tipo = tipo;
        }

        public double Calcular(double a, double b)
        {
            if (tipo == "resta") return a - b;
            if (tipo == "division")
            {
                if (b == 0) throw new DivideByZeroException("No se puede dividir por cero");
                return a / b;
            }
            throw new InvalidOperationException("Operación no soportada en Resta");
        }
    }
}
