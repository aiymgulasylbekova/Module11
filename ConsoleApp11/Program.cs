using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{

    // Интерфейс для частей дома
    interface IPart
    {
        void Build();
    }

    // Интерфейс для рабочих
    interface IWorker
    {
        void Work(House house, Team team);
    }

    // Фундамент
    class Basement : IPart
    {
        public void Build()
        {
            Console.WriteLine("Фундамент построен");
        }
    }

    // Стены
    class Walls : IPart
    {
        public void Build()
        {
            Console.WriteLine("Стены построены");
        }
    }

    // Дверь
    class Door : IPart
    {
        public void Build()
        {
            Console.WriteLine("Дверь построена");
        }
    }

    // Окно
    class Window : IPart
    {
        public void Build()
        {
            Console.WriteLine("Окно построено");
        }
    }

    // Крыша
    class Roof : IPart
    {
        public void Build()
        {
            Console.WriteLine("Крыша построена");
        }
    }

    // Дом
    class House
    {
        private List<IPart> parts = new List<IPart>();

        public void AddPart(IPart part)
        {
            parts.Add(part);
        }

        public void Show()
        {
            Console.WriteLine("Дом построен. Состоит из:");

            foreach (var part in parts)
            {
                part.Build();
            }
        }
    }

    // Рабочий
    class Worker : IWorker
    {
        public void Work(House house, Team team)
        {
            foreach (var part in team.GetParts())
            {
                part.Build();
                house.AddPart(part);
            }
        }
    }

    // Бригадир
    class TeamLeader : IWorker
    {
        public void Work(House house, Team team)
        {
            Console.WriteLine("Отчет по строительству:");

            foreach (var part in team.GetParts())
            {
                Console.WriteLine("- " + part.GetType().Name);
            }
        }
    }

    // Бригада строителей
    class Team
    {
        private List<IPart> parts = new List<IPart>();

        public void AddPart(IPart part)
        {
            parts.Add(part);
        }

        public List<IPart> GetParts()
        {
            return parts;
        }
    }

    class Program
    {
        static void Main()
        {
            House house = new House();
            Team team = new Team();

            team.AddPart(new Basement());
            for (int i = 0; i < 4; i++)
            {
                team.AddPart(new Walls());
            }
            team.AddPart(new Door());
            for (int i = 0; i < 4; i++)
            {
                team.AddPart(new Window());
            }
            team.AddPart(new Roof());

            Console.WriteLine("Строительство дома начинается:");
            foreach (IWorker worker in team.GetParts())
            {
                worker.Work(house, team);
            }

            Console.WriteLine("\nСтроительство завершено. Результат:");
            house.Show();
        }
    }
}

