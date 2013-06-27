using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AnimalCrossingQR
{
    public partial class URLDialog : Form
    {
        Thread thread;
        byte[] downloadData;

        public Bitmap ResultImage { get; private set; }

        public URLDialog()
        {
            InitializeComponent();
        }

        private void URLDialog_Load(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                Uri uri;
                if (Uri.TryCreate(Clipboard.GetText(), UriKind.Absolute, out uri))
                {
                    if (uri.Scheme.Equals("http", StringComparison.OrdinalIgnoreCase) ||
                        uri.Scheme.Equals("https", StringComparison.OrdinalIgnoreCase))
                        urlTextBox.Text = Clipboard.GetText();
                }
            }
        }

        private void DownloadAsync(string url)
        {
            if (thread != null)
                return;

            thread = new Thread(() =>
                {
                    okButton.Invoke((Action)(() => 
                        {
                            okButton.Text = "Downloading...";
                            okButton.Enabled = false;
                        }));

                    try
                    {
                        using (WebClient webClient = new WebClient())
                            downloadData = webClient.DownloadData(url);

                        MemoryStream ms = new MemoryStream(downloadData);
                        ResultImage = (Bitmap)Bitmap.FromStream(ms);

                        DialogResult = DialogResult.OK;
                    }
                    catch (WebException e)
                    {
                        errorLabel.Invoke((Action)(() =>
                            {
                                errorLabel.Text = "Failed to download image. Check the URL and try again.";
                                errorLabel.Visible = true;
                            }));
                    }
                    catch (ArgumentException e)
                    {
                        errorLabel.Invoke((Action)(() =>
                        {
                            errorLabel.Text = "The downloaded file is not a valid image. Check that the URL is a direct image link.";
                            errorLabel.Visible = true;
                        }));
                    }
                    catch (ThreadAbortException)
                    {
                    }
                    finally
                    {
                        thread = null;

                        okButton.Invoke((Action)(() =>
                        {
                            okButton.Text = "OK";
                            okButton.Enabled = true;
                        }));
                    }
                });

            thread.IsBackground = true;
            thread.Start();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DownloadAsync(urlTextBox.Text);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (thread != null)
            {
                thread.Abort();
                thread = null;
                return;
            }

            DialogResult = DialogResult.Cancel;
        }
    }
}
