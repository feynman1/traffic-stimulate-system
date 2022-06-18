using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsFormsApp1
{
    public class Light
    {
        //0:红灯，1：绿灯
        //初始设置l2,l3为绿灯;l1,l4为红灯
        //初始设置l6,l7为绿灯;l5,l8为红灯
        private int l1 = 0;
        private int l2 = 1;
        private int l5;
        private int l6;
        private int redGap = 0;
        private int greenGap = 0;
        private int delayGap = 0;
        private int gap = 0;
        private int specialGap = 0;
        private int T1sem = 0;
        private int T2sem = 0;
        private int T3sem = 0;
        private int T4sem = 0;



        private static System.Timers.Timer T1;
        private static System.Timers.Timer T2;
        private static System.Timers.Timer T3;
        private static System.Timers.Timer T4;
        private static System.Timers.Timer T5;
        private static System.Timers.Timer T6;
        private static System.Timers.Timer T7;
        private static System.Timers.Timer T8;

        public int getl1 { get => l1; set => l1 = value; }
        public int getl2 { get => l2; set => l2 = value; }
        public int getl5 { get => l5; set => l5 = value; }
        public int getl6 { get => l6; set => l6 = value; }

        public Light(int L23r, int L23g, int L67g)
        {
            redGap = L23r;
            greenGap = L23g;
            delayGap = L67g;
            gap = redGap + greenGap;
            //判断CR2路口初始时刻的红绿灯应该如何设置。
            if (redGap >= delayGap)
            {
                l5 = 1;
                l6 = 0;
                specialGap = delayGap + greenGap;
            }
            else
            {
                l5 = 0;
                l6 = 1;
                specialGap = delayGap - redGap;
            }

            setTimer();
            T1.Start();
            T2.Start();
            T3.Start();
            T4.Start();
            T5.Start();
            T6.Start();
            T7.Start();
            T8.Start();
        }
        public void setTimer()
        {
            T1 = new System.Timers.Timer(gap * 1000);
            T1.Elapsed += OneTimeEvent;
            T1.AutoReset = true;
            T1.Enabled = true;

            T2 = new System.Timers.Timer(gap * 1000);
            T2.Elapsed += TwoTimeEvent;
            T2.AutoReset = true;
            T2.Enabled = true;

            T3 = new System.Timers.Timer(gap * 1000);
            T3.Elapsed +=ThreeTimeEvent;
            T3.AutoReset = true;
            T3.Enabled = true;

            T4 = new System.Timers.Timer(gap * 1000);
            T4.Elapsed += FiveTimeEvent;
            T4.AutoReset = true;
            T4.Enabled = true;

            T5 = new System.Timers.Timer(greenGap * 1000);
            T5.Elapsed += T5Event;
            T5.AutoReset = false;
            T5.Enabled = true;

            T6 = new System.Timers.Timer(gap * 1000);
            T6.Elapsed += T6Event;
            T6.AutoReset = false;
            T6.Enabled = true;

            T7 = new System.Timers.Timer(specialGap * 1000);
            T7.Elapsed += T7Event;
            T7.AutoReset = false;
            T7.Enabled = true;

            T8 = new System.Timers.Timer(delayGap * 1000);
            T8.Elapsed += T8Event;
            T8.AutoReset = false;
            T8.Enabled = true;

        }
        public void OneTimeEvent(Object source,ElapsedEventArgs e)
        {
            if (l1 == 0&&T1sem ==1)
            {
                l1 = 1;
                l2 = 0;
            }
            return;
        }
        public void TwoTimeEvent(Object source, ElapsedEventArgs e)
        {
            if (l1 == 1 && T2sem == 1)
            {
                l1 = 0;
                l2 = 1;
            }
            return;
        }
        public void ThreeTimeEvent(Object source, ElapsedEventArgs e)
        {
            if (l5 == 0 && T3sem == 1)
            {
                l5 = 1;
                l6 = 0;
            }
            return;
        }
        public void FiveTimeEvent(Object source, ElapsedEventArgs e)
        {
            if (l5 == 1 && T4sem == 1)
            {
                l5 = 0;
                l6 = 1;
            }
            return;
        }

        public void T5Event(Object source, ElapsedEventArgs e)
        {
            T1sem = 1;
            return;
        }
        public void T6Event(Object source, ElapsedEventArgs e)
        {
            T2sem = 1;
            return;
        }
        public void T7Event(Object source, ElapsedEventArgs e)
        {
            T3sem = 1;
            return;
        }
        public void T8Event(Object source, ElapsedEventArgs e)
        {
            T4sem = 1;
            return;
        }

    }
  
}
