using System;
using System.Text.RegularExpressions;

namespace P02.SongEncryption
{
    public class Program
    {
        public static void Main()
        {
            var regexToValidadeInput = @"^([A-Z][a-z'\s]+):([A-Z \s]+)$";

            string inputLine = string.Empty;

            while ((inputLine = Console.ReadLine()) != "end")
            {
                string encryptedMessage = string.Empty;

                if (Regex.IsMatch(inputLine, regexToValidadeInput))
                {
                    int keyOfDecryption = 0;

                    var match = Regex.Match(inputLine, regexToValidadeInput);

                    keyOfDecryption = match.Groups[1].Length;

                    string currentMatch = match.ToString();

                    for (int i = 0; i < currentMatch.Length; i++)
                    {
                        char currentSymbolsToEncrypt = currentMatch[i];

                        if (char.IsUpper(currentSymbolsToEncrypt))
                        {
                            char encryptedCharacter = (char) (currentSymbolsToEncrypt + keyOfDecryption);

                            if (encryptedCharacter > 'Z')
                            {
                                int offset = encryptedCharacter - 'Z';
                                //int remaningValue = keyOfDecryption - ('Z' - currentSymbolsToEncrypt);
                                //int charToFind = 'A' + remaningValue;
                                //char charToAdd = (char)charToFind;
                                encryptedMessage += (char) ('A' + offset - 1);
                            }
                            else
                            {
                                //int chartofind = currentsymbolstoencrypt + keyofdecryption;
                                //char chartoadd = (char)chartofind;
                                encryptedMessage += encryptedCharacter;
                            }
                        }
                        else if (char.IsLower(currentSymbolsToEncrypt))
                        {
                            if (currentSymbolsToEncrypt + keyOfDecryption > 122)
                            {
                                int remaningValue = keyOfDecryption - (122 - currentSymbolsToEncrypt);
                                int charToFind = '`' + remaningValue;
                                char charToAdd = (char)charToFind;
                                encryptedMessage += charToAdd;
                            }
                            else
                            {
                                int charToFind = currentSymbolsToEncrypt + keyOfDecryption;
                                char charToAdd = (char)charToFind;
                                encryptedMessage += charToAdd;
                            }
                        }
                        else if (currentSymbolsToEncrypt == ':')
                        {
                            encryptedMessage += '@';
                        }
                        else
                        {
                            encryptedMessage += currentSymbolsToEncrypt;
                        }
                    }

                    Console.WriteLine($"Successful encryption: {encryptedMessage}");
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}