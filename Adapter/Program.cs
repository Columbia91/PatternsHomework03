using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            // человек
            Human human = new Human();
            // сканер
            Scanner scanner = new Scanner();
            // готовит копию документа
            human.ToPrepareDocument(scanner);
            // качество копии не устраивает, но есть смартфон
            Samsung samsung = new Samsung();
            // используем адаптер
            InputDevice smartphone = new Adapter(samsung);
            // для получения копии, делаем снимок документа на смартфон
            human.ToPrepareDocument(smartphone);

            Console.Read();
        }
    }
    interface InputDevice
    {
        void Scan();
    }
    // класс машины
    class Scanner : InputDevice
    {
        public void Scan()
        {
            Console.WriteLine("Сканировать документ");
        }
    }
    class Human
    {
        public void ToPrepareDocument(InputDevice device)
        {
            device.Scan();
        }
    }
    
    interface SmartPhone
    {
        void MakePhoto();
    }
    
    class Samsung : SmartPhone
    {
        public void MakePhoto()
        {
            Console.WriteLine("Сфотографировать документ");
        }
    }
    
    class Adapter : InputDevice
    {
        Samsung samsung;
        public Adapter(Samsung s)
        {
            samsung = s;
        }

        public void Scan()
        {
            samsung.MakePhoto();
        }
    }
}
