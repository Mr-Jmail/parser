namespace Parser;

public class Day {
    public string DayTittle { get; private set; }
    private List<Lesson> Lessons { get; set; } = new();

    public Day(string dayTittle) => DayTittle = dayTittle;
    public Day(string dayTittle, List<Lesson> lessons) 
    {
        DayTittle = dayTittle;
        Lessons = lessons;
    }
    public void AddLesson(Lesson lesson) => Lessons.Add(lesson);

    public override string ToString()
    {
        string str = $"{DayTittle}\n\n";

        for (int i = 0; i < Lessons.Count; i++) 
        {
            str += Lessons[i];
            if(i != Lessons.Count - 1) str += "\n";
        }

        return str;
    }
}