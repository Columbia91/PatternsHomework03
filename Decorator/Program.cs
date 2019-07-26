using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Component carlson = new Carlson();
            Decorator overall = new Overall();
            Decorator propeller = new Propeller();

            overall.Component = carlson;
            propeller.Component = overall;
            propeller.Move();
        }

        abstract class Component
        {
            public abstract void Move();
        }

        class Carlson : Component
        {
            public override void Move()
            {
                Console.WriteLine("Карлсон проснулся и встал");
            }
        }
        abstract class Decorator : Component
        {
            public Component Component { get; set; }
            public override void Move()
            {
                if (Component != null)
                {
                    Component.Move();
                }
            }
        }
        class Overall : Decorator
        {
            private void Walk()
            {
                Console.WriteLine("Карлсон одел комбинезон и пошел гулять");
            }
            public override void Move()
            {
                base.Move();
                Walk();
            }
        }
        class Propeller : Decorator
        {
            private void Fly()
            {
                Console.WriteLine("Карлсон одел пропеллер и полетел");
            }
            public override void Move()
            {
                base.Move();
                Fly();
            }
        }
    }
}
