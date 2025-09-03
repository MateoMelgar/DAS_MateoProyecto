using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; 
namespace CrudWindsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Actualizar();
        }
        
        private void Actualizar()
        {
            PersonasBD persona = new PersonasBD();
            dataGridView1.DataSource = persona.Lista();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            FrmNuevo frmNuevo = new FrmNuevo();
            frmNuevo.ShowDialog();
            Actualizar();
        }
        #region Helper
        private int? GetId()
        {
            try
            {
                return int.Parse(
                    dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString()
                );
            }
            catch
            {
                return null;
            }         
        }
        #endregion
        private void btneliminar_Click(object sender, EventArgs e)
        {
            var id = GetId();
            if (!id.HasValue)
            {
                MessageBox.Show("Seleccioná una fila primero.");
                return;
            }

            // OJO: si el grid autogeneró columnas desde tu modelo, el nombre es "Nombre" (con mayúscula)
            var nombre = dataGridView1.CurrentRow?.Cells["Nombre"]?.Value?.ToString();
            // Si no tenés la columna por nombre, podés usar índice: 
            // var nombre = dataGridView1.CurrentRow?.Cells[1]?.Value?.ToString();

            // Armamos el texto sin interpolación anidada
            string texto = string.IsNullOrWhiteSpace(nombre)
                ? $"¿Eliminar ID {id.Value}?"
                : $"¿Eliminar '{nombre}' (ID {id.Value})?";

            var confirmar = MessageBox.Show(
                texto,
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (confirmar != DialogResult.Yes) return;

            try
            {
                var repo = new PersonasBD();
                repo.Eliminar(id.Value);
                Actualizar(); // refresca la grilla
            }
            catch (SqlException ex) when (ex.Number == 547) // FK constraint
            {
                MessageBox.Show("No se puede eliminar porque el registro está relacionado con otros datos.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            var id = GetId();
            if (!id.HasValue) { MessageBox.Show("Elegí una fila."); return; }

            using (var frm = new FrmNuevo(id))
                if (frm.ShowDialog() == DialogResult.OK)
                    Actualizar();
        }

      
        private void btneliminar_Click_1(object sender, EventArgs e)
        {
            var id = GetId();
            if (!id.HasValue)
            {
                MessageBox.Show("Seleccioná una fila primero.");
                return;
            }
            var nombre = dataGridView1.CurrentRow?.Cells["Nombre"]?.Value?.ToString();

            string texto = string.IsNullOrWhiteSpace(nombre)
                ? $"¿Eliminar ID {id.Value}?"
                : $"¿Eliminar '{nombre}' (ID {id.Value})?";

            var confirmar = MessageBox.Show(
                texto,
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (confirmar != DialogResult.Yes) return;

            try
            {
                var repo = new PersonasBD();
                repo.Eliminar(id.Value);
                Actualizar(); // refresca la grilla
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                MessageBox.Show("No se puede eliminar porque el registro está relacionado con otros datos.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }
    }
}
