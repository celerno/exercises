using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryFinder
{
    public class Search
    {
        List<Category> data;
        public Search(List<Category> _data)
        {
            data = _data;
        }

        public Category GetCategoryById(int id)
        {
            var result = data.FirstOrDefault(x => x.CategoryId ==id);
            if (result != null)
            {
                if (string.IsNullOrWhiteSpace(result.Keywords))
                    result.Keywords = GetCategoryById(result.ParentCategoryId).Keywords;
            }
            return result;
        }
        /// <summary>
        /// Given category level as parameter (say N) return the names of the categories which are 
        /// of N’th level in the hierarchy
        /// </summary>
        /// <param name="till">Min Value accepted is 1</param>
        /// <returns></returns>
        public List<string> GetByLevel(int till)
        {
            if (till == 1)
                return data.Where(x => x.ParentCategoryId == -1).Select(x=>x.Name).ToList();
            else
            {
                List<Category> result = data.Where(x => x.ParentCategoryId == -1 && till > 0).ToList();
                int i = 1;
                while (i<till && result.Count()>0) //recursive-ish solution.
                {
                    List<int> ids = new List<int>();
                    List<Category> categories = new List<Category>();
                    foreach(Category c in result)
                    {
                        ids.Add(c.CategoryId);
                    }
                    foreach (int cId in ids)
                    {
                        categories.AddRange(data.Where(x => x.ParentCategoryId == cId));
                    }
                    result = categories;
                    i++;
                }
                return result.Select(x => x.Name).ToList();
            }
        }
    }
    
    public class Category
    {
        public int CategoryId { get; set; }
        public int ParentCategoryId { get; set; }
        public string Name { get; set; }
        public string Keywords { get; set; }
    }
}
