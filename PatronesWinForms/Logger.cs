using System;
using System.IO;

namespace PatronesWinForms
{
    public class Logger
    {
        private static Logger instancia;
        private readonly string ruta = "log.txt";

        private Logger() { }

        public static Logger ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new Logger();
            return instancia;
        }

        public void Log(string mensaje)
        {
            File.AppendAllText(ruta, $"{DateTime.Now}: {mensaje}{Environment.NewLine}");
        }
    }
}
