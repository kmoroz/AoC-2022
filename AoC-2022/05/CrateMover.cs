namespace AoC_2022._05
{
    internal class CrateMover
    {
        public static void CrateMover9000(List<List<int>> movingCoordinates, List<Stack> stacks)
        {
            foreach (var instruction in movingCoordinates)
            {
                var amount = instruction[0];
                var from = instruction[1] - 1;
                var to = instruction[2] - 1;

                for (int i = 1; i <= amount; i++)
                {
                    var source = stacks.ElementAt(from);
                    var destination = stacks.ElementAt(to);
                    var crate = source.Pop();
                    destination.Push(crate);
                }
            }
        }

        public static void CrateMover9001(List<List<int>> movingCoordinates, List<Stack> stacks)
        {
            foreach (var instruction in movingCoordinates)
            {
                var amount = instruction[0];
                var from = instruction[1] - 1;
                var to = instruction[2] - 1;

                var source = stacks.ElementAt(from);
                var crateQueue = source.Crates.Take(amount).Reverse();
                var destination = stacks.ElementAt(to);
                foreach (var crate in crateQueue)
                {
                    source.Pop();
                    destination.Push(crate);
                }
            }
        }
    }
}
