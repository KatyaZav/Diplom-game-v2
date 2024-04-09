namespace ColorChooseGame.Bubbles
{
    public interface IChooseble
    {
        ColorTypes[] GenerateAnswer(ColorTypes[] colors);
        void Chosed();
        ChosesType Type { get; } 
    }
}
