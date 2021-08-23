using System;
using System.Collections.Generic;
using System.Linq;

namespace Assessment
{
    public class PaginationString : IPagination<string>
    {
        private readonly IEnumerable<string> data;
        private readonly int pageSize;
        private int currentPage;
        private int NPages;
        private int NElements;

        public PaginationString(string source, int pageSize, IElementsProvider<string> provider)
        {
            data = provider.ProcessData(source);
            currentPage = 1;
            this.pageSize = pageSize;
            int cnt = 0;
            foreach(string movie in data) {
                cnt++;
            }
            if(pageSize >= cnt){
                NPages = 1;
            }
            else{
                if(cnt % pageSize != 0) {
                    NPages = cnt / pageSize + 1;
                }
                else {
                    NPages = cnt / pageSize;
                }
            }
            NElements = cnt;
        }
        public void FirstPage()
        {
            currentPage = 1;
        }

        public void GoToPage(int page)
        {
            // throw new System.NotImplementedException();
            if(page <= 0 || page>NPages){
                throw new System.InvalidOperationException();
            }else{
                currentPage = page;
            }
        }

        public void LastPage()
        {
            // throw new System.NotImplementedException();
            currentPage = NPages;
        }

        public void NextPage()
        {
            if(currentPage + 1 > NPages){
                // throw new System.NotImplementedException();
                throw new System.InvalidOperationException();
            }else{
                currentPage++;
            }
        }

        public void PrevPage()
        {
            if(currentPage - 1 <= 0){
                throw new System.InvalidOperationException();
            }else{
                currentPage--;
            }
            // throw new System.NotImplementedException();
        }

        public IEnumerable<string> GetVisibleItems()
        {
            // IEnumerable<string> aux = data.Skip((currentPage-1)*pageSize).Take(pageSize);
            // foreach(string xx in aux) {
            //     Console.WriteLine(xx);
            // }   
            return data.Skip((currentPage-1)*pageSize).Take(pageSize);
        }

        public int CurrentPage()
        {
            return currentPage;
        }

        public int Pages()
        {
            // throw new System.NotImplementedException();
            // return data.length
            return NPages;
        }
    }
}