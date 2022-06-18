using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Threading;
using Image = System.Drawing.Image;

namespace WindowsFormsApp1
{
    
    public class Draw
    {
        PictureBox p;
        Graphics g;
        Document z;
        public Draw(PictureBox x_,int L23r,int L23g,int L67g,int tsn,int tew)
        {
            //bitmap相当于一个画布，g相当于一个画笔，在bitmap上作画。
            p = x_;
            Bitmap bitmap = new Bitmap(p.Width,p.Height);
            g = Graphics.FromImage((Image)bitmap);
            g.Clear(Color.White);
            p.Image = bitmap;
            z = new Document(L23r,L23g,L67g,tsn,tew);
        }
       
        public void init()
        {
            g.Clear(Color.White);
            //drawCar(z.carlist);
            drawLine();
            drawblocks();
            drawLight(z.t);
            drawCar(z.carlist);
            p.Refresh();

        }
        public void drawCar(ArrayList carlist)
        {
            Document.prior.Clear();
            Pen blackPen;
            int a = carlist.Count;
            for (int i = 0;i<a;i++)
            {
                while(carlist[i] == null&& i<a)
                {
                    i++;
                }
                if(i == a)
                {
                    return;
                }
                int roadA = ((Car)carlist[i]).getBegin();
                //如果是南北路口产生的车，设置为蓝色；否则为绿色
                if (roadA == 1 || roadA == 3 || roadA == 4 || roadA == 6)
                {
                    blackPen = new Pen(Color.Blue, 3);
                }
                else
                {
                   blackPen = new Pen(Color.Gray, 3);
                }
                g.DrawRectangle(blackPen, ((Car)carlist[i]).getcarX(), ((Car)carlist[i]).getcarY(),10,8);
                if (((Car)carlist[i]).getcarX() == -10 && ((Car)carlist[i]).getcarY() == -10)
                {
                    carlist.Remove(i);
                    a = a - 1;
                }
                // 每一个车达到终点，则从车的列表中remove
               
                    int X = ((Car)carlist[i]).getcarX();
                    int Y = ((Car)carlist[i]).getcarY();
                    String x = String.Concat(X, Y);
                if (Document.prior.ContainsKey(x))
                {
                    carlist.Remove(i);
                    a = a - 1;
                }
                else
                {
                    Document.prior.Add(x, 1);
                }
            }
        }
        public void drawLine()
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);

            // Create coordinates of points that define line.


            // Draw line to screen.
            g.DrawLine(blackPen, 50, 175, 275, 175);
            g.DrawLine(blackPen, 275, 100, 275, 175);
            g.DrawLine(blackPen, 50, 250, 275, 250);
            g.DrawLine(blackPen, 275, 250, 275, 550);

            g.DrawLine(blackPen, 350, 100, 350, 175);
            g.DrawLine(blackPen, 350, 250, 350, 550);
            g.DrawLine(blackPen, 350, 250, 1250, 250);
            g.DrawLine(blackPen, 350, 175, 1250, 175);

            g.DrawLine(blackPen, 1250, 100, 1250, 175);
            g.DrawLine(blackPen, 1250, 250, 1250, 550);

            g.DrawLine(blackPen, 1325, 100, 1325, 175);
            g.DrawLine(blackPen, 1325, 175, 1550, 175);
            g.DrawLine(blackPen, 1325, 250, 1550, 250);
            g.DrawLine(blackPen, 1325, 250, 1325, 550);
        }
        public void drawLight(Light light)
        {
            SolidBrush brush;
            if (light.getl1 == 1)
            {
                brush = new SolidBrush(Color.Green);
                g.FillPie(brush, 275, 165, 8, 8, 0, 360);//L1
                g.FillPie(brush, 342, 252, 8, 8, 0, 360);//L4
                brush = new SolidBrush(Color.Red);
                g.FillPie(brush, 352, 176, 8, 8, 0, 360);//L2
                g.FillPie(brush, 265, 242, 8, 8, 0, 360);//L3
            }
            else
            {
                brush = new SolidBrush(Color.Red);
                g.FillPie(brush, 275, 165, 8, 8, 0, 360);//L1
                g.FillPie(brush, 342, 252, 8, 8, 0, 360);//L4
                brush = new SolidBrush(Color.Green);
                g.FillPie(brush, 352, 176, 8, 8, 0, 360);//L2
                g.FillPie(brush, 265, 242, 8, 8, 0, 360);//L3
            }
            if (light.getl5 == 1)
            {
                brush = new SolidBrush(Color.Green);
                g.FillPie(brush, 1250, 165, 8, 8, 0, 360);//L5
                g.FillPie(brush, 1317, 252, 8, 8, 0, 360);//L7
                brush = new SolidBrush(Color.Red);
                g.FillPie(brush, 1327, 176, 8, 8, 0, 360);//L8
                g.FillPie(brush, 1240, 242, 8, 8, 0, 360);//L9
            }
            else
            {
                brush = new SolidBrush(Color.Red);
                g.FillPie(brush, 1250, 165, 8, 8, 0, 360);//L5
                g.FillPie(brush, 1317, 252, 8, 8, 0, 360);//L7
                brush = new SolidBrush(Color.Green);
                g.FillPie(brush, 1327, 176, 8, 8, 0, 360);//L8
                g.FillPie(brush, 1240, 242, 8, 8, 0, 360);//L9
            }
            return;
        }
        public void drawblocks()
        {
            SolidBrush brush2 = new SolidBrush(Color.Gray);
            g.FillRectangle(brush2, 60, 210, 215, 5);
            g.FillRectangle(brush2, 360, 210, 880, 5);
            g.FillRectangle(brush2, 1325, 210, 215, 5);
        }
    }


    

}
