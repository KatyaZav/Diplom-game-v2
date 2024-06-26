namespace ColorChooseGame.Bubbles
{
    public class NullChoose : IChooseble
    {
        public ChosesType Type { get => ChosesType.NullChoose; }
        public void Chosed()
        {
            throw new System.NotImplementedException();
        }

        public ColorTypes[] GenerateAnswer(ColorTypes[] colors)
        {
            return new ColorTypes[] { ColorsHolder.Instance.ZeroBubble };
        }
    }
}
