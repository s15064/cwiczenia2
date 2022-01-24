using System;
using System.Collections.Generic;
using System.IO;

namespace csv2xml
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string ifile = args[0];
                string ofile = args[1];
                string format = args[2];
                string generationDate = DateTime.Now.ToString("dd.MM.yyyy");
                string json = "{uczelnia:" +
                              "{createdAt:\"" + generationDate + "\"," +
                              "author:\"" + generationDate + "\"" +
                              "studenci:[";

                //Załadowanie danych z pliku
                var students = new List<Person>();
                var lines = System.IO.File.ReadAllLines(ifile);
                foreach (string line in lines)
                {
                    Person tempPerson = new Person(line);
                    students.Add(tempPerson);
                }
                Console.WriteLine("Data load finished.");
                Console.WriteLine("Converting to ." + format);
                foreach (Person p in students)
                {
                    json = json + "{" +
                        "indexNumber:\"" + p.indexNumber + "\"," +
                        "fname:\"" + p.fname + "\"," +
                        "lname:\"" + p.lname + "\"," +
                        "birthdate:\"" + p.birthdate + "\"," +
                        "email:\"" + p.email + "\"," +
                        "mothersName:\"" + p.mothersName + "\"," +
                        "fathersName:\"" + p.fathersName + "\"," +
                        "studies:{" +
                            "name:\"" + p.studies + "\"," +
                            "mode:\"" + p.mode + "\"},";

                }
                json = json.Remove(json.Length - 1, 1);

                json = json + "],activeStudies:[{name:\"Computer Science\",numberOfStudents:\"";
                int counter = 0;
                foreach (Person p in students)
                {
                    if (p.studies.Equals("Computer Science"))
                    { 
                        counter++;
                    }

                }
                json = json + counter + "\"},{name:\"New Media Art\",numberOfStudents:\"";
                counter = 0;
                foreach (Person p in students)
                {
                    if (p.studies.Equals("New Media Art"))
                    {
                        counter++;
                    }

                }
                json = json + counter + "\"}]}}";
            } 
            catch (ArgumentException ae)
            {
                Console.WriteLine("Podana ścieżka jest niepoprawna");
            }
            catch (FileNotFoundException fnf)
            {
                Console.WriteLine("Plik " + args[0] + "nie istnieje");
            }

            Console.ReadKey();
        }
    }
}
