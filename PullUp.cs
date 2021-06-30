using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Workout
{
    class PullUp : Exercise
    {
        protected override int ApproachesCount { get; set; }
        protected override int CurrentApproach { get; set; }
        protected override int RepsCount { get; set; }
        protected override int EntireTime { get; set; }
        public PullUp()
        {
            CurrentApproach = 0;
            RepsCount = 0;    
        }
        public override void MakeExercise()
        {
            Console.WriteLine("Начинаем подтягиваться...");
            base.MakeExercise();
        }
        protected override void MakeApproach()
        {
            base.MakeApproach();
        }
        protected override void Countdown(int seconds)
        {
            base.Countdown(seconds);
        }
        protected override void TakeResultOfApproach()
        {
            base.TakeResultOfApproach();
        }
        protected override void Rest(int seconds)
        {
            base.Rest(seconds);
        }
        protected override void ShowStatistics()
        {
            base.ShowStatistics();
        }
    }
}
