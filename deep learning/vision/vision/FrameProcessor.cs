//----------------------------------------------------------------------------
//
// Introduction à Emgu / OpenCV  - exemples simples
//
// Pierre-Alexandre FAVIER - 13/01/18
//----------------------------------------------------------------------------



using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;

namespace vision
{
    // Cette classe correspond au "moteur" de l'application
    // Elle contient le code métier et doit rester ignorante de
    // l'interface
    public class FrameProcessor : INotifyPropertyChanged
    {

        private VideoCapture webcam;

        private UMat sourceImage;
        private UMat processedImage;

        // L'objet faceDetector ne sert que pour l'exemple de détection de visage
        private FaceDetector faceDetector;

        // on crée un type délégué pour les méthodes s'inscrivant à 
        //  notre événement "une image a été traitée"
        // ces méthode recevrons en paramètres l'image source et l'image traitée 
        // c'est le point d'articulation avec l'interface qui récupère ces images
        // par inscription à l'événement
        public delegate void ImageProcessedHandler(UMat source, UMat processed);

        // on déclare l'événement permettant d'anoncer le traitement d'une frame
        public event ImageProcessedHandler ImageProcessed;

        // on crée un type délégué pour le traitement de l'image en lui-même
        // il est ainsi facile d'en proposer plusieurs et d'en changer à la volée
        public delegate void ImageProcessingHandler();

        // ainsi processingMethod désigne le traitement actuellement sélectionné
        private ImageProcessingHandler processingMethod;

        #region Notification de modification des propriétés
        // la classe FrameProcessor notifie les modification de ses propriétés
        public event PropertyChangedEventHandler PropertyChanged;
        
