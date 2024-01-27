/*using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using QRCoder;
using ZXing;

namespace Supermarket_app
{
    public partial class CameraForm : Form
    {
        public CameraForm()
        {
            InitializeComponent();
        }

        private FilterInfoCollection filterInfoCollection;
        private VideoCaptureDevice captureDevice;

        private void CameraForm_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo filterInfo in filterInfoCollection)
            {
                cboDevice.Items.Add(filterInfo.Name);
            }

            if (cboDevice.Items.Count > 0)
            {
                cboDevice.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No video devices found.");
                btnStart.Enabled = false;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                captureDevice = new VideoCaptureDevice(filterInfoCollection[cboDevice.SelectedIndex].MonikerString);
                captureDevice.NewFrame += CaptureDevice_NewFrame;
                captureDevice.Start();
                timer1.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting video capture: {ex.Message}");
            }
        }

        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void CameraForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (captureDevice.IsRunning)
                captureDevice.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                try
                {
                    BarcodeReader barcodeReader = new BarcodeReader();
                    var result = barcodeReader.Decode((Bitmap)pictureBox.Image);

                    if (result != null)
                    {
                        textQRCode.Text = result.Text;
                        timer1.Stop();

                        if (captureDevice != null && captureDevice.IsRunning)
                        {
                            captureDevice.Stop();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error decoding QR code: {ex.Message}");
                }
            }
        }
    }
}*/

/*using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;

namespace Supermarket_app
{
    public partial class CameraForm : Form
    {
        public CameraForm()
        {
            InitializeComponent();
        }

        private FilterInfoCollection filterInfoCollection;
        private VideoCaptureDevice captureDevice;

        private void CameraForm_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo filterInfo in filterInfoCollection)
            {
                cboDevice.Items.Add(filterInfo.Name);
            }

            if (cboDevice.Items.Count > 0)
            {
                cboDevice.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No video devices found.");
                btnStart.Enabled = false;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                captureDevice = new VideoCaptureDevice(filterInfoCollection[cboDevice.SelectedIndex].MonikerString);
                captureDevice.NewFrame += CaptureDevice_NewFrame;
                captureDevice.Start();
                timer1.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting video capture: {ex.Message}");
            }
        }

        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void CameraForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (captureDevice.IsRunning)
                captureDevice.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                try
                {
                    BarcodeReader barcodeReader = new BarcodeReader();
                    var result = barcodeReader.Decode((Bitmap)pictureBox.Image);

                    if (result != null)
                    {
                        textQRCode.Text = result.Text;
                        timer1.Stop();

                        if (captureDevice != null && captureDevice.IsRunning)
                        {
                            captureDevice.Stop();
                        }

                        // Add the following code to close the form and set DialogResult
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error decoding QR code: {ex.Message}");
                }
            }
        }
    }
}*/

using System;                 // auto login done
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using System.Security.Cryptography;
using System.IO;

namespace Supermarket_app
{
    public partial class CameraForm : Form
    {
        public CameraForm()
        {
            InitializeComponent();
        }

        private FilterInfoCollection filterInfoCollection;
        private VideoCaptureDevice captureDevice;

        /*

          private string DecryptData(string encryptedData, string encryptionKey)
         {
             using (Aes aesAlg = Aes.Create())
             {
                 aesAlg.Key = Encoding.UTF8.GetBytes(encryptionKey);
                 aesAlg.IV = new byte[16]; // Initialization Vector

                 ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                 using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(encryptedData)))
                 {
                     using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                     {
                         using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                         {
                             return srDecrypt.ReadToEnd();
                         }
                     }
                 }
             }
         }*/

        private void CameraForm_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo filterInfo in filterInfoCollection)
            {
                cboDevice.Items.Add(filterInfo.Name);
            }

            if (cboDevice.Items.Count > 0)
            {
                cboDevice.SelectedIndex = 0;
                // Start the camera automatically
                StartCamera();
            }
            else
            {
                MessageBox.Show("No video devices found.");
                //btnStart.Enabled = false;
            }
        }

        private void StartCamera()
        {
            try
            {
                captureDevice = new VideoCaptureDevice(filterInfoCollection[cboDevice.SelectedIndex].MonikerString);
                captureDevice.NewFrame += CaptureDevice_NewFrame;
                captureDevice.Start();
                timer1.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting video capture: {ex.Message}");
            }
        }

        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void CameraForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (captureDevice != null && captureDevice.IsRunning)
                captureDevice.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                try
                {
                    BarcodeReader barcodeReader = new BarcodeReader();
                    var result = barcodeReader.Decode((Bitmap)pictureBox.Image);

                    if (result != null)
                    {
                        //textQRCode.Text = result.Text;
                        timer1.Stop();

                        if (captureDevice != null && captureDevice.IsRunning)
                        {
                            captureDevice.Stop();
                        }

                        // Add the following code to close the form and set DialogResult
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error decoding QR code: {ex.Message}");
                }
            }
        }

        /*  private void timer1_Tick(object sender, EventArgs e)
          {
              if (pictureBox.Image != null)
              {
                  try
                  {
                      BarcodeReader barcodeReader = new BarcodeReader();
                      var result = barcodeReader.Decode((Bitmap)pictureBox.Image);

                      if (result != null)
                      {
                          // Decrypt the QR code data
                          string decryptedData = DecryptData(result.Text, "81807210ABCD");//encryption key goes here

                          // Use the decrypted data as needed
                          MessageBox.Show($"Decrypted QR Code Data: {decryptedData}");

                          timer1.Stop();

                          if (captureDevice != null && captureDevice.IsRunning)
                          {
                              captureDevice.Stop();
                          }

                          // Add the following code to close the form and set DialogResult
                          DialogResult = DialogResult.OK;
                          Close();
                      }
                  }
                  catch (Exception ex)
                  {
                      MessageBox.Show($"Error decoding QR code: {ex.Message}");
                  }
              }
          }
        */

        private void lblCode_Click(object sender, EventArgs e)
        {
        }

        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}