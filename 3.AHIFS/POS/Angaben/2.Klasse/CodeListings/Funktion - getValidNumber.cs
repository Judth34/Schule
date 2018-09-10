static void getValidNumber(out int varNumber, int validMin, int validMax, string userText)
{
    bool erg;
    do
    {
        Console.Write(userText);
        erg = int.TryParse(Console.ReadLine(), out varNumber);
    } while (erg == false || varNumber < validMin || varNumber > validMax);
}