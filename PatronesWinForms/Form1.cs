using System;
using System.Drawing;
using System.Windows.Forms;

namespace PatronesWinForms
{
    public class Form1 : Form
    {
        private TextBox txtNumero1;
        private TextBox txtNumero2;
        private Label lblResultado;

        public Form1()
        {
            this.Text = "Calculadora con Patrones";
            this.Size = new Size(420, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(50, 50, 55);

            InicializarComponentes();
        }

        private void InicializarComponentes()
        {
            Label lbl1 = new Label
            {
                Text = "Número 1:",
                Location = new Point(30, 30),
                Size = new Size(100, 25),
                Font = new Font("Segoe UI", 10, FontStyle.Italic),
                ForeColor = Color.White
            };
            this.Controls.Add(lbl1);

            txtNumero1 = new TextBox
            {
                Location = new Point(130, 30),
                Size = new Size(200, 30),
                Font = new Font("Segoe UI", 10)
            };
            this.Controls.Add(txtNumero1);

            Label lbl2 = new Label
            {
                Text = "Número 2:",
                Location = new Point(30, 70),
                Size = new Size(100, 25),
                Font = new Font("Segoe UI", 10, FontStyle.Italic),
                ForeColor = Color.White
            };
            this.Controls.Add(lbl2);

            txtNumero2 = new TextBox
            {
                Location = new Point(130, 70),
                Size = new Size(200, 30),
                Font = new Font("Segoe UI", 10)
            };
            this.Controls.Add(txtNumero2);

            Button btnSumar = CrearBoton("Sumar", 30, 120, (s, e) => EjecutarOperacion("suma"));
            Button btnRestar = CrearBoton("Restar", 160, 120, (s, e) => EjecutarOperacion("resta"));
            Button btnMultiplicar = CrearBoton("Multiplicar", 30, 170, (s, e) => EjecutarOperacion("multiplicacion"));
            Button btnDividir = CrearBoton("Dividir", 160, 170, (s, e) => EjecutarOperacion("division"));

            this.Controls.Add(btnSumar);
            this.Controls.Add(btnRestar);
            this.Controls.Add(btnMultiplicar);
            this.Controls.Add(btnDividir);

            lblResultado = new Label
            {
                Text = "Resultado:",
                Location = new Point(30, 220),
                Size = new Size(350, 30),
                Font = new Font("Segoe UI", 10, FontStyle.Italic),
                ForeColor = Color.White
            };
            this.Controls.Add(lblResultado);
        }

        private Button CrearBoton(string texto, int x, int y, EventHandler accion)
        {
            var boton = new Button
            {
                Text = texto,
                Location = new Point(x, y),
                Size = new Size(120, 35),
                Font = new Font("Segoe UI", 10, FontStyle.Italic),
                BackColor = Color.FromArgb(70, 70, 75),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            boton.Click += accion;
            return boton;
        }

        private void EjecutarOperacion(string tipoOperacion)
        {
            try
            {
                double numero1 = double.Parse(txtNumero1.Text);
                double numero2 = double.Parse(txtNumero2.Text);

                IOperacion operacion;

                if (tipoOperacion == "suma" || tipoOperacion == "multiplicacion")
                {
                    operacion = new Suma(tipoOperacion);
                }
                else if (tipoOperacion == "resta" || tipoOperacion == "division")
                {
                    operacion = new Resta(tipoOperacion);
                }
                else
                {
                    throw new InvalidOperationException("Operación desconocida");
                }

                Calculadora calc = new Calculadora();
                calc.EstablecerOperacion(operacion);
                double resultado = calc.Calcular(numero1, numero2);

                lblResultado.Text = $"Resultado: {resultado}";

                Logger log = Logger.ObtenerInstancia();
                log.Log($"Operación: {tipoOperacion}, Resultado: {resultado}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
