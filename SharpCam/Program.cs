using System.Collections.Generic;
using System.Threading;
using WebEye.Controls.WinForms.WebCameraControl;
using System.Drawing;

namespace SharpCam
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            WebCameraControl cameraControl = new WebCameraControl();
            List<WebCameraId> cameras = new List<WebCameraId>(cameraControl.GetVideoCaptureDevices());
            if (args.Length == 0)
            {
                cameraControl.StartCapture(cameras[0]);
                Thread.Sleep(250);
                Bitmap image = cameraControl.GetCurrentImage();
                image.Save("webcam.png", System.Drawing.Imaging.ImageFormat.Png);
            }
            else if (args.Length == 1)
            {
                cameraControl.StartCapture(cameras[int.Parse(args[0])]);
                Thread.Sleep(250);
                Bitmap image = cameraControl.GetCurrentImage();
                image.Save("webcam.png", System.Drawing.Imaging.ImageFormat.Png);
            }
            else
            {
                cameraControl.StartCapture(cameras[int.Parse(args[0])]);
                Thread.Sleep(250);
                Bitmap image = cameraControl.GetCurrentImage();
                image.Save(args[1], System.Drawing.Imaging.ImageFormat.Png);
            }
            cameraControl.StopCapture();
        }
    }
}
