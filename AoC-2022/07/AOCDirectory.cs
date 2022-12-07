namespace AoC_2022._07
{
    public class AOCDirectory
    {
        public string Name { get; set; } = string.Empty;
        public int Size { get; set; } = 0;
        public IDictionary<string, AOCDirectory> Children = new Dictionary<string, AOCDirectory>();
        public AOCDirectory Parent;
        public IDictionary<string, int> Files = new Dictionary<string, int>();

        public AOCDirectory(string name, AOCDirectory parent)
        {
            Name = name;
            Parent = parent;
        }
        public void Push(AOCDirectory child)
        {
            Children.Add(new KeyValuePair<string, AOCDirectory>(child.Name, child));
        }

        public void Push(string fileName, int fileSize)
        {
            Files.Add(new KeyValuePair<string, int>(fileName, fileSize));
            Size += fileSize;
            UpdateParent(Parent, fileSize);
        }

        private AOCDirectory UpdateParent(AOCDirectory parent, int size)
        {
            if (parent is null)
                return null;
            parent.Size += size;
            return UpdateParent(parent.Parent, size);
        }
    }
}
