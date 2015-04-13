using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Web.Configuration;
namespace Team11
{

    public partial class acceptRequests2 : System.Web.UI.Page
    {
        int userID = 0;
        string room = "";
        string roomID = "";
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
            if (!userIsAdmin)
            {

                tableDiv.InnerHtml = "You are not currently logged in as an admin. If you wish to use this page, you must be logged in as an admin.";
                buttonDiv.InnerHtml = "";
            }
            else
            {
                string allRoomsSQL = "SELECT roomID,roomName FROM Room";

                SqlConnection allRoomsConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["AdminConnectionString"].ToString());
                SqlCommand allRoomsCmd = new SqlCommand(allRoomsSQL, allRoomsConnection);
                SqlDataReader allReader;

                try
                {
                    if (!Page.IsPostBack)
                    {

                        listOfRooms.Items.Clear();

                        ListItem newItem = new ListItem();
                        newItem.Text = "Choose a room";
                        newItem.Value = "test";
                        listOfRooms.Items.Add(newItem);

                        allRoomsConnection.Open();
                        allReader = allRoomsCmd.ExecuteReader();
                        while (allReader.Read())
                        {
                            newItem = new ListItem();
                            newItem.Text = allReader["roomName"].ToString();
                            newItem.Value = allReader["roomID"].ToString();
                            listOfRooms.Items.Add(newItem);
                        }
                        allReader.Close();
                    }
                }
                catch (Exception err)
                {
                    //TODO
                }
                finally
                {
                    //Blank, may need to contain connection closing
                }
                acceptRequestedRoom.Click += new EventHandler(acceptRequestedRoomFunction);
                changeRequestedRoom.Click += new EventHandler(changeRequestedRoomFunction);
                rejectRequestedRoom.Click += new EventHandler(rejectRequestedRoomFunction);
                string url = Request.Url.Query; ///Gets url
                Match match = Regex.Match(url, @"=(.*)"); ///Gets reference from url
                string reference = match.Groups[1].Value;
                referenceLabel.Text = "You are responding to the request with reference number: " + reference + ".";

                string listSQL = "SELECT * FROM Request WHERE requestID =" + reference;

                SqlConnection Connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["AdminConnectionString"].ToString());
                Connection.Open();
                SqlCommand cmd = new SqlCommand(listSQL, Connection);

                SqlDataReader reader; reader = cmd.ExecuteReader();
                string moduleCode = "", status = "", weekID = "", day = "", periodStart = "", periodEnd = "", semester = "", year = "", round = "";

                while (reader.Read())
                {

                    moduleCode = reader["moduleCode"].ToString();
                    status = reader["status"].ToString();
                    weekID = reader["weekID"].ToString();
                    day = reader["day"].ToString();
                    periodStart = reader["periodStart"].ToString();
                    periodEnd = reader["periodEnd"].ToString();
                    semester = reader["semester"].ToString();
                    year = reader["year"].ToString();
                    round = reader["round"].ToString();

                }
                reader.Close();
                string weeks = "";
                string weekSQL = "SELECT * FROM Week WHERE weekID =" + weekID;
                bool week1 = false, week2 = false, week3 = false, week4 = false, week5 = false, week6 = false, week7 = false, week8 = false, week9 = false, week10 = false, week11 = false, week12 = false, week13 = false, week14 = false, week15 = false;
                SqlCommand cmd2 = new SqlCommand(weekSQL, Connection);
                SqlDataReader reader2; reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {

                    if (reader2["week1"].ToString() == "1") { week1 = true; } else { week1 = false; }
                    if (reader2["week2"].ToString() == "1") { week2 = true; } else { week2 = false; }
                    if (reader2["week3"].ToString() == "1") { week3 = true; } else { week3 = false; }
                    if (reader2["week4"].ToString() == "1") { week4 = true; } else { week4 = false; }
                    if (reader2["week5"].ToString() == "1") { week5 = true; } else { week5 = false; }
                    if (reader2["week6"].ToString() == "1") { week6 = true; } else { week6 = false; }
                    if (reader2["week7"].ToString() == "1") { week7 = true; } else { week7 = false; }
                    if (reader2["week8"].ToString() == "1") { week8 = true; } else { week8 = false; }
                    if (reader2["week9"].ToString() == "1") { week9 = true; } else { week9 = false; }
                    if (reader2["week10"].ToString() == "1") { week10 = true; } else { week10 = false; }
                    if (reader2["week11"].ToString() == "1") { week11 = true; } else { week11 = false; }
                    if (reader2["week12"].ToString() == "1") { week12 = true; } else { week12 = false; }
                    if (reader2["week13"].ToString() == "1") { week13 = true; } else { week13 = false; }
                    if (reader2["week14"].ToString() == "1") { week14 = true; } else { week14 = false; }
                    if (reader2["week15"].ToString() == "1") { week15 = true; } else { week15 = false; }

                }
                reader2.Close();
                room = "No preferred room";
                string roomSQL = "SELECT * FROM PreferredRoom WHERE requestID =" + reference;