        // La méthode OnPropertyChanged déclenche l'événement
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(processingDescription));
            }
        }
        #endregion

        // cette propriété contient une chaîne de caractères décrivant
        // succontement le traitement actuel
        private string processingDescription;
        public string ProcessingDescription
    {
            get { return processingDescription; }
            set
            {
                processingDescription = value;
                // on notifie par OnPropertyChanged à chaque modif
                OnPropertyChanged("ProcessingDescription");
            }
        }

        // on utilise ici un dictionnaire détourné de son usage normal 
        // pour stocker des paires description / délégué
        private Dictionary<string, ImageProcessingHandler> descritpionHandlerDictionary;

        // numéro du traitement actuel
        // on initialise à -1 pour que l'appel à NextProcess() dans le constructeur
        // sélectionne le premier traitement au lancement de l'application
        private int currentProcessIndex=-1;

        public FrameProcessor()
        {
            #region Initialisation des membres
            sourceImage = new UMat();
            processedImage = new UMat();

            // les cascades utilisées pour l'initialisation sont des paramètres de l'application
            faceDetector = new FaceDetector(Properties.Settings.Default.FaceCascade, Properties.Settings.Default.EyeCascade);
            
            #endregion

            #region Création de dictionnaire des traitements

            descritpionHandlerDictionary = new Dictionary<string, ImageProcessingHandler>();

            descritpionHandlerDictionary["SnapChat"] = SnapChat;
            descritpionHandlerDictionary["Simple copie - Clone"]                        =  SimpleCopy;
            descritpionHandlerDictionary["Conversion en N&B - CvtColor"]                = ConvertToGrey;
            descritpionHandlerDictionary["Calcul de la pyramide descendante - PyrDown"] = PyramidDown;
            descritpionHandlerDictionary["Seuillage couleur - Threshold"]               = ThresholdColor;
            descritpionHandlerDictionary["Seuillage N&B - CvtColor + Threshold"]        = Threshold;
            descritpionHandlerDictionary["Egalisation de l'histogramme- EqualizeHist"]  = HEqualize;
            descritpionHandlerDictionary["Détection de contour - Canny"]                = Canny;
            descritpionHandlerDictionary["Esquisse... - cf code"]                       = Esquisse;
            descritpionHandlerDictionary["Détection de visage - cf code"]               = Head;


            NextProcess();
            #endregion

            #region Initialisation de la webcam

            try
            {
                // initialisation de la webcam
                webcam = new VideoCapture();
                // On abonne la méthode ProcessFrame à 
                // l'événement de capture d'une nouvelle image
                webcam.ImageGrabbed += ProcessFrame;

                // on démarre la capture
                webcam.Start();

            }
            catch (NullReferenceException excpt)
            {
                 ProcessingDescription = excpt.Message;
            }
            #endregion

        }

        ~FrameProcessor()
        {
            // le périphérique de capture tourne dans un thread séparé
            // il faut donc le "libérer" à la destruction de l'objet managé
            if (webcam != null)
                webcam.Dispose();
        }


        // changement du traitement sélectionné, on passe simplement au suivant
        // la technique n'est pas très élégante, c'est une simplification du code d'origine
        public void NextProcess()
        {
            currentProcessIndex = ++currentProcessIndex % descritpionHandlerDictionary.Count;
            ProcessingDescription = descritpionHandlerDictionary.ElementAt(currentProcessIndex).Key;
            processingMethod = descritpionHandlerDictionary.ElementAt(currentProcessIndex).Value;

        }

        // méthode de traitement d'une frame
        // déclenchée automatiquement par abonnement 
        // à l'évenement de la webcam (ImageGrabbed)
        private void ProcessFrame(object sender, EventArgs arg)
        {
            // si une image valide est capturée
            if (webcam != null && webcam.Ptr != IntPtr.Zero)
            {
                // on la récupère dans sourceImage
                webcam.Retrieve(sourceImage, 0);

                // on la traite selon le traitement actuellement choisi, s'il existe
                processingMethod?.Invoke();
                
                // on prévient qu'on a traité une image
                onImageProccessed(sourceImage, processedImage);

            }
        }

        // méthode déclanchant l'événemant pour prévenir de la fin du traitement
        private void onImageProccessed(UMat sourceImage, UMat processedImage)
        {
            if (ImageProcessed != null)
                ImageProcessed(sourceImage, processedImage);
        }



        #region Méthodes de traitement proposées
        void SimpleCopy()
        {
            processedImage = sourceImage.Clone();
        }

        void ConvertToGrey()
        {
            
            CvInvoke.CvtColor(sourceImage, processedImage, ColorConversion.Bgr2Gray);
        }

        void PyramidDown()
        {
            CvInvoke.PyrDown(sourceImage, processedImage);
        }

        void ThresholdColor()
        {
            CvInvoke.Threshold(sourceImage, processedImage, 128, 255, Emgu.CV.CvEnum.ThresholdType.Binary);
        }

        void Threshold()
        {
            CvInvoke.CvtColor(sourceImage, processedImage, ColorConversion.Bgr2Gray);
            CvInvoke.Threshold(processedImage, processedImage, 128, 255, Emgu.CV.CvEnum.ThresholdType.Binary);
        }

        void HEqualize()
        {
            CvInvoke.CvtColor(sourceImage, processedImage, ColorConversion.Bgr2Gray);
            CvInvoke.EqualizeHist(processedImage, processedImage);
        }

        void Canny()
        {
            UMat NB = new UMat();
            CvInvoke.CvtColor(sourceImage, NB, ColorConversion.Bgr2Gray);
            CvInvoke.Canny(NB, processedImage,50,150);

        }

        void Esquisse()
        {
            UMat NB = new UMat();
            CvInvoke.CvtColor(sourceImage, NB, ColorConversion.Bgr2Gray);
            CvInvoke.PyrDown(NB, NB);
            CvInvoke.PyrUp(NB, NB);
            CvInvoke.EqualizeHist(NB, NB);
            CvInvoke.Canny(NB, NB, 50, 150);
            CvInvoke.BitwiseNot(NB, processedImage);
        }

        void Head()
        {
        
            List<Rectangle> faces = new List<Rectangle>();
            List<Rectangle> eyes = new List<Rectangle>();

            faceDetector.Detect(sourceImage, faces, eyes);

            processedImage = sourceImage.Clone();

            foreach (Rectangle face in faces)
                CvInvoke.Rectangle(processedImage, face, new Bgr(Color.Red).MCvScalar, 2);
            foreach (Rectangle eye in eyes)
                CvInvoke.Rectangle(processedImage, eye, new Bgr(Color.Blue).MCvScalar, 2);

        }

        void SnapChat()
        {
            Mat img = CvInvoke.Imread("C:\\Users\\plaurent003\\Downloads\\Masque_Mangemort.png");// path can be absolute or relative.
            List<Rectangle> faces = new List<Rectangle>();
            List<Rectangle> eyes = new List<Rectangle>();

            faceDetector.Detect(sourceImage, faces, eyes);
            UMat newImg = new UMat();

            processedImage = sourceImage.Clone();
            foreach (Rectangle face in faces)
            {
                UMat resizedSmallImage = new UMat();
                // on resize l'image vide à la taille de l'oeil trouvé
                CvInvoke.Resize(img, resizedSmallImage, face.Size);

                // on remplit une matrice avec une région d'intérêt avec les data de l'oeil
                UMat visage = new UMat(processedImage, face);

                // on ajoute la petite image sur l'oeil grâce à la zone d'intérêt
                // alpha des deux images superposées = 1            
                CvInvoke.AddWeighted(resizedSmallImage, 1, visage, 0, 0, visage);
            }
                

        }

        void transparent(UMat mat)
        { 
        
        }

         #endregion
    }
}
