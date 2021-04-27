using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Lolaflora.Baskets.Domain.SeedWork
{
    public abstract class Enumeration : IComparable
    {
        public string Name { get; private set; }

        public int Value { get; private set; }

        protected Enumeration(int value, string name)
        {
            Value = value;
            Name = name;
        }

        public override string ToString() => Name;

        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        public override bool Equals(object obj)
        {

            if (!(obj is Enumeration otherValue))
                return false;

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Value.Equals(otherValue.Value);

            return typeMatches && valueMatches;
        }

        public override int GetHashCode() => Value.GetHashCode();

        public static T FromValue<T>(int value) where T : Enumeration
        {
            var matchingItem = Parse<T, int>(value, item => item.Value == value);
            return matchingItem;
        }

        private static T Parse<T, K>(K value, Func<T, bool> predicate) where T : Enumeration
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);

            if (matchingItem == null)
                throw new InvalidOperationException($"'{value}' is not a valid in {typeof(T)}");

            return matchingItem;
        }

        public int CompareTo(object other) => Value.CompareTo(((Enumeration)other).Value);
    }
}
