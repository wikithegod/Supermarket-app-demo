using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton;
using ComponentFactory.Krypton.Toolkit;

namespace Supermarket_app
{
    public partial class SellerForm : KryptonForm
    {
        public SellerForm()
        {
            InitializeComponent();
        }

        private SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Administrator\Documents\SUPRMARKET.mdf;Integrated Security=True;Connect Timeout=30 ");

        private void populate()
        {
            con.Open();
            String query = "select * from SellerTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            SellerDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void SellerForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        /*  private void SellerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
          {
              Sid.Text = SellerDGV.SelectedRows[0].Cells[0].Value.ToString();
              Sname.Text = SellerDGV.SelectedRows[0].Cells[1].Value.ToString();
              Sage.Text = SellerDGV.SelectedRows[0].Cells[2].Value.ToString();
              Sphone.Text = SellerDGV.SelectedRows[0].Cells[3].Value.ToString();
              Spass.Text = SellerDGV.SelectedRows[0].Cells[4].Value.ToString();
          }*/

        /* private void kryptonButton10_Click(object sender, EventArgs e)
         {
             try
             {
                 con.Open();
                 string query = "INSERT INTO SellerTbl VALUES(" + Sid.Text + ", '" + Sname.Text + "', " + Sage.Text + "," + Sphone.Text + ",'" + Spass.Text + "')";
                 SqlCommand cmd = new SqlCommand(query, con);
                 cmd.ExecuteNonQuery();
                 MessageBox.Show("Seller Added Successfully");

                 //con.Close();
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
             finally
             {
                 con.Close();
                 populate();

                 Sid.Text = "";
                 Sname.Text = "";
                 Sphone.Text = "";
                 Spass.Text = "";
                 Sage.Text = "";
             }
         }*/

        /* private void kryptonButton10_Click(object sender, EventArgs e)
         {
             try
             {
                 con.Open();
                 int age;
                 if (!int.TryParse(Sage.Text, out age))
                 {
                     MessageBox.Show("Please enter a valid age.");
                     return;
                 }

                 if (age <= 18)
                 {
                     MessageBox.Show("Seller age must be greater than 18.");
                     return;
                 }

                 string query = "INSERT INTO SellerTbl VALUES(" + Sid.Text + ", '" + Sname.Text + "', " + age + "," + Sphone.Text + ",'" + Spass.Text + "')";
                 SqlCommand cmd = new SqlCommand(query, con);
                 cmd.ExecuteNonQuery();
                 MessageBox.Show("Seller Added Successfully");
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
             finally
             {
                 con.Close();
                 populate();

                 Sid.Text = "";
                 Sname.Text = "";
                 Sphone.Text = "";
                 Spass.Text = "";
                 Sage.Text = "";
             }
         }*/

        private void kryptonButton10_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                int age;
                if (!int.TryParse(Sage.Text, out age) || age <= 18 || age >= 90)
                {
                    MessageBox.Show("Please enter a valid age between 18 and 90.");
                    return;
                }

                string query = "INSERT INTO SellerTbl VALUES(" + Sid.Text + ", '" + Sname.Text + "', " + age + "," + Sphone.Text + ",'" + Spass.Text + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Seller Added Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                populate();

                Sid.Text = "";
                Sname.Text = "";
                Sphone.Text = "";
                Spass.Text = "";
                Sage.Text = "";
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void SellerDGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            Sid.Text = SellerDGV.SelectedRows[0].Cells[0].Value.ToString();
            Sname.Text = SellerDGV.SelectedRows[0].Cells[1].Value.ToString();
            Sage.Text = SellerDGV.SelectedRows[0].Cells[2].Value.ToString();
            Sphone.Text = SellerDGV.SelectedRows[0].Cells[3].Value.ToString();
            Spass.Text = SellerDGV.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void kryptonButton2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (Sid.Text == "")

                    MessageBox.Show("Select The Seller to delete");
                else
                {
                    con.Open();
                    string query = "delete from SellerTbl where SellerId =" + Sid.Text + "";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Seller Deleted Successfully");

                    /*con.Close();
                      populate(); */
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                populate();
                Sid.Text = "";
                Sname.Text = "";
                Sphone.Text = "";
                Spass.Text = "";
                Sage.Text = "";
            }
        }

