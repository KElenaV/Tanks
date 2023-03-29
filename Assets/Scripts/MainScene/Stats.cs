public static class Stats
{
    private static int _score = 0;
    
    public static int Level { get; private set; } = 1;

    public static int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            int nextLevelPoints = 100 * Level;
            
            if (_score >= nextLevelPoints)
            {
                _score -= nextLevelPoints;
                Level++;
            }
        }
    }

    public static void ResetAllStats()
    {
        Level = 1;
        _score = 0;
    }
}
