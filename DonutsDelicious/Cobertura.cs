using System;
using System.Windows.Forms;
using Negocio;
using Microsoft.Extensions.DependencyInjection;
using Datos.Models;
using DonutsDelicious;

namespace Presentacion
{
    public partial class Cobertura : Form
    {
        private readonly AutomataService _automataService;
        private readonly DonasContext _context;
        private readonly IServiceProvider _serviceProvider;

        public Cobertura(AutomataService automataService, DonasContext context, IServiceProvider serviceProvider)
        {
            _automataService = automataService;
            _context = context;
            _serviceProvider = serviceProvider;
            InitializeComponent();
            InicializarFormulario();
        }

        private void InicializarFormulario()
        {
            var coberturas = _context.DonaCoberturas.ToList();
            foreach (var cobertura in coberturas)
            {
                var button = new Button
                {
                    Text = cobertura.Nombre,
                    Tag = cobertura.Id,
                    AutoSize = true
                };
                button.Click += (sender, e) =>
                {
                    _automataService.IngresarCobertura((int)((Button)sender).Tag);
                    // Aquí puedes agregar lógica adicional si necesitas manejar más coberturas
                };
                flowLayoutPanel1.Controls.Add(button);
            }

            var btnSinToppings = new Button
            {
                Text = "Sin Toppings",
                AutoSize = true
            };
            btnSinToppings.Click += (sender, e) =>
            {
                var pagoForm = _serviceProvider.GetRequiredService<ResumenPedido>();
                pagoForm.Show();
                this.Hide();
            };
            flowLayoutPanel1.Controls.Add(btnSinToppings);
        }

        private void Cobertura_Load(object sender, EventArgs e)
        {

        }

        private void btnSinToppings_Click(object sender, EventArgs e)
        {
            var toppingsForm = _serviceProvider.GetRequiredService<Topings>();
            toppingsForm.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var selectedToppings = flowLayoutPanel1.Controls.OfType<CheckBox>()
                                          .Where(cb => cb.Checked)
                                          .Select(cb => (int)cb.Tag)
                                          .ToArray();
            _automataService.IngresarToppings(selectedToppings);

            var pagoForm = _serviceProvider.GetRequiredService<ResumenPedido>();
            pagoForm.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var pagoForm = _serviceProvider.GetRequiredService<Relleno>();
            pagoForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
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
