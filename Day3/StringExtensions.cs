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
        public static int GetItemPriority(this string str)
        {
            int total = 0;

            foreach (char ch in str.ToCharArray())
            {
                char lower = char.ToLower(ch);

                // Ignore unprioritized
                if (lower < 97 || lower > 122) continue;

                // Add 26 to uppercase
                if (char.IsUpper(ch)) total += 26;

                total += lower - 96;
            }

            return total;
        }
    }
}
