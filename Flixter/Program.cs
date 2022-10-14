using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
/// <summary>
/// Nom : LAROSE
/// Prenom : Christ-Yan Love
/// Date : 13/10/2022
/// </summary>
namespace Flixter
{
	static class Program
	{
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new SplashScreen());// launch the splashscreen
		}
	}
}
