using System;

namespace BE
{
    public class DayWork
    {
        public TimeSpan ben;
        public TimeSpan ed;
        public Clock begin;
        public Clock end;
        public int sumMinuts { get; set; }
        public DayWork() { }
        public DayWork(Clock b, Clock e)
        {
            begin = b;
            end = e;
        }
        /// <summary>
        /// return number that use to compareble
        /// </summary>
        public int Fixed(DayWork obj)
        {
            return (obj.sumMinuts - sumMinuts);
        }
        /// <summary>
        /// return if this instance can Contain an other instance
        /// </summary>
        public bool contain(DayWork obj)
        {
            return (obj.begin.sumMinuts() - begin.sumMinuts() >= 0 && obj.end.sumMinuts() - end.sumMinuts() <= 0);
        }
    }
}