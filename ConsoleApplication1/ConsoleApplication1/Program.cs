using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileUnsorter = "unsorted-list.txt";
            string fileSorted = "sorted-names-list.txt";

            ReadFiles readFile = new ReadFiles();
            GetString getString = new GetString();
            Create createFile = new Create();
            ShowData showData = new ShowData();
            Reverse reverseArray = new Reverse();
            Reverse unReverseArray = new Reverse();
            DoSorting sortingData = new DoSorting();


            readFile._fileName = fileUnsorter;
            readFile.ReadFile();

            string unSorted = getString.BuildString(readFile.array);

            reverseArray.ReverseArray(readFile.array);
            sortingData.SortingArray(reverseArray.array);
            unReverseArray.ReverseArray(sortingData.Arr);

            string Sorted = getString.BuildString(unReverseArray.array.ToArray());
            showData.ShowToScreen(unSorted);
            showData.ShowToScreen("");
            showData.ShowToScreen("sorting by Last Name....");
            showData.ShowToScreen("");
            showData.ShowToScreen(Sorted);

            createFile._fileName = fileSorted;
            createFile.CreateFile(Sorted);

            Console.ReadLine();
        }
    }

    #region pr
    interface iRead
    {
        void ReadFile();
    }

    interface iBuildString
    {
        string BuildString(string[] arr);
    }

    public class Create
    {
        public virtual void CreateFile(string data)
        {
            File.WriteAllText(FileName, data);
        }

        public string _fileName;

        private string FileName
        {
            get
            {
                return FileName = _fileName;
            }

            set
            {
                _fileName = value;
            }
        }

    }

    public interface IShowData
    {
        void ShowToScreen();
    }

    public class GetString : iBuildString
    {
        public string BuildString(string[] arr)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var c in arr)
            {
                sb.AppendLine(c);
            }

            return sb.ToString();
        }
    }

    public class Reverse
    {
        public void ReverseArray(string[] a)
        {
            foreach (var item in a)
            {
                array.Add(String.Join(" ", item.Split(' ').Reverse().ToArray()));
            }


        }

        public List<string> _array;

        public List<string> array
        {
            get
            {
                if (_array == null)
                    array = new List<string>();

                return array = _array;
            }

            set { _array = value; }
        }

    }

    public class ShowData
    {
        public void ShowToScreen(string data)
        {
            Console.WriteLine(data);
        }
    }

    public class DoSorting
    {
        public string[] SortingArray(List<string> data)
        {
            var result = from name in data
                         orderby name
                         select name;
            Arr = result.ToList().ToArray();

            return Arr;
        }

        private string[] _arr;

        public string[] Arr
        {
            get { return _arr; }
            set { _arr = value; }
        }


    }

    public class ReadFiles : DoSorting, iRead
    {
        public void ReadFile()
        {
            array = File.ReadAllLines(_fileName);
        }


        public string[] array
        {
            get;
            set;
        }

        public string _fileName;

    }
    #endregion
}


