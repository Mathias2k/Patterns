using System.Text.Json;

namespace FlyWeight
{
   public class Flyweight
   {
      private Car _sharedState;
      public Flyweight(Car car)
      {
         _sharedState = car;
      }
      public void Operation(Car uniqueState)
      {
         string s = JsonSerializer.Serialize(_sharedState);
         string u = JsonSerializer.Serialize(uniqueState);
         Console.WriteLine($"Flyweight: Displaying shared {s} and unique {u} state.");
      }
   }

   // The Flyweight Factory creates and manages the Flyweight objects. It
   // ensures that flyweights are shared correctly. When the client requests a
   // flyweight, the factory either returns an existing instance or creates a
   // new one, if it doesn't exist yet.
   public class FlyweightFactory
   {
      private List<Tuple<Flyweight, string>> flyweights = new();

      public FlyweightFactory(params Car[] args)
      {
         foreach (var elem in args)
            flyweights.Add(new Tuple<Flyweight, string>(new Flyweight(elem), GetKey(elem)));
      }

      // Returns a Flyweight's string hash for a given state.
      public string GetKey(Car key)
      {
         List<string> elements = new()
         {
            key.Model,
            key.Color,
            key.Company
         };

         if (key.Owner != null && key.Number != null)
         {
            elements.Add(key.Number);
            elements.Add(key.Owner);
         }

         elements.Sort();

         return string.Join("_", elements);
      }

      // Returns an existing Flyweight with a given state or creates a new
      // one.
      public Flyweight GetFlyweight(Car sharedState)
      {
         string key = GetKey(sharedState);

         if (!flyweights.Where(t => t.Item2 == key).Any())
         {
            Console.WriteLine("FlyweightFactory: Can't find a flyweight, creating new one.");
            flyweights.Add(new Tuple<Flyweight, string>(new Flyweight(sharedState), key));
         }
         else
            Console.WriteLine("FlyweightFactory: Reusing existing flyweight.");

         return flyweights.FirstOrDefault(t => t.Item2 == key).Item1;
      }
      public void ListFlyweights()
      {
         var count = flyweights.Count;
         Console.WriteLine($"\nFlyweightFactory: I have {count} flyweights:");
         foreach (var flyweight in flyweights)
            Console.WriteLine(flyweight.Item2);
      }
   }
   public class Car
   {
      public string Owner { get; set; }

      public string Number { get; set; }

      public string Company { get; set; }

      public string Model { get; set; }

      public string Color { get; set; }
   }
}
