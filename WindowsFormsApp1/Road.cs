using System;
using System.Collections.Generic;
using System.Drawing;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Road
    {
		public Point A = new Point(290, 100);
		public Point B = new Point(290, 175);
		public Point D = new Point(50, 190);
		public Point H = new Point(290, 550);
		public Point E = new Point(50, 235);
		public Point F = new Point(275, 235);
		public Point T = new Point(1265, 550);
		public Point O = new Point(1265, 100);
		public Point R = new Point(1250, 235);
		public Point a = new Point(1550, 190);
		public Point b = new Point(1550, 235);
		public Point W = new Point(1325, 190);
		public Point U = new Point(1310, 100);
		public Point Q = new Point(1250, 190);
		public Point K = new Point(350, 190);
		public Point G = new Point(290, 250);
		public Point J = new Point(335, 175);
		public Point I = new Point(335, 100);
		public Point N = new Point(335, 550);
		public Point M = new Point(335, 250);
		public Point L = new Point(350, 235);
		public Point V = new Point(1310, 175);
		public Point R1 = new Point(290, 190);
		public Point R2 = new Point(290, 235);
		public Point R3 = new Point(335, 235);
		public Point R6 = new Point(1265, 235);
		public Point R8 = new Point(1310, 190);
		public Point Z = new Point(1310, 550);
		public Point Y = new Point(1310, 250);
		public Point R7 = new Point(1310, 235);
		public Point R4 = new Point(335, 190);
		public Point R5 = new Point(1265, 190);
		public Point P = new Point(1265, 175);
		public Point C = new Point(275, 190);

		//public ArrayList RoadList = new ArrayList();
		public  List<Point> RoadList = new List<Point>();

		public Road(int begin, int end)
		{
			choose(begin, end);
		}
		
		//根据起始点和终点，产生一辆车要走的路。
		public List<Point> choose(int begin, int end)
		{
			//BSN-EHW
			//对于拐弯的路，记录起点，转折点，终点
			if (begin == 1 && end == 2)
			{
				RoadList.Add(A); // A
				RoadList.Add(R1); // R1
				RoadList.Add(D); // D
			}
			//BSN-BSS
			//对于直行的车辆，记录起点，在红绿灯口出，终点
			else if (begin == 1 && end == 3)
			{
				RoadList.Add(A); //A
				RoadList.Add(B); //B
				RoadList.Add(H); //H
			}
			//BSN-TBS
			else if (begin == 1 && end == 4)
			{
				RoadList.Add(A); //A
				RoadList.Add(R1); //R1
				RoadList.Add(D); //D
				RoadList.Add(E); //E
				RoadList.Add(F); //F
				RoadList.Add(R6); //R6
				RoadList.Add(T); //T		
			}
			//BSN-EHE
			else if (begin == 1 && end == 5)
			{
				RoadList.Add(A); //A
				RoadList.Add(R1); //R1
				RoadList.Add(D); //D
				RoadList.Add(E); //E
				RoadList.Add(F); //F
				RoadList.Add(R); //R
				RoadList.Add(b); //b
			}
			//BSN-TBN
			else if (begin == 1 && end == 6)
			{
				RoadList.Add(A); //A
				RoadList.Add(R1); //R1
				RoadList.Add(D); //D
				RoadList.Add(E); //E
				RoadList.Add(F); //F
				RoadList.Add(R); //R
				RoadList.Add(b); //b				
				RoadList.Add(a); //a
				RoadList.Add(W); //W
				RoadList.Add(R8); //R8
				RoadList.Add(U); //U
			}
			//EHW-BSN
			//对于掉头的车，要记录拐点的坐标
			else if (begin == 2 && end == 1)
			{
				RoadList.Add(E); //E
				RoadList.Add(F); //F
				RoadList.Add(R); //R	
				RoadList.Add(Q); //Q
				RoadList.Add(R4); //R4
				RoadList.Add(I); //I
			}
			//EHW-BSS
			else if (begin == 2 && end == 3)
			{
				RoadList.Add(E); //E
				RoadList.Add(R2); //R2
				RoadList.Add(H); //H
			}
			//EHW-TBS
			else if (begin == 2 && end == 4)
			{
				RoadList.Add(E); //E
				RoadList.Add(F); //F
				RoadList.Add(R6); //R6
				RoadList.Add(T); //T
			}
			//EHW-EHE
			else if (begin == 2 && end == 5)
			{
				RoadList.Add(E); //E
				RoadList.Add(F); //F
				RoadList.Add(R); //R
				RoadList.Add(b); //b
			}
			//EHW-TBN
			else if (begin == 2 && end == 6)
			{
				RoadList.Add(E); //E
				RoadList.Add(F); //F
				RoadList.Add(R); //R
				RoadList.Add(b); //b		
				RoadList.Add(a); //a		
				RoadList.Add(W); //W
				RoadList.Add(R8); //R8
				RoadList.Add(U); //U
			}
			//BSS-BSN
			else if (begin == 3 && end == 1)
			{
				RoadList.Add(N); //N
				RoadList.Add(M); //M
				RoadList.Add(I); //I
			}
			//BSS-EHW
			else if (begin == 3 && end == 2)
			{
				RoadList.Add(N); //N
				RoadList.Add(R3); //R3
				RoadList.Add(R); //R
				RoadList.Add(Q); //Q
				RoadList.Add(K); //K
				RoadList.Add(D); //D
			}
			//BSS-TBS
			else if (begin == 3 && end == 4)
			{
				RoadList.Add(N); //N
				RoadList.Add(R3); //R3
				RoadList.Add(R6); //R6
				RoadList.Add(T); //T
			}
			//BSS-EHE
			else if (begin == 3 && end == 5)
			{
				RoadList.Add(N); //N
				RoadList.Add(R3); //R3
				RoadList.Add(R); //R
				RoadList.Add(b); //b
			}
			//BSS-TBN
			else if (begin == 3 && end == 6)
			{
				RoadList.Add(N); //N
				RoadList.Add(R3); //R3
				RoadList.Add(R); //R
				RoadList.Add(b); //b
				RoadList.Add(a); //a
				RoadList.Add(R8); //R8
				RoadList.Add(U); //U
			}
			//TBS-BSN
			else if (begin == 4 && end == 1)
			{
				RoadList.Add(Z); //Z
				RoadList.Add(R7); //R7
				RoadList.Add(b); //b
				RoadList.Add(a); //a
				RoadList.Add(W); //W
				RoadList.Add(R4); //R4
				RoadList.Add(I); //I
			}

			//TBS-EHW
			else if (begin == 4 && end == 2)
			{
				RoadList.Add(Z); //Z
				RoadList.Add(R7); //R7
				RoadList.Add(b); //b
				RoadList.Add(a); //a
				RoadList.Add(W); //W
				RoadList.Add(K); //K
				RoadList.Add(D); //D
			}

			//TBS-BSS
			else if (begin == 4 && end == 3)
			{
				RoadList.Add(Z); //Z
				RoadList.Add(R7); //R7
				RoadList.Add(b); //b
				RoadList.Add(a); //a
				RoadList.Add(W); //W
				RoadList.Add(K); //K
				RoadList.Add(D); //D
				RoadList.Add(E); //E
				RoadList.Add(R2); //R2
				RoadList.Add(H); //H
			}
			//TBS-EHE
			else if (begin == 4 && end == 5)
			{
				RoadList.Add(Z); //Z
				RoadList.Add(R7); //R7
				RoadList.Add(b); //b
			}
			//TBS-TBN
			else if (begin == 4 && end == 6)
			{
				RoadList.Add(Z); //Z
				RoadList.Add(Y); //Y
				RoadList.Add(U); //U
			}
			//EHE-BSN
			else if (begin == 5 && end == 1)
			{
				RoadList.Add(a); //a
				RoadList.Add(W); //W
				RoadList.Add(K); //K
				RoadList.Add(R4); //R4
				RoadList.Add(I); //I
			}
			//EHE-EHW
			else if (begin == 5 && end == 2)
			{
				RoadList.Add(a); //a
				RoadList.Add(W); //W
				RoadList.Add(K); //K
				RoadList.Add(D); //D
			}
			//EHE-BSS
			else if (begin == 5 && end == 3)
			{
				RoadList.Add(a); //a
				RoadList.Add(W); //W
				RoadList.Add(K); //K
				RoadList.Add(D); //D
				RoadList.Add(E); //E
				RoadList.Add(R2); //R2
				RoadList.Add(H); //H
			}
			//EHE-TBS
			else if (begin == 5 && end == 4)
			{
				RoadList.Add(a); //a
				RoadList.Add(W); //W
				RoadList.Add(K); //K
				RoadList.Add(L); //L
				RoadList.Add(R6); //R6
				RoadList.Add(T); //T
			}

			//EHE-TBN
			else if (begin == 5 && end == 6)
			{
				RoadList.Add(a); //a
				RoadList.Add(R8); //R8
				RoadList.Add(U); //U
			}

			//TBN-BSN
			else if (begin == 6 && end == 1)
			{
				RoadList.Add(O); //O
				RoadList.Add(R5); //R5
				RoadList.Add(R4); //R4
				RoadList.Add(I);//I
			}

			//TBN-EHW
			else if (begin == 6 && end == 2)
			{
				RoadList.Add(O); //O
				RoadList.Add(R5); //R5
				RoadList.Add(K); //K
				RoadList.Add(D);//D
			}

			//TBN-BSS
			else if (begin == 6 && end == 3)
			{
				RoadList.Add(O); //O
				RoadList.Add(R5); //R5
				RoadList.Add(K); //K
				RoadList.Add(D);//D
				RoadList.Add(E); //E
				RoadList.Add(R2); //R2
				RoadList.Add(H); //H
			}

			//TBN-TBS
			else if (begin == 6 && end == 4)
			{
				RoadList.Add(O); //O
				RoadList.Add(P); //P
				RoadList.Add(T); //T
			}

			//TBN-EHE
			else if (begin == 6 && end == 5)
			{
				RoadList.Add(O); //O
				RoadList.Add(R5); //R5
				RoadList.Add(K); //K
				RoadList.Add(L); //L
				RoadList.Add(R); //R
				RoadList.Add(b); //b
			}
			//返回一条路径。
			return RoadList;
		}


    }
}
