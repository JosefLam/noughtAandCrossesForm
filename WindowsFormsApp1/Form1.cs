using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        const string CROSS = "X";
        const string NOUGHT = "O";
        string userMK = CROSS;
        string CPU = NOUGHT;
        Button[,] grid;
        public Form1()
        {
            InitializeComponent();
            grid = new Button[,] { { btn00, btn10, btn20 },
                                   { btn01, btn11, btn21 },
                                   { btn02 ,btn12 ,btn22 } };
            wipe();
        }

        Button resetbtn = new Button;
        public void resetbtn_click
        {

        }
        
        public void button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int x_coord = int.Parse(btn.Name[3].ToString());
            int y_coord = int.Parse(btn.Name[4].ToString());
            if (btn.Text == "")
            {
                btn.Text = userMK;  //places marker
                lineCheck(userMK);    //check for win
                    // switches turn
            }
            //MessageBox.Show(x_coord.ToString() + y_coord.ToString());
        }
        private void lineCheck(string mark)    //probs pass player or maker as parameter
        {
            bool win = false;
            for (int i =0; i <3; i++)
            {   //check verticle lines
                if (grid[i,0].Text == mark & grid[i, 1].Text == mark & grid [i, 2].Text == mark)
                {
                    win = true;
                }
            }
            for (int j = 0; j < 3; j++)
            {   //check horrizontal lines
                if (grid[0, j].Text == mark & grid[1, j].Text == mark & grid[2, j].Text == mark)
                {
                    win = true;
                }
            }
            //check diagonial line for / gradient
            if (grid[0, 0].Text == mark & grid[1, 1].Text == mark & grid[2, 2].Text == mark)
            {
                win = true;
            }
            //check diagonial line for \ gradient
            if (grid[0, 2].Text == mark & grid[1, 1].Text == mark & grid[2, 0].Text == mark)
            {
                win = true;
            }

            if (win)
            {
                MessageBox.Show(mark + " has won");
                wipe();
            }


        }
        private void wipe()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    grid[i, j].Text = "";
                }
            }
        }
    }
}
