namespace Nootes.Models
{
    public class Subject
    {
        public Subject(string title,
                       string teacher,
                       double note)
        {
            Title = title;
            Teacher = teacher;
            Note = note;
        }

        public string Title { get; }

        public string Teacher { get; set; }

        public double Note { get; set; }

        public override string ToString() => $"{Title},{Teacher},{Note}";

        public static implicit operator string(Subject subject) => subject.ToString();
        
        public static implicit operator Subject(string subject)
        {
            string[] props = subject.Split(",");

            string title = props[0];
            string teacher = props[1];

            if (!double.TryParse(props[2], out double note))
                note = default;

            return new Subject(title, teacher, note);
        }

        public override bool Equals(object? obj) => obj is Subject subject
                                                 && subject.Title == Title
                                                 && subject.Teacher == Teacher
                                                 && subject.Note.Equals(Note);

        public override int GetHashCode() => Title.GetHashCode();
    }
}
