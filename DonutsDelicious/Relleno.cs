using System;
using System.Windows.Forms;
using Negocio;
using Microsoft.Extensions.DependencyInjection;
using Datos.Models;
using DonutsDelicious;

namespace Presentacion
{
    public partial class Relleno : Form
    {
        private readonly AutomataService _automataService;
        private readonly IServiceProvider _serviceProvider;
        private readonly DonasContext _context;


        public Relleno(AutomataService automataService, IServiceProvider serviceProvider, DonasContext context)
        {
            _automataService = automataService;
            _serviceProvider = serviceProvider;
            _context = context;
            InitializeComponent();
            InicializarFormulario();
        }

        private void InicializarFormulario()
        {
            var rellenos = _context.DonaRellenos.ToList();
            foreach (var relleno in rellenos)
            {
                var button = new Button
                {
                    Text = relleno.Nombre,
                    Tag = relleno.Id,
                    AutoSize = true
                };
                button.Click += (sender, e) =>
                {
                    _automataService.IngresarRelleno((int)((Button)sender).Tag);
                    // Navegar al siguiente formulario
                    var coberturaForm = _serviceProvider.GetRequiredService<Cobertura>();
                    coberturaForm.Show();
                    this.Hide();
                };
                flowLayoutPanel1.Controls.Add(button); // Asume que tienes un FlowLayoutPanel llamado flowLayoutPanel en el formulario
            }
        }

        private void Relleno_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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
            var tamañoForm = _serviceProvider.GetRequiredService<TipoDona>();
            tamañoForm.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
