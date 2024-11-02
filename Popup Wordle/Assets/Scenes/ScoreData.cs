using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ScoreData
{
    public static int Score { get; set; }

    public static int IVWords { get; set; }
    public static int VWords { get; set; }
    public static int VIWords { get; set; }
    public static int VIIWords { get; set; }
    public static int VIIIWords { get; set; }

    public static Difficulty Difficulty { get; set; }
}

public enum Difficulty
{
    Easy,
    Hard,
    Shakespear
}
