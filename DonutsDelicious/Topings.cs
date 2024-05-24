using Datos.Models;
using Negocio;
using System;
using System.Collections.Generic;
using System;
using System.Windows.Forms;
using Negocio;
using Microsoft.Extensions.DependencyInjection;
using Datos.Models;
using DonutsDelicious;

namespace Presentacion
{
    public partial class Topings : Form
    {
        private readonly AutomataService _automataService;
        private readonly DonasContext _context;
        private readonly IServiceProvider _serviceProvider;

        public Topings(AutomataService automataService, DonasContext context, IServiceProvider serviceProvider)
        {
            _automataService = automataService;
            _context = context;
            _serviceProvider = serviceProvider;
            InitializeComponent();
            InicializarFormulario();
        }

        private void InicializarFormulario()
        {
            var toppings = _context.DonaToppings.ToList();
            foreach (var topping in toppings)
            {
                var checkBox = new CheckBox
                {
                    Text = topping.Nombre,
                    Tag = topping.Id,
                    AutoSize = true
                };
                flowLayoutPanel1.Controls.Add(checkBox);
            }
        }

        private void btnContinuar_Click(object sender, EventArgs e)
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

        private void btnSinToppings_Click(object sender, EventArgs e)
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var pagoForm = _serviceProvider.GetRequiredService<Cobertura>();
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
