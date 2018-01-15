//----------------------------------------------------------------------------
//
// Introduction à Emgu / OpenCV  - exemples simples
//
// Fichier basé sur l'exemple FaceDetect fourni avec Emgu
//
// Pierre-Alexandre FAVIER - 13/01/18
//----------------------------------------------------------------------------


using System;
using System.Collections.Generic;

using System.Drawing;
using Emgu.CV;

#if !(__IOS__ || NETFX_CORE)
using Emgu.CV.Cuda;
#endif
using Emgu.CV.Structure;

namespace vision
{
    // cette classe un peu bancale reprend le code de la méthode 
    // statique FaceDetect de l'exemple Emgu
    // elle est duale : traitement avec ou sans support CUDA 
    class Snap
    {

        private CudaCascadeClassifier faceCuda;
        private CudaCascadeClassifier eyeCuda;

        private CascadeClassifier faceCpu;
        private CascadeClassifier eyeCpu;

        public Snap(string faceFileName, string eyeFileName)
        {
            // Dans le constructeur, il suffit d'instancier les classifieurs

#if !(__IOS__ || NETFX_CORE)
            if (CudaInvoke.HasCuda)
            {
                faceCuda = new CudaCascadeClassifier(faceFileName);
                faceCuda.ScaleFactor = 1.1;
                faceCuda.MinNeighbors = 10;
                faceCuda.MinObjectSize = Size.Empty;

                eyeCuda = new CudaCascadeClassifier(eyeFileName);
                eyeCuda.ScaleFactor = 1.1;
                eyeCuda.MinNeighbors = 10;
                eyeCuda.MinObjectSize = Size.Empty;
            }
#endif
            faceCpu = new CascadeClassifier(faceFileName);
            eyeCpu = new CascadeClassifier(eyeFileName);

        }

        public void Detect(
       IInputArray image,
       List<Rectangle> faces, List<Rectangle> eyes)
        {

            using (InputArray iaImage = image.GetInputArray())
            {

#if !(__IOS__ || NETFX_CORE)
                if (iaImage.Kind == InputArray.Type.CudaGpuMat && CudaInvoke.HasCuda)
                {
                    // Traitement avec CUDA

                    using (CudaImage<Bgr, Byte> gpuImage = new CudaImage<Bgr, byte>(image))
                    using (CudaImage<Gray, Byte> gpuGray = gpuImage.Convert<Gray, Byte>())
                    using (GpuMat region = new GpuMat())
                    {
                        faceCuda.DetectMultiScale(gpuGray, region);
                        Rectangle[] faceRegion = faceCuda.Convert(region);
                        faces.AddRange(faceRegion);

                        /*foreach (Rectangle f in faceRegion)
                        {
                            using (CudaImage<Gray, Byte> faceImg = gpuGray.GetSubRect(f))
                            {
                                //For some reason a clone is required.
                                //Might be a bug of CudaCascadeClassifier in opencv
                                using (CudaImage<Gray, Byte> clone = faceImg.Clone(null))
                                using (GpuMat eyeRegionMat = new GpuMat())
                                {
                                    eyeCuda.DetectMultiScale(clone, eyeRegionMat);
                                    Rectangle[] eyeRegion = eyeCuda.Convert(eyeRegionMat);
                                    foreach (Rectangle e in eyeRegion)
                                    {
                                        Rectangle eyeRect = e;
                                        eyeRect.Offset(f.X, f.Y);
                                        eyes.Add(eyeRect);
                                    }
                                }
                            }
                        }*/
                    }
                }

                else
#endif
                {
                    // Traitement sans CUDA


                    using (UMat ugray = new UMat())
                    {
                        CvInvoke.CvtColor(image, ugray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);

                        //normalizes brightness and increases contrast of the image
                        CvInvoke.EqualizeHist(ugray, ugray);

                        //Detect the faces  from the gray scale image and store the locations as rectangle
                        //The first dimensional is the channel
                        //The second dimension is the index of the rectangle in the specific channel                     
                        Rectangle[] facesDetected = faceCpu.DetectMultiScale(
                           ugray,
                           1.1,
                           10,
                           new Size(20, 20));

                        faces.AddRange(facesDetected);

                        foreach (Rectangle f in facesDetected)
                        {
                            //Get the region of interest on the faces
                            using (UMat faceRegion = new UMat(ugray, f))
                            {
                                Rectangle[] eyesDetected = eyeCpu.DetectMultiScale(
                                   faceRegion,
                                   1.1,
                                   10,
                                   new Size(20, 20));

                                foreach (Rectangle e in eyesDetected)
                                {
                                    Rectangle eyeRect = e;
                                    eyeRect.Offset(f.X, f.Y);
                                    eyes.Add(eyeRect);
                                }

                            }
                        }
                    }
                }
            }
        }



    }
}
