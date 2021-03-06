using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Configuration;
using System.Collections;
using System.Web.UI.HtmlControls;
using System.ComponentModel;
using System.Windows;
using System.Drawing;

namespace Team11
{
    public partial class acceptRequests : System.Web.UI.Page
    {
        int userID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            userID = Convert.ToInt32(Session["userID"]);
            SqlConnection connect = new SqlConnection(WebConfigurationManager.ConnectionStrings["AdminConnectionString"].ToString());
            connect.Open();
            string adminString = "Select administrator from [User] where userID = " + userID;
            SqlCommand adminCommand = new SqlCommand(adminString, connect);
            string administratorYesNo = adminCommand.ExecuteScalar().ToString();
            string trimmedAdmin = administratorYesNo.Trim();
            bool userIsAdmin = (trimmedAdmin == "yes");
            if (userIsAdmin)
            {
                if (!this.IsPostBack)
                {
                  
                    //Populating a DataTable from database.
                    DataTable dt = this.GetData();

                    //Building an HTML string.
                    StringBuilder html = new StringBuilder();

                    //Table start.
                    html.Append("<table border = '1'>");

                    //Building the Header row.
                    html.Append("<tr>");
                    foreach (DataColumn column in dt.Columns)
                    {
                        html.Append("<th>");
                        html.Append(column.ColumnName);
                        html.Append("</th>");
                    }
                    html.Append("</tr>");

                    //Building the Data rows.
                    foreach (DataRow row in dt.Rows)
                    {
                        html.Append("<tr>");
                        bool reference = true;
                        bool one = false; bool two = false; bool three = false;
                        foreach (DataColumn column in dt.Columns)
                        {
                            //  string compare = row[column.ColumnName].ToString();
                            if (reference)
                            {
                                string columnName = row[column.ColumnName].ToString();

                                html.Append("<td>");
                                html.Append("<a href=\"acceptRequests2.aspx?requestReference=" + columnName + "\">" + row[column.ColumnName] + "</a>");
                                html.Append("</td>");
                                reference = false; one = true;

                            }
                            
                           
                            else
                            {
                                string checkPriority = row[column.ColumnName].ToString();
                                if (column.ColumnName == "priority") { 
                                if (checkPriority == "1")
                                {
                                    html.Append("<td bgcolor=\"#FF0000\">");
                                    html.Append(row[column.ColumnName]);
                                    html.Append("</td>");

                                }
                                else
                                {
                                    html.Append("<td>");

                                    html.Append(row[column.ColumnName]);
                                    html.Append("</td>");
                                }
                                }
                                else
                                {
                                    html.Append("<td>");

                                    html.Append(row[column.ColumnName]);
                                    html.Append("</td>");
                                }
                            }
                        }
                        html.Append("</tr>");
                    }

                    //Table end.
                    html.Append("</table>");

                    //Append the HTML string to Placeholder.
                    PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
                }
            }
            else {

                acceptRequestsDiv.InnerHtml = "You are not logged in as an admin. To use this page, you must be logged in as an admin.";
            
            
            }
        }

        private DataTable GetData()
        {
            string constr = ConfigurationManager.ConnectionStrings["AdminConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT requestID, moduleCode, status, weekID , day, periodStart, periodEnd, semester, year, round, priority FROM Request WHERE status='Pending'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }
    }
}
