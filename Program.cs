﻿using System;
using System.Collections.Generic;

namespace Interpreter_Replit
{
    class Context
    {

        private string input;
        private int output;

        public Context(string input)
        {
            this.input = input;
        }

        public string Input
        {
            get { return input; }
            set { input = value; }
        }

        public int Output
        {
            get { return output; }
            set { output = value; }
        }

    }


    abstract class Phrase
    {

        public void Interpreter(Context context)
        {

            if (context.Input.Length == 0)
                return;

            if (context.Input.StartsWith(Nine()))
            {
                context.Output += (9 * Multiplier());
                context.Input = context.Input.Substring(Nine().Length);
            }
            if (context.Input.StartsWith(Four()))
            {
                context.Output += (4 * Multiplier());
                context.Input = context.Input.Substring(Four().Length);
            }
            if (context.Input.StartsWith(One()))
            {
                context.Output += (1 * Multiplier());
                context.Input = context.Input.Substring(One().Length);
            }
            if (context.Input.StartsWith(Five()))
            {
                context.Output += (5 * Multiplier());
                context.Input = context.Input.Substring(Five().Length);
            }
        }

        public abstract string One();
        public abstract string Four();
        public abstract string Five();
        public abstract string Nine();
        public abstract int Multiplier();

    }


    class PhraseThousands : Phrase
    {
        public override string One() { return "M"; }
        public override string Four() { return " "; }
        public override string Five() { return " "; }
        public override string Nine() { return " "; }
        public override int Multiplier() { return 1000; }
    }
    class PhraseHundreds : Phrase
    {
        public override string One() { return "C"; }
        public override string Four() { return "CD"; }
        public override string Five() { return "D"; }
        public override string Nine() { return "CM"; }
        public override int Multiplier() { return 100; }
    }
    class PhraseDozeens : Phrase
    {
        public override string One() { return "X"; }
        public override string Four() { return "XL"; }
        public override string Five() { return "L"; }
        public override string Nine() { return "XC"; }
        public override int Multiplier() { return 10; }
    }
    class PhraseOnes : Phrase
    {
        public override string One() { return "I"; }
        public override string Four() { return "IV"; }
        public override string Five() { return "V"; }
        public override string Nine() { return "IX"; }
        public override int Multiplier() { return 1; }
    }


    class Program
    {
        static void Main()
        {

            List<Phrase> tree = new List<Phrase>();
            tree.Add(new PhraseThousands());
            tree.Add(new PhraseHundreds());
            tree.Add(new PhraseDozeens());
            tree.Add(new PhraseOnes());

            string roman = "MDXLIII";
            string roman2 = "CMXVII";

            Context context = new Context(roman);
            Context context2 = new Context(roman2);

            for (int i = 0; i < 3; i++)
            {
                foreach (Phrase item in tree)
                {
                    item.Interpreter(context);
                }
            }
            for (int i = 0; i < 3; i++)
            {
                foreach (Phrase item in tree)
                {
                    item.Interpreter(context2);
                }
            }


            Console.WriteLine(roman + " = " + context.Output);
            Console.WriteLine(roman2 + " = " + context2.Output);


        }
    }
}

