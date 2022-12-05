namespace AoC_2022._05
{
    public class Stack
    {
        public List<char> Crates { get; set; } = new List<char>();

        public void Push(char crate)
        {
            Crates.Insert(0, crate);
        }

        public char Pop()
        {
            var crateOnTop = Crates.First();

            Crates.Remove(crateOnTop);

            return crateOnTop;
        }
    }
}