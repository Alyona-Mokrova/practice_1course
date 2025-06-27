using System;

public static class StringExtensions
{
    public static bool IsPalindrome(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return false;

        string cleanedInput = "";
        foreach (char c in input.ToLower())
        {
            if (!char.IsWhiteSpace(c) && !char.IsPunctuation(c))
                cleanedInput += c;
        }
        string reversedInput = "";
        for (int i = cleanedInput.Length - 1; i >= 0; i--)
        {
            reversedInput += cleanedInput[i];
        }

        return cleanedInput == reversedInput;
    }
}
