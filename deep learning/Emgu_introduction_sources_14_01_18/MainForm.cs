using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMGU_introduction
{
    public partial class MainForm : Form
    {

        // le seul attribut non purement graphique de la Form est
        // le FrameProcesssor : c'est lui qui contient la logique métier
        public FrameProcessor frameProcessor;

        public MainForm()
        {
            InitializeComponent();
            // on ne rajoute rien d'autre ici : la logique
            // d'interception des exception par le Designer cache
            // le sproblème sinon
            // tout ce qui relève de l'initialisation est reporté 
            // dans l'événement Load()
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            frameProcessor = new FrameProcessor();
            frameProcessor.ImageProcessed += FrameProcessor_ImageProcessed;

            BindingSource labelBindingSource = new BindingSource();
            labelBindingSource.DataSource = frameProcessor;
            //labelBindingSource.DataMember = "ProcessingDescription";
            labelDescription.DataBindings.Add("Text", labelBindingSource,"ProcessingDescription");


        }

        private void FrameProcessor_ImageProcessed(Emgu.CV.UMat source, Emgu.CV.UMat processed)
        {
            imageBoxSource.Image = source;
            imageBoxProcessed.Image = processed;
        }

        private void buttonSwitch_Click(object sender, EventArgs e)
        {
            frameProcessor.NextProcess();
        }
    }
}
