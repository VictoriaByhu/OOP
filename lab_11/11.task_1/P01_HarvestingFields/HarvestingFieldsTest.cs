 namespace P01_HarvestingFields
{
    using System;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type type = typeof(HarvestingFields);

            
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            string command;
            while ((command = Console.ReadLine()) != "HARVEST")
            {
                foreach (var field in fields)
                {
                    string accessModifier = "";

                    if (field.IsPrivate)
                        accessModifier = "private";
                    else if (field.IsFamily)
                        accessModifier = "protected";
                    else if (field.IsPublic)
                        accessModifier = "public";

                    if (command == "all" || accessModifier == command)
                    {
                        Console.WriteLine($"{accessModifier} {field.FieldType.Name} {field.Name}");
                    }
                }
            }
        }
    }
}
