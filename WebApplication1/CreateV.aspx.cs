using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace Voting_System
{
    public partial class CreateV : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnCV_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Voting.mdf;Integrated Security=True";
            string strlnsert = String.Format("INSERT INTO Vote VALUES('{0}','{1}','{2}')", TextNV.Text,TextID.Text,TextNOV.Text);



            SqlCommand cmdlnsert = new SqlCommand(strlnsert, conn);

            try
            {

                conn.Open();

                cmdlnsert.ExecuteNonQuery();

                conn.Close();


                lblMMSG.Text = "You vote " + TextNV.Text + "  In The List";
            }

            catch (SqlException err)
            {
                if (err.Number == 2627)
                    lblMMSG.Text = "The username" + TextNV.Text + "already used , please choose another";
                else
                    lblMMSG.Text = "Sorry,database problem,please try later ";

            }

            catch
            {
                lblMMSG.Text = "Sorry, the system is not available at the moment,you may try later";
            }
        }
    }
    }
