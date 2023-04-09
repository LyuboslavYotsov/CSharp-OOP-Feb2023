namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            IShape circle = new Circle();
            IShape rectangle = new Rectangle();
            IShape square = new Square();
            IShape prism = new Prism();
            circle.Draw();
            rectangle.Draw();
            square.Draw();
            prism.Draw();
            GraphicEditor gEditor = new GraphicEditor();
            gEditor.DrawShape(circle);
            gEditor.DrawShape(rectangle);
            gEditor.DrawShape(square);
            gEditor.DrawShape(prism);
        }
    }
}
