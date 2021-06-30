using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Workout
{
    class User
    {
        private Exercise exercise;
        private Queue<Exercise> exercises;
        private int RestingTime;
        private int SecondInMilliseconds = 1000;
        public User()
        {
            exercises = new Queue<Exercise>();
            RestingTime = 120;
        }
        public void StartWorkout()
        {
            if (exercises.Count == 0) return;
            for (int i = 0; i < exercises.Count + 1; i++)
            {
                SetExercise(exercises.Dequeue());
                MakeExercise();
                Rest(RestingTime);
            }
            Console.WriteLine("Тренировка закончена!");
        }
        public void AddExercises()
        {
            var isCancelled = false;
            while (!isCancelled)
            {
                Console.Write("Выберите упражнение: ");
                string enteredExercise = Console.ReadLine();
                var exercise = GetExerciseType(enteredExercise);
                exercises.Enqueue(exercise);
                Console.WriteLine($"Чтобы закончить добавление упражнений в тренировку, напишите {"Закончить"}, в ином случае Enter");
                isCancelled = Console.ReadLine() == "Закончить" ? true : false;
            }
        }
        public void MakeExercise()
        {
            exercise?.MakeExercise();
        }
        private void SetExercise(Exercise exercise)
        {
            this.exercise = exercise;
        }
        private Exercise GetExerciseType(string enteredExercise)
        {
            try
            {
                return Exercise.dictionary[enteredExercise];
            }
            catch (Exception)
            {
                Console.WriteLine("Упражнение не идентифицировано.");
                return null;
            }
        }
        private void Rest(int seconds)
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
}
