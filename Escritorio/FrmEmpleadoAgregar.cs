using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TpIngSoftII.Interfaces;
using TpIngSoftII.Interfaces.Services;
using TpIngSoftII.Models.DTOs;
using Escritorio.Metodos_estaticos;
using SimpleInjector;

namespace Escritorio
{
    public partial class FrmEmpleadoAgregar : Form
    {
        //private readonly IEmpleadoService empleadoService;
        //private readonly IPerfilService perfilService;
        //private readonly IAppContext2 appContext2;
        private readonly Container container;
        private int ID = 0;

        public FrmEmpleadoAgregar(/*IEmpleadoService empleadoService, IPerfilService perfilService, IAppContext2 appContext2*/Container container)
        {
            //this.empleadoService = empleadoService;
            //this.perfilService = perfilService;
            //this.appContext2 = appContext2;
            this.container = container;
            InitializeComponent();
        }

        
        private void FrmEmpleadoAgregar_Load(object sender, EventArgs e)
        {
            AgregarBotonElejirPerfil();
            CargarlistaEmpleados();
        }

        private void AgregarPerfilButton_Click(object sender, EventArgs e)
        {
            int count = PerfilPanel.Controls.OfType<ComboBox>().ToList().Count;
            var perfiles = container.GetInstance<IPerfilService>().GetAllAsNoTracking();
            if(count<perfiles.Count())
                AgregarBotonElejirPerfil();
            container.GetInstance<IPerfilService>().Limpiar();
        }
        private void AgregarButton_Click(object sender, EventArgs e)
        {
            EmpleadoDto empleadoDto = new EmpleadoDto();
            if (NombretextBox.Text == "")
            {
                MessageBox.Show("Por favor complete el nombre");
                return;
            }
            empleadoDto.Nombre = NombretextBox.Text;
            if (ApellidotextBox.Text == "")
            {
                MessageBox.Show("Por favor complete el Apellido");
                return;
            }
            empleadoDto.Apellido = ApellidotextBox.Text;
            if (DNInumericUpDown.Value ==0)
            {
                MessageBox.Show("Por favor complete el DNI");
                return;
            }
            empleadoDto.Dni =(long)DNInumericUpDown.Value;
            if (FechaTimePicker.Value ==null)
            {
                MessageBox.Show("Por favor complete la fecha de ingreso");
                return;
            }
            empleadoDto.FechaIngreso = FechaTimePicker.Value;
            if (UsuarioTextBox.Text == "")
            {
                MessageBox.Show("Por favor complete el nombre de usuario");
                return;
            }
            empleadoDto.Usuario = UsuarioTextBox.Text;
            if (ContraseniatextBox.Text == "")
            {
                MessageBox.Show("Por favor complete la contraseña");
                return;
            }
            empleadoDto.Clave = ContraseniatextBox.Text;
            if (RolCombo.SelectedItem == null)
            {
                MessageBox.Show("Por favor asigne un rol");
                return;
            }
            empleadoDto.RolID = RolCombo.SelectedIndex+1;

            var listaElegirPerfiles = PerfilPanel.Controls.OfType<ComboBox>().ToList();
            bool perfilelegido = false;
            foreach (ComboBox elegirPerfil in listaElegirPerfiles)
            {
                if (elegirPerfil.SelectedItem != null)
                    perfilelegido = true;
            }
            if (!perfilelegido)
            {
                MessageBox.Show("Por favor elija al menos un perfil");
                return;
            }
            empleadoDto.Perfiles = new List<EmpleadoPerfilDto>();

            foreach (ComboBox elegirPerfil in listaElegirPerfiles)
            {
                if (elegirPerfil.SelectedItem != null)
                {
                    EmpleadoPerfilDto empleadoPerfilDto = new EmpleadoPerfilDto();
                    empleadoPerfilDto.PerfilID= ObtenerPerfilID(elegirPerfil);
                    empleadoPerfilDto.EmpleadoID = 0;
                    //empleadoPerfilDto.ID = 0;
                    empleadoDto.Perfiles.Add(empleadoPerfilDto);
                }
            }
            if (ID != 0)
            {
                var EmpleadoAEditar = container.GetInstance<IEmpleadoService>().GetByIdAsNoTracking(ID);
                EmpleadoAEditar.Nombre = NombretextBox.Text;
                EmpleadoAEditar.Apellido = ApellidotextBox.Text;
                EmpleadoAEditar.Dni = (long)DNInumericUpDown.Value;
                EmpleadoAEditar.FechaIngreso = FechaTimePicker.Value;
                EmpleadoAEditar.Usuario = UsuarioTextBox.Text;
                EmpleadoAEditar.Clave = ContraseniatextBox.Text;
                EmpleadoAEditar.RolID = RolCombo.SelectedIndex + 1;
                EmpleadoAEditar.Perfiles.Clear();
                foreach (ComboBox elegirPerfil in listaElegirPerfiles)
                {
                    if (elegirPerfil.SelectedItem != null)
                    {
                        EmpleadoPerfilDto empleadoPerfilDto = new EmpleadoPerfilDto();
                        empleadoPerfilDto.PerfilID = ObtenerPerfilID(elegirPerfil);
                        empleadoPerfilDto.EmpleadoID = ID;
                        //empleadoPerfilDto.ID = 0;
                        EmpleadoAEditar.Perfiles.Add(empleadoPerfilDto);
                    }
                }
                try
                {
                    var respuesta = container.GetInstance<IEmpleadoService>().Update(EmpleadoAEditar);
                    if (respuesta != null)
                    {
                        MessageBox.Show("Empleado editado");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se a podido editar el empleado. " + ex.Message);
                }
                ID = 0;
                EmpleadocomboBox.ResetText();
                EmpleadocomboBox.Items.Clear();
                CargarlistaEmpleados();
                container.GetInstance<IEmpleadoService>().Limpiar();
            }
            else
            {
                try
                {
                    var respuesta = container.GetInstance<IEmpleadoService>().Update(empleadoDto);
                    if (respuesta != null)
                    {
                        MessageBox.Show("Empleado creado");
                        container.GetInstance<IEmpleadoService>().Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se a podido crear el Empleado");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se a podido crear el Empleado. " + ex.Message);
                }
            }
            container.GetInstance<IEmpleadoService>().Limpiar();
            NombretextBox.Text = "";
            ApellidotextBox.Text = "";
            DNInumericUpDown.Value = 10000000;
            FechaTimePicker.Value = new DateTime(2021,2,27);
            UsuarioTextBox.Text = "";
            ContraseniatextBox.Text = "";
            RolCombo.ResetText();
            PerfilPanel.Controls.Clear();
        }

        private void AgregarBotonElejirPerfil()
        {
            //Create the dynamic TextBox.
            ComboBox ElejirPerfil = new ComboBox();
            int count = PerfilPanel.Controls.OfType<ComboBox>().ToList().Count;
            ElejirPerfil.Location = new System.Drawing.Point(26, 25 * count);
            ElejirPerfil.Size = new System.Drawing.Size(128, 21);
            ElejirPerfil.Name = "ElejirPerfil_" + (count + 1);
            ElejirPerfil.Text = "Elija un perfil";
            CargarListaPerfiles(ElejirPerfil);
            PerfilPanel.Controls.Add(ElejirPerfil);

            //Create the dynamic Button to remove the TextBox.
            Button button = new Button();
            button.Location = new System.Drawing.Point(172, 25 * count);
            button.Size = new System.Drawing.Size(21, 25);
            button.Name = "btnDelete_" + (count + 1);
            button.ForeColor = Color.Red;
            button.BackColor = PerfilPanel.BackColor;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.BorderColor = button.BackColor;
            button.FlatStyle = FlatStyle.Flat;
            button.Text = "X";
            button.Click += new System.EventHandler(this.btnDelete_Click);
            PerfilPanel.Controls.Add(button);
        }


        private void PerfilPanel_Paint(object sender, PaintEventArgs e)
        {
           
        }
        private void elegirPerfiles(object sender, EventArgs e)
        {
            ComboBox Elegir = (sender as ComboBox);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (PerfilPanel.Controls.OfType<ComboBox>().ToList().Count > 1)
            {
                //Reference the Button which was clicked.
                Button button = (sender as Button);

                //Determine the Index of the Button.
                int index = int.Parse(button.Name.Split('_')[1]);

                //Find the TextBox using Index and remove it.
                PerfilPanel.Controls.Remove(PerfilPanel.Controls.Find("ElejirPerfil_" + index, true)[0]);

                //Remove the Button.
                PerfilPanel.Controls.Remove(button);

                //Rearranging the Location controls.
                foreach (Button btn in PerfilPanel.Controls.OfType<Button>())
                {
                    int controlIndex = int.Parse(btn.Name.Split('_')[1]);
                    if (controlIndex > index)
                    {
                        ComboBox txt = (ComboBox)PerfilPanel.Controls.Find("ElejirPerfil_" + controlIndex, true)[0];
                        btn.Top = btn.Top - 25;
                        txt.Top = txt.Top - 25;
                    }
                }
            }
        }
        private void CargarListaPerfiles(ComboBox ElejirPerfilcomboBox)
        {
            var perfiles = container.GetInstance<IPerfilService>().GetAllAsNoTracking();
            foreach (PerfilDto perfil in perfiles)
            {
                ElejirPerfilcomboBox.Items.Add(perfil.Descripcion);
            }
        }

        private void CargarlistaEmpleados()
        {
            var empleados = container.GetInstance<IEmpleadoService>().GetAllAsNoTracking();
            foreach (EmpleadoDto empleado in empleados)
            {
                EmpleadocomboBox.Items.Add(empleado.Nombre + " " + empleado.Apellido);
            }
        }
        private int ObtenerPerfilID(ComboBox ElejirPerfilcomboBox)
        {
            int idPerfil = 0;
            var perfiles = container.GetInstance<IPerfilService>().GetAllAsNoTracking();
            foreach (PerfilDto perfil in perfiles)
            {
                if (ElejirPerfilcomboBox.SelectedItem.ToString() == perfil.Descripcion)
                    idPerfil= perfil.ID;
            }
            container.GetInstance<IPerfilService>().Limpiar(); 
            return idPerfil;
        }

        private void EmpleadocomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var empleados = container.GetInstance<IEmpleadoService>().GetAllAsNoTracking();
            foreach (EmpleadoDto empleado in empleados)
            {
                if (EmpleadocomboBox.SelectedItem.ToString() == empleado.Nombre + " " + empleado.Apellido)
                {
                    NombretextBox.Text= empleado.Nombre;
                    ApellidotextBox.Text= empleado.Apellido;
                    DNInumericUpDown.Value= empleado.Dni;
                    FechaTimePicker.Value= empleado.FechaIngreso;
                    UsuarioTextBox.Text= empleado.Usuario;
                    ContraseniatextBox.Text=empleado.Clave ;
                    RolCombo.SelectedIndex= empleado.RolID-1;
                    var perfiles =empleado.Perfiles;
                    PerfilPanel.Controls.Clear();
                    foreach (EmpleadoPerfilDto perfil in perfiles)
                    {
                        AgregarBotonElejirPerfil(perfil.PerfilDescripcion);
                    }
                    ID = empleado.ID;
                }
            }
        }


