using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryOfWorkers
{
    public struct ListOfWorkers
    {
        public int Id { get; set; }

        public DateTime TimeWrite { get; set; }

        public string NameWorker { get; set; }

        public uint Age { get; set; }

        public uint Height { get; set; }

        public DateTime Birthday { get; set; }

        public string Birthplace { get; set; }

        public ListOfWorkers(int Id, DateTime TimeWrite, string NameWorker, uint Age, uint Height, DateTime Birthday, string Birthplace)
        {
            this.Id = Id;
            this.TimeWrite = TimeWrite;
            this.NameWorker = NameWorker;
            this.Age = Age;
            this.Height = Height;
            this.Birthday = Birthday;
            this.Birthplace = Birthplace;
        }
        public string Print ()
        {
            return $"{Id,4}\t{TimeWrite,20}\t{NameWorker,30}\t{Age,10}\t{Height,5}\t" +
                $"{Birthday.ToShortDateString(),15}\t{Birthplace,25}\t";
        }

        //private int id;
        //private DateTime timeWrite;
        //private string nameWorker;
        //private uint age;
        //private uint height;
        //private DateTime birthday;
        //private string birthplace;

    }
}
