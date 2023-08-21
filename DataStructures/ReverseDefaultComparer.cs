namespace Library.DataStructures
{
    public class ReverseDefaultComparer<T> : Comparer<T>
    {
        /// <summary>
        /// Static instnace to use if you need avoid repeated instantiations of new copies.
        /// </summary>
        public static readonly Comparer<T> Instance = new ReverseDefaultComparer<T>();

        public override int Compare(T? x, T? y)
        {
            return -Default.Compare(x, y);
        }
    }
}
