namespace Parser;

public class Lesson {
    private string NumberOfLesson { get; set; }
    private string SubGroup { get; set; }
    private string SubjectName { get; set; }
    private string TeachersName { get; set; }
    private string Audience { get; set; }
    private string TypeOfLesson { get; set; }
    private string Comment { get; set; }


    public Lesson(string numberOfLesson, string subGroup, string subjectName, string teachersName, string audience, string typeOfLesson, string comment)
    {
        NumberOfLesson = numberOfLesson;
        SubGroup = subGroup.Contains("&nbsp;") ? "" : subGroup;
        SubjectName = subjectName;
        TeachersName = teachersName;
        Audience = audience;
        TypeOfLesson = typeOfLesson;
        Comment = comment.Contains("&nbsp;") ? "" : comment;
    }

    public override string ToString() => $"Номер пары: {NumberOfLesson}\n{(SubGroup.Length != 0 ? $"Подгруппа: {SubGroup}\n" : "")}Предмет: {SubjectName}\nПреподаватель: {TeachersName}\nКаибнет: {Audience}\nВид пары: {TypeOfLesson}\n{(Comment.Length != 0 ? $"Примечание: {Comment}" : "")}";
}