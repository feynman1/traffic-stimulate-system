using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace WindowsFormsApp1
{
    public class Document
    {
        private int oneCrossA;
        private int oneCrossB;
        private int threeCrossA;
        private int threeCrossB;
        private int snTime;
        private int ewTime;
        public static Hashtable prior;
        public ArrayList carlist;
        public Light t;
        Road r;
        private static System.Timers.Timer DocumentTimerOne;
        private static System.Timers.Timer DocumentTimerThree;
        int[] One = { 2, 5 };
        int[] Three = { 1, 3, 4, 6 };
        int[] Final = { 1, 2, 3, 4, 5, 6 };

        public  Document(int L23r, int L23g, int L67g, int tsn, int tew)
        {
            snTime = tsn;
            ewTime = tew;
            carlist = new ArrayList();
            prior = new Hashtable();
            t = new Light(L23r,L23g,L67g);
            r = new Road(1, 2);
           
            setDocumentTimerOne();
            setDocumentTimerThree();
        }

        public void setDocumentTimerOne()
        {
            DocumentTimerOne = new System.Timers.Timer(ewTime*1000);
            DocumentTimerOne.Elapsed += OneTimedEvent;
            DocumentTimerOne.AutoReset = true;
            DocumentTimerOne.Enabled = true;
        }
        public void setDocumentTimerThree()
        {
            DocumentTimerThree = new System.Timers.Timer(snTime*1000);
            DocumentTimerThree.Elapsed += ThreeTimedEvent;
            DocumentTimerThree.AutoReset = true;
            DocumentTimerThree.Enabled = true;
        }
        private  void OneTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            randomOne();
            if (!judgejam(oneCrossA))
            {
                Car car1 = new Car(oneCrossA, oneCrossB, t);
                carlist.Add(car1);
            }
        }
        private void ThreeTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            randomThree();
            if (!judgejam(threeCrossA))
            {
                Car car1 = new Car(threeCrossA, threeCrossB, t);
                carlist.Add(car1);
            }
        }
        // 东西路口随机产生车，EHW, EHE任一点作为起始点。
        public void randomOne()
        {
            int index;
            Random ran = new Random();
            //随机数生成出发路口
            index = ran.Next(0,One.Length);
            //随机数产生终点
            int end = ran.Next(0, Final.Length);
            while (One[index] == Final[end])
            {
                end = ran.Next(0,Final.Length);
            }
            oneCrossA = One[index];
            oneCrossB = Final[end];
        }
        // 南北路口随机产生车，BSN, TBN, BSS, TBS任一点作为起始点。
        public void randomThree()
        {
            int index;
            Random ran = new Random();
            //随机数生成出发路口
            index = ran.Next(0,Three.Length);
            //随机数产生终点
            int end = ran.Next(0, Final.Length);
            while (Three[index] == Final[end])
            {
                end = ran.Next(0,Final.Length);
            }
            threeCrossA = Three[index];
            threeCrossB = Final[end];
        }
        
        public bool judgejam(int begin)
        {
            if (begin == 2)
            {
                String first = String.Concat(r.E.X, r.E.Y);
                if (prior.ContainsKey(first))
                {
                    return true;
                }
            }
            if (begin == 5)
            {
                String first = String.Concat(r.a.X, r.a.Y);
                if (prior.ContainsKey(first))
                {
                    return true;
                }
            }
            if (begin == 1)
            {
                String first = String.Concat(r.A.X, r.A.Y);
                Console.WriteLine(first);
                if (prior.ContainsKey(first))
                {
                    return true;
                }
            }
            if (begin == 6)
            {
                String first = String.Concat(r.O.X, r.O.Y);
                if (prior.ContainsKey(first))
                {
                    return true;
                }
            }
            if (begin == 3)
            {
                String first = String.Concat(r.N.X, r.N.Y);
                if (prior.ContainsKey(first))
                {
                    return true;
                }
            }

            if (begin == 4)
            {
                String first = String.Concat(r.Z.X, r.Z.Y);
                if (prior.ContainsKey(first))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
