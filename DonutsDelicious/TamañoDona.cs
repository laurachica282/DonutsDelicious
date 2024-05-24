using System;
using System.Windows.Forms;
using Negocio;
using Microsoft.Extensions.DependencyInjection;
using Datos.Models;
using DonutsDelicious;

namespace Presentacion
{
    public partial class TamañoDona : Form
    {
        private readonly AutomataService _automataService;
        private readonly IServiceProvider _serviceProvider;
        private readonly DonasContext _context;

        public TamañoDona(AutomataService automataService, IServiceProvider serviceProvider, DonasContext context)
        {
            _automataService = automataService;
            _serviceProvider = serviceProvider;
            _context = context;
            InitializeComponent();
            InicializarFormulario();
        }

        private void InicializarFormulario()
        {
            var tamanos = _context.DonaTamaños.ToList();
            foreach (var tamano in tamanos)
            {
                var button = new Button
                {
                    Text = tamano.Nombre,
                    Tag = tamano.Id,
                    AutoSize = true
                };
                button.Click += (sender, e) =>
                {
                    _automataService.IngresarTamano((int)((Button)sender).Tag);
                    var tipoDonaForm = _serviceProvider.GetRequiredService<TipoDona>();
                    tipoDonaForm.Show();
                    this.Hide();
                };
                flowLayoutPanel.Controls.Add(button);
            }
        }

        private void flowLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

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
    }
}
