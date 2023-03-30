
using System;
using System.IO;

namespace Analex
{
    class Program
    {
        static readonly string[] palabrest = { "if", "else", "while", "for", "int", "float", "char", "void", "foreach", "static", "bool", "class", "return", "using", "true", "false" };
        static readonly string[] simbolos = { "+", "-", "*", "/", "=", "==", ">", "<", "(", ")", "{", "}", ";", "!=", "<=", ">=", "%", "[", "]", ".", "||", "&&" };

        static bool IsPalabra(string token)
        {
            foreach (string reserv in palabrest)
            {
                if (token == reserv)
                {
                    return true;
                }
            }
            return false;
        }

        static bool IsSimbolo(string token)
        {
            foreach (string simbolo in simbolos)
            {
                if (token == simbolo)
                {
                    return true;
                }
            }
            return false;
        }

        static void Main(string[] args)
        {
            Console.Write("Ingrese el nombre del archivo: ");
            string filename = Console.ReadLine();

            if (!File.Exists(filename))
            {
                Console.WriteLine("No se pudo abrir el archivo");
                return;
            }

            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] tokens = line.Split(' ');

                    foreach (string token in tokens)
                    {
                        if (IsPalabra(token))
                        {
                            Console.WriteLine("{0} es una palabra reservada", token);
                        }
                        else if (IsSimbolo(token))
                        {
                            Console.WriteLine("{0} es un simbolo", token);
                        }
                        else
                        {
                            Console.WriteLine("{0} es un identificador o un valor", token);
                        }
                    }
                }
            }
        }
    }
}
