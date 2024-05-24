using Negocio;
using Presentacion;
using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Datos.Models;

namespace DonutsDelicious
{
    public partial class Inicio : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public Inicio(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            var tamañoForm = _serviceProvider.GetRequiredService<TamañoDona>();
            tamañoForm.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
