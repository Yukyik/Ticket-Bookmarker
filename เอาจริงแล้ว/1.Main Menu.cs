using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using System.Globalization;

namespace เอาจริงแล้ว
{
    public partial class Form1 : Form
    {
        int[] seatlist =
            {
                0, 0 , 0, 0 ,0, 0, 0,
                0, 0 , 0, 0 ,0, 0, 0,
                0, 0 , 0, 0 ,0, 0, 0,
                0, 0 , 0, 0 ,0, 0, 0,
                0, 0 , 0, 0 ,0, 0, 0,
                0, 0 , 0, 0 ,0, 0, 0,
            };
        string[] Seat_name =
        {
            "A1","A2","A3","A4","A5","A6","A7",
            "B1","B2","B3","B4","B5","B6","B7",
            "C1","C2","C3","C4","C5","C6","C7",
            "D1","D2","D3","D4","D5","D6","D7",
            "E1","E2","E3","E4","E5","E6","E7",
            "F1","F2","F3","F4","F5","F6","F7",
        };
        int Movie_Selected = 0;
        int[] Time_edit = { 0, 0, 0 };
        int Slot_edit = 0;

        PrintPreviewDialog PrintPreview = new PrintPreviewDialog();
        PrintDocument PrintDoc = new PrintDocument();
        Bitmap memory_img;

