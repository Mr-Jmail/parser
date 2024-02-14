namespace Parser;

class Week {
    private List<Day> Days { get; set; } = new();

    public void AddDay(Day day) => Days.Add(day);

    public Day GetDay(string dayOfWeek) 
    {
        Day? day = Days.Find(day => day.DayTittle == dayOfWeek);
        if(day != null) return day;
        day = new Day(dayOfWeek);
        AddDay(day);
        return day;
    }

    public override string ToString()
    {
        string str = string.Empty;

        for (int i = 0; i < Days.Count; i++)
        {
            if(i != 0) str += "\n";
            str += Days[i];
        }
        
        return str;
    }
}