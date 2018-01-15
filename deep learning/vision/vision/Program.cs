//----------------------------------------------------------------------------
//
// Introduction à Emgu / OpenCV  - exemples simples
//
// Pierre-Alexandre FAVIER - 13/01/18
//----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

// Ajouter les références aux DLLs Emgu.CV.World  et Emgu.CV.UI
// Ajouter les fichiers correspondant ainsi que les répertoires x86 et/ou x64
// Paramétrer les options de compilation : option Build, "Plateforme cible"

// Pour tout cela, voir :

//  http://www.emgu.com/wiki/index.php/Download_And_Installation#Getting_the_Dependency

// Ajouter l'inclusion des namespaces correspondant à Emgu :
using Emgu.CV;
using Emgu.Util;



namespace vision
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
