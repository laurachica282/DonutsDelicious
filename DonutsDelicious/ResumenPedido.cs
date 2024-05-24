using System;
using System.Windows.Forms;
using Negocio;
using Microsoft.Extensions.DependencyInjection;
using Datos.Models;
using DonutsDelicious;

namespace Presentacion
{
    public partial class ResumenPedido : Form
    {
        private readonly AutomataService _automataService;
        private readonly DonasContext _context;
        private readonly IServiceProvider _serviceProvider;

        public ResumenPedido(AutomataService automataService, DonasContext context, IServiceProvider serviceProvider)
        {
            _automataService = automataService;
            _context = context;
            _serviceProvider = serviceProvider;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Txt_DineroIngresado_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string input = txtDineroIngresado.Text;
            MessageBox.Show($"Valor ingresado: {input}"); // Depuración adicional

            if (decimal.TryParse(input, out decimal dineroIngresado) && dineroIngresado > 0)
            {
                _automataService.IngresarDinero(dineroIngresado);

                var cambio = _automataService.ObtenerCambio();
                if (cambio >= 0)
                {
                    lblCambio.Text = $"Cambio: {cambio:C2}";
                    MessageBox.Show("Pago exitoso. ¡Gracias por su compra!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _automataService.Resetear();
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Dinero insuficiente. Total requerido: {_automataService.ObtenerPrecio():C2}. Por favor, ingrese el monto correcto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"Por favor, ingrese una cantidad válida de dinero. Valor ingresado: {input}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResumenPedido_Load(object sender, EventArgs e)
        {
            try
            {
                _automataService.CalcularPrecio();
                lblTotal.Text = $"Total: {_automataService.ObtenerPrecio():C2}";

                if (_automataService.ObtenerTipoDona() == 2) // Super
                {
                    var relleno = _context.DonaRellenos.Find(_automataService.ObtenerRellenoId());
                    var cobertura = _context.DonaCoberturas.Find(_automataService.ObtenerCoberturaId());
                    var toppings = _automataService.ObtenerToppingsIds()
                        .Select(toppingId => _context.DonaToppings.Find(toppingId)?.Nombre)
                        .Where(nombre => nombre != null)
                        .ToArray();

                    lblDetalles.Text = $"Relleno: {relleno?.Nombre ?? "N/A"}\n" +
                                       $"Cobertura: {cobertura?.Nombre ?? "N/A"}\n" +
                                       $"Toppings: {(toppings.Length > 0 ? string.Join(", ", toppings) : "Ninguno")}";
                }
                else // Clásica
                {
                    lblDetalles.Text = "Dona Clásica";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var pagoForm = _serviceProvider.GetRequiredService<Cobertura>();
            pagoForm.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("¿Está seguro que desea cancelar y volver al inicio?",
                                                 "Confirmar Cancelación",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                var inicioForm = _serviceProvider.GetRequiredService<Inicio>();
                inicioForm.Show();
                this.Close();
            }
        }
    }
}
