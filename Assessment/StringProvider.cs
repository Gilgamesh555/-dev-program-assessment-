using System.Collections.Generic;

namespace Assessment
{
    public class StringProvider : IElementsProvider<string>
    {
        private readonly string separator = ",";

        public IEnumerable<string> ProcessData(string source)
        {
            foreach(char item in source)
            {
                if(item == ','){
                    return source.Split(separator);        
                }
            }
            foreach(char item in source)
            {
                if(item == '|'){
                    return source.Split("|");        
                }
            }
            foreach(char item in source)
            {
                if(item == ' '){
                    return source.Split(" ");        
                }
            }
            return source.Split(separator);
        }
    }
}