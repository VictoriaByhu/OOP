namespace P02_BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type type = typeof(BlackBoxInteger);

            var instance = Activator.CreateInstance(type, true);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] parts = input.Split('_');
                string methodName = parts[0];
                int value = int.Parse(parts[1]);

                MethodInfo method = type.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);

                method.Invoke(instance, new object[] { value });

                FieldInfo field = type.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic);
                int currentValue = (int)field.GetValue(instance);

                Console.WriteLine(currentValue);
            }
        }
    }
}
