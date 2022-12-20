using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    public interface ICalorieCounter
    {
        /// <summary>
        /// Returns the total of all calorie lists.
        /// </summary>
        /// <returns></returns>
        int Total();

        /// <summary>
        /// Returns the maximum calories in a single list.
        /// </summary>
        /// <returns></returns>
        int Max();
        
        /// <summary>
        /// Returns a list of the maximum calories in <paramref name="count"/> lists. Sorted in descending order.
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        int Top(int count);
    }

    public class CalorieCounter : ICalorieCounter
    {
        public readonly List<CalorieList> CalorieList;

        public CalorieCounter(string[] lines)
        {
            CalorieList = new List<CalorieList>()
            {
                new CalorieList()
            };

            IEnumerator enumerator = lines.GetEnumerator();
            while (enumerator.MoveNext())
            {
                string line = (string)enumerator.Current;
                if (line.Count() == 0)
                {
                    CalorieList.Add(new CalorieList());
                }
                else
                {
                    int value = int.Parse(line);
                    CalorieList.Last().Add(value);
                }
            }
        }

        public int Total()
        {
            return CalorieList.Sum(list => list.Sum());
        }

        public int Max()
        {
            return CalorieList.Max(list => list.Sum());
        }

        public int Top(int count)
        {
            return CalorieList
                .Select(list => list.Sum())
                .OrderByDescending(calories => calories)
                .Take(count)
                .Sum();
        }
    }

    public class CalorieList : List<int>
    {
    }
}
