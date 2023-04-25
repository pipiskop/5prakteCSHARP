using System;
using System.Collections.Generic;

namespace YukiPesik
{
    public class VIBOR_POLZOVATELYA
    {
        public readonly static string[] NASTRIKCHKA = {"funny", "hugy", "kaif", "nose"};

        public VIBOR_POLZOVATELYA(DateOnly date)
        {
            this.date = date;
        }

        public DateOnly date { get; init; }
        public List<string> items = new ();
    }
}