        public Form1()
        {
            InitializeComponent();
            hide_menu_on_start();
        }
        private void hide_menu_on_start()
        {
            Receipt_Panel.Visible = false;
            Cart_Payment_Panel.Visible = false;
            Movie_List.Enabled = false;
            Cart_Payment.Enabled = false;
            Receipt.Enabled = false;
            highA.Enabled = false;
            highB.Enabled = false;
            highC.Enabled = false;
            highD.Enabled = false;
            highE.Enabled = false;
            highF.Enabled = false;
            T1.Visible = false;
            T2.Visible = false;
            T3.Visible = false;
            TT1.Visible = false;
            TT2.Visible = false;
            TT3.Visible = false;
            TTT1.Visible = false;
            TTT2.Visible = false;
            TTT3.Visible = false;

            register_form.Visible = false;
            MainPanel.Visible = false;
            movie_panel.Visible = false;
            Seat_panel.Visible = false;
            Confirm_panel.Visible = false;
            Print_Panel_main.Visible = false;
            Maintance_panel.Visible = false;
            Help_panel.Visible = false;

            Maintance_button.Enabled = false;

            textBox1.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
        }
        private void Hidemenu()
        {
            if (Receipt_Panel.Visible == true)
                Receipt_Panel.Visible = false;
            if (Cart_Payment_Panel.Visible == true)
                Cart_Payment_Panel.Visible = false;
            if (MainMenu_Panel.Visible == true)
                MainMenu_Panel.Visible = false;
        }
        private void Showmenu(Panel Submenu)
        {
            if (Submenu.Visible == false)
            {
                Hidemenu();
                Submenu.Visible = true;
            }
            else
                Submenu.Visible = false;
        }
        private void Hide_panel()
        {
            if (register_form.Visible == true)
                register_form.Visible = false;
            if (MainPanel.Visible == true)
                MainPanel.Visible = false;
            if (movie_panel.Visible == true)
                movie_panel.Visible = false;
            if (Seat_panel.Visible == true)
                Seat_panel.Visible = false;
            if (Confirm_panel.Visible == true)
                Confirm_panel.Visible = false;
            if (Print_Panel_main.Visible == true)
                Print_Panel_main.Visible = false;
            if (Maintance_panel.Visible == true)
                Maintance_panel.Visible = false;
            if (Help_panel.Visible == true)
                Help_panel.Visible = false;
        }
        private void ShowPanel(Panel Subpanel)
        {
            if (Subpanel.Visible == false)
            {
                Hide_panel();
                Subpanel.Visible = true;
            }
            else
                Subpanel.Visible = false;
        }
        private void Movie_Time_Click(object sender, EventArgs e)
        {
            if ((sender == T1) | (sender == T2) | (sender == T3))
            {
                string Theater = "seat";
                TheaterNo.Text = "1";
                Theater_show_inconfirm.Text = "Theater 1";
                Seat_Check(Theater);
            }
            if ((sender == TT1) | (sender == TT2) | (sender == TT3))
            {
                string Theater = "seat2";
                TheaterNo.Text = "2";
                Theater_show_inconfirm.Text = "Theater 2";
                Seat_Check(Theater);
            }
            if ((sender == TTT1) | (sender == TTT2) | (sender == TTT3))
            {
                string Theater = "seat3";
                TheaterNo.Text = "3";
                Theater_show_inconfirm.Text = "Theater 3";
                Seat_Check(Theater);
            }
            if ((sender == T1) | (sender == TT1) | (sender == TTT1))
            {
                button9.Text = "11:00";
                textBox1.Text = "11:00 O'clock";
            }
            if ((sender == T2) | (sender == TT2) | (sender == TTT2))
            {
                button9.Text = "14:30";
                textBox1.Text = "14:30 O'clock";
            }
            if ((sender == T3) | (sender == TT3) | (sender == TTT3))
            {
                button9.Text = "17:00";
                textBox1.Text = "17:00 O'clock";
            }
            ShowPanel(Seat_panel);
            Cart_Payment.Enabled = true;
            Cart_Payment_Panel.Visible = true;
            Confirm_button.Enabled = false;
        }
        private void Movie_Time_Selected(object sender, EventArgs e)
        {
            ShowPanel(movie_panel);
            
            DB db = new DB();
            int a = 1;
            string[] timeset = { "", "", "" };
            while (a < 4)
            {
                byte[] getImg = new byte[0];
                DataSet da = new DataSet();
                DataSet da_img = new DataSet();
                MySqlDataAdapter adapter_info = new MySqlDataAdapter();

                MySqlCommand Search_command = new MySqlCommand("SELECT `Name`, `Movie_length`, `Language`, `Image` , `Time1` ,`Time2` ,`Time3` FROM `movie` WHERE id = @AA", db.GetConnection());
                Search_command.Parameters.Add("@AA", MySqlDbType.Int32).Value = a;

                db.OpenConnection();

                MySqlDataReader data_rec = Search_command.ExecuteReader();

                while (data_rec.Read())
                {
                    timeset[0] = data_rec.GetValue(4).ToString();
                    timeset[1] = data_rec.GetValue(5).ToString();
                    timeset[2] = data_rec.GetValue(6).ToString();
                    if (a == 1)
                    {
                        Movie_name1.Text = data_rec.GetValue(0).ToString();
                        Movie_time1.Text = data_rec.GetValue(1).ToString() + " Mins";
                        Lang_1.Text = data_rec.GetValue(2).ToString();
                        if (timeset[0] == "1")
                            T1.Visible = true;
                        if (timeset[1] == "1")
                            T2.Visible = true;
                        if (timeset[2] == "1")
                            T3.Visible = true;
                    }
                    if (a == 2)
                    {
                        Movie_name2.Text = data_rec.GetValue(0).ToString();
                        Movie_time2.Text = data_rec.GetValue(1).ToString() + " Mins";
                        Lang_2.Text = data_rec.GetValue(2).ToString();
                        if (timeset[0] == "1")
                            TT1.Visible = true;
                        if (timeset[1] == "1")
                            TT2.Visible = true;
                        if (timeset[2] == "1")
                            TT3.Visible = true;
                    }
                    if (a == 3)
                    {
                        Movie_name3.Text = data_rec.GetValue(0).ToString();
                        Movie_time3.Text = data_rec.GetValue(1).ToString() + " Mins";
                        Lang_3.Text = data_rec.GetValue(2).ToString();
                        if (timeset[0] == "1")
                            TTT1.Visible = true;
                        if (timeset[1] == "1")
                            TTT2.Visible = true;
                        if (timeset[2] == "1")
                            TTT3.Visible = true;
                    }
                }

                db.CloseConnection();
                db.OpenConnection();

                adapter_info.SelectCommand = Search_command;
                adapter_info.Fill(da_img);
                foreach (DataRow dr in da_img.Tables[0].Rows)
                {
                    getImg = (byte[])dr["Image"];
                }
                byte[] imgData = getImg;
                MemoryStream stream = new MemoryStream(imgData);

                if (a == 1)
                    Movie_list_pic1.Image = Image.FromStream(stream);
                if (a == 2)
                    Movie_list_pic2.Image = Image.FromStream(stream);
                if (a == 3)
                    Movie_list_pic3.Image = Image.FromStream(stream);

                db.CloseConnection();
                a++;
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            ShowPanel(Seat_panel);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            ShowPanel(Maintance_panel);
        }
        private void Cart_Payment_Click(object sender, EventArgs e)
        {
            Showmenu(Cart_Payment_Panel);
        }
        private void Receipt_Click(object sender, EventArgs e)
        {
            Showmenu(Receipt_Panel);
        }
        private void MainMenu_Click(object sender, EventArgs e)
        {
            ShowPanel(panel2);
            Showmenu(MainMenu_Panel);
        }
        private void Login_Click(object sender, EventArgs e)
        {
            ShowPanel(MainPanel);
        }
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            ShowPanel(register_form);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ShowPanel(Help_panel);
        }
        private void Login_do(object sender, EventArgs e)
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `user_pass` WHERE `username` = @usn and `password` = @pass", db.GetConnection());

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = UserIn.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = PassIn.Text;

