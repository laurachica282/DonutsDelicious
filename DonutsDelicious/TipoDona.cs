using System;
using System.Windows.Forms;
using Negocio;
using Microsoft.Extensions.DependencyInjection;
using Datos.Models;
using DonutsDelicious;

namespace Presentacion
{
    public partial class TipoDona : Form
    {
        private readonly AutomataService _automataService;
        private readonly IServiceProvider _serviceProvider;
        private readonly DonasContext _context;

        public TipoDona(AutomataService automataService, IServiceProvider serviceProvider, DonasContext context)
        {
            InitializeComponent();
            _automataService = automataService;
            _serviceProvider = serviceProvider;
            _context = context;
            InicializarFormulario();
        }

        private void TipoDona_Load(object sender, EventArgs e)
        {

        }

        private void InicializarFormulario()
        {
            var tipos = _context.DonaTipos.ToList();
            foreach (var tipo in tipos)
            {
                var button = new Button
                {
                    Text = tipo.Nombre,
                    Tag = tipo.Id,
                    AutoSize = true
                };
                button.Click += (sender, e) =>
                {
                    _automataService.IngresarTipoDona((int)((Button)sender).Tag);
                    if (_automataService.ObtenerTipoDona() == 2) // Super
                    {
                        var rellenoForm = _serviceProvider.GetRequiredService<Relleno>();
                        rellenoForm.Show();
                    }
                    else // Clásica
                    {
                        var pagoForm = _serviceProvider.GetRequiredService<ResumenPedido>();
                        pagoForm.Show();
                    }
                    this.Hide();
                };
                flowLayoutPanel.Controls.Add(button);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var tamañoForm = _serviceProvider.GetRequiredService<TamañoDona>();
            tamañoForm.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
