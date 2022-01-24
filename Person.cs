using System.Collections.Generic;

namespace csv2xml
{
    internal class Person
    {
        public string indexNumber;
        public string fname;
        public string lname;
        public string birthdate;
        public string email;
        public string mothersName;
        public string fathersName;
        public string studies;
        public string mode;

        //Paweł,Nowak1,Informatyka dzienne,Dzienne,459,2000-02-12 00:00:00.000,nowak@pjwstk.edu.pl,Alina,Adam
        // 0      1        2                  3     4             5                      6           7     8

        public Person(string data)
        {
            string[] temp = data.Split(',');
            indexNumber = temp[4];
            fname = temp[0];
            lname = temp[1];
            birthdate = temp[5];
            email = temp[6];
            mothersName = temp[7];
            fathersName = temp[8];
            string tempS = temp[2].Split(' ')[0];
            switch (tempS)
            {
                case "Informatyka":
                    studies = "Computer Science";
                    break;

                case "Sztuka":
                    studies = "New Media Art";
                    break;
                default:
                    studies = "";
                    break;

            }
            mode = temp[3];
        }
    }
}