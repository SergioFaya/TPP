using System;

namespace colors
{
    public class SynchronizedColor : Color
    {
        static object _locker = new object();

        public SynchronizedColor(ConsoleColor color)
            : base(color)
        {
        }
        
        override public void Show()
        {
            lock (/*Console.Out*/_locker)
            {
                base.Show();
            }
        }
    }
}
