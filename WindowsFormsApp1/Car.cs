using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsFormsApp1
{
    class Car
    {
		private int carX = 0;
		private int carY = 0;
		private int a = 0;
		private int b = 0;
		private int c = 0;
		private int d = 0;
		private int x = 0;
		private int y = 0;
		private int i = 0;
		private int moveLength = 5;
		private String s1;
		private String s2;
		private bool change1 = false;
		private bool change2 = false;
		private int begin;
		private int end;
		Light l;
        Road road;
        public  Hashtable map = new Hashtable();

		public Car(int begin, int end, Light l)
		{
			this.l = l;
			this.begin = begin;
			this.end = end;
			road = new Road(begin, end);
			setCarTimer();
			carX = road.RoadList[0].X;
			carY = road.RoadList[0].Y;
            a = road.RoadList[0].X;
            b = road.RoadList[1].X;
            c = road.RoadList[0].Y;
            d = road.RoadList[1].Y;
            x = b - a;
            y = d - c;
        }

        //hash存入需要等红灯的路口
        public Hashtable saveHash()
        {
            map.Add(road.B.X.ToString() + road.B.Y.ToString(), l.getl1);// B
            map.Add(road.F.X.ToString() + road.F.Y.ToString(), l.getl2);// F
            map.Add(road.M.X.ToString() + road.M.Y.ToString(), l.getl1);// M
            map.Add(road.K.X.ToString() + road.K.Y.ToString(), l.getl2);// K
            map.Add(road.P.X.ToString() + road.P.Y.ToString(), l.getl5);// P
            map.Add(road.R.X.ToString() + road.R.Y.ToString(), l.getl6);// R
            map.Add(road.Y.X.ToString() + road.Y.Y.ToString(), l.getl5);// Y
            map.Add(road.W.X.ToString() + road.W.Y.ToString(), l.getl6);// W
            return map;
        }

       
        public  void move()
		{
			moveLength = 15;
			if (carX == road.RoadList[i + 1].X
					&& carY == road.RoadList[i + 1].Y
					&& i <= road.RoadList.Count() - 3)
			{
				s1 = carX.ToString() + carY.ToString();
				s2 = road.RoadList[i + 2].X.ToString()
						+ road.RoadList[i + 2].Y.ToString();

				if (!judgeInflexion())
				{ //判断是否到达掉头的拐点,若不是拐点,再判断红绿灯
					if (judgeLight(s1) == false)
					{//判断红绿灯
						moveLength = 0;
					}
				}

				i++;
				a = road.RoadList[i].X;
				b = road.RoadList[i+1].X;
				c = road.RoadList[i].Y;
				d = road.RoadList[i+1].Y;
				x = b - a;
				y = d - c;
			}
			//到达终点的处理
			if (carX - road.RoadList[i + 1].X == 0
					&& carY - road.RoadList[i + 1].Y == 0)
			{
				carX = -10;
				carY = -10;
				road.RoadList.Clear();
				return;
			}
			if (moveLength == 0)
			{
				i--;
			}
			else
			{
				if (!judgeInflexionClash())
				{ //若是否是拐点以及是否碰撞
					differentDirection();
				}
			}
		}
		//超不同方向走,在走之前判断前一个车的状态
		public void differentDirection()
		{
			if (y > 0)
			{
				//走之前先判断该方向的前一个车,若前一个车的状态是停止,则停止;否则向前走
				if (!Document.prior.ContainsKey(carX.ToString()
						+ (carY+moveLength).ToString()))
				{
					carX = a;
					carY += moveLength;
				}


			}
			else if (y < 0)
			{
				if (!Document.prior.ContainsKey(carX.ToString()
						+ (carY - moveLength).ToString()))
				{
					carX = a;
					carY -= moveLength;

				}
			}
			else if (x < 0)
			{
				if (!Document.prior.ContainsKey((carX-moveLength).ToString()
						+ carY.ToString()))
				{
					carX -= moveLength;
					carY = c;

				}
			}
			else if (x > 0)
			{
				if (!Document.prior.ContainsKey((carX + moveLength).ToString()
						+ carY.ToString()))
				{
					carX += moveLength;
					carY = c;
				}

			}
		}
		// 判断红绿灯
		public bool judgeLight(String a)
		{

			if (map.ContainsKey(a))
			{
				if ((int)map[a] == 0)
				{
					return false;
				}
				else
					return true;
			}

			return true;
		}

		// 判断拐点是否碰撞
		public bool judgeInflexionClash()
		{
			if (carX == 1250 && carY == 205)
			{
				if (Document.prior.ContainsKey("1265190"))
				{

					return true;
				}

			}
			else if (carX == 350 && carY == 220)
			{
				if (Document.prior.ContainsKey("335235"))
				{

					return true;
				}
			}
			return false;
		}

		// 判断是否是掉头的拐点，若是，则不判断红绿灯
		public bool judgeInflexion()
		{
			if (s1.Equals("1250235") && s2.Equals("1250190"))
				change1 = true;
			else
				change1 = false;
			if (s1.Equals("350190") && s2.Equals("350235"))
				change2 = true;
			else
				change2 = false;
			return change1 || change2;

		}

		// 车的定时器
		public void setCarTimer()
		{
			Timer t1 = new Timer();
			// 在1秒之后执行,每隔1s执行一次
			t1.Enabled = true;
			t1.Interval = 1000; //执行间隔时间,单位为毫秒; 这里实际间隔为10分钟  
			t1.Start();
			t1.Elapsed += new System.Timers.ElapsedEventHandler(run);
		}


		public void run(object source, ElapsedEventArgs e)
		{
			map.Clear();
			map = saveHash();
			if (carX != -10 && carY != -10)
			{
                 move();
			}
		}
	   
        public int getcarX()
        {
            return carX;
        }

        public int getcarY()
        {
            return carY;
        }
		public int getBegin()
		{
			return begin;
		}
		public int getEnd()
		{
			return end;
		}
	}
}
