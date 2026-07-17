using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace prueba // <--- Volvemos a usar 'prueba' para solucionar todos los errores rojos
{
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            InitializeComponent(); // ¡Ahora sí volverá a funcionar!

            // --- TRUCO PARA EL DISEÑADOR ---
            try
            {
                RJButton botonPrueba = new RJButton();
                botonPrueba.Text = "Despierta VS";
            }
            catch (Exception) { }
            // --------------------------------
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            // Código de tu botón de MaterialSkin
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Código al cargar la ventana
        }
    }
}