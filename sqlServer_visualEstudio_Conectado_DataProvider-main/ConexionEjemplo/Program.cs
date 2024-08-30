using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConexionEjemplo
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // habilita los estilos visuales para la aplicación, lo que asegura que los controles
            Application.EnableVisualStyles();
            // Establece que la aplicación use un modo de renderización de texto compatible
            Application.SetCompatibleTextRenderingDefault(false);
            // Inicia la ejecución de la aplicación y abre la ventana principal definida en el form1
            Application.Run(new Form1());
        }
    }
}
