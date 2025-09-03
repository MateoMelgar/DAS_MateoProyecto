using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudWindsForms
{
    public partial class FrmNuevo : Form
    {
        private int? Id;
        private readonly PersonasBD repo = new PersonasBD();
        public FrmNuevo(int? id=null)
        {
            InitializeComponent();
            this.Id = id;
          
        }
        private void CargarDatos()
        {
            var persona = repo.Md(Id.Value);
            if (persona == null)
            {
                MessageBox.Show("No se encontró el registro.");
                this.Close();
                return;
            }

            txtnombre.Text = persona.Nombre;
            txtedad.Text = persona.Edad.ToString();
        }
        private void FrmNuevo_Load(object sender, EventArgs e)
        {
            if (Id.HasValue) CargarDatos();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                var nombre = txtnombre.Text.Trim();
                if (string.IsNullOrWhiteSpace(nombre))
                    throw new Exception("El nombre es obligatorio.");

                if (!int.TryParse(txtedad.Text, out var edad) || edad < 0)
                    throw new Exception("Edad inválida.");

                if (Id.HasValue)     // ✅ EDITAR
                    repo.Modificar(nombre, edad, Id.Value);
                else                 // ✅ NUEVO
                    repo.Add(nombre, edad);

                MessageBox.Show("Guardado correctamente.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }
    }
}
