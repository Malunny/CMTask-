namespace TaskWorking.Service.StringCutterExtension;

public static class StringCuttingExtension
{
    public static IEnumerable<string> CutIntoSmaller(this string stringType, int stringLength, int maxLines = 2)
    {
        ReadOnlySpan<char> text = stringType.AsSpan();
        ICollection<string> result = new List<string>();
        
        if (text.Length < stringLength)
            return new List<string>() { stringType };
        
        for (int i = 0; i < (stringType.Length / stringLength); i++)
        {
            result.Add(text.Slice(0, stringLength).ToString());
            text = text.Slice(stringLength);
        }
        
        if (text.Length % stringLength != 0 && text.Length / stringLength < 1)
            result.Add(text.ToString());
        
        string change = result.ElementAt(maxLines - 1);
        
        return result.Take(maxLines);
    }
}