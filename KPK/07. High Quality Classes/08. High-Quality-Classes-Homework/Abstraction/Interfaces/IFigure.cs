namespace Abstraction.Interfaces
{
    public interface IFigure
    {
        double Width { get; }
        double Height { get; }
        double Radius { get; }

        double CalcSurface();
        double CalcPerimeter();
    }
}