            adapter.SelectCommand = command;

            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Success");
                Movie_List.Enabled = true;
                LoginButton.Enabled = false;
                RegisterButton.Enabled = false;
            }
            else
            {
                if (UserIn.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Enter Your Username To Login", "Empty Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (PassIn.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Enter Your Password To Login", "Empty Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Wrong Username Or Password", "Wrong Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if ((UserIn.Text == "Admin") && (PassIn.Text == "123456"))
            {
                Maintance_button.Enabled = true;
            }
        }
        private void Register_go(object sender, EventArgs e)
        {
            if ((CheckUsername()) && (Pass_rs.Text == Pass_rs_rs.Text) && (Pass_rs.Text != ""))
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("INSERT INTO `user_pass`(`Firstname`, `Lastname`, `Phone`, `Username`, `Password`) VALUES (@fn, @ln, @phone, @usn, @pass)", db.GetConnection());

                command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = FN.Text;
                command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = LN.Text;
                command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = PH.Text;
                command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = User_rs.Text;
                command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = Pass_rs.Text;

                db.OpenConnection();

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Success");
                }
                else
                {
                    MessageBox.Show("Error");
                }

                db.CloseConnection();
            }
            else if ((Pass_rs.Text != Pass_rs_rs.Text) && (Pass_rs.Text != ""))
            {
                MessageBox.Show("Password not match");
            }
            else if (!CheckUsername())
            {
                MessageBox.Show("Username already been used");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
        private bool CheckUsername()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `user_pass` WHERE `Username` = @usn", db.GetConnection());

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = User_rs.Text;
            MySqlDataAdapter adapter_CheckUsername = new MySqlDataAdapter();
            adapter_CheckUsername.SelectCommand = command;

            adapter_CheckUsername.Fill(table);
            if (table.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void SeatClick(object sender, EventArgs e)
        {
            int i = 0;
            Button b = (Button)sender;
            if (b.Text != "X")
            {
                if ((b == A1) | (b == A2) | (b == A3) | (b == A4) | (b == A5) | (b == A6) | (b == A7))
                {
                    if (b.Text == "1")
                        seatlist[0] = 1;
                    if (b.Text == "2")
                        seatlist[1] = 1;
                    if (b.Text == "3")
                        seatlist[2] = 1;
                    if (b.Text == "4")
                        seatlist[3] = 1;
                    if (b.Text == "5")
                        seatlist[4] = 1;
                    if (b.Text == "6")
                        seatlist[5] = 1;
                    if (b.Text == "7")
                        seatlist[6] = 1;
                }
                else if ((b == B1) | (b == B2) | (b == B3) | (b == B4) | (b == B5) | (b == B6) | (b == B7))
                {
                    if (b.Text == "1")
                        seatlist[7] = 1;
                    if (b.Text == "2")
                        seatlist[8] = 1;
                    if (b.Text == "3")
                        seatlist[9] = 1;
                    if (b.Text == "4")
                        seatlist[10] = 1;
                    if (b.Text == "5")
                        seatlist[11] = 1;
                    if (b.Text == "6")
                        seatlist[12] = 1;
                    if (b.Text == "7")
                        seatlist[13] = 1;
                }
                else if ((b == C1) | (b == C2) | (b == C3) | (b == C4) | (b == C5) | (b == C6) | (b == C7))
                {
                    if (b.Text == "1")
                        seatlist[14] = 1;
                    if (b.Text == "2")
                        seatlist[15] = 1;
                    if (b.Text == "3")
                        seatlist[16] = 1;
                    if (b.Text == "4")
                        seatlist[17] = 1;
                    if (b.Text == "5")
                        seatlist[18] = 1;
                    if (b.Text == "6")
                        seatlist[19] = 1;
                    if (b.Text == "7")
                        seatlist[20] = 1;
                }
                else if ((b == D1) | (b == D2) | (b == D3) | (b == D4) | (b == D5) | (b == D6) | (b == D7))
                {
                    if (b.Text == "1")
                        seatlist[21] = 1;
                    if (b.Text == "2")
                        seatlist[22] = 1;
                    if (b.Text == "3")
                        seatlist[23] = 1;
                    if (b.Text == "4")
                        seatlist[24] = 1;
                    if (b.Text == "5")
                        seatlist[25] = 1;
                    if (b.Text == "6")
                        seatlist[26] = 1;
                    if (b.Text == "7")
                        seatlist[27] = 1;
                }
                else if ((b == E1) | (b == E2) | (b == E3) | (b == E4) | (b == E5) | (b == E6) | (b == E7))
                {
                    if (b.Text == "1")
                        seatlist[28] = 1;
                    if (b.Text == "2")
                        seatlist[29] = 1;
                    if (b.Text == "3")
                        seatlist[30] = 1;
                    if (b.Text == "4")
                        seatlist[31] = 1;
                    if (b.Text == "5")
                        seatlist[32] = 1;
                    if (b.Text == "6")
                        seatlist[33] = 1;
                    if (b.Text == "7")
                        seatlist[34] = 1;
                }
                else if ((b == F1) | (b == F2) | (b == F3) | (b == F4) | (b == F5) | (b == F6) | (b == F7))
                {
                    if (b.Text == "1")
                        seatlist[35] = 1;
                    if (b.Text == "2")
                        seatlist[36] = 1;
                    if (b.Text == "3")
                        seatlist[37] = 1;
                    if (b.Text == "4")
                        seatlist[38] = 1;
                    if (b.Text == "5")
                        seatlist[39] = 1;
                    if (b.Text == "6")
                        seatlist[40] = 1;
                    if (b.Text == "7")
                        seatlist[41] = 1;
                }
            }
            else
            {
                if ((b == A1) | (b == A2) | (b == A3) | (b == A4) | (b == A5) | (b == A6) | (b == A7))
                {
                    if (b.Text == "1")
                        seatlist[0] = 0;
                    if (b.Text == "2")
                        seatlist[1] = 0;
                    if (b.Text == "3")
                        seatlist[2] = 0;
                    if (b.Text == "4")
                        seatlist[3] = 0;
                    if (b.Text == "5")
                        seatlist[4] = 0;
                    if (b.Text == "6")
                        seatlist[5] = 0;
                    if (b.Text == "7")
                        seatlist[6] = 0;
                }
                else if ((b == B1) | (b == B2) | (b == B3) | (b == B4) | (b == B5) | (b == B6) | (b == B7))
                {
                    if (b.Text == "1")
                        seatlist[7] = 0;
                    if (b.Text == "2")
                        seatlist[8] = 0;
                    if (b.Text == "3")
                        seatlist[9] = 0;
                    if (b.Text == "4")
                        seatlist[10] = 0;
                    if (b.Text == "5")
                        seatlist[11] = 0;
                    if (b.Text == "6")
                        seatlist[12] = 0;
                    if (b.Text == "7")
                        seatlist[13] = 0;
                }
                else if ((b == C1) | (b == C2) | (b == C3) | (b == C4) | (b == C5) | (b == C6) | (b == C7))
                {
                    if (b.Text == "1")
                        seatlist[14] = 0;
                    if (b.Text == "2")
                        seatlist[15] = 0;
                    if (b.Text == "3")
                        seatlist[16] = 0;
                    if (b.Text == "4")
                        seatlist[17] = 0;
                    if (b.Text == "5")
                        seatlist[18] = 0;
                    if (b.Text == "6")
                        seatlist[19] = 0;
                    if (b.Text == "7")
                        seatlist[20] = 0;
                }
                else if ((b == D1) | (b == D2) | (b == D3) | (b == D4) | (b == D5) | (b == D6) | (b == D7))
                {
                    if (b.Text == "1")
                        seatlist[21] = 0;
                    if (b.Text == "2")
                        seatlist[22] = 0;
                    if (b.Text == "3")
                        seatlist[23] = 0;
                    if (b.Text == "4")
                        seatlist[24] = 0;
                    if (b.Text == "5")
                        seatlist[25] = 0;
                    if (b.Text == "6")
                        seatlist[26] = 0;
                    if (b.Text == "7")
                        seatlist[27] = 0;
                }
                else if ((b == E1) | (b == E2) | (b == E3) | (b == E4) | (b == E5) | (b == E6) | (b == E7))
                {
                    if (b.Text == "1")
                        seatlist[28] = 0;
                    if (b.Text == "2")
                        seatlist[29] = 0;
                    if (b.Text == "3")
                        seatlist[30] = 0;
                    if (b.Text == "4")
                        seatlist[31] = 0;
                    if (b.Text == "5")
                        seatlist[32] = 0;
                    if (b.Text == "6")
                        seatlist[33] = 0;
                    if (b.Text == "7")
                        seatlist[34] = 0;
                }
                else if ((b == F1) | (b == F2) | (b == F3) | (b == F4) | (b == F5) | (b == F6) | (b == F7))
                {
                    if (b.Text == "1")
                        seatlist[35] = 0;
                    if (b.Text == "2")
                        seatlist[36] = 0;
                    if (b.Text == "3")
                        seatlist[37] = 0;
                    if (b.Text == "4")
                        seatlist[38] = 0;
                    if (b.Text == "5")
                        seatlist[39] = 0;
                    if (b.Text == "6")
                        seatlist[40] = 0;
                    if (b.Text == "7")
                        seatlist[41] = 0;
                }
            }

            if (b.Text != "X")
            {
                b.Text = "X";
            }
            else if (b.Text == "X")
            {
                if ((b == A1) | (b == B1) | (b == C1) | (b == D1) | (b == E1) | (b == F1))
                    b.Text = "1";
                if ((b == A2) | (b == B2) | (b == C2) | (b == D2) | (b == E2) | (b == F2))
                    b.Text = "2";
                if ((b == A3) | (b == B3) | (b == C3) | (b == D3) | (b == E3) | (b == F3))
                    b.Text = "3";
                if ((b == A4) | (b == B4) | (b == C4) | (b == D4) | (b == E4) | (b == F4))
                    b.Text = "4";
                if ((b == A5) | (b == B5) | (b == C5) | (b == D5) | (b == E5) | (b == F5))
                    b.Text = "5";
                if ((b == A6) | (b == B6) | (b == C6) | (b == D6) | (b == E6) | (b == F6))
                    b.Text = "6";
                if ((b == A7) | (b == B7) | (b == C7) | (b == D7) | (b == E7) | (b == F7))
                    b.Text = "7";
            }
        }
        private void Seat_Check(string Theater)
        {
            DB db = new DB();
            DataSet table = new DataSet();
            List<Button> Buttonlist = new List<Button>
                {
                        A1, A2 , A3, A4 ,A5, A6, A7,
                        B1, B2 , B3, B4 ,B5, B6, B7,
                        C1, C2 , C3, C4 ,C5, C6, C7,
                        D1, D2 , D3, D4 ,D5, D6, D7,
                        E1, E2 , E3, E4 ,E5, E6, E7,
                        F1, F2 , F3, F4 ,F5, F6, F7,
                };
            if (Theater == "seat")
            {
                MySqlCommand Search_command = new MySqlCommand("SELECT Seat_no FROM seat WHERE Status = 'B'", db.GetConnection());
                MySqlDataAdapter Search = new MySqlDataAdapter(Search_command);
                Movie_Selected = 1;
                Search.Fill(table);
            }
            if (Theater == "seat2")
            {
                MySqlCommand Search_command = new MySqlCommand("SELECT Seat_no FROM seat2 WHERE Status = 'B'", db.GetConnection());
                MySqlDataAdapter Search = new MySqlDataAdapter(Search_command);
                Movie_Selected = 2;
                Search.Fill(table);
            }
            if (Theater == "seat3")
            {
                MySqlCommand Search_command = new MySqlCommand("SELECT Seat_no FROM seat3 WHERE Status = 'B'", db.GetConnection());
                MySqlDataAdapter Search = new MySqlDataAdapter(Search_command);
                Movie_Selected = 3;
                Search.Fill(table);
            }
            int rows = table.Tables[0].Rows.Count;
            int i = 0;
            while (i < rows)
            {
                int j = 0;
                String Seat_to_disable;
                int STD = 0;
                Seat_to_disable = table.Tables[0].Rows[i]["Seat_no"].ToString();
                STD = Int32.Parse(Seat_to_disable);

                foreach (Button a in Buttonlist)
                {
                    j += 1;
                    if (j == STD)
                        a.Enabled = false;
                }

                i++;
            }
        }
        private void Confirm_Click(object sender, EventArgs e)
        {
            int a = Movie_Selected;
            byte[] getImg = new byte[0];
            DB db = new DB();
            DataSet da = new DataSet();
            DataSet da_img = new DataSet();
            MySqlDataAdapter adapter_info = new MySqlDataAdapter();

            MySqlCommand Search_command = new MySqlCommand("SELECT `Name`, `Movie_length`, `Language`, `Image` FROM `movie` WHERE id = @AA", db.GetConnection());
            Search_command.Parameters.Add("@AA", MySqlDbType.Int32).Value = a;

            db.OpenConnection();
            
            MySqlDataReader data_rec = Search_command.ExecuteReader();
            
            while (data_rec.Read())
            {
                Confirm_Movie.Text = data_rec.GetValue(0).ToString();
                Confirm_time.Text = " " + data_rec.GetValue(1).ToString();
                Confirm_Lang.Text = data_rec.GetValue(2).ToString();
                Receipt_name.Text = data_rec.GetValue(0).ToString();
                Receipt_time.Text = data_rec.GetValue(1).ToString() +" Mins";
                Receipt_Lang.Text = data_rec.GetValue(2).ToString();
            }
            db.CloseConnection();
            db.OpenConnection();
            adapter_info.SelectCommand = Search_command;
            adapter_info.Fill(da_img);
            foreach (DataRow dr in da_img.Tables[0].Rows)
            {
                getImg = (byte[])dr["Image"];
            }

            byte[] imgData = getImg;
            MemoryStream stream = new MemoryStream(imgData);
            Confirm_pic.Image = Image.FromStream(stream);
            Receipt_pic.Image = Image.FromStream(stream);
            db.CloseConnection();

            if (a == 1)
                Confirm_theater_no.Text = "Theater1";
            if (a == 2)
                Confirm_theater_no.Text = "Theater2";
            if (a == 3)
                Confirm_theater_no.Text = "Theater3";

            if (Seat_show_bigbox.Text == "")
            {
                int V = 0;
                int tempV = 0;
                int money = 0;
                while (V < 42)
                {
                    if (seatlist[V] == 1)
                    {
                        tempV += 1;
                        Seat_show_bigbox.Text += Seat_name[V] + " ";
                        textBox3.Text += Seat_name[V] + " ";
                    }
                    V++;
                }
                Seat_temp.Text = tempV.ToString();

                label25.Text = Movie_Selected.ToString();

                money = tempV * 120;
                Total.Text = money.ToString();
                textBox4.Text = money.ToString();

                DateTime localDate = DateTime.Now;
                button13.Text = localDate.ToString();

                Confirm_button.Enabled = true;
                ShowPanel(Confirm_panel);
            }
        }
        private void Pay_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            int i = 1;
            int h = 0;
            int k = 0;
            int loop7 = 1;
            List<Button> Seat_list_cancel = new List<Button>
            {
                A1 ,A2 ,A3 ,A4 ,A5 ,A6 ,A7 ,
                B1 ,B2 ,B3 ,B4 ,B5 ,B6 ,B7 ,
                C1 ,C2 ,C3 ,C4 ,C5 ,C6 ,C7 ,
                D1 ,D2 ,D3 ,D4 ,D5 ,D6 ,D7 ,
                E1 ,E2 ,E3 ,E4 ,E5 ,E6 ,E7 ,
                F1 ,F2 ,F3 ,F4 ,F5 ,F6 ,F7 ,
            };
            if (sender == Cancel_confirm)
            {
                while (k < 42)
                {
                    seatlist[k] = 0;
                    k++;
                }
                foreach (Button a in Seat_list_cancel)
                {
                    if (a.Text == "X")
                    {
                        a.Text = loop7.ToString();
                    }
                    loop7 += 1;
                    if (loop7 == 8)
                    {
                        loop7 = 1;
                    }
                }
                Seat_show_bigbox.Text = "";
                textBox3.Text = "";
                ShowPanel(movie_panel);
                Cart_Payment.Enabled = false;
                Cart_Payment_Panel.Visible = false;
            }
            else
            {
                while (i < 42)
                {
                    h = seatlist[i - 1];
                    if (h == 1)
                    {
                        if (Theater_show_inconfirm.Text == "Theater 1")
                        {
                            MySqlCommand command = new MySqlCommand("UPDATE `seat` SET `Status`= @STS WHERE `Seat_no`= @ID", db.GetConnection());

                            command.Parameters.Add("@STS", MySqlDbType.VarChar).Value = "B";
                            command.Parameters.Add("@ID", MySqlDbType.Int32).Value = i;
                            db.OpenConnection();
                            command.ExecuteNonQuery();
                            db.CloseConnection();
                        }

                        if (Theater_show_inconfirm.Text == "Theater 2")
                        {
                            MySqlCommand command = new MySqlCommand("UPDATE `seat2` SET `Status`= @STS WHERE `Seat_no`= @ID", db.GetConnection());

                            command.Parameters.Add("@STS", MySqlDbType.VarChar).Value = "B";
                            command.Parameters.Add("@ID", MySqlDbType.Int32).Value = i;
                            db.OpenConnection();
                            command.ExecuteNonQuery();
                            db.CloseConnection();
                        }

                        if (Theater_show_inconfirm.Text == "Theater 3")
                        {
                            MySqlCommand command = new MySqlCommand("UPDATE `seat3` SET `Status`= @STS WHERE `Seat_no`= @ID", db.GetConnection());

                            command.Parameters.Add("@STS", MySqlDbType.VarChar).Value = "B";
                            command.Parameters.Add("@ID", MySqlDbType.Int32).Value = i;
                            db.OpenConnection();
                            command.ExecuteNonQuery();
                            db.CloseConnection();
                        }
                    }
                    i++;
                }
                ShowPanel(Print_Panel_main);
                Receipt_Panel.Visible = true;
                Receipt.Enabled = true;
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Filter = "Choose Image (*.JPG;*.PNG;)|*.jpg;*.png";
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                Maintance_pic.Image = Image.FromFile(openfile.FileName);
            }
        }
        private void Save_Click(object sender, EventArgs e)
        {
            int i = 0;
            DB db = new DB();
            MemoryStream ms = new MemoryStream();
            Maintance_pic.Image.Save(ms, Maintance_pic.Image.RawFormat);
            byte[] img = ms.ToArray();
            int time_edit1 = Time_edit[0];
            int time_edit2 = Time_edit[1];
            int time_edit3 = Time_edit[2];
            while (i < 43)
            {
                if (Slot_edit == 1)
                {
                    MySqlCommand command1 = new MySqlCommand("UPDATE `seat` SET `Status`= @STS WHERE `Seat_no`= @ID", db.GetConnection());

                    command1.Parameters.Add("@STS", MySqlDbType.VarChar).Value = "A";
                    command1.Parameters.Add("@ID", MySqlDbType.Int32).Value = i;
                    db.OpenConnection();
                    command1.ExecuteNonQuery();
                    db.CloseConnection();
                }
                if (Slot_edit == 2)
                {
                    MySqlCommand command1 = new MySqlCommand("UPDATE `seat2` SET `Status`= @STS WHERE `Seat_no`= @ID", db.GetConnection());

                    command1.Parameters.Add("@STS", MySqlDbType.VarChar).Value = "A";
                    command1.Parameters.Add("@ID", MySqlDbType.Int32).Value = i;
                    db.OpenConnection();
                    command1.ExecuteNonQuery();
                    db.CloseConnection();
                }
                if (Slot_edit == 3)
                {
                    MySqlCommand command1 = new MySqlCommand("UPDATE `seat3` SET `Status`= @STS WHERE `Seat_no`= @ID", db.GetConnection());

                    command1.Parameters.Add("@STS", MySqlDbType.VarChar).Value = "A";
                    command1.Parameters.Add("@ID", MySqlDbType.Int32).Value = i;
                    db.OpenConnection();
                    command1.ExecuteNonQuery();
                    db.CloseConnection();
                }
                i++;
            }
            MySqlCommand max_command = new MySqlCommand("SET GLOBAL max_allowed_packet=1024*1024*1024", db.GetConnection());
            MySqlCommand command = new MySqlCommand(" UPDATE `movie` SET `Name`= @NAME ,`Movie_length`= @TIME ,`Language`= @LANG ,`Time1`= @T1,`Time2`= @T2 ,`Time3`= @T3,`Image`= @IMG WHERE `id`= @ID", db.GetConnection());
            command.Parameters.Add("@NAME", MySqlDbType.VarChar).Value = Movie_to_edit.Text;
            command.Parameters.Add("@TIME", MySqlDbType.Int32).Value = Duration_edit.Text;
            command.Parameters.Add("@LANG", MySqlDbType.VarChar).Value = Lang_to_edit.Text;
            command.Parameters.Add("@T1", MySqlDbType.Int32).Value = time_edit1;
            command.Parameters.Add("@T2", MySqlDbType.Int32).Value = time_edit2;
            command.Parameters.Add("@T3", MySqlDbType.Int32).Value = time_edit3;
            command.Parameters.Add("@IMG", MySqlDbType.MediumBlob).Value = img;
            command.Parameters.Add("@ID", MySqlDbType.Int32).Value = Slot_edit;

            db.OpenConnection();
            max_command.ExecuteNonQuery();
            command.ExecuteNonQuery();
            db.CloseConnection();

            Duration_edit.Text = "";
            Lang_to_edit.Text = "";
            Movie_to_edit.Text = "";
        }
        private void SwapButton(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if ((b.Text != "X") && (b.Text != "O"))
            {
                if (sender == Time1)
                {
                    Time1.Text = "O";
                    Time_edit[0] = 1;
                }
                if (sender == Time2)
                {
                    Time2.Text = "O";
                    Time_edit[1] = 1;
                }
                if (sender == Time3)
                {
                    Time3.Text = "O";
                    Time_edit[2] = 1;
                }
                if (sender == Slot_1)
                {
                    b.Text = "X";
                    Slot_2.Text = "2";
                    Slot_3.Text = "3";
                    Slot_edit = 1;
                }
                if (sender == Slot_2)
                {
                    b.Text = "X";
                    Slot_1.Text = "1";
                    Slot_3.Text = "3";
                    Slot_edit = 2;
                }
                if (sender == Slot_3)
                {
                    b.Text = "X";
                    Slot_1.Text = "1";
                    Slot_2.Text = "2";
                    Slot_edit = 3;
                }
            }
            else if (b.Text == "O")
            {
                if (sender == Time1)
                {
                    Time1.Text = "Select";
                    Time_edit[0] = 0;
                }
                if (sender == Time2)
                {
                    Time2.Text = "Select";
                    Time_edit[1] = 0;
                }
                if (sender == Time3)
                {
                    Time3.Text = "Select";
                    Time_edit[2] = 0;
                }
            }
        }
        private void Print_Click(object sender, EventArgs e)
        {
            Print_recipt(this.Print_Panel);
        }
        public void Print_recipt(Panel pnl)
        {
            PrinterSettings ps = new PrinterSettings();
            PrintDoc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("custom", 730, 285);
            Print_Panel = pnl;
            GetPrintArea(pnl);
            PrintPreview.Document = PrintDoc;
            PrintDoc.PrintPage += new PrintPageEventHandler(PrintDoc_Printpage);
            PrintPreview.ShowDialog();
        }
        public void PrintDoc_Printpage(object sender,PrintPageEventArgs e)
        {
            Rectangle PageArea = e.PageBounds;
            e.Graphics.DrawImage(memory_img, 0, 0);
        }
        public void GetPrintArea(Panel pnl)
        {
            memory_img = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(memory_img, new Rectangle(0,0,pnl.Width,pnl.Height));
        }
        private void PH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        private void FN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        private void Lang_to_edit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        private void Duration_edit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}