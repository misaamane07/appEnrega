using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        cls_Estudiantes[] Estudiantes = new cls_Estudiantes [100];
        int posicion = 0, registro = 0;
        Boolean sw = false;
        string ruta_directorio_Raiz;
        public Form1()
        {
            InitializeComponent();
            ruta_directorio_Raiz = Path.Combine(Application.StartupPath + "\\Imagenes");
            fnt_LimpiarControles();
        }
        private void fnt_LimpiarControles()
        {
            txt_apellidos.Clear();
            txt_contactos.Clear();
            txt_correos.Clear();
            txt_identificacion.Clear();
            txt_nombres.Clear();
            ptb_Foto.Image = Image.FromFile(ruta_directorio_Raiz + "\\user_vacio.png");
            txt_identificacion.Focus();//Ubicar en la caja de texto inicial.
        }
        private void btn_NuevoEstudiante_Click(object sender, EventArgs e)
        {
            fnt_LimpiarControles();
        }
        private void fnt_GuardarEstudiantes(string id, string n, string a, string cot, string corr)
        {
            sw = false;
            for (int i = 0; i < dtg_Estudiantes.RowCount; i++)
            {
                if (id.Equals(dtg_Estudiantes.Rows[i].Cells[0].Value))
                {
                    sw = true;
                    break;
                }
            }
            if (sw == false)
            {
                ptb_Foto.Image.Save(ruta_directorio_Raiz + "\\" + id + ".jpg", ImageFormat.Jpeg);
                string rfot = ruta_directorio_Raiz + "\\" + id + ".jpg";
                dtg_Estudiantes.Rows.Add(id, n, a, cot, corr, rfot);
                MessageBox.Show("La persona " + n + " ha sido registrada");
                fnt_LimpiarControles();
            }
            else
            {
                MessageBox.Show("Esta persona ya se encuentra registrado");
            }
        }
        private void btn_GuardaEstudinate_Click(object sender, EventArgs e)
        {
             if (txt_identificacion.Text == "" || txt_nombres.Text == "" || txt_apellidos.Text == "" ||
                txt_contactos.Text == "" || txt_correos.Text == "")
            {
                MessageBox.Show("Debe ingresar toda la información solicitada");
            }
            else
            {
                fnt_GuardarEstudiantes (txt_identificacion.Text, txt_nombres.Text, txt_apellidos.Text,
                    txt_contactos.Text, txt_correos.Text);
            }
        }
        private void fnt_ConsultarEstudiante(string id)
        {
            posicion = 0;
            sw = false;
            if (id.Equals(""))
            {
                MessageBox.Show("Ingrese el criterio de busqueda");
            }
            else
            {
                for (int i = 0; i < dtg_Estudiantes.RowCount; i++)
                {
                    if (id.Equals(dtg_Estudiantes.Rows[i].Cells[0].Value))
                    {
                        posicion = i;
                        sw = true;
                        break;
                    }
                }
                if (sw == false)
                {
                    MessageBox.Show("No existen registros para mostrar");
                }
                else
                {//Traer los datos desde el datagridview de acuerdo a la posición de celda variable.
                    txt_nombres.Text = Convert.ToString(dtg_Estudiantes.Rows[posicion].Cells[1].Value);
                    txt_apellidos.Text = Convert.ToString(dtg_Estudiantes.Rows[posicion].Cells[2].Value);
                    txt_contactos.Text = Convert.ToString(dtg_Estudiantes.Rows[posicion].Cells[3].Value);
                    txt_correos.Text = Convert.ToString(dtg_Estudiantes.Rows[posicion].Cells[4].Value);
                }
            }
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            fnt_ConsultarEstudiante(txt_identificacion.Text);
        }
        private void fnt_ActualizarEstudiantes(string nP, string aP, string cotP, string corrP, string rfotP)
        {
            dtg_Estudiantes.Rows[posicion].Cells[1].Value = nP;
            dtg_Estudiantes.Rows[posicion].Cells[2].Value = aP;
            dtg_Estudiantes.Rows[posicion].Cells[3].Value = cotP;
            dtg_Estudiantes.Rows[posicion].Cells[4].Value = corrP;
            dtg_Estudiantes.Rows[posicion].Cells[5].Value = rfotP;
            MessageBox.Show("Registro actualizado de forma exitosa");


        }
        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            fnt_ActualizarEstudiantes(txt_nombres.Text, txt_apellidos.Text, txt_contactos.Text, txt_correos.Text, "");
        }
        private void fnt_LimpiarControlesProfesor()
        {
            txt_apellidosP.Clear();
            txt_contactoP.Clear();
            txt_correoP.Clear();
            txt_idP.Clear();
            txt_nombresP.Clear();
            ptb_fotoP.Dispose();
            txt_idP.Focus();//Ubicar en la caja de texto inicial.
        }
        private void btn_NuevoProfesor_Click(object sender, EventArgs e)
        {
          fnt_LimpiarControlesProfesor();
        }
        private void fnt_GuardarProfesores(string idP, string nP, string aP, string cotP, string corrP, string rfotP)
        {
            sw = false;
            posicion = 0;
            for (int i = 0; i < dtg_profesor.RowCount; i++)
            {
                if (idP.Equals(dtg_profesor.Rows[i].Cells[0].Value))
                {
                    sw = true;
                    break;
                }
            }
            if (sw == false)
            {
                dtg_profesor.Rows.Add(idP, nP, aP, cotP, corrP, rfotP);
                MessageBox.Show("Registro exitoso");
            }
            else
            {
                MessageBox.Show("Esta persona ya se encuentra registrado");
            }
        }
        private void btn_Guardarprofesor_Click(object sender, EventArgs e)
        {
            if (txt_idP.Text == "" || txt_nombresP.Text == "" || txt_apellidosP.Text == "" ||
                txt_contactoP.Text == "" || txt_correoP.Text == "")
            {
                MessageBox.Show("Debe ingresar toda la información solicitada");
            }
            else
            {
                fnt_GuardarProfesores (txt_idP.Text, txt_nombresP.Text, txt_apellidosP.Text,
                    txt_contactoP.Text, txt_correoP.Text, "");
            }
        }
        private void fnt_Buscarprofesor(string idP)
        {
            posicion = 0;
            sw = false;
            if (idP.Equals(""))
            {
                MessageBox.Show("Ingrese el criterio de busqueda");
            }
            else
            {
                for (int i = 0; i < dtg_profesor.RowCount; i++)
                {
                    if (idP.Equals(dtg_profesor.Rows[i].Cells[0].Value))
                    {
                        posicion = i;
                        sw = true;
                        break;
                    }
                }
                if (sw == false)
                {
                    MessageBox.Show("No existen registros para mostrar");
                }
                else
                {//Traer los datos desde el datagridview de acuerdo a la posición de celda variable.
                    txt_nombresP.Text = Convert.ToString(dtg_profesor.Rows[posicion].Cells[1].Value);
                    txt_apellidosP.Text = Convert.ToString(dtg_profesor.Rows[posicion].Cells[2].Value);
                    txt_contactoP.Text = Convert.ToString(dtg_profesor.Rows[posicion].Cells[3].Value);
                    txt_correoP.Text = Convert.ToString(dtg_profesor.Rows[posicion].Cells[4].Value);
                }
            }
        }
        private void btn_Buscarprofesor_Click(object sender, EventArgs e)
        {
            fnt_Buscarprofesor(txt_idP.Text);
        }
        private void fnt_Actualizarprofesor(string nP, string aP, string cotP, string corrP, string rfotP)
        {
            dtg_profesor.Rows[posicion].Cells[1].Value = nP;
            dtg_profesor.Rows[posicion].Cells[2].Value = aP;
            dtg_profesor.Rows[posicion].Cells[3].Value = cotP;
            dtg_profesor.Rows[posicion].Cells[4].Value = corrP;
            dtg_profesor.Rows[posicion].Cells[5].Value = rfotP;
            MessageBox.Show("Registro actualizado de forma exitosa");


        }
        private void btn_Actualizarprofesor_Click(object sender, EventArgs e)
        {
            fnt_Actualizarprofesor(txt_nombresP.Text, txt_apellidosP.Text, txt_contactoP.Text, txt_correoP.Text, "");
        }

        private void txt_contactos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 55 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }


        }

        private void txt_identificacion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_identificacion_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }

            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
           
        }

        private void txt_contactoP_KeyPress(object sender, KeyPressEventArgs e)
        {
            
                if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 55 && e.KeyChar <= 255))
                {
                    e.Handled = true;
                    return;
                }


            
        }

        private void txt_idP_KeyPress(object sender, KeyPressEventArgs e)
        {
            
                if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 55 && e.KeyChar <= 255))
                {
                    e.Handled = true;
                    return;
                }


            
        }

        private void txt_apellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;

            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;

            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;

            }
        }

        private void txt_apellidosP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;

            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;

            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;

            }
        }

        private void txt_nombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;

            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;

            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;

            }
        }

        private void txt_nombresP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;

            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;

            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;

            }
        }

        private void ptb_fotoE_Click(object sender, EventArgs e)
        {

        }

        private void txt_nombres_TextChanged(object sender, EventArgs e)
        {

        }

        private void ptb_Foto_Click(object sender, EventArgs e)
        {
            
            try
            {
                ruta_directorio_Raiz = Path.Combine(Application.StartupPath + "\\Imagenes");
                OpenFileDialog file = new OpenFileDialog();
                file.Filter = "Archivo JPG|*.jpg";

                if (file.ShowDialog() == DialogResult.OK)
                {
                    ptb_Foto.Image = Image.FromFile(file.FileName);
                }
            }
            catch { }   
        }
        }
        }
        
       

        
        

