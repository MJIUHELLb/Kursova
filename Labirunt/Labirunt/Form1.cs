using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Labirunt
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        public int[ , ]  MASIV = new int[20,20];
        public string stan = "wall";
        public string risovat = "Намалюйте лабіринт";
        public int krdnPochatkuX = 1, krdnPochatkuY = 1, krdnExitX = 15, krdnExitY = 12, ni = 0, mi= 0;
        public string[] str = new string[20];
              
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            panel2.Visible = false;
            panel1.Visible = true;
            label3.Visible = true;
            panel3.Visible = true;
            Graphics gr = panel1.CreateGraphics();
            Pen p = new Pen(Color.Black);
            for (int i = 0; i < 17; i++)
                for (int j = 1; j < 16;j++ )
                {
                    MASIV[i, j] = 0; //ROZPUSUEM MASIV
                }
                //Лінії      
                for (int i = 1; i < 17; i++)
                {
                    gr.DrawLine(p, i * 30, 0, i * 30, 420);
                }
            for (int i = 1; i < 14; i++)
            {
                gr.DrawLine(p, 0, i * 30, 511, i * 30);
            }
            //стіни
            for (int i = 0; i < 17; i++)
            {
                //ctiHu HA 1
                MASIV[i, 0] = 1;
                MASIV[i, 13] = 1;
                gr.DrawImage(imageList1.Images[0], i * 30+1, 1, 29, 29);
                gr.DrawImage(imageList1.Images[0], i * 30+1, 391, 29, 29);
            }
            
            for (int i = 1; i < 13; i++)
            {
                //CTINU NA 1
                MASIV[0, i] = 1;
                MASIV[16, i] = 1;
                gr.DrawImage(imageList1.Images[0], 1, i * 30+1, 29, 29);
                gr.DrawImage(imageList1.Images[0], 481, i * 30+1, 29, 29);
            }
            // Початок\Кінець
            gr.DrawImage(imageList1.Images[2], 1, 31, 29, 29);                      
            gr.DrawImage(imageList1.Images[3], 481, 361, 29, 29);             
        }

        //KOORDUNATU
        public int KX;
        public int KY;
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            rectangleShape1.Visible = true;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            rectangleShape1.Visible = false;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            rectangleShape2.Visible = true;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            rectangleShape2.Visible = false;
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            XtaY to4ku = new XtaY();
            to4ku.Klitunka(KX,KY);
            label4.Text = "X: " + (KX);
            label5.Text = "Y: " + (KY);
            Graphics gr = panel1.CreateGraphics();

            if ((to4ku.x > 30) && (to4ku.x < 481) && (to4ku.y > 30) && (to4ku.y < 390)/*&&(to4ku.nx!=krdnPochatkuX)&&
                (to4ku.ny!=krdnPochatkuY)&&(to4ku.nx!=krdnExitX)&&(to4ku.ny!=krdnExitY)*/)
            {
                if (stan == "wall")
                {
                    gr.DrawImage(imageList1.Images[1], to4ku.x, to4ku.y, 29, 29);
                    MASIV[to4ku.nx, to4ku.ny] = 1;
                }
                if (stan == "start")
                {
                    MASIV[to4ku.nx, to4ku.ny] = 2;
                    gr.DrawImage(imageList1.Images[2], to4ku.x, to4ku.y, 29, 29);
                    if (ni == 1)
                    {
                        gr.DrawImage(imageList1.Images[4], krdnPochatkuX * 30 + 1, krdnPochatkuY * 30 + 1, 29, 29);
                        MASIV[krdnPochatkuX, krdnPochatkuY] = 0;
                    }
                    if (ni == 0)
                    {
                        gr.DrawImage(imageList1.Images[0], 1, 31, 29, 29);
                        MASIV[krdnPochatkuX, krdnPochatkuY] = 1;
                        ni = 1;
                    }                    
                    krdnPochatkuX = to4ku.nx;
                    krdnPochatkuY = to4ku.ny;                   

                }
                if (stan == "exit")
                {
                    MASIV[to4ku.nx, to4ku.ny] = 3;
                    gr.DrawImage(imageList1.Images[3], to4ku.x, to4ku.y, 29, 29);
                    if (mi == 1)
                    {
                        gr.DrawImage(imageList1.Images[4], krdnExitX * 30 + 1, krdnExitY * 30 + 1, 29, 29);
                        MASIV[krdnExitX, krdnExitY] = 0;
                    }
                    if (mi == 0)
                    {
                        gr.DrawImage(imageList1.Images[0], 481, 361, 29, 29);
                        MASIV[krdnExitX, krdnExitY] = 1;
                        mi = 1;
                    }
                    
                    krdnExitX = to4ku.nx; 
                    krdnExitY = to4ku.ny; 
                }
                if (stan == "way")
                {
                    MASIV[to4ku.nx, to4ku.ny] = 0;
                    gr.DrawImage(imageList1.Images[4], to4ku.x, to4ku.y, 29, 29); 
                }
                //label4.Text = "X: " + (to4ku.nx);
                //label5.Text = "Y: " + (to4ku.ny);
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            int CX = e.X;
            int CY = e.Y;
            label5.Visible = true;
            label4.Visible = true;
            label4.Text = "X: " + ((int)(CX/30));
            label5.Text = "Y: " + ((int)(CY/30));
            KX = CX;
            KY = CY;      
        }              

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            stan = "wall";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            stan = "start";
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            stan = "exit";
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            label3.Text = "Звичайна непрохідна стіна";
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            label3.Text = "Вкажіть звітки програмі почати шлях";
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            label3.Text = "Вкажіть, де вихід із лабіринту";
        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            label3.Text = "Межі, за які не можна вийти";
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            label3.Text = risovat;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            stan = "exit";
        }

        private void label6_Click(object sender, EventArgs e)
        {
            stan = "wall";
        }

        private void label9_Click(object sender, EventArgs e)
        {
            stan = "way";
        }

        private void label7_Click(object sender, EventArgs e)
        {
            stan = "start";
        }

        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            label3.Text = "Там, де можна пройти";
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            label3.Text = risovat;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            stan = "way";
        }

        private void відкритиМатрицюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            RECORD r = new RECORD();
            r.COPYMASIV(MASIV);            
            for (int j = 0; j < 14; j++)
            form2.listBox1.Items.Add(r.mas[j]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
//MAIN BUTTOON
            Graphics gr = panel1.CreateGraphics();
            FindTheWay FTW = new FindTheWay();
            FTW.CopyMas(MASIV);            
            FTW.Find(krdnPochatkuX, krdnPochatkuY, krdnExitX, krdnExitY);
            if (mi==0)
            for (int i = 0; i < FTW.n; i++)
            {
                gr.DrawImage(imageList1.Images[5], FTW.WayX[i]*30+1 , FTW.WayY[i]*30+1, 29, 29); 
            }
            if (mi == 0) gr.DrawImage(imageList1.Images[5], 15* 30 + 1, 12 * 30 + 1, 29, 29);             
        }      

              
    }
    class XtaY
    {
        public int x,y,nx,ny;
        private int[] masx = {1,30,60,90,120,150,180,210,240,270,300,330,360,390,420,450,480};
        private int[] masy = {1,30,60,90,120,150,180,210,240,270,300,330,360,390};
        public void Klitunka(int fx, int fy)
        {
            for (int j = 0; j < 17; j++)
            {
                if (fx < masx[j]) { x = masx[j - 1] + 1; nx = j - 1 ; break; }
            }
            for (int j = 0; j < 14; j++) 
            {
                if (fy < masy[j]) { y = masy[j - 1] + 1; ny = j - 1; break; }
            }
        }
    }
    class RECORD
    {
        public string[] mas = new string[20];
        public void COPYMASIV(int[,] M)
        {
            for (int i = 0; i < 14; i++)
              for (int j = 0; j < 17; j++)
                 mas[i] += "  " + M[j, i].ToString();                             
            
        }        
    }
    class FindTheWay
    {
        
        public int[] WayX = new int[250];
        public int[] WayY = new int[250];
        public int[] WayMainX = new int[250];
        public int[] WayMainY = new int[250];
        public int[] CrossRoads = new int[250];
        public int n = 0;
        int k = 0;

        public int[,] MASIV = new int[18,15];
        public void CopyMas(int[,] m)
        {
            for (int i = 0; i < 17; i++)
                for (int j = 0; j < 14; j++)  MASIV[i,j]=m[i,j];
        }
        public void Find(int x, int y ,int xk,int yk)
        {
            int i = x, j = y; int z = 0;
            WayX[n] = i; WayY[n] = j;
            for (int g = 0; g < 250; g++) CrossRoads[g] = 0;
           
            while ((i != xk) || (j != yk))
            {                               
                k = 0;
                z = 0;
                if (MASIV[i, j - 1] != 1)
                {
                    j = j - 1;
                    z++;
                    k++;
                    CrossRoads[k]++;
                }
                if (MASIV[i + 1, j] != 1 )
                {
                    if (z == 0)  i++; 
                    z++;
                    if (z == 1)   k++; 
                    CrossRoads[k]++; 
                }
                if (MASIV[i, j + 1] != 1) 
                { 
                    if (z == 0) j++; 
                    z++; 
                    if (z == 1) k++; 
                    CrossRoads[k]++; }
                if (MASIV[i - 1, j] != 1)
                {
                    if (z == 0) i = i - 1; 
                    z++;                             
                    if (z == 1) k++; 
                    CrossRoads[k]++; 
                }
                 if ((MASIV[i, j - 1] == 1) && (MASIV[i + 1, j] == 1) && (MASIV[i, j + 1] == 1) && (MASIV[i - 1, j] == 1) && n==0) break;

                n++;
                WayX[n] = i; WayY[n] = j;
                MASIV[i, j] = 1;
                if ((MASIV[i, j - 1] == 1) &&
                    (MASIV[i + 1, j] == 1) &&
                    (MASIV[i, j + 1] == 1) &&
                    (MASIV[i - 1, j] == 1))
                {
                    
                    while (CrossRoads[n] < 2)
                    {
                        n = n - 1;
                        i = WayX[n]; j = WayY[n];
                        MASIV[i, j] = 0;
                    }
                    
                }
                                       
            }             

            if ((i != xk) && (j != yk)) NoWay();
        }
        public void NoWay()
        {
            Form1 form1 = new Form1();            
            form1.label3.Text = " Виходу не існує!!!";            
        }
    }    

}