        /*   private void kryptonButton5_Click(object sender, EventArgs e)
           {
               try
               {
                   if (Sname.Text == "" || Sid.Text == "" || Sage.Text == "" || Sphone.Text == "" || Spass.Text == "")
                   {
                       MessageBox.Show("Missing Information");
                   }
                   else
                   {
                       con.Open();
                       string query = "UPDATE SellerTbl SET SellerName='" + Sname.Text + "', SellerAge='" + Sage.Text + "', SellerPhone='" + Sphone.Text + "', SellerPass='" + Spass.Text + "' WHERE SellerID =" + Sid.Text + ";";
                       SqlCommand cmd = new SqlCommand(query, con);
                       cmd.ExecuteNonQuery();
                       MessageBox.Show("Seller Details Updated Successfully");
                   }
               }
               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message);
               }
               finally
               {
                   con.Close();
                   populate();
                   Sid.Text = "";
                   Sname.Text = "";
                   Sphone.Text = "";
                   Spass.Text = "";
                   Sage.Text = "";
               }
           }*/

        /*  private void kryptonButton5_Click(object sender, EventArgs e)
          {
              try
              {
                  if (Sname.Text == "" || Sid.Text == "" || Sage.Text == "" || Sphone.Text == "" || Spass.Text == "")
                  {
                      MessageBox.Show("Missing Information");
                  }
                  else
                  {
                      con.Open();
                      int age;
                      if (!int.TryParse(Sage.Text, out age))
                      {
                          MessageBox.Show("Please enter a valid age.");
                          return;
                      }

                      if (age <= 18)
                      {
                          MessageBox.Show("Seller age must be greater than 18.");
                          return;
                      }

                      string query = "UPDATE SellerTbl SET SellerName='" + Sname.Text + "', SellerAge='" + age + "', SellerPhone='" + Sphone.Text + "', SellerPass='" + Spass.Text + "' WHERE SellerID =" + Sid.Text + ";";
                      SqlCommand cmd = new SqlCommand(query, con);
                      cmd.ExecuteNonQuery();
                      MessageBox.Show("Seller Details Updated Successfully");
                  }
              }
              catch (Exception ex)
              {
                  MessageBox.Show(ex.Message);
              }
              finally
              {
                  con.Close();
                  populate();
                  Sid.Text = "";
                  Sname.Text = "";
                  Sphone.Text = "";
                  Spass.Text = "";
                  Sage.Text = "";
              }
          }
        */

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            try
            {
                if (Sname.Text == "" || Sid.Text == "" || Sage.Text == "" || Sphone.Text == "" || Spass.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    con.Open();
                    int age;
                    if (!int.TryParse(Sage.Text, out age) || age <= 18 || age >= 90)
                    {
                        MessageBox.Show("Please enter a valid age between 18 and 90.");
                        return;
                    }

                    string query = "UPDATE SellerTbl SET SellerName='" + Sname.Text + "', SellerAge='" + age + "', SellerPhone='" + Sphone.Text + "', SellerPass='" + Spass.Text + "' WHERE SellerID =" + Sid.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Seller Details Updated Successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                populate();
                Sid.Text = "";
                Sname.Text = "";
                Sphone.Text = "";
                Spass.Text = "";
                Sage.Text = "";
            }
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            CATEGORYFORM3 cat = new CATEGORYFORM3();
            cat.Show();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductForm prod = new ProductForm();
            prod.Show();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            SellingForm sell = new SellingForm();
            sell.Show();
        }

        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}