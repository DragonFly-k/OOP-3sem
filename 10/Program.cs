using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace _10
{
    class Program
    {
        static void Main(string[] args)
        {
            Game arcade = new Game("Arcade");
            Game strategy = new Game("Strategy");
            Game quest = new Game("Quest");
            Game simulation = new Game("Simulation");
            MyCollection<Game> game = new MyCollection<Game>() { arcade, strategy, quest, simulation};
            game.ShowCollection();
            game.Delete(arcade);
            game.ShowCollection();
            game.Search(strategy);

            BlockingCollection<int> bc = new BlockingCollection<int>(boundedCapacity: 5);
            bc.Add(10);
            bc.Add(20);
            bc.Add(30);
            bc.Add(40);
            bc.Add(50);
            if (bc.TryAdd(6, TimeSpan.FromSeconds(2)))
            {
                Console.WriteLine("Добавлен элемент");
            }
            else
            {
                Console.WriteLine("Элемент не добавлен");
            }
            foreach (var item in bc)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Введите количество элементов для удаления");
            int number = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                bc.Take(); 
            }
            foreach (var item in bc)
            {
                Console.WriteLine(item);
            }

            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (var item in bc)
            {
                dict.Add(item, item);
            }
            ObservableCollection<Game> obsGame = new ObservableCollection<Game>() { arcade, strategy, quest, simulation };
            obsGame.CollectionChanged += ObsGameChanged;
            Game newGame = new Game("Fighting");
            obsGame.Add(newGame);
            obsGame.Remove(strategy);
            Console.ReadKey();
        }
        private static void ObsGameChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        Game game = e.NewItems[0] as Game;
                        Console.WriteLine($"Элемент {game.Type} был добавлен");
                        break;
                    };
                case NotifyCollectionChangedAction.Remove:
                    {
                        Game game = e.OldItems[0] as Game;
                        Console.WriteLine($"Элемент {game.Type} был удален");
                        break;
                    }
            } 
        }
    }
}