                SqlCommand cmd3 = new SqlCommand(roomSQL, Connection);
                SqlDataReader reader3; reader3 = cmd3.ExecuteReader();

                while (reader3.Read())
                {
                    roomID = reader3["roomID"].ToString();
                }
                reader3.Close();
                string roomSQL2 = "SELECT * FROM Room WHERE roomID =" + roomID;
                if (!(roomID == ""))
                {
                    SqlCommand cmd4 = new SqlCommand(roomSQL2, Connection);
                    SqlDataReader reader4; reader4 = cmd4.ExecuteReader();

                    while (reader4.Read())
                    {
                        room = reader4["roomName"].ToString();
                    }
                }




                if (week1) { weeks += "1, "; }
                if (week2) { weeks += "2, "; }
                if (week3) { weeks += "3, "; }
                if (week4) { weeks += "4, "; }
                if (week5) { weeks += "5, "; }
                if (week6) { weeks += "6, "; }
                if (week7) { weeks += "7, "; }
                if (week8) { weeks += "8, "; }
                if (week9) { weeks += "9, "; }
                if (week10) { weeks += "10, "; }
                if (week11) { weeks += "11, "; }
                if (week12) { weeks += "12, "; }
                if (week13) { weeks += "13, "; }
                if (week14) { weeks += "14, "; }
                if (week15) { weeks += "15, "; }
                if (weeks == "") { weeks += "None"; }
                else
                {
                    weeks = weeks.Remove(weeks.Length - 2, 2);
                }



