namespace Bubbles
{
    public interface IChooseble
    {
        ColorType[] GenerateAnswer(ColorType[] colors);
        void Chosed();
    }
}
