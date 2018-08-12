using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Parser
{
    class Parser
    {
        static void Main(string[] args)
        {
            string _readPath = Environment.GetCommandLineArgs()[1];
            string _writePath = Environment.GetCommandLineArgs()[2];
            string _line = " ";
            string[] Word = null;
            Dictionary<string, int> CountWord = new Dictionary<string, int>();
            Dictionary<string, int> OrderWord = new Dictionary<string, int>();
            StreamReader _streamReader = new StreamReader(_readPath);
            StreamWriter _streamWriter = new StreamWriter(_writePath, false, Encoding.Default);
            string _str;
            char _st1 = ' ';

            try
            {

                while ((_line = _streamReader.ReadLine()) != null)
                {

                    Word = _line.ToLower().Split(new Char[] { ' ', ',', '.', ':', ';','!','?','@','#','+','%','(',')', '\t' });
                }

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            finally
            {
                _streamReader.Close();
            }


            if (Word != null)
            {
                foreach (var _letter in Word.Distinct())
                {
                    CountWord.Add(_letter, Word.Count(chr => chr == _letter));
                }

            }

            else
            {
                _streamWriter.WriteLine("Текст отсутствует");
            }


            foreach (var keyValue in CountWord.OrderBy(keyValue => keyValue.Key).ThenBy(keyValue => keyValue.Value))
            {
                OrderWord.Add(keyValue.Key, keyValue.Value);

            }

            using (_streamWriter)
            {

                try
                {
                    foreach (var key in OrderWord)
                    {
                        _str = key.Key;

                        if (_str[0] != _st1)
                        {

                            _streamWriter.WriteLine(_str[0]);
                        }
                        _st1 = _str[0];

                        _streamWriter.WriteLine("строка:{0} , повторов:{1}", key.Key, key.Value);

                    }
                }

                catch (Exception w)
                {
                    Console.WriteLine(w.Message);
                }
            }           
        }
    }
}