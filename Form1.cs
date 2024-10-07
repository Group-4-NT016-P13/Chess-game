using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using logic;
namespace ChessGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeChessBoard();
        }

        private void InitializeChessBoard()
        {
            int size = 8; // Kích thước bàn cờ 8x8
            tableLayoutPanel1.RowCount = size;
            tableLayoutPanel1.ColumnCount = size;

            // Tạo ô bàn cờ
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    // Tạo một Panel cho mỗi ô
                    Panel panel = new Panel();
                    panel.Dock = DockStyle.Fill;

                    // Thay đổi màu sắc ô
                    if ((i + j) % 2 == 0)
                        panel.BackColor = Color.LightGoldenrodYellow;
                    else
                        panel.BackColor = Color.Purple;

                    tableLayoutPanel1.Controls.Add(panel, j, i);
                }
            }
        }
       
            private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
