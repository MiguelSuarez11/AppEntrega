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

namespace App_PruebaDulfran2023
{
    public partial class Form1 : Form
    {
        cls_Calificaciones[] Calificaciones = new cls_Calificaciones[100];
        cls_Anotaciones[] Anotaciones = new cls_Anotaciones[100];
        cls_Cursos[] cursos = new cls_Cursos[100];
        cls_Programacion[] programacion = new cls_Programacion[100];
        cls_Docentes[] Docentes = new cls_Docentes[100];
        cls_Estudiantes[] Estudiante = new cls_Estudiantes[100];
        int posicion = 0, registro = 0;
        Boolean sw = false;
        string ruta_directorio_Raiz;
        public Form1()
        {
            InitializeComponent();
            ruta_directorio_Raiz = Path.Combine(Application.StartupPath + "\\Imagenes");
            fnt_LimpiarControles();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello word");
        }
        private void fnt_LimpiarControles()
        {
            txt_Apellidos.Clear();
            txt_Contacto.Clear();
            txt_Correo.Clear();
            txt_ID.Clear();
            txt_Nombres.Clear();
            ptb_Foto.Image = Image.FromFile(ruta_directorio_Raiz + "\\user_vacio.png");
            txt_ID.Focus();
        }
        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            fnt_LimpiarControles();
        }
        private void fnt_GuardarEstudiante(string id, string n, string a, string cot, string corr)
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


        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            if (txt_ID.Text == "" || txt_Nombres.Text == "" || txt_Apellidos.Text == "" ||
                txt_Contacto.Text == "" || txt_Correo.Text == "")
            {
                MessageBox.Show("Debe ingresar toda la información solicitada");
            }
            else
            {
                fnt_GuardarEstudiante(txt_ID.Text, txt_Nombres.Text, txt_Apellidos.Text,
                    txt_Contacto.Text, txt_Correo.Text);
            }
        }
        private void fnt_ConsultarEstudiante(string id)
        {
            posicion = 0;
            sw = false;
            if (id.Equals(""))
            {
                MessageBox.Show("Debe ingresar criterio de busqueda");
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
                {
                    // traer los datos desde el datagriview de acuerdo a la posicion de celda variable,
                    txt_Nombres.Text = Convert.ToString(dtg_Estudiantes.Rows[posicion].Cells[1].Value);
                    txt_Apellidos.Text = Convert.ToString(dtg_Estudiantes.Rows[posicion].Cells[2].Value);
                    txt_Contacto.Text = Convert.ToString(dtg_Estudiantes.Rows[posicion].Cells[3].Value);
                    txt_Correo.Text = Convert.ToString(dtg_Estudiantes.Rows[posicion].Cells[4].Value);
                    ptb_Foto.Image = Image.FromFile(Convert.ToString(dtg_Estudiantes.Rows[posicion].Cells[5].Value));
                }
            }

        }
        private void btn_Consultar_Click(object sender, EventArgs e)
        {
            fnt_ConsultarEstudiante(txt_ID.Text);
        }
        private void fnt_ActualizarEstudiante(string n, string a, string cot, string corr, string rfot)
        {
            dtg_Estudiantes.Rows[posicion].Cells[1].Value = n;
            dtg_Estudiantes.Rows[posicion].Cells[2].Value = a;
            dtg_Estudiantes.Rows[posicion].Cells[3].Value = cot;
            dtg_Estudiantes.Rows[posicion].Cells[4].Value = corr;
            dtg_Estudiantes.Rows[posicion].Cells[5].Value = rfot;
            MessageBox.Show("Registro actualizado con exito");
        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            fnt_ActualizarEstudiante(txt_Nombres.Text, txt_Apellidos.Text, txt_Contacto.Text, txt_Correo.Text, "");
        }

        private void fnt_LimpiarControlesDocentes()
        {
            txt_ContactoDocentes.Clear();
            txt_CorreoDocentes.Clear();
            txt_IdDocente.Clear();
            txt_NombreDocentes.Clear();
            txt_IdDocente.Focus();
        }
        private void btn_NuevoDocente_Click(object sender, EventArgs e)
        {
            fnt_LimpiarControlesDocentes();
        }

        private void btn_GuardarDocente_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fnt_GuardarDocente(string IdDoc, string NomDoc, string ContDoc, string corrDoc)
        {
            sw = false;
            posicion = 0;
            for (int i = 0; i < dtg_Docentes.RowCount; i++)
            {
                if (IdDoc.Equals(dtg_Docentes.Rows[i].Cells[0].Value))
                {
                    sw = true;
                    break;
                }
            }
            if (sw == false)
            {
                dtg_Docentes.Rows.Add(IdDoc, NomDoc, ContDoc, corrDoc);
                MessageBox.Show("Registro exitoso");
            }
            else
            {
                MessageBox.Show("Esta persona ya esta registrada");
            }
        }
        private void fnt_ConsultarDocente(string IdDoc)
        {
            posicion = 0;
            sw = false;
            if (IdDoc.Equals(""))
            {
                MessageBox.Show("Debe ingresar criterio de busqueda");
            }
            else
            {
                for (int i = 0; i < dtg_Docentes.RowCount; i++)
                {
                    if (IdDoc.Equals(dtg_Docentes.Rows[i].Cells[0].Value))
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
                {
                    txt_NombreDocentes.Text = Convert.ToString(dtg_Docentes.Rows[posicion].Cells[1].Value);
                    txt_ContactoDocentes.Text = Convert.ToString(dtg_Docentes.Rows[posicion].Cells[2].Value);
                    txt_CorreoDocentes.Text = Convert.ToString(dtg_Docentes.Rows[posicion].Cells[3].Value);
                }
            }

        }
        private void btn_ConsultarDocente_Click(object sender, EventArgs e)
        {
            fnt_ConsultarDocente(txt_IdDocente.Text);
        }
        private void fnt_ActualizarDocente(string NomDoc, string ContDoc, string corrDoc)
        {
            dtg_Docentes.Rows[posicion].Cells[1].Value = NomDoc;
            dtg_Docentes.Rows[posicion].Cells[2].Value = ContDoc;
            dtg_Docentes.Rows[posicion].Cells[3].Value = corrDoc;
            MessageBox.Show("Registro actualizado con exito");
        }
        private void btn_ActualizarDocente_Click(object sender, EventArgs e)
        {
            fnt_ActualizarDocente(txt_NombreDocentes.Text, txt_ContactoDocentes.Text, txt_CorreoDocentes.Text);
        }

        private void txt_ID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_Nombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_Apellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_Contacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_Correo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txt_IdDocente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_NombreDocentes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_ContactoDocentes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }

        private void btn_GuardarDocente_Click_1(object sender, EventArgs e)
        {
            if (txt_IdDocente.Text == "" ||
                txt_NombreDocentes.Text == "" || txt_ContactoDocentes.Text == "" ||
                txt_CorreoDocentes.Text == "")
            {
                MessageBox.Show("Debe ingresat toda la informacion solicitada");
            }
            else
            {
                fnt_GuardarDocente(txt_IdDocente.Text, txt_NombreDocentes.Text, txt_ContactoDocentes.Text, txt_CorreoDocentes.Text);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Today;
        }


        private void pictureBox6_Click(object sender, EventArgs e)
        {
            fecha.Text = DateTime.Today.ToShortDateString();
        }
        private void fnt_LimpiarControlesPrograma()
        {
            fecha.Clear();
            txt_Id_Doc.Clear();
            txt_Id_Est.Clear();
            txt_Cod_Cur.Clear();
            txt_Id_Doc.Focus();
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            fnt_LimpiarControlesPrograma();
        }

        private void fecha_TextChanged(object sender, EventArgs e)
        {

        }
        private void fnt_GuardarProgramacion(string fecha, string Id_Docen, string Id_Est, string cod_Cur)
        {
            sw = false;
            posicion = 0;
            for (int i = 0; i < dtg_Programacion.RowCount; i++)
            {
                if (Id_Docen.Equals(dtg_Programacion.Rows[i].Cells[1].Value))
                {
                    sw = true;
                    break;

                }
            }
            if (sw == false)
            {
                dtg_Programacion.Rows.Add(fecha, Id_Docen, Id_Est, cod_Cur);
                MessageBox.Show("registro exitoso");
            }
            else
            {
                MessageBox.Show("Esta persona ya esta registrada");
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (fecha.Text == "" ||
                txt_Id_Doc.Text == "" ||
                txt_Id_Est.Text == "" ||
                txt_Cod_Cur.Text == "")
            {
                MessageBox.Show("Debe ingrear criterio de busqueda");
            }
            else
            {
                fnt_GuardarProgramacion(fecha.Text, txt_Id_Doc.Text, txt_Id_Est.Text, txt_Cod_Cur.Text);
            }
        }

        private void fnt_ConsultarPrograma(string Id_Docen)
        {
            posicion = 0;
            sw = false;
            if (Id_Docen.Equals(""))
            {
                MessageBox.Show("Debe ingresar criterio de busqueda");
            }
            else
            {
                for (int i = 0; i < dtg_Programacion.RowCount; i++)
                {
                    if (Id_Docen.Equals(dtg_Programacion.Rows[i].Cells[1].Value))
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
                {
                    fecha.Text = Convert.ToString(dtg_Programacion.Rows[posicion].Cells[0].Value);
                    txt_Id_Est.Text = Convert.ToString(dtg_Programacion.Rows[posicion].Cells[2].Value);
                    txt_Cod_Cur.Text = Convert.ToString(dtg_Programacion.Rows[posicion].Cells[3].Value);
                }
            }

        }
        private void btn_Consultar_programa_Click(object sender, EventArgs e)
        {
            fnt_ConsultarPrograma(txt_Id_Doc.Text);
        }
        private void fnt_Actualizarprograma(string fecha, string Id_Est, string cod_Cur)
        {
            dtg_Programacion.Rows[posicion].Cells[0].Value = fecha;
            dtg_Programacion.Rows[posicion].Cells[2].Value = Id_Est;
            dtg_Programacion.Rows[posicion].Cells[3].Value = cod_Cur;
            MessageBox.Show("Registro actualizado con exito");
        }

        private void btn_Actualizarprograma_Click(object sender, EventArgs e)
        {
            fnt_Actualizarprograma(fecha.Text,
            txt_Id_Est.Text,
            txt_Cod_Cur.Text);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            txt_Fecha2.Text = DateTime.Today.ToShortDateString();
        }
        private void fnt_LimpiarControlesCursos()
        {
            txt_Codigo_Curso.Clear();
            txt_Nombre_Curso.Clear();
            txt_Creditos.Clear();
            txt_Valor.Clear();
            txt_Horario.Clear();
            txt_Codigo_Curso.Focus();
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            fnt_LimpiarControlesCursos();
        }
        private void fnt_GuardarCursos(string Codigo, string NombreCur, string Creditos, string Valor, string Horario)
        {
            sw = false;
            posicion = 0;
            for (int i = 0; i < dtg_Cursos.RowCount; i++)
            {
                if (Codigo.Equals(dtg_Cursos.Rows[i].Cells[0].Value))
                {
                    sw = true;
                    break;

                }
            }
            if (sw == false)
            {
                dtg_Cursos.Rows.Add(Codigo, NombreCur, Creditos, Valor, Horario);
                MessageBox.Show("registro exitoso");
            }
            else
            {
                MessageBox.Show("Esta persona ya esta registrada");
            }
        }

        private void btn_GuardarCurso_Click(object sender, EventArgs e)
        {
            if (txt_Codigo_Curso.Text == "" ||
               txt_Nombre_Curso.Text == "" ||
               txt_Creditos.Text == "" ||
               txt_Valor.Text == "" ||
               txt_Horario.Text == "")
            {
                MessageBox.Show("Debe ingrear criterio de busqueda");
            }
            else
            {
                fnt_GuardarCursos(txt_Codigo_Curso.Text, txt_Nombre_Curso.Text, txt_Creditos.Text, txt_Valor.Text, txt_Horario.Text);
            }
        }
        private void fnt_ConsultarCurso(string Codigo)
        {
            posicion = 0;
            sw = false;
            if (Codigo.Equals(""))
            {
                MessageBox.Show("Debe ingresar criterio de busqueda");
            }
            else
            {
                for (int i = 0; i < dtg_Cursos.RowCount; i++)
                {
                    if (Codigo.Equals(dtg_Cursos.Rows[i].Cells[0].Value))
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
                {
                    txt_Nombre_Curso.Text = Convert.ToString(dtg_Cursos.Rows[posicion].Cells[1].Value);
                    txt_Creditos.Text = Convert.ToString(dtg_Cursos.Rows[posicion].Cells[2].Value);
                    txt_Valor.Text = Convert.ToString(dtg_Cursos.Rows[posicion].Cells[3].Value);
                    txt_Horario.Text = Convert.ToString(dtg_Cursos.Rows[posicion].Cells[4].Value);
                }
            }
        }
        private void btn_ConsultarCurso_Click(object sender, EventArgs e)
        {
            fnt_ConsultarCurso(txt_Codigo_Curso.Text);
        }
        private void fnt_ActualizarCurso(string NombreCur, string Creditos, string Valor, string Horario)
        {
            dtg_Cursos.Rows[posicion].Cells[1].Value = NombreCur;
            dtg_Cursos.Rows[posicion].Cells[2].Value = Creditos;
            dtg_Cursos.Rows[posicion].Cells[3].Value = Valor;
            dtg_Cursos.Rows[posicion].Cells[4].Value = Horario;
            MessageBox.Show("Registro actualizado con exito");
        }


        private void btn_ActualizarCurso_Click(object sender, EventArgs e)
        {
            fnt_ActualizarCurso(txt_Nombre_Curso.Text, txt_Creditos.Text, txt_Valor.Text, txt_Horario.Text);
        }
        private void fnt_LimpiarControlesAnotaciones()
        {
            txt_ID_Nota.Clear();
            txt_Fecha2.Clear();
            txt_Anotaciones.Clear();
            txt_ID_Nota.Focus();
        }
        private void btn_NuevaNota_Click(object sender, EventArgs e)
        {
            fnt_LimpiarControlesAnotaciones();
        }
        private void fnt_GuardarAnotaciones(string ID_EA, string FechaA, string Anotaciones)
        {
            sw = false;
            posicion = 0;
            for (int i = 0; i < dtg_Anotaciones.RowCount; i++)
            {
                if (ID_EA.Equals(dtg_Anotaciones.Rows[i].Cells[0].Value))
                {
                    sw = true;
                    break;

                }
            }
            if (sw == false)
            {
                dtg_Anotaciones.Rows.Add(ID_EA, FechaA, Anotaciones);
                MessageBox.Show("registro exitoso");
            }
            else
            {
                MessageBox.Show("Esta persona ya esta registrada");
            }
        }

        private void btn_GuardarNota_Click(object sender, EventArgs e)
        {
            if (txt_ID_Nota.Text == "" ||
               txt_Fecha2.Text == "" ||
               txt_Anotaciones.Text == "")
            {
                MessageBox.Show("Debe ingrear criterio de busqueda");
            }
            else
            {
                fnt_GuardarAnotaciones(txt_ID_Nota.Text,
               txt_Fecha2.Text,
               txt_Anotaciones.Text);
            }
        }
        private void fnt_ConsultarAnotaciones(string ID_EA)
        {
            posicion = 0;
            sw = false;
            if (ID_EA.Equals(""))
            {
                MessageBox.Show("Debe ingresar criterio de busqueda");
            }
            else
            {
                for (int i = 0; i < dtg_Anotaciones.RowCount; i++)
                {
                    if (ID_EA.Equals(dtg_Anotaciones.Rows[i].Cells[0].Value))
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
                {
                    txt_Fecha2.Text = Convert.ToString(dtg_Cursos.Rows[posicion].Cells[1].Value);
                    txt_Anotaciones.Text = Convert.ToString(dtg_Cursos.Rows[posicion].Cells[2].Value);
                }
            }
        }
        private void btn_ConsultarAnotaciones_Click(object sender, EventArgs e)
        {
            fnt_ConsultarAnotaciones(txt_ID_Nota.Text);
        }
        private void fnt_ActualizarAnotaciones(string FechaA, string Anotaciones)
        {
            dtg_Anotaciones.Rows[posicion].Cells[1].Value = FechaA;
            dtg_Anotaciones.Rows[posicion].Cells[2].Value = Anotaciones;
            MessageBox.Show("Registro actualizado con exito");
        }

        private void btn_ActualizarAnotaciones_Click(object sender, EventArgs e)
        {
            fnt_ActualizarAnotaciones(txt_Fecha2.Text, txt_Anotaciones.Text);
        }
        private void fnt_LimpiarControlesCalificaciones()
        {
            txt_ID_CAL.Clear();
            txt_Fecha2.Clear();
            txt_Nota.Clear();
            txt_ID_CAL.Focus();
        }
        private void btn_Nueva_Calificacion_Click(object sender, EventArgs e)
        {
            fnt_LimpiarControlesCalificaciones();
        }
        private void fnt_GuardarCalificaciones(string ID_EC, string FechaC, string Notas)
        {
            sw = false;
            posicion = 0;
            for (int i = 0; i < dtg_Calificaciones.RowCount; i++)
            {
                if (ID_EC.Equals(dtg_Calificaciones.Rows[i].Cells[0].Value))
                {
                    sw = true;
                    break;

                }
            }
            if (sw == false)
            {
                dtg_Anotaciones.Rows.Add(ID_EC, FechaC, Notas);
                MessageBox.Show("registro exitoso");
            }
            else
            {
                MessageBox.Show("Esta persona ya esta registrada");
            }
        }

        private void btn_GuardarCalificacion_Click(object sender, EventArgs e)
        {
            if (txt_ID_CAL.Text == "" ||
               txt_Fecha3.Text == "" ||
               txt_Nota.Text == "")
            {
                MessageBox.Show("Debe ingrear criterio de busqueda");
            }
            else
            {
                fnt_GuardarCalificaciones(txt_ID_CAL.Text,
               txt_Fecha3.Text,
               txt_Nota.Text);
            }
        }
        private void fnt_ConsultarCalificaciones(string ID_EC)
        {
            posicion = 0;
            sw = false;
            if (ID_EC.Equals(""))
            {
                MessageBox.Show("Debe ingresar criterio de busqueda");
            }
            else
            {
                for (int i = 0; i < dtg_Calificaciones.RowCount; i++)
                {
                    if (ID_EC.Equals(dtg_Calificaciones.Rows[i].Cells[0].Value))
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
                {
                    txt_Fecha3.Text = Convert.ToString(dtg_Cursos.Rows[posicion].Cells[1].Value);
                    txt_Nota.Text = Convert.ToString(dtg_Cursos.Rows[posicion].Cells[2].Value);
                }
            }
        }
        private void btn_ConsultarCalificacion_Click(object sender, EventArgs e)
        {
            fnt_ConsultarCalificaciones(txt_ID_CAL.Text);
        }
        private void fnt_ActualizarCalificaciones(string FechaC, string Notas)
        {
            dtg_Calificaciones.Rows[posicion].Cells[1].Value = FechaC;
            dtg_Calificaciones.Rows[posicion].Cells[2].Value = Notas;
            MessageBox.Show("Registro actualizado con exito");
        }

        private void ptb_foto_click(object sender, EventArgs e)
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


        private void btn_ActualizarCalificacion_Click(object sender, EventArgs e)
        {
            fnt_ActualizarCalificaciones(txt_Fecha3.Text, txt_Nota.Text);
        }

        private void txt_Cod_Cur_KeyPress(object sender, KeyPressEventArgs e)
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
                e.Handled = true;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txt_Id_Est_KeyPress(object sender, KeyPressEventArgs e)
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
                e.Handled = true;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txt_Codigo_KeyPress(object sender, KeyPressEventArgs e)
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
                e.Handled = true;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txt_Cant_Cre_KeyPress(object sender, KeyPressEventArgs e)
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
                e.Handled = true;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txt_Valor_KeyPress(object sender, KeyPressEventArgs e)
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
                e.Handled = true;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txt_ID_Nota_KeyPress(object sender, KeyPressEventArgs e)
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
                e.Handled = true;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txt_Atonaciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }

        private void txt_ID_CAL_KeyPress(object sender, KeyPressEventArgs e)
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
                e.Handled = true;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txt_Nota_KeyPress(object sender, KeyPressEventArgs e)
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
                e.Handled = true;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txt_Nombre_Curso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
   
    
    
