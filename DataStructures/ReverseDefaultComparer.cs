namespace Library.DataStructures
{
    public class ReverseDefaultComparer<T> : Comparer<T>
    {
        public override int Compare(T? x, T? y)
        {
            return -Default.Compare(x, y);
        }
    }
}
