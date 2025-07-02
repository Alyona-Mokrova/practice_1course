namespace task04
{
    public interface ISpaceship
    {
        void MoveForward();
        void Rotate(int angle);
        void Fire();
        int Speed { get; }
        int FirePower { get; }
    }

    public class Cruiser : ISpaceship
    {
        public int Speed
        {
            get { return 50; }
        }

        public int FirePower
        {
            get { return 100; }
        }

        private int _rotationAngle;

        public void MoveForward()
        {
            System.Console.WriteLine("The Cruiser sails forward");
        }


        public void Rotate(int angle)
        {
            _rotationAngle += angle;
            _rotationAngle %= 360;
            if (_rotationAngle < 0)
            {
                _rotationAngle += 360;
            }
        }

        public void Fire()
        {
            System.Console.WriteLine($"The Cruiser launches a powerful photon missile {FirePower}");

        }
    }

    public class Fighter : ISpaceship
    {
        public int Speed
        {
            get { return 100; }
        }

        public int FirePower
        {
            get { return 50; }
        }

        private int _rotationAngle;

        public void MoveForward()
        {
            System.Console.WriteLine("The Fighter sails forward");
        }

        public void Rotate(int angle)
        {
            _rotationAngle += angle;
            _rotationAngle %= 360;
            if (_rotationAngle < 0)
            {
                _rotationAngle = 360;
            }
        }

        public void Fire()
        {
            System.Console.WriteLine($"The Fighter launches a powerful photon missile {FirePower}");
        }
    }
}
