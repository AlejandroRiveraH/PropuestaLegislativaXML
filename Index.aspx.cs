using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
// Universidad Estatal A Distancia
// Ingeniería Informática y Desarrollo de Aplicaciones WEB
// Estudiante: Alejandro Rivera Herrera
namespace PropuestaLegislativaXML
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public int RevisarCampos() // metodo para revisar reglas en campos
        {
            int Numero;
            
            String identificacion;
            identificacion = @"\A[0-9]{10,11}\z";

            String correo;
            correo = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            String telefono;
            telefono = @"\A[0-9]{8,8}\z";

            String propuesta;
            propuesta = @"^[\s\S]{50,200}$";

            if (Regex.IsMatch(TxtIdentificacion.Text, identificacion) == false)
            {
                LblErrores.Text = "Identificación con formato incorrecto";
                Numero = 0;
            }
            else if (Regex.IsMatch(TxtCorreo.Text, correo) == false)
            {
                LblErrores.Text = "Correo con formato incorrecto";
                Numero = 0;
            }
            else if (Regex.IsMatch(TxtTelefono.Text, telefono) == false)
            {
                LblErrores.Text = "Teléfono con formato";
                Numero = 0;
            }
            else if (Regex.IsMatch(TxtPropuesta.Text, propuesta) == false)
            {
                LblErrores.Text = "La propuesta tiene que tener entre  50 y 200 caracteres";
                Numero = 0;
            }
            else
            {
                Numero = 1;
            }
            return Numero;
        } // Fin del método

        private void Guardar() // metodo para almacenar los registros
        {

            
            int resultado = RevisarCampos(); // realiza revisión de datos

            if (resultado == 1)
            {

                string nombreArchivo = @"D:\Propuestas\Propuestas.xml";// ruta del archivo
                if (File.Exists(nombreArchivo) == false)
                {

                    XmlDocument doc = new XmlDocument();
                    XmlElement raiz = doc.CreateElement("Propuestas_Legislativa");
                    doc.AppendChild(raiz);

                    XmlElement propuestaLeg = doc.CreateElement("Propuesta");
                    raiz.AppendChild(propuestaLeg);

                    XmlElement tipo_Id = doc.CreateElement("Tipo_Identificacion");
                    tipo_Id.AppendChild(doc.CreateTextNode(DDLTipoId.Text));
                    propuestaLeg.AppendChild(tipo_Id);

                    XmlElement identificacion = doc.CreateElement("Identificacion");
                    identificacion.AppendChild(doc.CreateTextNode(TxtIdentificacion.Text));
                    propuestaLeg.AppendChild(identificacion);

                    XmlElement nombre = doc.CreateElement("Nombre");
                    nombre.AppendChild(doc.CreateTextNode(TxtNombre.Text));
                    propuestaLeg.AppendChild(nombre);

                    XmlElement apellido1 = doc.CreateElement("Primer_Apellido");
                    apellido1.AppendChild(doc.CreateTextNode(TxtApellido1.Text));
                    propuestaLeg.AppendChild(apellido1);

                    XmlElement apellido2 = doc.CreateElement("Segundo_Apellido");
                    apellido2.AppendChild(doc.CreateTextNode(TxtApellido2.Text));
                    propuestaLeg.AppendChild(apellido2);

                    XmlElement telefono = doc.CreateElement("Telefono");
                    telefono.AppendChild(doc.CreateTextNode(TxtTelefono.Text));
                    propuestaLeg.AppendChild(telefono);

                    XmlElement correo = doc.CreateElement("Correo");
                    correo.AppendChild(doc.CreateTextNode(TxtCorreo.Text));
                    propuestaLeg.AppendChild(correo);

                    XmlElement provincia = doc.CreateElement("Provincia");
                    provincia.AppendChild(doc.CreateTextNode(DDLProvincia.Text));
                    propuestaLeg.AppendChild(provincia);

                    XmlElement canton = doc.CreateElement("Canton");
                    canton.AppendChild(doc.CreateTextNode(DDLCanton.Text));
                    propuestaLeg.AppendChild(canton);

                    XmlElement propuesta = doc.CreateElement("Propuesta");
                    propuesta.AppendChild(doc.CreateTextNode(TxtPropuesta.Text));
                    propuestaLeg.AppendChild(propuesta);


                    doc.Save(@"D:\Propuestas\Propuestas.xml");
                    //MessageBox.Show("El archivo fue creado con exito");
                    LblMensaje.Text = "El archivo fue creado con exito";
                    LblErrores.Text = "";
                    Response.Redirect("Felicidades.html");
                }
                else
                {
                    //MessageBox.Show("El archivo ya existe | Debe agregar el registro ");
                    //BtnGenerar.Enabled = false;

                    XmlDocument doc = new XmlDocument();
                    doc.Load(@"D:\Propuestas\Propuestas.xml");

                    XmlNode nodoRaiz = doc.DocumentElement;

                    XmlElement legislativa = doc.CreateElement("Propuesta");
                    nodoRaiz.AppendChild(legislativa);

                    XmlElement tipo_Id = doc.CreateElement("Tipo_Identificacion");
                    tipo_Id.AppendChild(doc.CreateTextNode(DDLTipoId.Text));
                    legislativa.AppendChild(tipo_Id);

                    XmlElement identificacion = doc.CreateElement("Identificacion");
                    identificacion.AppendChild(doc.CreateTextNode(TxtIdentificacion.Text));
                    legislativa.AppendChild(identificacion);

                    XmlElement nombre = doc.CreateElement("Nombre");
                    nombre.AppendChild(doc.CreateTextNode(TxtNombre.Text));
                    legislativa.AppendChild(nombre);

                    XmlElement apellido1 = doc.CreateElement("Primer_Apellido");
                    apellido1.AppendChild(doc.CreateTextNode(TxtApellido1.Text));
                    legislativa.AppendChild(apellido1);

                    XmlElement apellido2 = doc.CreateElement("Segundo_Apellido");
                    apellido2.AppendChild(doc.CreateTextNode(TxtApellido2.Text));
                    legislativa.AppendChild(apellido2);

                    XmlElement telefono = doc.CreateElement("Telefono");
                    telefono.AppendChild(doc.CreateTextNode(TxtTelefono.Text));
                    legislativa.AppendChild(telefono);

                    XmlElement correo = doc.CreateElement("Correo");
                    correo.AppendChild(doc.CreateTextNode(TxtCorreo.Text));
                    legislativa.AppendChild(correo);

                    XmlElement provincia = doc.CreateElement("Provincia");
                    provincia.AppendChild(doc.CreateTextNode(DDLProvincia.Text));
                    legislativa.AppendChild(provincia);

                    XmlElement canton = doc.CreateElement("Canton");
                    canton.AppendChild(doc.CreateTextNode(DDLCanton.Text));
                    legislativa.AppendChild(canton);

                    XmlElement propuesta = doc.CreateElement("Propuesta");
                    propuesta.AppendChild(doc.CreateTextNode(TxtPropuesta.Text));
                    legislativa.AppendChild(propuesta);

                    doc.Save(@"D:\Propuestas\Propuestas.xml");
                    //MessageBox.Show("El registro fue agregado con exito");
                    LblMensaje.Text = "El registro fue agregado con exito";
                    LblErrores.Text = "";
                    Response.Redirect("Felicidades.html");
                }
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        protected void DDLProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            DDLCanton.Items.Clear();


            if (DDLProvincia.SelectedItem.ToString() == " San José ")
            {
                DDLCanton.Items.Add("San José");
                DDLCanton.Items.Add("Escazú");
                DDLCanton.Items.Add("Desamparados");
                DDLCanton.Items.Add("Puriscal");
                DDLCanton.Items.Add("Tarrazú");
                DDLCanton.Items.Add("Aserrí");
                DDLCanton.Items.Add("Mora");
                DDLCanton.Items.Add("Goicoechea");
                DDLCanton.Items.Add("Santa Ana");
                DDLCanton.Items.Add("Alajuelita");
                DDLCanton.Items.Add("Vásquez de Coronado");
                DDLCanton.Items.Add("Acosta");
                DDLCanton.Items.Add("Tibás");
                DDLCanton.Items.Add("Moravia");
                DDLCanton.Items.Add("Montes de Oca");
                DDLCanton.Items.Add("Turrubares");
                DDLCanton.Items.Add("Dota");
                DDLCanton.Items.Add("Curridabat");
                DDLCanton.Items.Add("Pérez Zeledón");
                DDLCanton.Items.Add("León Cortés");

            }
            else if (DDLProvincia.SelectedItem.ToString() == " Alajuela ")
            {
                DDLCanton.Items.Add("Alajuela");
                DDLCanton.Items.Add("San Ramón");
                DDLCanton.Items.Add("Grecia");
                DDLCanton.Items.Add("San Mateo");
                DDLCanton.Items.Add("Atenas");
                DDLCanton.Items.Add("Naranjo");
                DDLCanton.Items.Add("Palmares");
                DDLCanton.Items.Add("Poás");
                DDLCanton.Items.Add("Orotina");
                DDLCanton.Items.Add("San Carlos");
                DDLCanton.Items.Add("Alfaro Ruíz");
                DDLCanton.Items.Add("Valverde Vega");
                DDLCanton.Items.Add("Upala");
                DDLCanton.Items.Add("Los Chiles");
                DDLCanton.Items.Add("Guatuso");
            }

            else if (DDLProvincia.SelectedItem.ToString() == " Cartago ")
            {
                DDLCanton.Items.Add("Cartago");
                DDLCanton.Items.Add("Paraiso");
                DDLCanton.Items.Add("La Unión");
                DDLCanton.Items.Add("Jiménez");
                DDLCanton.Items.Add("Turrialba");
                DDLCanton.Items.Add("Alvarado");
                DDLCanton.Items.Add("Oreamuno");
                DDLCanton.Items.Add("El Guarco");

            }
            else if (DDLProvincia.SelectedItem.ToString() == " Heredia ")
            {
                DDLCanton.Items.Add("Heredia");
                DDLCanton.Items.Add("Barva");
                DDLCanton.Items.Add("Santo Domingo");
                DDLCanton.Items.Add("Santa Bárbara");
                DDLCanton.Items.Add("San Rafael");
                DDLCanton.Items.Add("San Isidro");
                DDLCanton.Items.Add("Belén");
                DDLCanton.Items.Add("Flores");
                DDLCanton.Items.Add("San Pablo");
                DDLCanton.Items.Add("Sarapiquí");

            }
            else if (DDLProvincia.SelectedItem.ToString() == " Guanacaste ")
            {
                DDLCanton.Items.Add("Liberia");
                DDLCanton.Items.Add("Nicoya");
                DDLCanton.Items.Add("Santa Cruz");
                DDLCanton.Items.Add("Bagaces");
                DDLCanton.Items.Add("Carrillo");
                DDLCanton.Items.Add("Cañas");
                DDLCanton.Items.Add("Abangares");
                DDLCanton.Items.Add("Tilarán");
                DDLCanton.Items.Add("Nandayure");
                DDLCanton.Items.Add("La Cruz");
                DDLCanton.Items.Add("Hojancha");

            }
            else if (DDLProvincia.SelectedItem.ToString() == " Puntarenas ")
            {
                DDLCanton.Items.Add("Puntarenas");
                DDLCanton.Items.Add("Esparza");
                DDLCanton.Items.Add("Buenos Aires");
                DDLCanton.Items.Add("Montes de Oro");
                DDLCanton.Items.Add("Osa");
                DDLCanton.Items.Add("Quepos o Aguirre");
                DDLCanton.Items.Add("Golfito");
                DDLCanton.Items.Add("Coto Brus");
                DDLCanton.Items.Add("Parrita");
                DDLCanton.Items.Add("Corredores");
                DDLCanton.Items.Add("Garabito");

            }
            else if (DDLProvincia.SelectedItem.ToString() == " Limón ")
            {
                DDLCanton.Items.Add("Limón");
                DDLCanton.Items.Add("Pococí");
                DDLCanton.Items.Add("Siquirres");
                DDLCanton.Items.Add("Talamanca");
                DDLCanton.Items.Add("Matina");
                DDLCanton.Items.Add("Guácimo");

            }

        }

        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {
            TxtIdentificacion.Text = "";
            TxtNombre.Text = "";
            TxtApellido1.Text = "";
            TxtApellido2.Text = "";
            TxtTelefono.Text = "";
            TxtCorreo.Text = "";
            TxtPropuesta.Text = "";
            LblMensaje.Text = "";
            LblErrores.Text = "";
        }
    }
}