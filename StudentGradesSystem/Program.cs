namespace StudentGradesSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //declaring select array 
            string[] select = { "[1] Enroll Students", "[2] Enter Student Grades", "[3] Show Student Grades", "[4] Show Top Student", "[5] Exit" };

            // Total number of students
            int totalStudents = 0;

            //initializing instances
            EnrollStudent e = new EnrollStudent();
            StudentGrades n = new StudentGrades();

            do
            {
                Console.WriteLine("Welcome to Student Grades System");

                foreach (string i in select)
                {
                    Console.WriteLine(i);
                }
                Console.Write("Choose the operation number (1-5): ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("\nEnter total students you want to enroll: ");
                        // Read the total number of students
                        while (!int.TryParse(Console.ReadLine(), out totalStudents) || totalStudents <= 0)
                        {
                            Console.Write("Please enter a valid positive number for the total number of students: ");
                        }
                        e.Enrol(totalStudents);
                        break;
                    case "2":
                        // Enter Student Grades
                        n.EnterGrades(e.GetEnrolledStudents());
                        break;
                    case "3":
                        // Show Student Grades
                        n.ShowGrades(e.GetEnrolledStudents());
                        break;
                    case "4":
                        // Show Top Student
                        n.ShowTopStudent(e.GetEnrolledStudents());
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                }
                Console.WriteLine("\n\n");
            } while (true);
        }

        class EnrollStudent
        {
            private List<string> enrolledStudents = new List<string>();

            public void Enrol(int totalStudents)
            {
                Console.WriteLine("\nEnroll Students");

                enrolledStudents.Clear(); // Clear the list before enrolling new students
       
                // Loop to add students
                for (int i = 1; i <= totalStudents; i++)
                {
                    string studentName;
                    int InvalidInput = 0;
                    do
                    {
                        Console.Write($"\nEnter the name of student #{i}: ");
                        studentName = Convert.ToString(Console.ReadLine());

                        if (string.IsNullOrEmpty(studentName))
                            {
                                 Console.WriteLine("Student Name is required!");
                            }
                        
                    } while (string.IsNullOrEmpty(studentName));
                    enrolledStudents.Add(studentName);

                    if (i < totalStudents)
                    {
                        Console.Write("Do you want to add another student? (Y/N): ");
                        char response = Console.ReadKey().KeyChar;
                        Console.WriteLine();

                        if (char.ToUpper(response) != 'Y')
                        {
                            break; // Exit
                        }
                    }
                    else
                    {
                        Console.WriteLine("Successfully Enrolled Student/s!");
                    }

                }
            }

            public List<string> GetEnrolledStudents()
            {
                return enrolledStudents;
            }
        }

        class StudentGrades
        {
            // Use a dictionary to store student names and their respective grades
            private Dictionary<string, int[]> studentGrades = new Dictionary<string, int[]>();

            public void EnterGrades(List<string> enrolledStudents)
            {
            
                Console.WriteLine("\nEnter Student Grades");

                foreach (var student in enrolledStudents)
                {
                   
                    Console.Write($"\nStudent Name: {student}\nScience: ");
                    int scienceGrade = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Math: ");        
                    int mathGrade = Convert.ToInt32(Console.ReadLine());
                    Console.Write("English: ");
                    int englishGrade = Convert.ToInt32(Console.ReadLine());

                    studentGrades.Add(student, new int[] { scienceGrade, mathGrade, englishGrade });

                    // Ask if the user wants to add grades for another student
                    Console.Write("Enter grades for another student? (Y/N): ");
                    char response = Console.ReadKey().KeyChar;
                    Console.WriteLine();

                    if (char.ToUpper(response) != 'Y')
                    {
                        break; // Exit
                    }
                }
            }

            public void ShowGrades(List<string> enrolledStudents)
            {
                Console.WriteLine("\nStudent Grades");
                Console.WriteLine("{0,-15} {1,-10} {2,-10} {3,-10} {4,-10}", "Name", "Science", "Math", "English", "Ave.");

                foreach (var student in enrolledStudents)
                {
                    Console.WriteLine("{0,-15} {1,-10} {2,-10} {3,-10} {4,-10}", student, studentGrades[student][0], studentGrades[student][1], studentGrades[student][2], 0);
                }
            }

            public void ShowTopStudent(List<string> enrolledStudents)
            {

                Console.WriteLine($"\nTop Student: {enrolledStudents[0]}");
            }
        }
    }
}
