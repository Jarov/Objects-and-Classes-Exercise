namespace _03.IntersectionOfCircles
{
    class Circle
    {
        public Point Center;
        public int Radius;

        public Circle(Point center, int radius)
        {
            Center = center;
            Radius = radius;
        }

        public Circle(string[] inPut)
        {
            Center = new Point(int.Parse(inPut[0]), int.Parse(inPut[1]));
            Radius = int.Parse(inPut[2]);
        }
    }
}
