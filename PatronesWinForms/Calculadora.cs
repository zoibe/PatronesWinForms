using System;

namespace PatronesWinForms
{
    public class Calculadora
    {
        private IOperacion operacion;

        public Calculadora() { }

        public Calculadora(IOperacion operacion)
        {
            this.operacion = operacion;
        }

        public void EstablecerOperacion(IOperacion operacion)
        {
            this.operacion = operacion;
        }

        public double Calcular(double a, double b)
        {
            if (operacion == null)
                throw new InvalidOperationException("No se ha establecido una operación");

            return operacion.Calcular(a, b);
        }
    }
}