                tableDiv.InnerHtml = "<table style=\"border: 4px solid black;\"><tr style=\"border: 4px solid black;\">" +
        "<td style=\"border: 4px solid black;\">Module Code</td>" +
        "<td style=\"border: 4px solid black;\">Status</td>" +
        "<td style=\"border: 4px solid black;\">Weeks</td>" +
    "<td style=\"border: 4px solid black;\">Day</td>" +
    "<td style=\"border: 4px solid black;\">Period Start</td>" +
    "<td style=\"border: 4px solid black;\">Period End</td>" +
    "<td style=\"border: 4px solid black;\">Semester</td>" +
    "<td style=\"border: 4px solid black;\">Year</td>" +
    "<td style=\"border: 4px solid black;\">Round</td>" +
    "<td style=\"border: 4px solid black;\">Preferred Room</td>" +
    "<tr style=\"border: 4px solid black;\">" +
    "<td style=\"border: 4px solid black;\">" + moduleCode + "</td>" +
    "<td style=\"border: 4px solid black;\">" + status + "</td>" +
    "<td style=\"border: 4px solid black;\">" + weeks + "</td>" +
    "<td style=\"border: 4px solid black;\">" + day + "</td>" +
    "<td style=\"border: 4px solid black;\">" + periodStart + "</td>" +
    "<td style=\"border: 4px solid black;\">" + periodEnd + "</td>" +
    "<td style=\"border: 4px solid black;\">" + semester + "</td>" +
    "<td style=\"border: 4px solid black;\">" + year + "</td>" +
    "<td style=\"border: 4px solid black;\">" + round + "</td>" +
    "<td style=\"border: 4px solid black;\">" + room + "</td>" +
    "</tr></table>";


            }
        }
        protected void changeRequestedRoomFunction(Object sender, EventArgs e)
        {

            string selectedRoom = listOfRooms.SelectedItem.Value;
            if (selectedRoom == "test") {

                scriptDiv.InnerHtml = "<script>alert(\"You have not selected a room. Please select a room from the drop down list (that is the room that will be booked for this request).\");</script>";
            
            }
            else
            {
                string url = Request.Url.Query; ///Gets url
                Match match = Regex.Match(url, @"=(.*)"); ///Gets reference from url
                string reference = match.Groups[1].Value;

                SqlConnection acceptConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["AdminConnectionString"].ToString());
                acceptConnect.Open();
                string acceptString = "UPDATE Request SET status='Accepted' WHERE requestID=" + reference;
                SqlCommand acceptCommand = new SqlCommand(acceptString, acceptConnect);
                acceptCommand.ExecuteNonQuery();
                string bookRoomSQL = "INSERT INTO BookedRoom VALUES (" + reference + "," + selectedRoom + ")";
                SqlCommand bookRoomCommand = new SqlCommand(bookRoomSQL, acceptConnect);
                bookRoomCommand.ExecuteNonQuery();
                scriptDiv.InnerHtml = "<script>alert(\"Request successfully accepted.\");</script>";
                Response.Redirect("acceptRequests.aspx");
            }

        }
        protected void acceptRequestedRoomFunction(Object sender, EventArgs e)
        {

            if (room == "No preferred room")
            {

                scriptDiv.InnerHtml = "<script>alert(\"You cannot accept a request that does not have a preferred room. Please click 'Accept request but assign a different room'.\");</script>";


            }
            else
            {
                string url = Request.Url.Query; ///Gets url
                Match match = Regex.Match(url, @"=(.*)"); ///Gets reference from url
                string reference = match.Groups[1].Value;

                SqlConnection acceptConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["AdminConnectionString"].ToString());
                acceptConnect.Open();
                string acceptString = "UPDATE Request SET status='Accepted' WHERE requestID=" + reference;
                SqlCommand acceptCommand = new SqlCommand(acceptString, acceptConnect);
                acceptCommand.ExecuteNonQuery();
                string bookRoomSQL = "INSERT INTO BookedRoom VALUES (" + reference + "," + roomID + ")";
                SqlCommand bookRoomCommand = new SqlCommand(bookRoomSQL, acceptConnect);
                bookRoomCommand.ExecuteNonQuery();
                scriptDiv.InnerHtml = "<script>alert(\"Request successfully accepted.\");</script>";
                Response.Redirect("acceptRequests.aspx");
            }
        }
        protected void rejectRequestedRoomFunction(Object sender, EventArgs e)
        {
            string url = Request.Url.Query; ///Gets url
            Match match = Regex.Match(url, @"=(.*)"); ///Gets reference from url
            string reference = match.Groups[1].Value;

            SqlConnection rejectConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["AdminConnectionString"].ToString());
            rejectConnect.Open();
            string rejectString = "UPDATE Request SET status='Rejected' WHERE requestID=" + reference;
            SqlCommand rejectCommand = new SqlCommand(rejectString, rejectConnect);
            rejectCommand.ExecuteNonQuery();
            scriptDiv.InnerHtml = "<script>alert(\"Request successfully rejected.\");</script>";
            Response.Redirect("acceptRequests.aspx");
        }




    }
}
