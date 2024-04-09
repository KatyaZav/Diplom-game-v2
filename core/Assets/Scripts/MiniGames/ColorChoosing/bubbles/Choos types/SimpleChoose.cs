namespace ColorChooseGame.Bubbles
{
    public class SimpleChoose : IChooseble
    {
        public ChosesType Type { get => ChosesType.SimpleChoose; }

        public void Chosed()
        {
            throw new System.NotImplementedException();
        }

        public ColorTypes[] GenerateAnswer(ColorTypes[] colors)
        {
            return new ColorTypes[] { BubbleColorRandom.GetRandomColor(colors) };
        }
    }
}


