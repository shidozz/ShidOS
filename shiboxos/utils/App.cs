namespace shiboxos.utils
{
    public class App
    {
        public string name;
        public string description;
        public bool isOpen;
        public enum BtnState
        {
            OFF,
            CLICKED,
            NORMAL
        }
        public struct Button
        {
            public int X;
            public int Y;
            public int maxX;
            public int maxY;
            public BtnState state;
            public Button(int X, int Y, int maxX, int maxY, BtnState state)
            {
                this.X = X;
                this.Y = Y;
                this.maxX = maxX;
                this.maxY = maxY;
                this.state = state;
            }
        }

        public App(string name, string description, bool isOpen)
        {
            this.name = name;
            this.description = description;
            this.isOpen = isOpen;
        }

    }
}