        private void AgregarBotonElejirPerfil(string perfilSeleccionado)
        {
            //Create the dynamic TextBox.
            ComboBox ElejirPerfil = new ComboBox();
            int count = PerfilPanel.Controls.OfType<ComboBox>().ToList().Count;
            ElejirPerfil.Location = new System.Drawing.Point(26, 25 * count);
            ElejirPerfil.Size = new System.Drawing.Size(128, 21);
            ElejirPerfil.Name = "ElejirPerfil_" + (count + 1);
            ElejirPerfil.Text = "Elija un perfil";
            CargarListaPerfiles(ElejirPerfil);
            ElejirPerfil.SelectedItem = perfilSeleccionado;
            PerfilPanel.Controls.Add(ElejirPerfil);

            //Create the dynamic Button to remove the TextBox.
            Button button = new Button();
            button.Location = new System.Drawing.Point(172, 25 * count);
            button.Size = new System.Drawing.Size(21, 25);
            button.Name = "btnDelete_" + (count + 1);
            button.ForeColor = Color.Red;
            button.BackColor = PerfilPanel.BackColor;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.BorderColor = button.BackColor;
            button.FlatStyle = FlatStyle.Flat;
            button.Text = "X";
            button.Click += new System.EventHandler(this.btnDelete_Click);
            PerfilPanel.Controls.Add(button);
        }


    }

   
}
