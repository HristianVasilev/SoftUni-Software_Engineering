using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {
            Type type = Type.GetType(investigatedClass);

            if (type == null)
            {
                throw new ArgumentException("Invalid class!");
            }

            object instance = Activator.CreateInstance(type);

            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            FieldInfo[] searchedFields = fields.Where(f => requestedFields.Contains(f.Name)).ToArray();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Class under investigation: {type.Name}");

            foreach (var field in searchedFields)
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(instance)}");
            }

            return sb.ToString().TrimEnd();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type type = Type.GetType(className);

            EnsureTypeIsValid(className, type);

            object instance = Activator.CreateInstance(type);

            FieldInfo[] fields = type.GetFields();
            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            MethodInfo[] publicMethods = methods.Where(t => t.IsPublic && t.Name.StartsWith("set")).ToArray();
            MethodInfo[] nonpublicMethods = methods.Where(t => !t.IsPublic && t.Name.StartsWith("get")).ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var field in fields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (var npm in nonpublicMethods)
            {
                sb.AppendLine($"{npm.Name} have to be private!");
            }

            foreach (var pm in publicMethods)
            {
                sb.AppendLine($"{pm.Name} have to be public!");
            }

            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string classType)
        {
            Type type = Type.GetType(classType);

            EnsureTypeIsValid(classType, type);

            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"All Private Methods for Class: {type.FullName}");
            sb.AppendLine($"Base Class: {type.BaseType.Name}");

            foreach (var method in methods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().TrimEnd();
        }

        public string CollectGettersAndSetters(string classType)
        {
            Type type = Type.GetType(classType);

            EnsureTypeIsValid(classType, type);

            MethodInfo[] methodInfos = type.GetMethods(BindingFlags.Instance | BindingFlags.Public  | BindingFlags.NonPublic);

            IEnumerable<MethodInfo> getters = methodInfos.Where(m => m.Name.StartsWith("get"));
            IEnumerable<MethodInfo> setters = methodInfos.Where(m => m.Name.StartsWith("set"));

            StringBuilder sb = new StringBuilder();

            foreach (var getter  in getters)
            {
                sb.AppendLine($"{getter.Name} will return {getter.ReturnType}");
            }

            foreach (var setter in setters)
            {
                sb.AppendLine($"{setter.Name} will set field of {setter.GetParameters().First().ParameterType.FullName}");
            }

            return sb.ToString().TrimEnd();
        }

        private static void EnsureTypeIsValid(string className, Type type)
        {
            if (type == null)
            {
                throw new ArgumentException($"Invalid class {className}!");
            }
        }

    }
}
