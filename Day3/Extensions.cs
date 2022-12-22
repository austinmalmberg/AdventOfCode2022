using System.Linq;

namespace Day3
{
    public static class StringExtensions
    {
        /// <summary>
        /// Returns the item priority of the string.
        /// 
        /// Priorites are as follows:
        /// <list type="bullet">
        /// <item>a through z are assigned priorities 1 through 26.</item>
        /// <item>A through Z are assigned priorities 27 through 52.</item>
        /// </list>
        /// 
        /// All other characters are ignored.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int GetPrioritySum(this string str)
        {
            return str.ToCharArray()
                .Select(ch => ch.GetPriority())
                .Sum();
        }
    }

    public static class CharExtensions
    {
        /// <summary>
        /// Returns the item priority of the char.
        /// 
        /// Priorites are as follows:
        /// <list type="bullet">
        /// <item>a through z are assigned priorities 1 through 26.</item>
        /// <item>A through Z are assigned priorities 27 through 52.</item>
        /// </list>
        /// 
        /// All other characters are priority 0.
        /// </summary>
        /// <param name="ch"></param>
        /// <returns>The priority.</returns>
        public static int GetPriority(this char ch)
        {
            if (!char.IsLetter(ch)) return 0;

            int basePriority = char.ToLower(ch) - 96;

            if (char.IsUpper(ch)) basePriority += 26;

            return basePriority;
        }
    }
}
