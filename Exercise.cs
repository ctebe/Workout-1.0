using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Workout
{
    public abstract class Exercise
    {
        public static Dictionary<string, Exercise> dictionary = new Dictionary<string, Exercise>()
        {
            {"Подтягивание", new PullUp() },
            {"Отжимание", new PushUp() },
            {"Приседание", new SitUp() },
            {"Скручивание", new Twist() },
        };
        protected const int AttemptsCount = 3;
        protected int CurrentAttempt = AttemptsCount;
        protected int RestingTime { get; } = 60;
        protected int SecondInMilliseconds { get; } = 1000;
        protected int TimeToApproach { get; } = 10;
        protected abstract int ApproachesCount { get; set; }
        protected abstract int CurrentApproach {  get; set; }
        protected abstract int RepsCount { get; set; }
        protected abstract int  EntireTime { get; set; }
        public virtual void MakeExercise()
        {
            Console.Write("Количество подходов: ");
            if (int.TryParse(Console.ReadLine(), out int result))
                ApproachesCount = result;
            else
            {
                Console.WriteLine("Ввод не распознан");
                return;
            }
            Countdown(TimeToApproach);
            while (!(CurrentApproach == ApproachesCount))
            {
                MakeApproach();
                TakeResultOfApproach();
                Rest(RestingTime);
                Countdown(TimeToApproach);
            }
            ShowStatistics();
            Console.WriteLine("Упражнение закончено. Отдыхайте.");
        }
        protected virtual void Countdown(int seconds)
        {
            if (!(CurrentApproach == ApproachesCount))
            {
                Console.WriteLine("Обратный отсчёт: ");
                for (int i = seconds - 1; i >= 0; i--)
                {
                    Console.WriteLine($"{i}...");
                    Thread.Sleep(SecondInMilliseconds);
                }
            }
        }
        protected virtual void MakeApproach()
        {
            CurrentApproach++;
            Console.WriteLine($"{CurrentApproach} Подход: ");
            var seconds = 0;
            while (!Console.KeyAvailable)
            {
                seconds++;
                Console.WriteLine(seconds);
                Thread.Sleep(SecondInMilliseconds);
            }
            EntireTime = seconds;
            Console.WriteLine("Подход закончен.");
        }
        protected virtual void TakeResultOfApproach()
        {
            Console.Write("Количество повторений: ");
            if (int.TryParse(Console.ReadLine(), out int result))
                RepsCount += result;
            else
            {
                Console.WriteLine("Ввод не распознан");
                RepeatMethod();
                return;
            }
        }
        protected virtual void Rest(int seconds)
        {
            if (!(CurrentApproach == ApproachesCount))
            {
                Console.WriteLine("Отдыхаем...");
                for (int i = 1; i <= seconds; i++)
                {
                    Console.WriteLine($"{i}...");
                    Thread.Sleep(SecondInMilliseconds);
                }
                Console.WriteLine("Отдых закончен.");
            }
        }
        protected virtual void ShowStatistics()
        {
            Console.WriteLine("Информация за упражнение: ");
            Console.WriteLine($"\t Количество подходов: {ApproachesCount}");
            Console.WriteLine($"\t Количество повторений: {RepsCount}");
            Console.WriteLine($"\t Общее время: {EntireTime + (RestingTime * ApproachesCount)}");
        }
        private void RepeatMethod()
        {
            CurrentAttempt--;
            if (!(CurrentAttempt == 0))
            {
                TakeResultOfApproach();
            }
            else
                Console.WriteLine("Слишком много попыток, присваиваем 0 =(");
            CurrentAttempt = AttemptsCount;
            return;
        }
    }
}
