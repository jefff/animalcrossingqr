using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AnimalCrossingQR
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += Application_ThreadException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            LogException((Exception)e.ExceptionObject);
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            LogException(e.Exception);
        }
        
        static void LogException(Exception exception)
        {
            try
            {
                string data = exception.Message + ";;" + exception.TargetSite + ";;" + exception.StackTrace;

                ZXing.BarcodeWriter writer = new ZXing.BarcodeWriter();
                writer.Format = ZXing.BarcodeFormat.QR_CODE;
                ZXing.Common.BitMatrix matrix = writer.Encode(data);

                int scale = 2;

                Bitmap result = new Bitmap(matrix.Width * scale, matrix.Height * scale);

                for (int x = 0; x < matrix.Height; x++)
                    for (int y = 0; y < matrix.Width; y++)
                    {
                        Color pixel = matrix[x, y] ? Color.Black : Color.White;
                        for (int i = 0; i < scale; i++)
                            for (int j = 0; j < scale; j++)
                                result.SetPixel(x * scale + i, y * scale + j, pixel);
                    }

                result.Save(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\crash-" + DateTime.Now.Ticks + ".png");
            }
            catch (Exception)
            {
                // FML.
            }
        }
    }
}
