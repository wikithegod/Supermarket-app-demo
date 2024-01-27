using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using ComponentFactory.Krypton;
using ComponentFactory.Krypton.Toolkit;
using Microsoft.VisualBasic;

using System.Linq;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Web.UI.WebControls;
using QRCoder;

//using ZXing;
//using ZXing.Common;
//using ZXing.QrCode.Internal;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Supermarket_app
{
    public partial class Login : KryptonForm
    {
        public Login()
        {
            InitializeComponent();
        }

        public static string SellerName = "";

        private string adminVerificationCode;

        private SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Administrator\Documents\SUPRMARKET.mdf;Integrated Security=True;Connect Timeout=30 ");

        private void Login_Load(object sender, EventArgs e)
        {
        }

        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (UnameTb.Text == "" || PassTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                if (RoleCb.SelectedIndex > -1)
                {
                    if (RoleCb.SelectedItem.ToString() == "ADMIN")
                    {
                        if (UnameTb.Text == "Admin" && PassTb.Text == "Admin")
                        {
                            /*adminVerificationCode = GenerateRandomVerificationCode();

                            // Generate a QR code for the verification code
                            string qrCodeData = $"Verification Code: {adminVerificationCode}";
                            Bitmap qrCodeBitmap = GenerateQRCode(qrCodeData);

                            // Send email notification to admin with verification code QR code as an attachment
                            SendEmailWithQRCode("Admin Login Verification Code", "Your verification code is attached as a QR code.", "reciver mail goes here  ", qrCodeBitmap);
                            */
                            adminVerificationCode = GenerateRandomVerificationCode();

                            // Generate a QR code for the verification code
                            string qrCodeData = $"Verification Code: {adminVerificationCode}";
                            Bitmap qrCodeBitmap = GenerateQRCode(qrCodeData);
                            // adminVerificationCode = GenerateRandomVerificationCode();

                            /* // Generate a QR code for the verification code
                             string qrCodeData = $"Verification Code: {adminVerificationCode}";
                             Bitmap encryptedQRCodeBitmap = GenerateEncryptedQRCode(qrCodeData, "enter encrypition any key");//encryption key goes here*/

                            // Send email notification to admin with encrypted QR code
                            // SendEmailWithVerificationCode("Admin Login Verification Code", $"Your verification code is: {adminVerificationCode}", "reciver mail", encryptedQRCodeBitmap);

                            // Send email notification to admin with verification code and QR code
                            SendEmailWithVerificationCode("Admin Login Verification Code", $"Your verification code is: {adminVerificationCode}", "reciver mail", qrCodeBitmap);
                            // SendEmailWithVerificationCode("Admin Login Verification Code", $"Your verification code is: {adminVerificationCode}", "reciver mail", qrCodeBitmap);
                            /*  // Prompt user for verification code
                              string enteredCode = Interaction.InputBox("Enter Verification Code", "Verification", "");

                              // Check verification code
                              if (!string.IsNullOrEmpty(enteredCode) && enteredCode == adminVerificationCode)
                              {
                                  ProductForm prod = new ProductForm();
                                  prod.Show();
                                  this.Hide();

                                  // Send email notification to admin
                                  SendEmail("Admin Login Notification", "Admin has logged in.",  "reciver mail");

                                  // MessageBox.Show("Email Notification Sent Successfully");
                              }
                              else
                              {
                                  MessageBox.Show("Verification code is incorrect");
                              }*/
                            CameraForm cameraForm = new CameraForm();
                            if (cameraForm.ShowDialog() == DialogResult.OK)
                            {
                                // Camera form returned OK, proceed with login
                                ProductForm prod = new ProductForm();
                                prod.Show();
                                this.Hide();

                                // Send email notification to admin
                                SendEmail("Admin Login Notification", "Admin has logged in.", "reciver mail");
                            }
                            else
                            {
                                // Prompt user for verification code
                                string enteredCode = Interaction.InputBox("Enter Verification Code", "Verification", "");

                                // Check verification code
                                if (!string.IsNullOrEmpty(enteredCode) && enteredCode == adminVerificationCode)
                                {
                                    ProductForm prod = new ProductForm();
                                    prod.Show();
                                    this.Hide();

                                    // Send email notification to admin
                                    SendEmail("Admin Login Notification", "Admin has logged in.", "reciver mail");

                                    // MessageBox.Show("Email Notification Sent Successfully");
                                }
                                else
                                {
                                    MessageBox.Show("Verification code is incorrect");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Wrong Username or Password");
                            UnameTb.Text = "";
                            PassTb.Text = "";
                        }
                    }
                    else
                    {
                        con.Open();
                        SqlDataAdapter sda = new SqlDataAdapter("select count(8) from SellerTbl where SellerName='" + UnameTb.Text + "' and SellerPass='" + PassTb.Text + "'", con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            SellerName = UnameTb.Text;
                            SellingForm sell = new SellingForm();
                            sell.Show();
                            this.Hide();

                            // Send email notification to admin
                            SendEmail("Seller Login Notification", $"Seller '{SellerName}' has logged in.", "reciver mail");

                            // Do not show the success message for sellers
                        }
                        else
                        {
                            MessageBox.Show("Wrong Username or Password");
                            UnameTb.Text = "";
                            PassTb.Text = "";
                        }

                        con.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Select Your Role First ");
                    UnameTb.Text = "";
                    PassTb.Text = "";
                }
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private string GenerateRandomVerificationCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";//for generate random key
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void SendEmail(string subject, string body, string to)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("your gmail (sendr)", "app password"),
                    EnableSsl = true,
                };

                MailMessage mail = new MailMessage("sender mail", to)
                {
                    Subject = subject,
                    Body = body,

                    IsBodyHtml = false,
                };
                client.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send email notification: {ex.Message}");
            }
        }

        private Bitmap GenerateQRCode(string data)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeBitmap = qrCode.GetGraphic(20); // Adjust the size as needed
            return qrCodeBitmap;
        }

        /*   private Bitmap GenerateEncryptedQRCode(string data, string encryptionKey)
           {
               // Encrypt the data using AES encryption
               string encryptedData = EncryptData(data, encryptionKey);

               // Generate QR code for the encrypted data
               QRCodeGenerator qrGenerator = new QRCodeGenerator();
               QRCodeData qrCodeData = qrGenerator.CreateQrCode(encryptedData, QRCodeGenerator.ECCLevel.Q);
               QRCode qrCode = new QRCode(qrCodeData);
               Bitmap qrCodeBitmap = qrCode.GetGraphic(20); // Adjust the size as needed

               return qrCodeBitmap;
           }

           private string EncryptData(string data, string encryptionKey)
           {
               using (Aes aesAlg = Aes.Create())
               {
                   aesAlg.Key = Encoding.UTF8.GetBytes(encryptionKey);
                   aesAlg.IV = new byte[16]; // Initialization Vector

                   ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                   using (MemoryStream msEncrypt = new MemoryStream())
                   {
                       using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                       {
                           using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                           {
                               swEncrypt.Write(data);
                           }
                       }
                       return Convert.ToBase64String(msEncrypt.ToArray());
                   }
               }
           }
        */

        private void SendEmailWithVerificationCode(string subject, string body, string to, Bitmap attachmentBitmap)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("your gmil", "gmail app password"),
                    EnableSsl = true,
                };

                MailMessage mail = new MailMessage("sender gmail", to)
                {
                    Subject = subject,
                    IsBodyHtml = true,
                };

                // Add the text body
                mail.Body = body;

                // Convert Bitmap to byte array for attachment
                System.IO.MemoryStream stream = new System.IO.MemoryStream();
                attachmentBitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                byte[] bitmapBytes = stream.ToArray();

                // Attach the QR code as an image
                mail.Attachments.Add(new Attachment(new System.IO.MemoryStream(bitmapBytes), "QRCode.png"));

                client.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send email notification: {ex.Message}");
            }
        }
    }
}