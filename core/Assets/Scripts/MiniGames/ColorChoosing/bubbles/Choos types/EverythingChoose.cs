namespace ColorChooseGame.Bubbles
{
    public class EverythingChoose : IChooseble
    {
        public ChosesType Type { get => ChosesType.EverythingChoose; }

        public void Chosed()
        {
            throw new System.NotImplementedException();
        }

        public ColorTypes[] GenerateAnswer(ColorTypes[] colors)
        {
            return colors;
        }
    }
}
