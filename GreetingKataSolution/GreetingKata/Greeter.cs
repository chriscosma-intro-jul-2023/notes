
namespace GreetingKata;

public class Greeter
{
    public string Greet(params string[] names)
    {
        names ??= new string[] { "Chief" };
        // Move all caps names to the end
        List<string> sortedNames = SortNamesByCaps(
            SplitCSNames(names.ToList()));

        // Handle single name case
        if (sortedNames.Count == 1 && IsAllCaps(sortedNames.First()))
        {
            return $"HELLO, {sortedNames.First()}!";
        } else if(sortedNames.Count == 1)
        {
            return $"Hello, {sortedNames.First()}!";
        }

        // Take last name, prefix with "and" or "AND" depending on case
        string lastName = sortedNames.Last();
        sortedNames.RemoveAt(sortedNames.Count - 1);
        if (IsAllCaps(lastName))
        {
            lastName = $"AND {lastName}";
        } else
        {
            lastName = $"and {lastName}";
        }

        // Get all of the other names and separate them by commas
        string csNames = string.Join(", ", sortedNames);
        // Add back last name
        sortedNames.Add(lastName);

        // If there are only two names, don't use a comma
        string result;
        if (sortedNames.Count == 2)
        {
            result = $"Hello, {csNames} {lastName}!";
        } else
        {
            result = $"Hello, {csNames}, {lastName}!";
        }

        // Convert to all uppercase if all names are uppercase
        if (sortedNames.All(s => IsAllCaps(s)))
        {
            result = result.ToUpper();
        }

        return result;
    }

    private List<string> SplitCSNames(List<string> names)
    {
        var result = new List<string>();
        foreach (string name in names)
        {
            if (name.Contains(","))
            {
                var splitNames = name.Split(",").Select(s => s.Trim());
                foreach (string name2 in splitNames)
                {
                    result.Add(name2);
                }
            } else
            {
                result.Add(name);
            }
        }

        return result;
    }

    public static List<string> SortNamesByCaps(List<string> names)
    {
        names.Sort((string n1, string n2) =>
        {
            if (IsAllCaps(n1) && IsAllCaps(n2))
            {
                return 0;
            } else if (!IsAllCaps(n1) && !IsAllCaps(n2))
            {
                return 0;
            }
            else if (IsAllCaps(n1) && !IsAllCaps(n2))
            {
                return 1;
            }
            else
            {
                return -1;
            }
        });

        return names;
    }

    private static bool IsAllCaps(string s)
    {
        return s.All(c => char.IsUpper(c));
    }
}
